select  pt_emp_last_name || ', ' || pt_emp_first_name as employee
	 , pt_emp_number
	, pt_emp_cost_center_dsc as Department
	, pt_job_number as Job
	, pt_job_dsc as Job
	, sum(pt_time_earnings) as Earnings
	, sum(pt_time_hours * 24) as hours
from productivity_transaction
where pt_time_date >= '2/1/2011'
	and pt_time_date <= '2/28/2011'
group by
	 pt_emp_last_name 
	, pt_emp_first_name 
	, pt_emp_number
	, pt_emp_cost_center_dsc
	, pt_job_number
	, pt_job_dsc



