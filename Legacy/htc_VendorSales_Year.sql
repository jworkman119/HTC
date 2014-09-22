/*Alter Procedure htc_VendorSales_Year
	 @year as integer

as
*/

	Declare @year as integer
	set @year = 2007


select Location.vend_no as Vendor#
        ,isnull(cicmpy.cmp_name, 'zzz No Vendor Listed') as Vendor
		,items.itemcode as ItemCode
		, Family.fam1 as FamilyCode
        ,items.description as Description 
		, family.fam2 as FamilyDescription
	    , cast(sum(oe.qty_ordered)as Int) as Qty
		, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
       , Year(oe.request_dt) as Year
into #tblTemp
from  oehdrhst_sql as Orders -- arcusfil_sql
	join oelinhst_sql as OE on Orders.ord_no = OE.ord_no
	join usfs_allemployees as usfs on Orders.cus_no = usfs.account_no
    join items on OE.item_no = items.ItemCode
    join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join cicmpy on Location.vend_no = cicmpy.cmp_code
	left join zzzhtc_family as Family on items.itemcode = Family.item
where year(request_dt) >= @year
		and year(request_dt) < year(getdate())
	and items.warehouse = 700
group by 
	Location.vend_no
	,cicmpy.cmp_name
	, items.itemcode
	, family.fam1
    , items.CostPriceStandard
	, items.description
	, family.fam2
	, year(oe.request_dt) 
order by Vendor, Year, items.itemcode;



select #tblTemp.Vendor#
	, #tblTemp.Vendor
	, #tblTemp.FamilyCode --as ItemCode
	, #tblTemp.FamilyDescription --as Descriptioin
	, sum(qty) as qty
	, cast(avg(CostPrice) as decimal(18,2) as decimal(18,2)) as decimal(18,2)) as TotalCost
	, Year
from #tblTemp
Group By
	#tblTemp.Vendor#
	, #tblTemp.Vendor
	, #tblTemp.FamilyCode
	, #tblTemp.FamilyDescription
--	, tbl2007.qty
--	, Year
order by #tblTemp.familycode --#tblTemp.Vendor




--drop table #tblTemp

