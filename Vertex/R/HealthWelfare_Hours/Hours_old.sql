select pt_emp_number *1 as EmployeeNumber
	, pt_used_dept_name as Department
	, pt_job_number as JobNumber
	, pt_job_dsc as JobDescription
	, avg(pt_productivity) as Productivity
	, sum(pt_time_hours * 24) as Hours
	, sum(Pt_Time_Earnings) as Earnings 
	, sum(Pt_Time_Pieces) as Pieces
from productivity_transaction
where  pt_time_date >= @StartDay
	and pt_time_date <= @EndDay
group by
	 pt_emp_number
	, pt_used_dept_name
	, pt_job_number
	, pt_job_dsc
Order by Employee	
