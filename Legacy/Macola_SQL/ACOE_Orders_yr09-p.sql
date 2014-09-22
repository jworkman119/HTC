select  Location.vend_no as Vendor#
        ,isnull(Vendors.cmp_name, 'zzz No Vendor Listed') as Vendor
--		,items.itemcode as ItemCode
		, Family.fam1 as FamilyCode
   --     ,items.description as Description 
		, family.fam2 as FamilyDescription
	    , cast(sum(oe.qty_ordered)as Int) as Qty
		, cast(round(Avg(items.CostPriceStandard),2) as decimal(18,2)) as CostPrice
       , Year(oe.billed_dt) as Year
from  oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
	 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
    join items on OE.item_no = items.ItemCode
    join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	left join zzzhtc_family as Family on items.itemcode = Family.item
where year(billed_dt) = 2009
--		and year(billed_dt) < year(getdate())
--	and items.warehouse = 700
--	and Customers.ClassificationID = 'usf'
	and left(Family.Fam1,3) = 'COE'
	and qty_ordered = qty_to_ship
	and Orders.status = 'p'
--	and Family.fam1 in ('fs320', '0176')
	and Orders.rma_no is null

group by 
	Location.vend_no
	,Vendors.cmp_name
--	, items.itemcode
	, family.fam1
--    , items.CostPriceStandard
--	, items.description
	, family.fam2
	, year(oe.billed_dt) 
order by Vendor, Year, familycode --items.itemcode;

