
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spReturnTimesWorked' AND TYPE='P')
	DROP Procedure spReturnTimesWorked
GO

Create Procedure spReturnTimesWorked

	@PersonID int
	
AS


-- Testing
/*
	Declare @PersonID int
	Set @PersonID = 1349
*/
-- End Testing

select Time.Id  as ID
	, Time.Time as TimeWorked --convert(varchar(20),Time.Time,100) as TimeWorked
--	, convert(varchar(20),Time.Time,1) + ' ' +  convert(varchar(8),Time.Time,108) as TimeWorked
	, Time.InOut
from Time
where person_id = @PersonID
order by Time.Time asc

GRANT EXECUTE ON spReturnTimesWorked TO TimeClock 


