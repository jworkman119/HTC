Select Employee_No
	, Employee
	, Department
	, strftime('%m', DateWorked) as Month
	, JobNumber
	, JobDescription
	, round(sum(HoursWorked),2) as  Hours
	, round(avg(WageRate),2) as AvgWage
	, round(sum(Earnings),2) as Earnings
from y2011
	Group By 
		Employee_No
		, Employee
		, Department
		, JobNumber
		, JobDescription
		, Month
Order by 
	Employee
	, DateWorked