/*
IF EXISTS (SELECT * FROM sysobjects WHERE NAME='htcDailySales' AND TYPE='P')
	drop procedure htcDailySales
GO

Create Procedure htcDailySales 

	@FromDate varchar(10) = NULL
	, @ToDate varchar(10) = NULL

as
 */
-- Testing 

	Declare @FromDate varchar(10)
	Declare @ToDate varchar(10)

	Set @FromDate = '8/10/2010'
	Set @ToDate = '8/12/2010'

-- End Testing

if @FromDate is NULL
	Set @FromDate = convert(varchar(10), DateAdd(dd,-1,GetDate()), 101)
	
if @ToDate is NULL
	Set @ToDate = convert(varchar(10), GetDate(), 101)


Select Distinct Ord_No
	, Entered_dt
	into #Temp
	From oehdrhst_sql
	where Entered_Dt >= @FromDate
		and Entered_Dt < @ToDate

	Select Customers.classificationid
		, Customers.Description 
		, OE.Ord_No 
		, OE.Line_Seq_No as Line
		, cast(OE.qty_ordered as int) as Quantity
		, round((OE.Unit_Price * OE.qty_ordered),2) as SalesTotal
		, case 
				when OE.qty_ordered != sum(OE.qty_to_ship) then
					'BackOrder'
				else
					'Orders'
			 End as BackOrder
	Into #TempTB
	from #Temp as OE2  
		Join oelinhst_sql as OE With (index (htcDailySales_OrdNo)) on OE2.Ord_No = OE.Ord_No
		join vwHTC_ClassificationID as Customers on OE.cus_no = Customers.cmp_code
	Where
		OE.Item_No not in ('JobCode','Allocation')
		and Customers.ClassificationID in ('USF','ACE')
	Group by 
		Customers.classificationid
		, Customers.Description 
		, OE.Ord_No 
		, OE.Line_Seq_No
		, OE.qty_ordered
		, OE.Unit_Price


Union 


Select 	Customers.classificationid
		, Customers.Description 
		, OE.Ord_No 
		, Count(OE.Line_Seq_No) as Line
		, Cast(sum(OE.qty_ordered) as int) as Quantity
		, round((OE.Unit_Price * sum(OE.qty_ordered)),2) as SalesTotal
	, 'BackOrder' as BackOrder
from OEOrdlin_sql as OE
	join oehdrhst_sql as OE2 on OE.Ord_no = OE2.ord_no
	join vwHTC_ClassificationID as Customers on OE.cus_no = Customers.cmp_code
Where OE2.Entered_Dt >= @FromDate
	and OE2.Entered_Dt < @ToDate
	and Customers.ClassificationID in ('USF','ACE')
Group By Customers.classificationid
		, Customers.Description 
		, OE.Ord_No 	
		, OE.Unit_Price 


drop table #Temp



select #tempTB.ClassificationID
	, #tempTB.Description
	, #TempOrders.Orders
	, Count(#tempTB.Line) as Lines
	, Sum(#tempTB.Quantity) as Items
	, Sum(#tempTB.SalesTotal)as TotalSales
	, #tempTB.BackOrder
	, @FromDate as FromDate
	, @ToDate as ToDate
from #tempTB
	Join (select ClassificationID 
				, count(Ord_No) Orders
				, BackOrder
			from (
				select distinct ClassificationID, Ord_No, BackOrder 
				From #tempTB
				) #tempOrders
			group by ClassificationID 
				, BackOrder
		) as #tempOrders on #tempTB.ClassificationID = #tempOrders.ClassificationID
				and #tempTB.BackOrder = #tempOrders.BackOrder
Group By
	#tempTB.BackOrder
	, #tempTB.ClassificationID
	, #tempTB.Description
	, #TempOrders.Orders
Order by 
	#tempTB.BackOrder desc
	, #tempTB.ClassificationID
	
drop table #tempTB



	
	
	
	