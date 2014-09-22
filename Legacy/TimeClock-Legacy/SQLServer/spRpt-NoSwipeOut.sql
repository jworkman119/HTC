USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spRptNoSwipeOut' AND TYPE='P')
	DROP PROCEDURE spRptNoSwipeOut
GO

Create Procedure spRptNoSwipeOut

	
As

select Person.ID as BadgeID 
	, Person.LastName + ', ' + Person.FirstName as Worker
	, Person.Hr_ID
	, convert(varchar(20), time, 100) as date
from time 
	Join Person on Time.Person_ID = Person.ID
where InOut = 'In'
	and Time.ID not in ( Select In_ID
						 from time
						 where In_ID is not null
							and InOut = 'Out'
						)


GRANT EXECUTE ON spRptTimeCard TO TimeClock 
GRANT EXECUTE ON spRptTimeCard TO  [htc\TimeClock]