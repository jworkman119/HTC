
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spReturnSchedule' AND TYPE='P')
	DROP PROCEDURE spReturnSchedule
GO

Create Procedure spReturnSchedule
	@Day datetime
	
As


 -- Testing
/*
Declare @Day as DateTime
Set @Day = '8/26/2010'
*/
-- End Testing


select Person.FirstName + ' ' + Person.LastName as Worker
	, Shift.Name as Shift
	, Shift.TimeIn 
	, Shift.TimeOut
	, Role.Description as Role
From Person
	left Join Schedule on Person.ID = Schedule.Person_ID 
		and Schedule.Day = @Day
	left Join Shift on Schedule.Shift_ID = Shift.ID
	left join Role on Person.Role_ID = Role.ID
Order by Role desc, Worker

-- GRANT EXECUTE ON spReturnSchedule TO TimeClock 