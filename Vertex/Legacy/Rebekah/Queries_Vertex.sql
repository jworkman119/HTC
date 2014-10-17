/* Earnings */
select  pt_emp_last_name || ', ' || pt_emp_first_name as employee
	 , pt_emp_number as EmplyeeNumber
	, pt_job_number as JobNumber
	, pt_job_dsc as JobDescription
	, PT_Job_Step_Number as Step
	, PT_Job_Step_Name as StepName
	, avg(pt_productivity) as Productivity
	, sum(pt_time_hours * 24) as Hours
	, sum(Pt_Time_Earnings) as Earnings 
	, sum(Pt_Time_Pieces) as Pieces
from productivity_transaction
where pt_time_date >= '9/16/2012'
	and pt_time_date <= '12/22/2012'
group by
	 pt_emp_last_name 
	, pt_emp_first_name 
	, pt_emp_number
	, pt_job_number
	, PT_Job_Step_Name
	, PT_Job_Step_Number
	, pt_job_dsc
				


/* Health & Welfare */
select pt_Emp_Number as EmployeeNumber
	 , substr(PT_Job_Number,1,1) as Job
	 , PT_Job_Number as JobNumber
	 , PT_Job_Step_Number as Step
	 , PT_Job_Step_Name as StepDescription
	, sum(pt_time_earnings) as Health_Welfare
from Productivity_Transaction
where PT_Time_Date >= '9/16/2012'
	and PT_Time_Date <= '12/22/2012'
	and pt_record_type_id in (1009, 1010, 1015, 1016)
group by
	 pt_Emp_Number
	, PT_Job_Number
	, PT_Job_Step_Number
	, PT_Job_Step_Name