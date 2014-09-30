Select 
	Role.Description as Job
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) as Hours
	, 'x 23.58' as PayRate
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) * 23.58 as Pay
	, 'Labor Day' as Days
from Time
	join Person on Time.Person_ID = Person.ID
	join Role on Role.ID = Person.Role_ID
Where Date(Time.TimeOut) >= '2012-09-03'
	and Date(TimeOut) <= '2012-09-03'
Group by Role.Description

Union

Select 
	Role.Description as Job
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) as Hours
	, 'x 13.38' as PayRate
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) * 13.38 as Pay
	, '8/19/2012 - 9/2/2012' as Days
from Time
	join Person on Time.Person_ID = Person.ID
	join Role on Role.ID = Person.Role_ID
Where Date(Time.TimeOut) >= '2012-08-19'
	and Date(TimeOut) < '2012-09-03'
	and Role.ID = 'jan'
Group by Role.Description

Union

Select 
	Role.Description as Job
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) as Hours
	, 'x 13.38' as PayRate
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) * 13.38 as Pay
	, '> 09/03/2012' as Days
from Time
	join Person on Time.Person_ID = Person.ID
	join Role on Role.ID = Person.Role_ID
Where Date(TimeOut) > '2012-09-03'
	and Role.ID = 'jan'
Group by Role.Description



Union

Select 
	Role.Description as Job
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) as Hours
	, 'x 14.00' as PayRate
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) * 14.00 as Pay
	, '8/19/2012 - 9/02/2012' as Days
from Time
	join Person on Time.Person_ID = Person.ID
	join Role on Role.ID = Person.Role_ID
Where  Date(Time.TimeOut) >= '2012-08-19'
	and Date(TimeOut) < '2012-09-03'
	and Role.ID = 'sup'
Group by Role.Description


Union

Select 
	Role.Description as Job
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) as Hours
	, 'x 14.00' as PayRate
	, sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) * 14.00 as Pay
	, '> 09/03/2012' as Days
from Time
	join Person on Time.Person_ID = Person.ID
	join Role on Role.ID = Person.Role_ID
Where Date(TimeOut) > '2012-09-03'
	and Role.ID = 'sup'
Group by Role.Description
Order by Job
