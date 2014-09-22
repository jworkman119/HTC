
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spRpt_Schedule' AND TYPE='P')
	DROP PROCEDURE spRpt_Schedule
GO

Create Procedure spRpt_Schedule
	@Day datetime
	,@Shift as varchar(50)
As



-- Testing
/*
declare @Day as datetime
declare @Shift as varchar(50)


Set @Day = '2010-08-26 10:54:45'
Set @Shift = 'First Shift'
*/
-- end Testing

declare @Date as varchar(10)
Set @Date = convert(varchar,@Day,101)


select Person.LastName + ', ' + Person.FirstName as Worker
	, Supervisor.FirstName + ' ' + Supervisor.LastName as Supervisor
	, Shift.Name
	, Case 
		When Person.PicPath is Null then
			'c:\htcStateFair\Silhoutte.jpg'
		Else
			Person.PicPath
	End as picpath
	, Shift.TimeIn
	, Shift.TimeOut
from Schedule
	join Person on Schedule.Person_ID = Person.ID
	join Role on Person.Role_ID = Role.ID
	join Person as Supervisor on Schedule.Supervisor_ID = Supervisor.ID
	join Shift on Schedule.Shift_ID = Shift.ID
Where Shift.Name = @Shift
	and Day = @Date
Order by Shift.TimeIn
	
GRANT EXECUTE ON spRpt_Schedule TO  [htc\TimeClock]