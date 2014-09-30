CREATE TABLE htcStateFair.Job (
	ID bigint(19) DEFAULT 0 NOT NULL,
	Job varchar(40),
	Role_ID varchar(25),
	PRIMARY KEY (ID)
); 

CREATE TABLE htcStateFair.Person (
	ID int(10) NOT NULL auto_increment,
	FirstName varchar(25),
	LastName varchar(35),
	PicPath varchar(255),
	Gender char(1) NOT NULL,
	Role_ID varchar(3) NOT NULL,
	under18 tinyint(3) NOT NULL,
	VertexID int(10),
	Disabled tinyint(3),
	PRIMARY KEY (ID)
); 

CREATE TABLE htcStateFair.Role (
	ID varchar(3) NOT NULL,
	Description varchar(25),
	PRIMARY KEY (ID)
) ;

CREATE TABLE htcStateFair.Schedule (
	ID int(10) NOT NULL auto_increment,
	Person_ID int(10) NOT NULL,
	Day date,
	TimeIn time,
	TimeOut time,
	Zone_ID varchar(50) NOT NULL,
	Supervisor_ID int(10),
	Hours float(12),
	PRIMARY KEY (ID)
);

CREATE TABLE htcStateFair.stagingTime (
	ID int(10) DEFAULT 0 NOT NULL,
	Person_ID int(10),
	Time datetime,
	PRIMARY KEY (ID)
);

CREATE TABLE htcStateFair.tempTotalHours (
	Person_Id int(10) DEFAULT 0 NOT NULL,
	Role_ID varchar(3) NOT NULL,
	Disabled bit(1) DEFAULT b'0',
	NonDisabled int(10),
	TotalHours decimal(34,2),
	NonLaborDay decimal(35,2),
	LaborDay decimal(34,2)
);

CREATE TABLE htcStateFair.tempVertex (
	FirstName varchar(25),
	LastName varchar(25),
	Vertex_ID int(10),
	Job varchar(25)
);

CREATE TABLE htcStateFair.Time (
	ID int(10) NOT NULL auto_increment,
	Person_ID int(10) NOT NULL,
	TimeIn datetime,
	TimeOut datetime,
	stagingTimeIn_ID int(10),
	stagingTimeOut_ID int(10),
	PRIMARY KEY (ID)
);

CREATE TABLE htcStateFair.Users (
	Username varchar(25) NOT NULL,
	Pwd varchar(100),
	PRIMARY KEY (Username)
);

CREATE TABLE htcStateFair.Zone (
	ID varchar(50) NOT NULL,
	Description varchar(100),
	PRIMARY KEY (ID)
);

ALTER TABLE htcStateFair.Person
	ADD FOREIGN KEY (Role_ID) 
	REFERENCES Role (ID);



ALTER TABLE htcStateFair.Schedule
	ADD FOREIGN KEY (Person_ID) 
	REFERENCES Person (ID);

ALTER TABLE htcStateFair.Schedule
	ADD FOREIGN KEY (Zone_ID) 
	REFERENCES Zone (ID);



CREATE VIEW htcStateFair.vwSpreadsheetTimeCount (TimeIn,TimeOut,Day,Total,Shift,Zone_ID) AS select `htcStateFair`.`Schedule`.`TimeIn` AS `TimeIn`,`htcStateFair`.`Schedule`.`TimeOut` AS `TimeOut`,`htcStateFair`.`Schedule`.`Day` AS `Day`,count(`htcStateFair`.`Schedule`.`TimeIn`) AS `Total`,(case when ((`htcStateFair`.`Schedule`.`TimeIn` >= '23:00:00') or (`htcStateFair`.`Schedule`.`TimeIn` < '05:30:00')) then 'Overnight' when ((`htcStateFair`.`Schedule`.`TimeIn` >= '05:30:00') and (`htcStateFair`.`Schedule`.`TimeIn` < '12:00:00')) then 'Morning' when ((`htcStateFair`.`Schedule`.`TimeIn` >= '12:00:00') and (`htcStateFair`.`Schedule`.`TimeIn` < '23:00:00')) then 'Night' end) AS `Shift`,`htcStateFair`.`Schedule`.`Zone_ID` AS `Zone_ID` from `htcStateFair`.`Schedule` group by `htcStateFair`.`Schedule`.`Zone_ID`,`htcStateFair`.`Schedule`.`TimeIn`,`htcStateFair`.`Schedule`.`TimeOut`,`htcStateFair`.`Schedule`.`Day` order by (case when ((`htcStateFair`.`Schedule`.`TimeIn` >= '23:00:00') or (`htcStateFair`.`Schedule`.`TimeIn` < '05:30:00')) then 'Overnight' when ((`htcStateFair`.`Schedule`.`TimeIn` >= '05:30:00') and (`htcStateFair`.`Schedule`.`TimeIn` < '12:00:00')) then 'Morning' when ((`htcStateFair`.`Schedule`.`TimeIn` >= '12:00:00') and (`htcStateFair`.`Schedule`.`TimeIn` < '23:00:00')) then 'Night' end),`htcStateFair`.`Schedule`.`TimeIn`,`htcStateFair`.`Schedule`.`Day`;

CREATE VIEW htcStateFair.vwSupSchedule (Supervisor,Worker_ID,Schedule_Id,Day,TimeIn,TimeOut,Zone_ID,Hours) AS select concat(`htcStateFair`.`Person`.`FirstName`,' ',`htcStateFair`.`Person`.`LastName`) AS `Supervisor`,`htcStateFair`.`Person`.`ID` AS `Worker_ID`,`htcStateFair`.`Schedule`.`ID` AS `Schedule_Id`,`htcStateFair`.`Schedule`.`Day` AS `Day`,`htcStateFair`.`Schedule`.`TimeIn` AS `TimeIn`,(case when (`htcStateFair`.`Schedule`.`TimeOut` = '00:00:10') then '23:59' else `htcStateFair`.`Schedule`.`TimeOut` end) AS `TimeOut`,`htcStateFair`.`Schedule`.`Zone_ID` AS `Zone_ID`,`htcStateFair`.`Schedule`.`Hours` AS `Hours` from (`htcStateFair`.`Schedule` join `htcStateFair`.`Person` on((`htcStateFair`.`Schedule`.`Person_ID` = `htcStateFair`.`Person`.`ID`))) where (`htcStateFair`.`Person`.`Role_ID` = 'sup');

CREATE VIEW htcStateFair.vwTotalHours (Person_Id,Role_ID,Disabled,TotalHours) AS select `htcStateFair`.`Time`.`Person_ID` AS `Person_Id`,`htcStateFair`.`Person`.`Role_ID` AS `Role_ID`,`htcStateFair`.`Person`.`Disabled` AS `Disabled`,sum(round((time_to_sec(timediff(`htcStateFair`.`Time`.`TimeOut`,`htcStateFair`.`Time`.`TimeIn`)) / 3600),2)) AS `TotalHours` from (`htcStateFair`.`Time` join `htcStateFair`.`Person` on((`htcStateFair`.`Time`.`Person_ID` = `htcStateFair`.`Person`.`ID`))) group by `htcStateFair`.`Time`.`Person_ID` order by `htcStateFair`.`Time`.`Person_ID`;

CREATE VIEW htcStateFair.vwWorkerSchedule (Id,Worker,FirstName,LastName,Worker_ID,PicPath,Day,TimeIn,TimeOut,Zone_ID,Hours) AS select `htcStateFair`.`Schedule`.`ID` AS `Id`,concat(`htcStateFair`.`Person`.`FirstName`,' ',`htcStateFair`.`Person`.`LastName`) AS `Worker`,`htcStateFair`.`Person`.`FirstName` AS `FirstName`,`htcStateFair`.`Person`.`LastName` AS `LastName`,`htcStateFair`.`Person`.`ID` AS `Worker_ID`,`htcStateFair`.`Person`.`PicPath` AS `PicPath`,`htcStateFair`.`Schedule`.`Day` AS `Day`,`htcStateFair`.`Schedule`.`TimeIn` AS `TimeIn`,`htcStateFair`.`Schedule`.`TimeOut` AS `TimeOut`,`htcStateFair`.`Schedule`.`Zone_ID` AS `Zone_ID`,`htcStateFair`.`Schedule`.`Hours` AS `Hours` from (`htcStateFair`.`Schedule` join `htcStateFair`.`Person` on((`htcStateFair`.`Schedule`.`Person_ID` = `htcStateFair`.`Person`.`ID`))) where (`htcStateFair`.`Person`.`Role_ID` = 'jan');

CREATE INDEX Person_ID ON htcStateFair.Time (Person_ID);

CREATE INDEX Person_ID ON htcStateFair.Schedule (Person_ID);

CREATE INDEX Role ON htcStateFair.Job (Role_ID);

CREATE INDEX Role_ID ON htcStateFair.Person (Role_ID);

CREATE INDEX stagingTimeIn_ID ON htcStateFair.Time (stagingTimeIn_ID);

CREATE INDEX stagingTimeOut_ID ON htcStateFair.Time (stagingTimeOut_ID);

CREATE INDEX Zone_ID ON htcStateFair.Schedule (Zone_ID);

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addSchedule_Auto`( strName varchar(75), strZone varchar(25), strDate varchar(15), tmTimeIn Time, tmTimeOut Time)
Begin
	
		Insert into Schedule(Person_ID,Zone_ID,Day,TimeIn,TimeOut)		
		Select Person.ID 
			, strZone
			, strDate 
			, tmTimeIn
			, tmTimeOut
		From Person
		Where concat(Person.FirstName, ' ', Person.LastName) = strName;

	
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `AddShift`(IN varName VARCHAR(35), IN varTimeIn TIME, IN varTimeOut TIME)
Begin	
	Declare isShift varchar(35);

	Select Name
	into isShift
	from Shift
	where Shift.Name = varName;

	If (isShift is NULL) Then
			Insert into Shift(Name, TimeIn, TimeOut)
			values(varName, varTimeIn, varTimeOut);
	Else
			Update Shift
			Set TimeIn = varTimeIn
			, TimeOut = varTimeOut
			Where Name = varName;
	End If;

End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addSupervisorSchedule_Auto`( strName varchar(75), strDate varchar(15), strShift varchar(35), strSupervisor varchar(75), strJob varchar(15))
Begin
	Insert into Schedule(Person_ID,Day,Shift_ID, Supervisor_ID, Job_ID)		
	Select Person.ID 
		, strDate 
		, Shift.ID as Shift_ID
		, Supervisor.ID
		, Job.ID 
	From Person
		, Shift
		, Job
	Where	concat(Person.FirstName, ' ', Person.LastName) = strName
		and Person.Role_ID = 'sup'
		and Shift.Name = strShift
		and Job.Name = strJob
		and Job.Role_ID = 'sup';
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addSupSchedule`(IN strFirstName VARCHAR(35), IN strLastName VARCHAR(50), IN Day VARCHAR(10), IN TimeIn TIME, IN TimeOut TIME, IN Zone varchar(25))
Begin
	Declare intWorker int;

	
	Select ID
	Into intWorker
	From Person 
	Where  concat(Person.FirstName, ' ', Person.LastName) = concat(strFirstName, ' ' , strLastName)
		and Person.Role_ID = 'sup';	
	
	-- Inserting into db
	If(intWorker > 0) Then
		Insert Into Schedule(Person_ID, Day,TimeIn, TimeOut, Zone_ID)
		Values (intWorker ,Date_Format(Day,'%Y-%m-%d') ,TimeIn, TimeOut, Zone);
	End If;	

End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addTime`(IN PersonID bigint,IN Time datetime,IN SQLiteDB_ID bigint)
Begin

	Declare TimeInID int;
	Declare TimeOutID int;

	-- Entering new time into Time
	INSERT INTO stagingTime(Person_ID, Time,ID)
	VALUES(PersonID, Time, SQLiteDB_ID);


	
	Set TimeInID = (Select stagingTimeIn_ID
					From Time
					Where stagingTimeIn_ID = SQLiteDB_ID);
					
	Set TimeOutID = (Select stagingTimeOut_ID
					From Time
					Where stagingTimeOut_ID = SQLiteDB_ID);
					
	Select Case
		When TimeInID is not null Then
			'In'
		When TimeOutID is not null Then
		'Out'
	end as Status;
	
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addTimeIn`(In PersonID int,In TimeIn datetime,In SQLiteDB_ID int)
Begin

	-- Entering new time into Time
	INSERT INTO Time(Person_ID, TimeIn,LocalDB_ID)
	VALUES(PersonID, TimeIn, SQLiteDB_ID);

	-- Returning new Time.Id to be placed in localDB
	SELECT ID
	FROM Time
	WHERE LocalDB_ID = SQLiteDB_ID;
	
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addTimeOut`(IN localTimeOut datetime,IN mysqlID bigint)
Begin 
	Update Time
	Set TimeOut = localTimeOut
	Where ID = mysqlID;
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `AddTime_Manually`(IN strFirst VARCHAR(25), IN strLast VARCHAR(35), IN TimeIn DATETIME, IN TimeOut DATETIME)
Begin

	Declare intPerson int;
		
		Select Person.ID
		Into intPerson
		from Person
		where FirstName = strFirst
		and LastName = strLast;
		
		if (intPerson>0) then
		   Insert into Time(Person_ID, TimeIn, TimeOut)
		   Values(intPerson,TimeIn,TimeOut);
		end if;
   
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `AddTime_NotAdded`(IN PersonID INT(10), IN TimeGiven DATETIME)
Begin	

	Declare TimeID int;
	Declare TimeDiff_In double;
	Declare TimeDiff_Out double;


	Select Time.ID
		, Now() - Time.TimeIn
		, Now() - Time.TimeOut 
	into TimeID, TimeDiff_In,TimeDiff_Out	
	From Time
		join Person on Time.Person_ID = Person.ID
	where Time.Person_ID = PersonID
		and (date(Now()) = date(Time.TimeIn)
			or date(Now()) = date(Time.TimeIn)
		)
	order by Time.id desc
	Limit 1;

		
	if ((TimeDiff_In >= 500 and TimeDiff_Out is NULL) OR TimeDiff_Out >= 500 OR TimeID is NULL) Then
		
		If (TimeDiff_Out is NULL and TimeDiff_In is Not Null) Then
			Update Time
				Join Person on Time.Person_ID = Person.ID
			Set Time.TimeOut = TimeGiven
			where Time.ID = TimeID
				and Person.ID = Time.Person_ID;
									
			Select Time.ID
				, Time.Person_ID
				, concat(Person.FirstName, ' ', Person.LastName) as Person
				, TimeDiff_In
				, Time.TimeIn as TimeIn
				, Time.TimeOut as TimeOut
				, 'Out' as Status
			from Time
				join Person on Time.Person_ID = Person.ID
			where Time.ID = TimeID;
		else
			Insert into Time(Time.Person_ID, Time.TimeIn)
				Select Person.ID, TimeGiven
				From Person
				Where Person.ID = PersonID;
		
			Select Time.ID
				, Time.Person_ID
				, concat(Person.FirstName, ' ', Person.LastName) as Person
				, TimeDiff_In
				, Time.TimeIn as TimeIn
				, Time.TimeOut as TimeOut
				, 'In' as Status 
			From Time
				join Person on Time.Person_ID = Person.ID
			Where Time.TimeOut is NULL
				and Time.Person_ID = PersonID;
		End If;
	else 
		Select 'Double-Swipe' as Status;
	End if;
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `addWorkerSchedule`(IN strFirstName VARCHAR(35), IN strLastName VARCHAR(50), IN Day VARCHAR(10), IN TimeIn TIME, IN TimeOut TIME, IN strZone varchar(25))
Begin
	Declare intWorker int;
	
	Select ID
	Into intWorker
	From Person 
	Where  concat(Person.FirstName, ' ', Person.LastName) = concat(strFirstName, ' ' , strLastName)
		and Person.Role_ID = 'jan';	
	
	-- Inserting into db
	If(intWorker > 0) Then
		Insert Into Schedule(Person_ID, Day,TimeIn, TimeOut, Zone_ID)
		Values (intWorker ,Date_Format(Day,'%Y-%m-%d') ,TimeIn, TimeOut, strZone);
	End If;
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `checkPassword`(IN UserName varchar(25),IN Pass varchar(100), Out Status varchar(6))
Begin

       Declare PassWd varchar(100);

 

       Select Pwd

       Into PassWd

       from Users

       where Users.Username = UserName;

      

	
	If(md5('htc') = PassWd) then
		Set Status = 'Update';
	ElseIf (Pass=Passwd) then

    	Set Status = 'OK';	
    Else
        Set Status = 'Fail';      
    end if;

 

       Select Status;

End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `checkPunchIns`(IN dtDay DATE)
select concat(Person.FirstName, ' ',Person.LastName) as Person
		, TimeStamp(Schedule.Day,Schedule.TimeIn) TimeIn
		, Schedule.TimeOut
		, Time.TimeIn
		, Time.TimeOut
		, TimeDiff(Time.TimeIn, TimeStamp(Schedule.Day, Schedule.TimeIn)) as TimeIn_Difference
	from Time
		Join Schedule on Time.Person_ID = Schedule.Person_ID
		Join Person on Time.Person_ID = Person.ID
	where Date(Time.TimeOut) = dtDay
		and Schedule.Day = dtDay
		and TimeDiff(Time.TimeIn, TimeStamp(Schedule.Day, Schedule.TimeIn)) > '01:00:00';

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `DailyPayroll`(IN dtFrom DATE, IN dtTo DATE)
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
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `deleteSchedule_Auto`(dtDay Date,strSheet varchar(25))
Begin
	Declare ShiftStart Time;
	Declare ShiftEnd Time;

	if(strSheet = 'Morning') then
		set ShiftStart = '05:00';
		set ShiftEnd = '12:00';
	elseif(strSheet = 'Evening')then		
		set ShiftStart = '12:00';
		set ShiftEnd = '23:59';
	elseif(strSheet = 'Overnight')then
		set ShiftStart = '00:00';
		set ShiftEnd = '5:00';		
	end if;

	Delete from Schedule
	Where Schedule.Day= dtDay
		and Schedule.TimeIn >= ShiftStart
		and Schedule.TimeIn<= ShiftEnd;
		
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `Demo`(IN PersonID INT(10))
Begin	

	Declare TimeID int;
	Declare TimeDiff_In Time;
	Declare TimeDiff_Out Time;

			
	Select Time.ID
		, TimeDiff(Now(),Time.TimeIn)
		, TimeDiff(Now(),Time.TimeOut)
	into TimeID, TimeDiff_In,TimeDiff_Out	
	From Time
		join Person on Time.Person_ID = Person.ID
	where Time.Person_ID = PersonID
		and (
					date(Now()) = date(Time.TimeIn)
					or 
					(date(Now()) = date(Time.TimeIn)+ 1 
						and Time.TimeOut is NULL)
			)
	order by Time.id desc
	Limit 1;

		
	if ((TimeDiff_In >= '00:05:00' and TimeDiff_Out is NULL) OR TimeDiff_Out >= '00:05:00' OR TimeID is NULL) Then
		
		If (TimeID is Not Null and TimeDiff_In <='17:00:00') Then
			Update Time
				Join Person on Time.Person_ID = Person.ID
			Set Time.TimeOut = Now()
			where Time.ID = TimeID
				and Person.ID = Time.Person_ID;
									
			Select Time.ID
				, Time.Person_ID
				, concat(Person.FirstName, ' ', Person.LastName) as Person
				, TimeDiff_In
				, Time.TimeIn as TimeIn
				, Time.TimeOut as TimeOut
				, 'Out' as Status
			from Time
				join Person on Time.Person_ID = Person.ID
			where Time.ID = TimeID;
		else
			Insert into Time(Time.Person_ID, Time.TimeIn)
				Select Person.ID, Now()
				From Person
				Where Person.ID = PersonID;
		
			Select Time.ID
				, Time.Person_ID
				, concat(Person.FirstName, ' ', Person.LastName) as Person
				, TimeDiff_In
				, Time.TimeIn as TimeIn
				, Time.TimeOut as TimeOut
				, 'In' as Status 
			From Time
				join Person on Time.Person_ID = Person.ID
			Where Time.TimeOut is NULL
				and Time.Person_ID = PersonID;
		End If;
	else 
		Select 'Double-Swipe' as Status;
	End if;
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `DownloadSchedule`(In dtStart Date, In dtEnd Date)
Select Case 
	When (Schedule.TimeIn>='23:00:00' or Schedule.TimeIn<'05:30:00') then
		'Overnight'
	When (Schedule.TimeIn>='05:30:00' and Schedule.TimeIn<'12:00:00') then
		'Morning'
	When (Schedule.TimeIn>='12:00:00' and Schedule.TimeIn<'23:00:00') then
		'Night'
	End as Shift
	, Schedule.Day
	, Schedule.Zone_ID
	, Schedule.TimeIn
	, Schedule.TimeOut
	, concat(Person.FirstName, ' ' ,Person.LastName) as Person
	, Role.Description as Role
	From Schedule
		Join Person on Person.ID = Schedule.Person_ID
		Join Zone on Zone.ID = Schedule.Zone_ID
		Join Role on Person.Role_ID= Role.ID
	Where Schedule.Day >= dtStart
		and Schedule.Day <= dtEnd
	order by Day,Shift,Zone_ID,TimeIn,TimeOut, Role desc;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `ReturnRosterSheets`(IN dtDay DATE, IN intSupervisor INT(10))
Begin

	select  
		vwSupSchedule.Supervisor
	, concat(Zone2.ID, ' - ' ,Zone2.Description ) as SupZone
	, concat(Time_Format(vwSupSchedule.TimeIn, '%h:%i'), ' - ',Time_Format(vwSupSchedule.TimeOut, '%h:%i %p')) as SupShift
	, vwWorkerSchedule.Worker
	 , Date_Format(vwWorkerSchedule.Day,'%m-%d-%Y') as Day 
	 , concat(Time_Format(vwWorkerSchedule.TimeIn, '%h:%i'), ' - ',Time_Format(vwWorkerSchedule.TimeOut, '%h:%i %p')) as Shift
	 , concat('../../images/',FirstName,'_',LastName,'.jpg') as PicPath
	 , concat(vwWorkerSchedule.Zone_ID, ' - ',Zone.Description) as Zone
	From vwWorkerSchedule 
		left Join vwSupSchedule on vwSupSchedule.Zone_ID = vwWorkerSchedule.Zone_ID 
			and vwSupSchedule.Day = vwWorkerSchedule.Day 
			and vwWorkerSchedule.TimeOut >= vwSupSchedule.TimeIn
			and vwWorkerSchedule.TimeIn <= vwSupSchedule.TimeOut 
		Left Join Zone on vwWorkerSchedule.Zone_ID = Zone.ID
		Left Join Zone as Zone2 on vwSupSchedule.Zone_ID = Zone2.ID	
	Where  
		vwSupSchedule.Day = dtDay
		and vwSupSchedule.Worker_ID = intSupervisor
		and timediff(vwSupSchedule.TimeOut,vwWorkerSchedule.TimeIn) > '02:00:00'
		and timediff(vwWorkerSchedule.TimeOut, vwSupSchedule.TimeIn) > '02:00:00'
	Order by vwWorkerSchedule.TimeIn, Zone,Worker;
		
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `ReturnWorkerSchedule`()
select WorkerSchedule.ID
		 , concat(Person.LastName, ', ' , Person.FirstName) as Worker
		, Person.FirstName
		, Person.LastName
		, Person.ID as Worker_ID
		, Date_Format(WorkerSchedule.Day,'%m-%d-%Y') as Day
		, Time_Format(WorkerSchedule.TimeIn,'%h:%i %p') as TimeIn
		, Time_Format(WorkerSchedule.TimeOut,'%h:%i %p') as TimeOut
		, WorkerSchedule.Hours as Hours
		, SupSchedule.Person_ID as Supervisor_ID
	From Person
	Join(Select Schedule.*
	         From Schedule
	             Join Person on Schedule.Person_ID = Person.ID
	         Where Role_ID = 'jan'
	         ) as WorkerSchedule on WorkerSchedule.Person_ID = Person.ID
	Left Join(
	     Select Schedule.*
	     From Schedule
	         Join Person on Schedule.Person_ID = Person.ID
	     Where Role_ID = 'sup'
	     ) as SupSchedule on SupSchedule.Zone_ID = WorkerSchedule.Zone_ID
	         and SupSchedule.Day = WorkerSchedule.Day
	Where
		WorkerSchedule.TimeIn < SupSchedule.TimeOut
		and TimeDiff(WorkerSchedule.TimeIn, SupSchedule.TimeIn) <= '2:00:00'
	Order by Person.LastName, Day;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `ScheduleVsPunches`(IN dtDay DATE)
Begin

	SELECT concat(vwWorkerSchedule.LastName,', ' , vwWorkerSchedule.FirstName) as Worker
	, concat(Time_Format(vwWorkerSchedule.TimeIn,'%h:%i %p'), ' - ',Time_Format(vwWorkerSchedule.TimeOut,'%h:%i %p')) as Scheduled
	, Date_Format(Time.TimeIn, '%c-%d-%y %h:%i %p') as TimeIn
	, Date_Format(Time.TimeOut, '%c-%d-%y %h:%i %p') as TimeOut
	,  Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2) as TotalHours
	from vwWorkerSchedule
		left join Time on vwWorkerSchedule.Worker_ID = Time.Person_ID
			and date(Time.TimeIn) = dtDay
	where vwWorkerSchedule.day = dtDay
	
	
	Union
	
	Select vwSupSchedule.Supervisor as Worker

	, concat(Time_Format(vwSupSchedule.TimeIn,'%h:%i %p'), ' - ',Time_Format(vwSupSchedule.TimeOut,'%h:%i %p')) as Scheduled
	, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
	, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
	,  Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2) as TotalHours
	from vwSupSchedule
		left join Time on vwSupSchedule.Worker_ID = Time.Person_ID
			and date(Time.TimeIn) = dtDay
	where vwSupSchedule.Day = dtDay


	Union
	
	select concat(Person.LastName, ', ', Person.FirstName) as Person

	, '' as Scheduled
	, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
	, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
	,  Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2) as TotalHours
	from Time
		Join Person on Time.Person_ID = Person.ID
	Where Date(Time.TimeIn)= dtDay
	and Person.ID Not In (
							Select Person_ID
							From Schedule
							where Day = dtDay
							)
	Order by  Worker;

End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `updatePassword`(IN User VARCHAR(25),IN PassWord VARCHAR(100))
Begin


Update Users
Set Users.Pwd = PassWord
where Users.UserName = User;

End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `updateSchedule`(intID int, strRole char(3), strSupervisor varchar(75), strJob varchar(20) )
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

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `updateSupSchedule`(IN ScheduleID INT(10), IN Day VARCHAR(10), IN tmTimeIn TIME, IN tmTimeOut TIME, IN Zone varchar(35))
Begin
	Declare intWorker int;
	Declare fltHours float;
	
	Set fltHours = Round(time_to_sec(TimeDiff(tmTimeOut,tmTimeIn))/3600,2);
	
	if (fltHours<0) then
		Set fltHours = 24 + fltHours;
	End If;
		
	-- Inserting into db
		Update Schedule
		Set Day = Date_Format(Day,'%Y-%m-%d') 
			, TimeIn = tmTimeIn
			, TimeOut = tmTimeOut
			, Hours = fltHours
			, Zone_ID = Zone
		Where Schedule.ID = ScheduleID;	
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `UpdateTime_Manually`(TimeID int, dtTimeIn varchar(50), dtTimeOut varchar(50))
Begin

		Update Time
		Set TimeIn = dtTimeIn
			, TimeOut = dtTimeOut
		Where ID = TimeID;
		
		Select dtTimeIn, dtTimeOut
		, Time.*
		From Time
		Where id = TimeID;
	
End;

CREATE DEFINER=`rootHTC`@`%` PROCEDURE `updateWorkerSchedule`(IN ScheduleID INT, IN Day VARCHAR(10),  IN tmTimeIn Time, IN tmTimeOut Time, In strZone VarChar(25))
Begin
	Declare intWorker int;
	Declare fltHours float;
	
	Set fltHours = Round(time_to_sec(TimeDiff(tmTimeOut,tmTimeIn))/3600,2);
	
	if (fltHours<0) then
		Set fltHours = 24 + fltHours;
	End If;
		
	-- Inserting into db
		Update Schedule
		Set Day = Date_Format(Day,'%Y-%m-%d') 
			, TimeIn = tmTimeIn
			, TimeOut = tmTimeOut
			, Hours = fltHours
			, Zone_ID = strZone
		Where Schedule.ID = ScheduleID;	
End;

CREATE TRIGGER insertScheduleHours BEFORE INSERT ON Schedule FOR EACH ROW Begin
	Declare fltHours float;

	Set fltHours = Round(time_to_sec(TimeDiff(New.TimeOut,New.TimeIn))/3600,2);
	
	if (fltHours<0) then
		Set fltHours = 24 + fltHours;
	End If;

	Set New.Hours = fltHours;
End;

CREATE TRIGGER insertStagingTime AFTER INSERT ON stagingTime FOR EACH ROW Begin
	
	Declare TimeID int;
	Declare NewTimeID int;
	
	Set TimeID = (Select Time.ID
				 From Time
				 Where Time.TimeOut is null
					and Time.Person_ID = new.Person_ID
					and time_to_sec(TimeDiff(New.Time,Time.TimeIn))/3600 <= 14
				order by Time.TimeIn
				Limit 1);
				
		
				
	If (TimeID is not null) then
		Update Time
		Set Time.TimeOut = New.Time
			, Time.stagingTimeOut_ID = New.Id
		Where Time.ID = TimeID;
	Else
		Insert into Time(Person_ID,TimeIn,stagingTimeIn_ID)
		Values(New.Person_ID, New.Time, New.ID);
				
	End If;
	

End;

CREATE TRIGGER updateScheduleHours BEFORE UPDATE ON Schedule FOR EACH ROW Begin
	Declare fltHours float;

	Set fltHours = Round(time_to_sec(TimeDiff(New.TimeOut,New.TimeIn))/3600,2);
	
	if (fltHours<0) then
		Set fltHours = 24 + fltHours;
	End If;

	Set New.Hours = fltHours;
End;

