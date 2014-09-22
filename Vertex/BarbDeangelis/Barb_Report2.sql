select person.Last_Name || ', ' || person.First_Name  as Employee
	, employee.emp_number
	, pp.payroll_program_name as Disability
	, pp.payroll_program_code as Disability_Code
	, pt.pt_emp_cost_center_dsc
	, extract(month from pt.pt_Time_Date) as MonthWorked
	, extract(day from pt.pt_time_date) as DateWorked
	, extract(year from pt.pt_time_date) as yearworked
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
from employee
	, payroll_program PP
	,T$Person person
	, Productivity_Transaction PT
where PT.PT_Time_Date >= '1/1/2014'
	and PT.PT_Time_Date <=  '3/31/2014' 
	and PP.payroll_program_id = employee.emp_payroll_program_id
	and person.person_id = employee.person_id
	and pt.pt_emp_number = Employee.emp_number
Group by
	person.Last_Name 
	, person.First_Name  
	, employee.emp_number
	, pp.payroll_program_name 
	, pp.payroll_program_code 
	, pt.pt_emp_cost_center_dsc
	, pt.pt_Time_Date
order by display_name


	join payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
	join T$Person person on person.person_id = employee.person_id
	join Productivity_Transaction pt on pt.pt_emp_number = Employee.emp_number