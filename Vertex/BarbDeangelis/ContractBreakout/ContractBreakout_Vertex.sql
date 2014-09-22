Select PT.Pt_Job_Number as JobCode 
	,  PT.pt_emp_number as Employee
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, pp.payroll_program_name as Disability
	, pp.payroll_program_code as Disability_Code
from employee
	join payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
	join Productivity_Transaction pt on pt.pt_emp_number = Employee.emp_number
where PT.PT_Time_Date >= '12/23/2012'
	and PT.PT_Time_Date <=  '3/16/2013' 
	and PT.Pt_Job_Number <> ''
Group By
	PT.Pt_Job_Number
	, PT.pt_emp_number
	, pp.payroll_program_name 
	, pp.payroll_program_code 		
	
	
