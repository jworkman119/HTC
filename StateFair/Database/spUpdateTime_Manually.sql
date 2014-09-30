/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.updateTime_Manually;

*/

CREATE  PROCEDURE `updateTime_Manually`(TimeID int, dtTimeIn varchar(50), dtTimeOut varchar(50))
Begin

		Update Time
		Set TimeIn = dtTimeIn
			, TimeOut = dtTimeOut
		Where ID = TimeID;
		
		Select ID 
			, Time_Format(Time.TimeIn,'%h:%i %p') as TimeIn
			, Time_Format(Time.TimeOut,'%h:%i %p') as TimeOut
			, Hours
		From Time			
		Where ID = TimeID;

	
End

