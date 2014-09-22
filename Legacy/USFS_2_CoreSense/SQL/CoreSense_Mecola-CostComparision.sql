select  Family.fam1 as FamilyCode
	, Items.ItemCode
	, cast(sum(oe.qty_ordered)as Int) as Qty_Sold
	, cast(sum(oe.qty_to_ship)as int) as Qty_Shipped
Into #tempTB
from  zzzhtc_family as Family 
    join items on items.itemcode = Family.item
	join oelinhst_sql as OE on OE.item_no = items.ItemCode
	join vwHTC_ClassificationID as Customers on OE.cus_no = Customers.cmp_code
where 
	year(OE.billed_dt) >= 2010
	and items.warehouse in (700,730)
	and OE.Item_No not in ('JobCode','Allocation')
	and Customers.ClassificationID in ('USF','ACE')
group by
	Family.fam1
	, Items.ItemCode
order by familycode 

select Item_No  
	, cast(sum(qty_ordered)as Int) Qty_Ordered
	, cast(round(avg(act_unit_cost), 2) as decimal(18,2)) as Unit_Cost
into #TempTB2
from poordlin_sql 
where 
	year(receipt_dt) = 2010
group by 
	Item_No


select rtrim(#TempTB.FamilyCode) as FamilyCode
	, #TempTB.ItemCode
	, #TempTB.Qty_Sold
	, #TempTB.Qty_Shipped
	, #TempTB2.Qty_Ordered
	, #TempTB2.Unit_Cost as UnitCost
	, cast(round(OE.Unit_Price,2) as decimal(18,2)) as Unit_Price
	, cast(round(OE.Unit_Cost, 2) as decimal(18,2)) as LastCostPrice
	, Max(oe.billed_dt) as LastBilledDate
from  #TempTB 
	join Items on Items.ItemCode = #TempTB.ItemCode
	join #TempTB2 on Items.ItemCode = #TempTB2.Item_No
	join oelinhst_sql as OE on OE.item_no = #TempTB.ItemCode
where 
	year(billed_dt) >= 2010
Group By 
	#TempTB.FamilyCode
	, #TempTB.ItemCode
	, #TempTB.Qty_Sold
	, #TempTB.Qty_Shipped
	, #TempTB2.Qty_Ordered
	, #TempTB2.Unit_Cost
	, OE.Unit_Cost
	, OE.Unit_Price
order by FamilyCode,LastBilledDate desc			


/*
drop table #tempTB
drop table #tempTB2
*/