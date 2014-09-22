-- Summary
Select  OrderDetails.PartID
	, sum(OrderDetails.Qty) as Qty
from Orders
	join OrderDetails on Orders.Number = OrderDetails.Orders_Number
	join (Select Distinct Tracking.Orders_Number
			From Tracking
		  ) as Distinct_Track on Orders.Number = Distinct_Track.Orders_Number
where 	TS >= '2012-04-23'
	and TS <= '2012-05-25'
Group By 
PartID
Order by OrderDetails.PartID;

-- Detailed
Select Orders.Number
	, Orders.TS
	, OrderDetails.PartID
	, sum(OrderDetails.Qty) as Qty
from Orders
	join OrderDetails on Orders.Number = OrderDetails.Orders_Number
	join (Select Distinct Tracking.Orders_Number
			From Tracking
		  ) as Distinct_Track on Orders.Number = Distinct_Track.Orders_Number
where 	TS >= '2012-04-23'
	and TS <= '2012-05-25'
Group By 
PartID
, Orders.Number
, Orders.TS
Order by OrderDetails.PartID
	, Orders.TS