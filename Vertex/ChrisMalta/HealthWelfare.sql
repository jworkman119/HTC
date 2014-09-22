/***** Health Welfare ****/
select  pt_Emp_Number *1 as EmployeeNumber
	,  pt_emp_last_name || ', ' || pt_emp_first_name as Person
	, sum(PT_time_earnings) as HealthWelfare
from Productivity_Transaction
where PT_Time_Date >= '2014-03-16'
	and PT_Time_Date <= '2014-03-29'
	and pt_record_type_id in (1009, 1010, 1015, 1016)
group by
	 PT_Emp_Number
	 , pt_emp_last_name
	 ,pt_emp_first_name

/**** Employee Hours ****/	
select  pt_Emp_Number *1 as EmployeeNumber
	,  pt_emp_last_name || ', ' || pt_emp_first_name as Person
	, sum(pt_time_hours * 24) as Hours
from Productivity_Transaction
where PT_Time_Date >= '2014-03-16'
	and PT_Time_Date <= '2014-03-29'
group by
	 PT_Emp_Number
	 , pt_emp_last_name
	 ,pt_emp_first_name
Order by Person	
