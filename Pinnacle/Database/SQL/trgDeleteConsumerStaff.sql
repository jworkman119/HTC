--	drop trigger DeleteConsumer_Review
CREATE TRIGGER DeleteConsumerStaff
Before Delete ON Consumer
For Each Row
BEGIN

	Delete 
	From ConsumerStaff
	Where ConsumerStaff.Consumer_ID = Old.ID;
	
END;
