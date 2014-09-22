/*
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spUpdateSupervisor' AND TYPE='P')
	DROP PROCEDURE spUpdateSupervisor
GO
*;
/*
Create Procedure spUpdateSupervisor
	@Sup_FName varchar(20)
	, @Sup_LName varchar(25)
	, @FName varchar(20)
	, @LName varchar(25)
	, @Day DateTime
	, @Shift varchar(20)

As
*/

-- Testing

Declare @Sup_FName varchar(20)
Declare @Sup_LName varchar(25)
Declare @FName varchar(20)
Declare @LName varchar(25)
Declare @Day DateTime
Declare @Shift varchar(20)

set @Sup_FName = 'Gregory'
set @Sup_LName = 'Trapps'

set @FName = 'Dennis'
set @LName = 'Edwards_Jr'

set @Day = '8/27/2010'
set @Shift = 'second shift'
-- End Testing


Declare @SupID int
Declare @PersID int
Declare @ShiftID int



-- Retrieving person ID for supervisor
Select @SupID = Person.ID
From Person
	join Role on person.Role_ID = Role.ID
where FirstName = @Sup_FName
and LastName = @Sup_LName
and Role.Description = 'Supervisor'

-- Retrieving person ID for worker
Select @PersID = Person.ID
From Person
where FirstName = @FName
	and LastName = @LName


-- Retrieving the Shift ID
Select @ShiftID = Shift.ID
From Shift
where Shift.Name = @Shift


Select @Day

Update Schedule
Set Schedule.Supervisor_ID = @SupID
Where Schedule.Person_ID = @PersID
	and Schedule.Shift_ID = @ShiftID
	and Schedule.Day = @Day

--GRANT EXECUTE ON spUpdateSupervisor TO TimeClock 