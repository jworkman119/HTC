/*
USE TimeClock 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spReturnSupervisor' AND TYPE='P')
	DROP PROCEDURE spReturnSupervisor
GO



Create Procedure spReturnSupervisor
	@Shift as varchar(25)
	, @Date as DateTime
	, @LastName as varchar(35)
	, @Firstname as varchar(20)	
AS
*/


Declare @Shift as varchar(25)
Declare @Date as Date
Declare @LastName as varchar(35)
Declare @Firstname as varchar(20)	

Set @Date = '8/24/2010'
Set @Shift = 'First Shift'

Set @Firstname = ''
Set @LastName = 'Tyson'


-- Returning the workers scheduled to work under supervisor

select Person.FirstName + ' ' + Person.LastName as Name
	, Schedule.Shift_ID
	, 'Scheduled' as Action
from Person
	join Schedule on Person.ID = Schedule.Person_ID
	Join Shift on Schedule.Shift_ID = Shift.ID
	join Person as Supervisor on Schedule.Supervisor_ID = Supervisor.ID
Where Schedule.Day = @Date
	and Shift.Name = @Shift
	and Supervisor.FirstName = @Firstname
	and Supervisor.LastName = @Lastname

UNION

-- Returning all workers not scheduled

select Person.FirstName + ' ' + Person.LastName as Name
	,Schedule.Shift_ID
	, '' as Action
From Person
	Left Join Schedule on Schedule.Person_ID = Person.ID 
	join Role on person.Role_ID = Role.ID
	join Shift on Shift.ID = Schedule.Shift_ID
Where Person.ID not In(

						Select Person.ID
						from Person
							join Schedule on Person.ID = Schedule.Person_ID
							Join Shift on Schedule.Shift_ID = Shift.ID
							join Person as Supervisor on Schedule.Supervisor_ID = Supervisor.ID
						Where Schedule.Day = @Date
							and Shift.Name = @Shift
							and Supervisor.FirstName = @Firstname
							and Supervisor.LastName = @Lastname

)
and Role.Description <> 'Supervisor'
and Shift.Name = @Shift
and Schedule.Day = @Date
and Schedule.Supervisor_ID is NULL
Order by Name

--GRANT EXECUTE ON spReturnSupervisor TO TimeClock 