select pp.payroll_program_name as Disability
	, pp.payroll_program_code as Disability_Code
	, PT.PT_Emp_Cost_Center_Code as CostCenter
	, PT.pt_job_number as Job
	, PT.pt_job_dsc as JobDescription
	, extract(month from pt.pt_Time_Date) as MonthWorked
	, extract(day from pt.pt_time_date) as DateWorked
	, extract(year from pt.pt_time_date) as yearworked
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
from employee
	join payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
	join T$Person person on person.person_id = employee.person_id
	join Productivity_Transaction pt on pt.pt_emp_number = Employee.emp_number
where PT.PT_Time_Date >= '12/1/2012'
	and PT.PT_Time_Date <=  '12/31/2012' 
	and PT.PT_Emp_Cost_Center_Code in (003100 
									, 003200
									, 003300 
									, 003000
									, 003400
									, 003500
								   )
Group by
	 pp.payroll_program_name 
	, pp.payroll_program_code
	, PT.PT_Emp_Cost_Center_Code
	, PT.pt_job_number 
	, PT.pt_job_dsc 	
	, pt.pt_Time_Date

