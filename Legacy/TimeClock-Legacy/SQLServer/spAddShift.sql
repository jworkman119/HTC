USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spAddShift' AND TYPE='P')
	DROP PROCEDURE spAddShift
GO


Create Procedure spAddShift
	@Name varchar(20)
	, @TimeIn datetime
	, @TimeOut datetime
	
AS

--Testing
/*
Declare @Name varchar(20)
	Set @Name = 'New Shift'
Declare @TimeIn time
	Set @TimeIn = '7:00 AM'
Declare @TimeOut time
	Set @TimeOut = '7:00 PM'
*/


Declare @IsValue varchar(20)

-- Checking to see if shift exists
Select @IsValue = Name
from shift
where Shift.Name = @Name

-- Entering new shift
If @IsValue is NULL
	Begin
		Insert into Shift(Name, TimeIn, TimeOut)
		values(@Name, @TimeIn, @TimeOut)
	End
Else
-- Updating shift
	Begin
		Update Shift
		Set TimeIn = @TimeIn
		, TimeOut = @TimeOut
		Where Name = @Name
	End


GRANT EXECUTE ON spAddShift TO TimeClock 