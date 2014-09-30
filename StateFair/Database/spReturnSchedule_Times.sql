/* 
	drop procedure returnSchedule_Times 
*/

CREATE PROCEDURE returnSchedule_Times (IN _Worker int)	
	
	Select concat(FirstName,' ' , LastName) as Person
		, replace(PicPath,'/','@') as PicPath
		, Case
			When Gender='f' then
				'female'
			else
		 		'male'
			End as Gender
		, Role.Description as Job
		, Case 
			When Under18=false then
				'No'
			Else
				'Yes'
		 End as Under18
		, Case When Disabled=false then
			'No'
		  Else
		  	'Yes'
		  End as Disabled
		, Phone
		, Case
			When Driver=false then
				'No'
			Else
				'Yes'
		 End as Driver
		 , Schedule_Time.ID
		 , Schedule_Time.Day
		 , Schedule_Time.TimeIn
		 , Schedule_Time.TimeOut
		 , Schedule_Time.Zone
		 , Hours
		 , Schedule_Time.Status  
	From Person
		Left Join (	
				Select Time.ID
					, Date_Format(Time.TimeIn,'%m-%d-%Y') as Day
					, Time_Format(Time.TimeIn,'%h:%i %p') as TimeIn
					, Time_Format(Time.TimeOut,'%h:%i %p') as TimeOut
					, null as Zone
					, Hours
					, 'Worked' as Status
					, Person.ID as Person_ID
				from  Person
					Join Time on Person.ID = Time.Person_ID
				Where Time.Person_ID = _Worker
				
				
				Union
				
				
				Select Schedule.ID 
					, Date_Format(Schedule.Day,'%m-%d-%Y') as Day
					, Time_Format(Schedule.TimeIn,'%h:%i %p') as TimeIn
					, Time_Format(Schedule.TimeOut,'%h:%i %p') as TimeOut
					, concat(Zone.ID , ' - ' , Zone.Description) as Zone
					, Hours
					, 'Scheduled' as Status
					, Person.ID as Person_ID
				from Person
					Left Join Schedule on Person.ID = Schedule.Person_ID
					Left Join Zone on Schedule.Zone_ID = Zone.ID
				Where Person.ID = _Worker
				and Schedule.Day not in
				(
					Select Distinct Date(Time.TimeIn) as Day
					From Time 
					Where Person_ID = _Worker
				)
			Order by Day
	) as Schedule_Time on Person.ID = Schedule_Time.Person_ID
		Left Join Role on Person.Role_ID = Role.ID
	Where Person.ID = _Worker
	Order by Day
