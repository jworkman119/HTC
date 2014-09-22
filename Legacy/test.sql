select  Location.vend_no as Vendor#
        ,isnull(Vendors.cmp_name, 'zzz No Vendor Listed') as Vendor
		, OE.ord_no
		, Customers.cmp_name
		,items.itemcode as ItemCode
		, Family.fam1 as FamilyCode
        ,items.description as Description 
		, family.fam2 as FamilyDescription
	    , cast(oe.qty_ordered as Int) as Qty
		, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
       , oe.billed_dt as Year
	 ,OE.total_cost
	, orders.status
	, orders.rma_no
	, Orders.ord_type
	, Orders.orig_ord_type
	, rma_seq
--into #tblTemp
from  oelinhst_sql as OE --on Orders.ord_no = OE.ord_no
	join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no

	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
    join items on OE.item_no = items.ItemCode
    join zzzhtc_family as Family on items.itemcode = Family.item
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	
where year(OE.billed_dt) = '2008'
		
	and items.warehouse = 700
	and Family.fam1 = 'fs320'
	and Customers.ClassificationID = 'usf'
	and OE.qty_ordered = OE.qty_to_ship
	and orders.rma_no is null
	and Orders.status = 'p'
order by customers.cmp_name


select distinct(status)
from oeordst_sql