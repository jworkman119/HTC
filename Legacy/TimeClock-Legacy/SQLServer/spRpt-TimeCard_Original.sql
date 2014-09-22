
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spRptTimeCard' AND TYPE='P')
	DROP PROCEDURE spRptTimeCard
GO

Create Procedure spRptTimeCard
	@Date datetime
	
As


-- Test
/*
Declare @Date as DateTime
Set @Date = '08/30/2010'
*/
--end Test

Declare @EndTime datetime
Select @EndTime = convert(varchar(10),@Date + 1,101) + ' 6am'
Declare @StartTime datetime
Select @StartTime = convert(varchar(10),@Date,101) + ' 6am'



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
			where Time.Time < @EndTime
				and Time.Time > @StartTime
			group by person_id
		) TbCount on Person.ID = TbCount.Person_Id	
where TbIn.Time < @EndTime
	and TbIn.Time > @StartTime
Order by Person.LastName, TbIn.Time

GRANT EXECUTE ON spRptTimeCard TO TimeClock 
GRANT EXECUTE ON spRptTimeCard TO  [htc\TimeClock]
