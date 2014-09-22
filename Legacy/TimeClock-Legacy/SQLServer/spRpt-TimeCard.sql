/*
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spRptTimeCard' AND TYPE='P')
	DROP PROCEDURE spRptTimeCard
GO

Create Procedure spRptTimeCard
	@Date datetime
	
As
*/

-- Test

Declare @Date as DateTime
Set @Date = '9/1/2010 013:34:00'

--end Test


Set @Date = DATEADD(dd, 0,DATEDIFF(dd, 0, @Date))

select Person.LastName + ', ' + Person.FirstName as Worker
	, Person.HR_ID
	, Person.ID
	, TbIn.ID
	, TbIn.Time as [Time In]
	, TbOut.ID
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
			where Time.Time >= @Date
				 and Time.Time < DateAdd(Day,1,@Date)
			group by person_id
		) TbCount on Person.ID = TbCount.Person_Id	
where TbIn.Time >= @Date
	and TbIn.Time < DateAdd(Day,1,@Date)
Order by Person.LastName, Person.FirstName, TbIn.Time

GRANT EXECUTE ON spRptTimeCard TO TimeClock 
GRANT EXECUTE ON spRptTimeCard TO  [htc\TimeClock]
