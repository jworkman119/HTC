/*
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFillcmbSupervisor' AND TYPE='P')
	DROP PROCEDURE spFillcmbSupervisor
GO

Create Procedure spFillcmbSupervisor
	@Day datetime
	, @Shift varchar(30)

AS 
*/
-- Testing

Declare @Day DateTime
Declare @Shift varchar(30)

Set @Day = '8/24/2010'
Set @Shift = 'First Shift'

-- End Testing

SELECT Person.FirstName + ' ' +  Person.LastName as Name 
FROM Person 
	JOIN Role on Person.Role_ID = Role.ID 
	Join Schedule on Person.ID = Schedule.Person_ID 
	JOIN Shift on Schedule.Shift_ID = Shift.ID 
Where Role.Description = 'Supervisor'
	And Schedule.Day = @Day
	And Shift.Name =  @Shift
Order by Name
--GRANT EXECUTE ON spFillcmbSupervisor TO TimeClock 
	
