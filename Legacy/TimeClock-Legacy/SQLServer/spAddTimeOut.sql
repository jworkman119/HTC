create procedure htcStateFair.addTimeOut (IN localTimeOut datetime,IN mysqlID bigint)
Begin 
	Update Time
	Set TimeOut = localTimeOut
	Where ID = mysqlID;
End;