select PT.pt_job_number as JobNumber
	, PT.pt_job_dsc as JobDescription
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, avg(PT.PT_JOB_STEP_WAGE_RATE) as WageRate
	, sum(PT.PT_TIME_EARNINGS) as Earnings
	, PT_PAY_CODE_NAME as PayCode
from Productivity_Transaction PT
where  PT.PT_Time_Date >= '11/1/2013' 
	and PT.PT_Time_Date <=  '12/31/2013' 
	and PT.Pt_Time_Hours is not null
	and PT_PAY_CODE in ('PT','HO','BV')
	and PT_USED_DEPT_CODE >=3000
	and PT_USED_DEPT_CODE <=3800
	and PT_JOB_STEP_NAME not like 'HTC%'
Group By PT.pt_job_number, PT.pt_job_dsc, PT_PAY_CODE_NAME
