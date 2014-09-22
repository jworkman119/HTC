
/*
Create Procedure htcDailySales

as 
*/

Declare @Date varchar(10)

set @Date = convert(varchar(10), DateAdd(dd,-1,GetDate()), 101)

Set @Date = '7/19/2010'

	select  Convert(varchar(10),OE.Billed_Dt, 101)as Date
		, Customers.ClassificationID
		, count(OE.Ord_No)  as Orders
		, cast(sum(OE.qty_ordered) as int) as Qty_Ordered
		, sum(OE.Unit_Price) as TotalSales
		, Status = 'Orders'
	from  oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
		 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
				and oe.inv_no = orders.inv_no
		join cicmpy as Customers on OE.cus_no = Customers.cmp_code
		join items on OE.item_no = items.ItemCode
		join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	--    left join zzzhtc_family as Family on items.itemcode = Family.item
	where OE.billed_dt >= @Date
		and OE.billed_dt < '7/20/2010' --GetDate()
		and Customers.ClassificationID in ('usf', 'ace')
		and OE.qty_ordered = OE.qty_to_ship
		and Orders.status = 'p'
		and Orders.rma_no is null
		and Items.ItemCode not in ('JobCode','Allocation')
	group by
		OE.Billed_dt 
		, Customers.ClassificationID
		 

UNION ALL



	select  Convert(varchar(10),OE.Billed_Dt, 101)as Date
		, Customers.ClassificationID
		, count(OE.Ord_No) as Orders
		, cast(sum(OE.qty_ordered) as int) as Qty_Ordered
		, sum(OE.Unit_Price) as TotalSales
		, Status = 'BackOrders'
	from  oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
		 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
				and oe.inv_no = orders.inv_no
		join cicmpy as Customers on OE.cus_no = Customers.cmp_code
		join items on OE.item_no = items.ItemCode
		join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	--    left join zzzhtc_family as Family on items.itemcode = Family.item
	where OE.billed_dt >= @Date
		and OE.billed_dt < '7/20/2010' --GetDate()
		and Customers.ClassificationID in ('usf', 'ace')
		and OE.qty_ordered != OE.qty_to_ship
		and Orders.status = 'p'
		and Orders.rma_no is null
		and Items.ItemCode not in ('JobCode','Allocation')
	group by
		OE.Billed_dt 
		, Customers.ClassificationID
	--	, OE.bkord_fg
	order by ClassificationID  

/*
select *
from oelinhst_sql 
where billed_dt >= '7/19/2010'
	and billed_dt < '7/20/2010'
*/