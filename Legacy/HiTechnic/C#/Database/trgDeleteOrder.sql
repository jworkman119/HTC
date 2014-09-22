CREATE TRIGGER "DeleteOrder" 
BEFORE DELETE ON "Orders" 
FOR EACH ROW  
	WHEN (Select Tracking.Orders_Number From Tracking Where Tracking.Orders_Number = Old.Number) isNull  
		BEGIN 
			Delete From ShipTo Where ShipTo.Orders_Number = Old.Number;
			Delete From BillTo Where BillTo.Orders_Number = Old.Number;
			Delete From OrderDetails Where OrderDetails.Orders_Number = Old.Number; 
		END;
	Else
		 RAISE(ABORT, 'Package has been shipped, cannot delete the order') 	
	End;



CREATE TRIGGER "DeleteOrder" 
BEFORE DELETE ON "Orders" 
FOR EACH ROW  BEGIN 
	Select Case
		When ((Select Tracking.Orders_Number From Tracking Where Tracking.Orders_Number = Old.Number) isNull) Then
			Delete From ShipTo Where ShipTo.Orders_Number = Old.Number;
			Delete From BillTo Where BillTo.Orders_Number = Old.Number;
			Delete From OrderDetails Where OrderDetails.Orders_Number = Old.Number;
        Else 
			RAISE(ABORT, 'Package has been shipped, cannot delete the order') 		
	End;
END;