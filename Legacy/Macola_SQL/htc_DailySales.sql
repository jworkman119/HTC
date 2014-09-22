
Declare @Date varchar(10)

set @Date = convert(varchar(10), DateAdd(dd,-1,GetDate()), 101)

Set @Date = '7/19/2010'


select  Convert(varchar(10),Billed_Dt, 101)as Date
		, Customers.ClassificationID
		, rtrim(Family.fam1) as FamilyCode
	--	, items.itemcode as ItemCode
		,Family.Fam2 as Description 	
		, cast(sum(oe.qty_ordered)as Int) as Qty
		, cast(Round(Avg(Location.Price), 2) as Decimal(18,2)) CurrentPrice
		, cast(round(Avg(items.CostPriceStandard),2) as decimal(18,2)) as CostPrice
		, cast(sum(oe.qty_ordered)as Int) * cast(Round(Avg(Location.Price), 2) as Decimal(18,2)) as Gross
		,  cast(sum(oe.qty_ordered)as Int) * cast(Round(Avg(items.CostPriceStandard), 2) as Decimal(18,2)) as TotalCost
		, cast(sum(oe.qty_ordered)as Int) * cast(Round(Avg(Location.Price), 2) as Decimal(18,2)) 
				- cast(sum(oe.qty_ordered)as Int) * cast(Round(Avg(items.CostPriceStandard), 2) as Decimal(18,2)) as Profit
--into #tblTemp
from  oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
	 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
    join items on OE.item_no = items.ItemCode
    join iminvloc_sql as Location on items.ItemCode = Location.Item_no
    left join zzzhtc_family as Family on items.itemcode = Family.item
where billed_dt >= @Date
	and billed_dt < '7/20/2010' --GetDate()
	and Customers.ClassificationID in ('usf', 'ace')
	and qty_ordered = qty_to_ship
	and Orders.status = 'p'
	and Orders.rma_no is null
	and Items.ItemCode not in ('JobCode','Allocation')
group by
	Billed_dt 
	, Customers.ClassificationID
--	, items.itemcode
	, family.fam1
	, family.fam2
order by ClassificationID, familycode, qty --items.itemcode;