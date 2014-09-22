/************* JobHours ****************/	

Select Employee
	, EmployeeNumber
	, JobNumber
	, JobDescription
	, max(Hours) as Hours
	, Productivity
From (
	select  Earnings.Employee
		, Earnings.EmployeeNumber
		, Earnings.JobNumber
		, Earnings.JobDescription
		, round(sum(Hours),2) as Hours
		, round(avg(Productivity),2) as Productivity
	from Earnings
	group by
		Earnings.Employee
		, Earnings.EmployeeNumber
		, Earnings.JobNumber
		, Earnings.JobDescription
	Order by Employee
) as TotalEarnings
Group By
 	Employee
	, EmployeeNumber


-- ************** - Health Welfare - No Step - *****************************

select  Earnings.Employee
	, Earnings.EmployeeNumber
	, Earnings.JobNumber
	, Earnings.JobDescription
	, Case Job
		When 1 then
			'Nish'
		When 2 then
			'NYSLD'
		Else
			'Commercial'
		End  as JobType
	, round(sum(Hours),2) as Hours
	, round(sum(Earnings),2) as Earnings
	, round(avg(Productivity),2) as Productivity
	, sum(Pieces) as Pieces
	, HealthWelfare
from Earnings
	Left Join HealthWelfare on Earnings.EmployeeNumber = HealthWelfare.EmployeeNumber
		and Earnings.JobNumber = HealthWelfare.JobNumber
		and Earnings.Step= HealthWelfare.Step
group by
	Earnings.Employee
	, Earnings.EmployeeNumber
	, Earnings.JobNumber
	, Earnings.JobDescription
Order by Employee
