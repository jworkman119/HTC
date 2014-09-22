
Alter Procedure htcDailySales

	As


Declare @FromDate varchar(10)
Declare @ToDate varchar(10)


Set @FromDate = convert(varchar(10), DateAdd(dd,-1,GetDate()), 101)
Set @ToDate = convert(varchar(10), GetDate(), 101)

select distinct OE2.Entered_Dt
	,  OE.ord_no
	, Customers.classificationid
	, count(OE.line_seq_no)as Lines
	, sum(OE.qty_ordered) as Qty
	, sum(OE.Unit_Price) as TotalSales
	, 'Order' as BackOrder
into #TempTB
from oelinhst_sql as OE
	join oehdrhst_sql as OE2 on OE.ord_no = OE2.ord_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
where OE2.Entered_Dt >= @FromDate
and OE2.Entered_Dt < @ToDate
and Customers.classificationid in ('usf', 'ace')
and OE.qty_ordered = OE.qty_to_ship
and OE.Item_No not in ('JobCode','Allocation')
group by OE2.Entered_Dt
	, OE.ord_no
	, Customers.classificationid
	
Union All

select distinct OE2.Entered_Dt
	,  OE.ord_no
	, Customers.classificationid
	, count(OE.line_seq_no)as Lines
	, sum(OE.qty_ordered) as Qty
	, sum(OE.Unit_Price) as TotalSales
	, 'BackOrder' as BackOrder
from oelinhst_sql as OE
	join oehdrhst_sql as OE2 on OE.ord_no = OE2.ord_no
	--test
	join oeordlin_sql on OE.ord_no = oeordlin_sql.ord_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
where OE2.Entered_Dt >= @FromDate
and OE2.Entered_Dt < @ToDate
and Customers.classificationid in ('usf', 'ace')
and oeordlin_sql.bkord_fg = 'Y'
and OE.Item_No not in ('JobCode','Allocation')
group by OE2.Entered_Dt
	, OE.ord_no
	, Customers.classificationid		
	 


select 
	convert(varchar(10),Entered_Dt,101) as Entered_Dt
	, ClassificationID
	, count(Ord_No) as Orders
	, sum(Lines) as Lines
	, Sum(Qty) as Qty
	, sum(TotalSales) as Sales
	, BackOrder
from #TempTB
Group by Entered_Dt
	, ClassificationID
	, BackOrder
	
	
Drop table #TempTB
/*
select *
from #TempTB
where BackOrder = 'BackOrder'
*/