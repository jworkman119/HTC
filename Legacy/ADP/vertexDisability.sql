select person.SSN 
	, person.First_Name as FirstName
	, person.Last_Name as LastName
	, pp.payroll_program_name as Disability
	, pp.payroll_program_code as Disability_Code
from employee
	join payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
	join T$Person person on person.person_id = employee.person_id
Order by Last_Name