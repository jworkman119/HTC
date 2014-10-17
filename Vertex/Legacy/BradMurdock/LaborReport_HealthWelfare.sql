Create view htcHealthWelfare(JobDSC,JobCode,HealthWelfare,YearWorked,Range)

AS

select JobDSC
	, JobCode
	, sum(HW.PT_TIME_EARNINGS) as HealthWelfare
	, 2011 as YearWorked
	, '2nd Qtr' as Range
from Productivity_Transaction HW
	join htcjobdsc_jobno htcJob on HW.pt_job_number = htcJob.JobCode
Where HW.PT_Time_Date >= '1/1/2012'
	and HW.PT_Time_Date <=  '6/30/2012' 
	and HW.Pt_Time_Hours is null
	and HW.PT_Emp_Cost_Center_Code in (
		003100 
		, 003200
		, 003300 
		, 003000
		, 003400
		, 003500
	)
	Group By JobDSC, JobCode




Create view htcHealthWelfare(JobDSC,JobCode,HealthWelfare,YearWorked,Range)

AS

select JobDSC
	, JobCode
	, sum(HW.PT_TIME_EARNINGS) as HealthWelfare
	, 2010 as YearWorked
	, 'YTD' as Range
from Productivity_Transaction HW
	join htcjobdsc_jobno htcJob on HW.pt_job_number = htcJob.JobCode
Where HW.PT_Time_Date >= '1/1/2012'
	and HW.PT_Time_Date <=  '6/30/2012' 
	and HW.Pt_Time_Hours is null
	and HW.PT_Emp_Cost_Center_Code in (
		003100 
		, 003200
		, 003300 
		, 003000
		, 003400
		, 003500
	)
	Group By JobDSC, JobCode