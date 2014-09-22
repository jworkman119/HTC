/*Alter Procedure htc_VendorSales_Year
	 @year as integer

as
*/

	Declare @year as integer
	set @year = 2008



select  rtrim(Family.fam1) as FamilyCode
	--	, items.itemcode as ItemCode
	--	,items.description as Description 	
		, Family.Fam2 as Description
		, cast(sum(oe.qty_ordered)as Int) as Qty
		, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
		
		, Case 
			When Month(oe.billed_dt) >= 1 and Month(oe.billed_dt) <= 3 Then
				'Qtr1'
		    When Month(oe.billed_dt) >=4 and Month(oe.billed_dt) <= 6 then
				'Qtr2'
			When Month(oe.billed_dt) >= 7 and Month(oe.billed_dt) <= 9 Then
				'Qtr3'
			When Month(oe.billed_dt) >= 10 and Month(oe.billed_dt) <= 12 then
				'Qtr4'
		End as Qtr
		, Year(oe.billed_dt) as Year
into #tblTemp
from  oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
	 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
    join items on OE.item_no = items.ItemCode
    left join zzzhtc_family as Family on items.itemcode = Family.item
where year(billed_dt) >= @year
		and year(billed_dt) < year(getdate())
	and items.warehouse = 700
	and Customers.ClassificationID = 'usf'
	and qty_ordered = qty_to_ship
	and Orders.status = 'p'
--	and Family.fam1 in ('fs320', '0176')
	and Orders.rma_no is null
group by 
--	items.itemcode
	 family.fam1
    , items.CostPriceStandard
--	, items.description
	, family.fam2
	, year(oe.billed_dt) 
	, month(oe.billed_dt)
order by Year,Qtr, familycode, qty --items.itemcode;


select familyCode
	, sum(Qty) as Qtr1
	, Year
into #tblQtr1
from #tblTemp
where Qtr = 'Qtr1'
group by familyCode, Year



select familyCode
	, sum(Qty) as Qtr2
	, Year
into #tblQtr2
from #tblTemp
where Qtr = 'Qtr2'
group by familyCode, Year


select familyCode
	, sum(Qty) as Qtr3
	, Year
into #tblQtr3
from #tblTemp
where Qtr = 'Qtr3'
group by familyCode, Year


select familyCode
	, sum(Qty) as Qtr4
	, Year
into #tblQtr4
from #tblTemp
where Qtr = 'Qtr4'
group by familyCode, Year

select  FamilyCode
		, Description
		, cast(round(avg(CostPrice),2) as decimal(18,2)) as CostPrice
		--, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
into #tblTemp2
from #tblTemp
Group By
	FamilyCode
	, Description
	


Select #tblTemp2.FamilyCode
	, Description
	, CostPrice
	, #tblQtr1.Qtr1
	, #tblQtr2.Qtr2
	, #tblQtr3.Qtr3
	, #tblQtr4.Qtr4
	, #tblQtr1.Year
from #tblTemp2
	left join #tblQtr1 on #tblQtr1.FamilyCode = #tblTemp2.FamilyCode
	left join #tblQtr2 on #tblQtr1.FamilyCode = #tblQtr2.FamilyCode
		and #tblQtr1.Year = #tblQtr2.Year 
	left join #tblQtr3 on #tblQtr1.FamilyCode = #tblQtr3.FamilyCode
		and #tblQtr1.Year = #tblQtr3.Year 
	left join #tblQtr4 on #tblQtr1.FamilyCode = #tblQtr4.FamilyCode
		and #tblQtr1.Year = #tblQtr4.Year 
Order by #tblQtr1.Year, #tblTemp2.FamilyCode
	


drop table #tblTemp
drop table #tblQtr1
drop table #tblQtr2
drop table #tblQtr3
drop table #tblQtr4
drop table #tblTemp2