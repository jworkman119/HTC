select PT.pt_job_number as JobNumber
	, PT.pt_job_dsc as JobDescription
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, sum(PT.PT_TIME_EARNINGS) as Earnings
from Productivity_Transaction PT
where  PT.PT_Time_Date >= '2/1/2014' 
	and PT.PT_Time_Date <=  '2/28/2014' 
	and PT_USED_DEPT_CODE >=3000
	and PT_USED_DEPT_CODE <=3800
Group By PT.pt_job_number, PT.pt_job_dsc


UNION ALL

select CAST('Grand Total' as varchar)
	, '' 
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, sum(PT.PT_TIME_EARNINGS) as Earnings
from Productivity_Transaction PT
where  PT.PT_Time_Date >= '2/1/2014' 
	and PT.PT_Time_Date <=  '2/28/2014' 
	and PT_USED_DEPT_CODE >=3000
	and PT_USED_DEPT_CODE <=3800

	
