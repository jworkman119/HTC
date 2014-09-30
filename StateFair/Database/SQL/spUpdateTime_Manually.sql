drop procedure UpdateTime_Manually

Create Procedure UpdateTime_Manually(TimeID int, dtTimeIn varchar(50), dtTimeOut varchar(50))

Begin

		Update Time
		Set TimeIn = dtTimeIn
			, TimeOut = dtTimeOut
		Where ID = TimeID;
		
		Select dtTimeIn, dtTimeOut
		, Time.*
		From Time
		Where id = TimeID;
	
End;


Call UpdateTime_Manually(21,'2011-08-24 18:00','2011-08-24 23:30')


Call UpdateTime_Manually(23,'2011-08-30 00:00','2011-08-30 5:00')


select *
from Time
where id = 25