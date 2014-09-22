/*
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spRptTimeCard2' AND TYPE='P')
	DROP PROCEDURE spRptTimeCard2
GO

Create Procedure spRptTimeCard2
	@FromDate datetime
	, @ToDate datetime
	
As
*/

-- Test

Declare	@FromDate datetime
Declare	@ToDate datetime

Set @FromDate = '8/30/2010'
Set @ToDate = '09/01/2010'

--end Test

select Person.LastName + ', ' + Person.FirstName as Worker
	, Person.HR_ID
	, TbIn.Time as [Time In]
	, TbOut.Time as [Time Out]
	, Case 
		When Cast(datediff(minute,TbIn.Time, TbOut.Time) as numeric)/60 >= 0 then
			Cast(datediff(minute,TbIn.Time, TbOut.Time) as numeric)/60
		else
			null
		End as [Hours Worked]
	, TbCount.Total
from Person 
	join (select * from Time where InOut = 'In')TbIn on Person.ID = TbIn.Person_ID
	left join (select * from Time where InOut = 'Out')TbOut on Person.ID = TbOut.Person_ID
		and TbOut.In_ID = TbIn.ID
	join ( 
			select Count(Person_id) as Total, person_id
			from time
			where Time.Time <= @ToDate
				and Time.Time >= @FromDate
			group by person_id
		) TbCount on Person.ID = TbCount.Person_Id	
where TbIn.Time <= @ToDate
	and TbIn.Time >= @FromDate
Order by Person.LastName, TbIn.Time

GRANT EXECUTE ON spRptTimeCard2 TO TimeClock 
GRANT EXECUTE ON spRptTimeCard2 TO  [htc\TimeClock]
