/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.DailyPayroll;

*/

CREATE PROCEDURE DailyPayroll(IN dtFrom DATE, IN dtTo DATE)
Begin


	if (dtFrom = dtTo) then
		select Person.VertexID 
			, concat(Person.LastName, ', ',Person.FirstName) as Worker
			, Role.Description as Role
			, case 
				When Time.TimeOut is null then
					Date_Format(Date(Time.TimeIn),'%m/%d/%Y')
				else
					Date_Format(Date(Time.TimeOut),'%m/%d/%Y')
			End as Day
			, Time_Format(Time(Time.TimeIn), '%h:%i %p') as Time_In
			, Time_Format(Time(Time.TimeOut), '%h:%i %p') as Time_Out
			, Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2) as HoursWorked
		from Time 
			join Person on Time.Person_ID = Person.ID
			Join Role on Person.Role_ID = Role.ID
		Where (
				Date(TimeOut) = dtTo
			  		OR 
			  	(Date(TimeIn) = dtFrom 
			  	and TimeOut is NULL)
			  )
		Order by Worker;		  

			

		
	Else
	
		select Person.VertexID 
			, concat(Person.LastName, ', ',Person.FirstName) as Worker
			, Role.Description as Role
			, Date_Format(Date(Time.TimeIn),'%m/%d/%Y') as Day
			, Time_Format(Time(Time.TimeIn), '%h:%i %p') as Time_In
			, Time_Format(Time(Time.TimeOut), '%h:%i %p') as Time_Out
			, Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2) as HoursWorked
			, 'Daily' as Type
		from Time 
			join Person on Time.Person_ID = Person.ID
			Join Role on Person.Role_ID = Role.ID
		Where Date(TimeOut) >= dtFrom
			and  Date(TimeOut)<= dtTo

		Union	
		
		select Person.VertexID 
				, concat(Person.LastName, ', ',Person.FirstName) as Worker
				, '' as Role
				, '' as Day
				, '' as Time_In
				, '' as Time_Out
				,  vwTotalHours.TotalHours as HoursWorked
				, 'TotalHours' as Type
			from Person 
				join vwTotalHours on vwTotalHours.Person_ID = Person.ID
				Join Role on Person.Role_ID = Role.ID
		Order by Worker,Type, Day;	

	End If;
End

