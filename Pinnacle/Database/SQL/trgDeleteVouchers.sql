--	drop trigger DeleteVouchers
CREATE TRIGGER DeleteVouchers
Before Delete ON Consumer
For Each Row
BEGIN

	Delete 
	From Voucher
	Where Voucher.Consumer_ID = Old.ID;
	
END;