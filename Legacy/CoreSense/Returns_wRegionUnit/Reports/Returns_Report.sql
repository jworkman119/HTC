/* Truncating Data */
/*
Delete from Customers;
Delete From OrderCustomer;
Delete from OrderCustomer2;
Delete from OrderData;
*/

/**** Removing duplicates ***/
/*
Insert Into OrderCustomer2
Select Distinct *
from OrderCustomer
*/

/**** Detailed ****/
Select Customers.Region
	, Customers.Unit
	, OrderData.*
from OrderData
	Join OrderCustomer2 on OrderData.OrderNo = OrderCustomer2.OrderNumber
	join Customers on OrderCustomer2.ClientID = Customers.client_id
Order by Customers.Region
	, Customers.Unit
	, OrderDate	

/*** Aggregate ***/
Select Customers.Region
	, Customers.Unit
	, sum(OrderData.ReturnedTotal) as ReturnTotal
	, sum(Round(OrderData.ReturnedTotal*.11,2)) as ReturnCharge
from OrderData
	Join OrderCustomer2 on OrderData.OrderNo = OrderCustomer2.OrderNumber
	join Customers on OrderCustomer2.ClientID = Customers.client_id
Group By Region
	, Unit
Order by Customers.Region
	, Customers.Unit
