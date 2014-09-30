/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.addTime_Manually;

*/

CREATE PROCEDURE `addTime_Manually`(IN PersonID INT, IN TimeIn DATETIME, IN TimeOut DATETIME)
Begin

	Declare LastID int;

	Insert into Time(Person_ID, TimeIn, TimeOut)
	Values(PersonID,TimeIn,TimeOut);
   
   Set LastId = Last_Insert_ID();
   
	Select Time.ID
	, Time_Format(Time.TimeIn,'%h:%i %p') as TimeIn
	, Time_Format(Time.TimeOut,'%h:%i %p') as TimeOut
	, Hours
	from Time
	Where Time.ID = LastID
		and Time.Person_ID = PersonID;
	   
End

