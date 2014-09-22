
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spAddTime' AND TYPE='P')
	DROP Procedure spAddTime
GO

Create Procedure spAddTime

	@PersonID int
	
AS


--Testing
/*
Declare @PersonID int
Set @PersonID = 1349
*/
-- End test

Declare @Minutes int

Select top 1 @Minutes =  datediff(minute,Time.Time,getdate()) 
from Time
where Person_ID = @PersonID
order by Time desc



if @Minutes >= 5 or @Minutes is Null
	Begin 
		Insert Into Time(Person_ID, Time)
		values (@PersonID,GetDate())
	
	
		Select Top 2 Person.FirstName + ' ' + Person.LastName as Worker
			, Person.PicPath
			, Time.InOut
			, Time.Time
		From Person
			Join Time on Time.Person_ID = Person.ID
		Where Person.ID = @PersonID
		Order by Time desc
	End
Else
	Begin
		Select 'Double-Swipe' as Worker
	End

GRANT EXECUTE ON spAddTime TO TimeClock 