USE TimeClock 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spGetSupervisors' AND TYPE='P')
	DROP PROCEDURE spGetSupervisors
GO


Create Procedure spGetSupervisors
	@Shift as varchar(25)
	, @Date as DateTime
		
AS

Select FirstName + ' ' + LastName as Supervisor
From Person
	join Role on Person.Role_ID = Role.ID
	Join Schedule on Person.ID = Schedule.Person_ID
	Join Shift on Schedule.Shift_ID = Shift.ID
Where Role.Description = 'Supervisor'
	and Shift.Name = @shift
	and Schedule.Day = @Date

GRANT EXECUTE ON spGetSupervisors TO TimeClock 
