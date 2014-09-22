 Select Orders.Number
	, Orders.ShipMethod
	, Orders.Email
	, Orders.Telephone
	, Orders.ShippingAccount
	, Case 
		When Orders.ShippingAccount is not Null then
			3
       else
			1
		End as BillTransTo
	, Orders.AES
	
	, BillTo.Contact as BillToContact
	, BillTo.Address1 as BillToAddress1
	, BillTo.Address2 as BillToAddress2
	, BillTo.Address3 as BillToAddress3
	, BillTo.City as BillToCity
	, BillTo.State as BillToState
 	, BillTo.Zip as BillToZip
	,Case  
	 When Country2.ID is NULL then
		 'US'
	  Else
		Country2.ID
	  End as BillToCountry
	, ShipTo.Contact 
	, ShipTo.Address1
	, ShipTo.Address2
	, ShipTo.Address3
	, ShipTo.City
	, ShipTo.State
	, ShipTo.Zip
	, Case 
	  When Country.ID is NULL then
		 'US'
	  Else
		Country.ID
	  End as Country
      , round(round(Orders.SubTotal/sum(OrderDetails.Qty),6) * sum(OrderDetails.Qty),6) as SubTotal
      , round(Orders.SubTotal/sum(OrderDetails.Qty),6) as UnitValue
	  , sum(OrderDetails.Qty) as Qty
From Orders
	Join ShipTo on Orders.Number = ShipTo.Orders_Number
	Left Join Country on ShipTo.Country = Country.Name
	Join BillTo on Orders.Number = BillTo.Orders_Number
	Left Join Country Country2 on BillTo.Country = Country2.Name
	Left Join Tracking on Orders.Number = Tracking.Orders_Number
	Join OrderDetails on Orders.Number = OrderDetails.Orders_Number
Where Tracking.Orders_Number is NULL
Group By
	Orders.Number
	, Orders.ShipMethod
	, Orders.Email
	, Orders.Telephone
	, Orders.ShippingAccount
	, Orders.AES
	, ShipTo.Contact
	, ShipTo.Address1
	, ShipTo.Address2
	, ShipTo.Address3
	, ShipTo.City
	, ShipTo.State
	, ShipTo.Zip
	, Country.ID
	, BillTo.Contact
	, BillTo.Address1
	, BillTo.Address2
	, BillTo.Address3
	, BillTo.City
	, BillTo.State
	, BillTo.Zip
	, Country2.ID