Select  Date
	,Description
	, StartTime
	,EndTime 
, ((cast(strftime('%s',EndTime)as float) - cast(strftime('%s',StartTime)as float))/60)/60 as TotalTime
From Administrative 
	Join Staff on Administrative.Staff_ID = Staff.ID 
	Where Staff.FirstName || ' ' || Staff.LastName = 'Teresa Cucchiara' 
	and strFtime('%m',Date) in ('08','09') 
	and strFtime('%Y',Date) = '2013'
Group By Date
	, Description
	,StartTime
	,EndTime
Order by Date 
	
Select 
	strftime('%m',Date) as Month
	, sum(((cast(strftime('%s',EndTime)as float) - cast(strftime('%s',StartTime)as float))/60)/60) as TotalHours
From Administrative 
	Join Staff on Administrative.Staff_ID = Staff.ID 
Where Staff.FirstName || ' ' || Staff.LastName = 'Teresa Cucchiara' 
	and strFtime('%m',Date) in ('08','09') 
	and strFtime('%Y',Date) = '2013'	
Group by strftime('%m',Date)	
	
