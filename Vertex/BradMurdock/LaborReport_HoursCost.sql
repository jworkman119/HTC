select htcJob.JobCode 
	, htcJob.JobDSC 
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, sum(PT.PT_TIME_EARNINGS) as Earnings
	, HealthWelfare as HealthWelfare_Premium

from Productivity_Transaction PT
	join htcjobdsc_jobno htcJob on PT.pt_job_number = htcJob.JobCode
	left join htcHealthWelfare on htcJob.JobCode = htcHealthWelfare.JobCode
where PT.PT_Time_Date >= '4/1/2011'
	and PT.PT_Time_Date <=  '4/3/2011' 
	and PT.Pt_Time_Hours is not null
	and PT.PT_Emp_Cost_Center_Code in (003100 
									, 003200
									, 003300 
									, 003000
									, 003400
									, 003500
								   )
group by 
		htcJob.JobDSC
		, htcJob.JobCode
		, HealthWelfare



