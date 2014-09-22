select  Location.vend_no as Vendor#
        ,isnull(Vendors.cmp_name, 'zzz No Vendor Listed') as Vendor
		, Family.fam1 as FamilyCode
   		, family.fam2 as FamilyDescription
		, cast(sum(oe.qty_ordered)as Int) as Qty_Sold
		, cast(Round(Avg(Location.Price), 2) as Decimal(18,2)) CurrentPrice
		, cast(round(avg(items.CostPriceStandard),2) as decimal(18,2)) as CostPrice
       , Year(oe.billed_dt) as Year
--into #tblTemp
from  oelinhst_sql as OE 	
	join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
--	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
    join items on OE.item_no = items.ItemCode
    left join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	left Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	join zzzhtc_family as Family on items.itemcode = Family.item
where year(billed_dt) >= 2009
		and year(billed_dt) < year(getdate())
	and items.warehouse = 730 --in (700,730)
	--and Customers.ClassificationID in ('usf','ace')
	and qty_ordered = qty_to_ship
	and Orders.status = 'p'
	and Orders.rma_no is null
group by 
	Location.vend_no
	, Location.Price
	,Vendors.cmp_name
	, family.fam1
	, family.fam2
	, year(oe.billed_dt) 
order by Vendor, Year, familycode 