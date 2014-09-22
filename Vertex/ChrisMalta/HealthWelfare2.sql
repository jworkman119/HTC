select  pt_Emp_Number *1 as EmployeeNumber
	,  pt_emp_last_name || ', ' || pt_emp_first_name as Person
	, Job.Job_ID
	, pt_job_number as JobNumber
	, sum(pt_time_hours * 24) as Hours
	, NishRate.Nish_Rate as NishRate
	, sum(pt_time_hours * 24) * NishRate.Nish_Rate as HealthWelfare
	, PT_Check_Date
from Productivity_Transaction pt
	, Job
	, Nish_Rate_Hist NishRate

where PT_Time_Date >= '2014-03-16'
	and PT_Time_Date <= '2014-04-12'
	and  pt.pt_job_number = job.job_number
	and Job.Job_ID = NishRate.Job_ID
	and Nish_Rate_Date || '|' || Job.Job_ID in (Select Max(Nish_Rate_Date)|| '|' || job_id
					  From NISH_RATE_HIST NishRate
					  where nish_rate_date <= '2014-04-12'
					  group by job_id
					  )
group by
	 PT_Emp_Number
	 , pt_emp_last_name
	 ,pt_emp_first_name
	 , Job.Job_ID
	 , pt_job_number
	 , NishRate.Nish_Rate
	 , pt_check_Date
Order by Person, PT_Time_Date