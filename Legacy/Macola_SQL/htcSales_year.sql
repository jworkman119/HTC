/*Alter Procedure htc_VendorSales_Year
	 @year as integer

as
*/

	Declare @year as integer
	set @year = 2008



select  rtrim(Family.fam1) as FamilyCode
		, items.itemcode as ItemCode
		,items.description as Description 	
		, cast(sum(oe.qty_ordered)as Int) as Qty
		--, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
		, Year(oe.billed_dt) as Year
--into #tblTemp
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
	and Family.fam1 in ('fs320', '0176')
	and Orders.rma_no is null
group by 
	items.itemcode
	, family.fam1
    , items.CostPriceStandard
	, items.description
	, family.fam2
	, year(oe.billed_dt) 
order by Year, familycode, qty --items.itemcode;

drop table #tblTemp


-- data from 2007
select #tblTemp.Vendor#
	, #tblTemp.Vendor
	, isnull(#tblTemp.FamilyCode, 'N/A') as ItemCode
	, isnull(rtrim(#tblTemp.FamilyDescription), 'N/A') as Description
	, sum(qty) as qty
into #tbl2007
from #tblTemp
where #tblTemp.year = 2007
Group By
	#tblTemp.Vendor#
	, #tblTemp.Vendor
	, #tblTemp.familycode
	, #tblTemp.FamilyDescription
order by #tblTemp.familycode --#tblTemp.Vendor


-- data from 2008
select #tblTemp.Vendor#
	, #tblTemp.Vendor
	, isnull(#tblTemp.FamilyCode, 'N/A') as ItemCode
	, sum(qty) as qty
into #tbl2008
from #tblTemp
where #tblTemp.year = 2008
Group By
	#tblTemp.Vendor#
	, #tblTemp.Vendor
	, #tblTemp.familycode
	, #tblTemp.FamilyDescription
order by #tblTemp.familycode --#tblTemp.Vendor

-- data from 2009
select isnull(#tblTemp.FamilyCode, 'N/A') as ItemCode
	, isnull(rtrim(#tblTemp.FamilyDescription), 'N/A') as Description
	, sum(qty) as qty
	, cast(avg(CostPrice) as decimal(18,2)) as Cost
into #tbl2009
from #tblTemp
where #tblTemp.year = 2009
Group By
	#tblTemp.Vendor#
	, #tblTemp.Vendor
	, #tblTemp.familycode
	, #tblTemp.FamilyDescription
order by #tblTemp.familycode --#tblTemp.Vendor

drop table #tblTemp

select
	#tbl2007.Vendor#
	, #tbl2007.Vendor
	, #tbl2007.ItemCode
	, #tbl2007.Description
	, #tbl2007.qty as qty2007
	, #tbl2008.qty as qty2008
	, #tbl2009.qty as qty2009
	, #tbl2009.Cost as Cost_2009
	, #tbl2009.qty * #tbl2009.Cost as TotalCost_2009
from #tbl2007
	join #tbl2008 on #tbl2007.itemcode = #tbl2008.itemcode
	join #tbl2009 on #tbl2007.itemcode = #tbl2009.itemcode

drop table #tbl2007
drop table #tbl2008
drop table #tbl2009

--htc_VendorSales_Year '2007'
