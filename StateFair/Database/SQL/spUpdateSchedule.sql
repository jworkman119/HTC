Create Procedure updateSchedule(intID int, strRole char(3), strSupervisor varchar(75), strJob varchar(20) )

if (strRole = 'jan') then
	Update Schedule
	Set 	 Schedule.Supervisor_ID = (Select Supervisor.ID 
														From Person Supervisor
														Where concat(Supervisor.FirstName, ' ' , Supervisor.LastName) = strSupervisor
															and Supervisor.Role_ID = 'sup')
			, Schedule.Job_ID = (select Job.ID
											From Job
											Where Job.Job = strJob
											and Job.Role_ID = 'jan') 													
	Where Schedule.ID = intID;
Else	
		Update Schedule
		Set 	 Schedule.Job_ID = (select Job.ID
											From Job
											Where Job.Job = strJob
											and Job.Role_ID = 'sup') 													
		Where Schedule.ID = intID;
End If;

