/*
Alter Procedure htcDailySales

	As
*/

Declare @FromDate varchar(10)
Declare @ToDate varchar(10)


Set @FromDate = convert(varchar(10), DateAdd(dd,-1,GetDate()), 101)
Set @ToDate = convert(varchar(10), GetDate(), 101)


select OE.Ord_No
	, OE.Line_Seq_No
	, OE.Item_No
	, cast(OE.qty_ordered as int) as Quantity
	, round((OE.Unit_Price * OE.qty_ordered),2) as SalesTotal
	, case 
		when OE.qty_ordered != sum(OE.qty_to_ship) then
			'BackOrder'
		else
			'Order'
	 End as BackOrder		
from (Select Distinct Ord_No
		, Entered_dt
	  From oehdrhst_sql
	  where Entered_Dt >= @FromDate
	and Entered_Dt < @ToDate) as OE2 
	join oelinhst_sql as OE on OE2.Ord_No = OE.Ord_No
where   OE.Item_No not in ('JobCode','Allocation')
Group By OE.Ord_No
	, OE.Item_No
	, OE.Line_Seq_No
	, OE.qty_ordered
	, OE.Unit_Price
order by OE.line_seq_no

