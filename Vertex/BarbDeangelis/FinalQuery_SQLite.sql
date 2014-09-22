select  Employee
	, EmpNumber
	, Disability
	, CostCenter
	, Month
	, Year
	, round(sum(Hours),2) as Hours
	, round(sum(Units),2) as Units
	, sum(Third) as Third
	, sum(Half) as Half
	, sum(Full) as Full
from vwMonth_Units
group by
	Employee
	, EmpNumber
	, Disability
	, CostCenter
	, Month
	, Year
Order by Employee