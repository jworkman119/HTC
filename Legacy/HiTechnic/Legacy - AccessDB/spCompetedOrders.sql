Create Procedure spCompletedOrders

as 

Select Ord_No
	, Mode
	, Tracking_no
	, Ship_Cost
	, ShippedDate as Shipped
from dbo_arshtfil2_sql
order by ShippedDate desc




