select 	ItemAccounts.crdnr as Vendor#
        , Credit.naam as Vendor
		, items.id
        ,items.itemcode
        , oe.item_desc_1
        , sum(oe.qty_ordered) as Qty
        , convert(MONEY,sum(items.CostPriceStandard)) as Cost
        , Year(oe.request_dt) as Year

   */
		--, '$' + CONVERT(VARCHAR,CONVERT(MONEY,oe.unit_cost),1) as unit_cost
        --, convert(varchar, oe.request_dt,101) as Requested_dt
from arcusfil_sql as Cus
    join oeordlin_sql as OE on Cus.cus_no = OE.cus_no 
    join items on OE.item_no = items.ItemCode
    join ItemAccounts on items.ItemCode = ItemAccounts.ItemCode
    join Credit on ItemAccounts.crdnr = Credit.crdnr
where cus.cus_type_cd = 'USFS'

and request_dt >= '1/1/2010'

group by 
	Credit.naam
	, ItemAccounts.crdnr
	, items.id
	, items.itemcode
	, oe.item_desc_1
--	, oe.qty_ordered
/*	, oe.request_dt
	, items.CostPriceStandard
	, ItemAccounts.crdnr
	, Credit.naam 
--having
		
--request_dt >= '1/1/2010'
	*/
order by items.id