Select  pt_Emp_Number *1 as EmployeeNumber
	, PT_Job_Number as JobNumber
	, Sum(PT_time_earnings) as HealthWelfare
From INTERBASE_VERTEXREHABMANAGEMENT...productivity_transaction
Where PT_Time_Date >= @StartDay
	and PT_Time_Date <= @EndDay
	and pt_record_type_id in (1009, 1010, 1015, 1016)
Group By
	PT_Emp_Number
	, PT_Job_Number
	, pt_job_dsc