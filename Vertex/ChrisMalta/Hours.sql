select pt_emp_number *1 as EmployeeNumber
	, Pt_Emp_Last_Name || ', ' || Pt_Emp_First_Name as Employee
	, sum(pt_time_hours * 24) as Hours
	, PT_Check_Date
from productivity_transaction
where  pt_time_date >= '2014-03-16'
	and pt_time_date <= '2014-04-12'
group by
	 pt_emp_number
	, Pt_Emp_Last_Name
	, Pt_Emp_First_Name
	, PT_Check_Date
Order by Employee	

