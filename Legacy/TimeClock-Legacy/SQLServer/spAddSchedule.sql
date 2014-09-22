
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spAddSchedule' AND TYPE='P')
	DROP PROCEDURE spAddSchedule
GO

Create Procedure spAddSchedule(
	@Person varchar(100)
	, @Shift varchar(20)
	, @Day DateTime
	, @Action varchar(6)
	)
AS


-- Testing
/*
Declare @Person varchar(100)
Set @Person = 'Bob Hayes'
Declare @Shift varchar(20)
Set @Shift = 'first shift'
Declare @Day date
Set @Day = '8/26/2010'
Declare @Action char(6)
Set @Action = 'Delete'
*/

Declare @PersonID int
Declare @ShiftID int


select @PersonID = Person.ID
from Person
Where Person.FirstName + ' ' + Person.LastName = @Person


select @ShiftID = Shift.ID
from Shift
where Shift.Name = @Shift

If @Action = 'Delete' 
	--Begin
		Delete from Schedule
		Where Schedule.Person_ID = @PersonID
			and Schedule.Shift_ID = @ShiftID
			and Schedule.Day = @Day 	
	--End
Else
	--Begin
		Insert Into Schedule(Person_ID, Shift_ID, Day)
		select @PersonID, @ShiftID, @Day 
	--End

-- GRANT EXECUTE ON spAddSchedule TO TimeClock 