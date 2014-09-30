Create Procedure DailyPayroll(dtFrom DATE, dtTo DATE)

Begin

	if (dtFrom = dtTo) then
			select Person.ID 
				, concat(Person.LastName, ', ',Person.FirstName) as Worker
				, Role.Description as Role
				, Date_Format(Date(Time.TimeOut),'%m/%d/%Y') as Day
				, Time_Format(Time(Time.TimeIn), '%h:%i %p') as Time_In
				, Time_Format(Time(Time.TimeOut), '%h:%i %p') as Time_Out
				, TimeDiff(TimeOut,TimeIn) as TimeWorked
				, Schedule.Hours as Garbage
				, Schedule2.Hours as Bathroom
				, 'Daily' as Type
			from Time 
				join Person on Time.Person_ID = Person.ID
				Join Role on Person.Role_ID = Role.ID
				left Join Schedule on Schedule.Person_ID = Person.ID
					and Date(Time.TimeOut) = Schedule.Day
					and Schedule.job_id in (Select ID from Job where Job.Job = 'Garbage')
				left join Job on Schedule.Job_ID = Job.ID
					and Job.Job = 'Garbage'
				left Join Schedule Schedule2 on Schedule2.Person_ID = Person.ID
					and Date(Time.TimeOut) = Schedule2.Day
					and Schedule2.job_id in (Select ID from Job where Job.Job = 'Bathroom')
				left join Job Job2 on Schedule2.Job_ID = Job2.ID
					and Job2.Job = 'Bathroom'
			Where Date(TimeOut) >= dtFrom
				and  Date(TimeOut)<= dtTo;

	Else
			select Person.ID 
				, concat(Person.LastName, ', ',Person.FirstName) as Worker
				, Role.Description as Role
				, Date_Format(Date(Time.TimeOut),'%m/%d/%Y') as Day
				, Time_Format(Time(Time.TimeIn), '%h:%i %p') as Time_In
				, Time_Format(Time(Time.TimeOut), '%h:%i %p') as Time_Out
				, TimeDiff(TimeOut,TimeIn) as TimeWorked
				, Schedule.Hours as Garbage
				, Schedule2.Hours as Bathroom
				, 'Daily' as Type
			from Time 
				join Person on Time.Person_ID = Person.ID
				Join Role on Person.Role_ID = Role.ID
				left Join Schedule on Schedule.Person_ID = Person.ID
					and Date(Time.TimeOut) = Schedule.Day
					and Schedule.job_id in (Select ID from Job where Job.Job = 'Garbage')
				left join Job on Schedule.Job_ID = Job.ID
					and Job.Job = 'Garbage'
				left Join Schedule Schedule2 on Schedule2.Person_ID = Person.ID
					and Date(Time.TimeOut) = Schedule2.Day
					and Schedule2.job_id in (Select ID from Job where Job.Job = 'Bathroom')
				left join Job Job2 on Schedule2.Job_ID = Job2.ID
					and Job2.Job = 'Bathroom'
			Where Date(TimeOut) >= dtFrom
				and  Date(TimeOut)<= dtTo

		Union
		
			select Person.ID
				, concat(Person.LastName, ', ',Person.FirstName) as Worker
				, Role.Description as Role
				, '' as Date
				, '' Time_In
				, '' Time_Out
				, Sec_To_Time(Sum(Time_To_Sec(TimeDiff(TimeOut, TimeIn))))as TimeWorked
				, sum(Schedule.Hours) as Garbage
				, sum(Schedule2.Hours) as Bathroom
				, 'Total' as Type
			from Time
				Join Person on Time.Person_ID = Person.ID
					Join Role on Person.Role_ID = Role.ID
				left Join Schedule on Schedule.Person_ID = Person.ID
					and Date(Time.TimeOut) = Schedule.Day
					and Schedule.job_id in (Select ID from Job where Job.Job = 'Garbage')
				left Join Schedule Schedule2 on Schedule2.Person_ID = Person.ID
					and Date(Time.TimeOut) = Schedule2.Day
					and Schedule2.job_id in (Select ID from Job where Job.Job = 'Bathroom')
			Where Date(TimeOut) >= dtFrom
			and  Date(TimeOut)<= dtTo
			Group by Person.ID
				, Worker
				, Date
				, Time_In
				, Time_Out
				, Type
			Order By
				Worker
				, Type	
				, Day;
	End If;		
End;
		