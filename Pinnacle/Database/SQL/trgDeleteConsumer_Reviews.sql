--	drop trigger DeleteConsumer_Review
CREATE TRIGGER DeleteConsumer_Review
Before Delete ON Consumer
For Each Row
BEGIN

	Delete 
	From Review
	Where Review.Consumer_ID = Old.ID;
	
END;




