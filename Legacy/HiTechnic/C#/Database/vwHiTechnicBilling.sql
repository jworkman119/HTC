-- View that displays the billing information based on the last 3 months

Select Orders_Qty.Number
		, Orders_Qty.Qty
		, Case 
			When Orders_Qty.Qty <= 10 then
				Round((Orders_Qty.Qty * .23) + 2.80,2)
			else
				7.80
			end HTC_Charges
		, Case 
			When substr(Tracking.ShipMethod,1,5) = 'FedEx' then
				null
			else 
				Tracking.Cost
		 	End as Cost
		, strftime( '%m/%d/%Y',Orders_Qty.TS) as Received
		, Case 
			When Tracking.ShipMethod = 'UPS' then
				'UPS'
			When substr(Tracking.ShipMethod,1,5) = 'FedEx' then
				'FedEx'
			Else
				'USPS'
		 End as Carrier
		 , Tracking.Tracking 
From Tracking
	Join (	Select Orders.Number
				,Orders.TS
				, sum(OrderDetails.Qty) as Qty
			from Orders
				join OrderDetails on Orders.Number = OrderDetails.Orders_Number
			where 	TS > date('now', '-3 months');
			Group By Orders.Number
				, Orders.TS
			Order by Orders.TS
		) as Orders_Qty on Tracking.Orders_Number= Orders_Qty.Number
Group By Orders_Qty.Number, Tracking.Tracking
order by Carrier, Orders_Qty.TS 