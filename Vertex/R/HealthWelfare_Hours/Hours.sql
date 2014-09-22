select pt_emp_number *1 as EmployeeNumber
	, Pt_Emp_Last_Name + ', ' + Pt_Emp_First_Name as Employee
	, Pt_Emp_Cost_Center_Dsc as CostCenter
	, pt_job_number as JobNumber
	, pt_job_dsc as JobDescription
	, avg(pt_productivity) as Productivity
	, sum(pt_time_hours * 24) as Hours
	, sum(Pt_Time_Earnings) as Earnings 
	, sum(Pt_Time_Pieces) as Pieces
	, Case pt_pay_code_name
		When 'Training' then
		'yes'
		else
		 ''
		 End  as TrainingWage
from INTERBASE_VERTEXREHABMANAGEMENT...productivity_transaction
where  pt_time_date >= @StartDay
	and pt_time_date <= @EndDay
group by
	 pt_emp_number
	, Pt_Emp_Last_Name
	, Pt_Emp_First_Name
	, PT_Emp_Cost_Center_Dsc
	, pt_job_number
	, pt_job_dsc 
	, pt_pay_code_name
Order by EmployeeNumber	
