Select PT.Pt_Job_Number as JobCode 
	, pp.payroll_program_name as Disability
	, 1 as DisabilityCount
	,  PT.pt_emp_number as Employee
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
from employee
	join payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
	join Productivity_Transaction pt on pt.pt_emp_number = Employee.emp_number
where PT.PT_Time_Date >= @StartDay
	and PT.PT_Time_Date <=  @EndDay 
	and PT.Pt_Job_Number <> ''
Group By
	PT.Pt_Job_Number
	, PT.pt_emp_number
	, pp.payroll_program_name 
	, pp.payroll_program_code
Order by JobCode 