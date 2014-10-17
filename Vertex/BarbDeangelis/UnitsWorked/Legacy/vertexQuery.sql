select 
	Pers.Last_Name + ', ' + Pers.First_Name  as Employee
	, Employee.emp_number * 1 as EmpNumber
	, pp.payroll_program_name as Disability
	, pp.payroll_program_code as DisabilityCode
	
	, pt.pt_emp_cost_center_dsc as CostCenter
	, month(pt.pt_Time_Date) as Month
	, day(pt.pt_time_date) as Date
	, year(pt.pt_time_date) as Year
	, Round(sum(PT.Pt_Time_Hours * 24),1) as Hours
from INTERBASE_VERTEXREHABMANAGEMENT...employee
	join INTERBASE_VERTEXREHABMANAGEMENT...payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
	join INTERBASE_VERTEXREHABMANAGEMENT...Productivity_Transaction pt on pt.pt_emp_number = Employee.emp_number
	join INTERBASE_VERTEXREHABMANAGEMENT...T$Person Pers on (Employee.emp_number * 1) = Pers.Person_ID
where PT.PT_Time_Date >= '6/1/2014'
	and PT.PT_Time_Date <=  '9/30/2014' 
	and PP.payroll_program_id = employee.emp_payroll_program_id

Group by
	Pers.Last_Name 
	, Pers.First_Name  
	, Employee.emp_number
	, pp.payroll_program_name 
	, pp.payroll_program_code 
	, pt.pt_emp_cost_center_dsc
	, pt.pt_Time_Date
order by Employee


