Select JobCode
	, sum(Employees) as Employees
	,sum(HoursWorked) as HoursWorked
	, sum(MentalHealth) as MentalHealth
	, sum(MentalRetardation) as MentalRetardation
	, sum(NonDisabled) as NonDisabled
	, sum(Other) as Other
from (select JobCode
	, count(Employee) as Employees
	, round(HoursWorked,2) as HoursWorked
	, Case 
		When Disability_Code = 1 then
			Count(Disability)
	  End as MentalHealth
	, Case 
		When Disability_Code = 2 then
			Count(Disability)
	  End as MentalRetardation
  	, Case 
		When Disability_Code = 3 then
			Count(Disability)
	  End as NonDisabled
	, Case 
		When Disability_Code = 4 then
			Count(Disability)
	  End as Other
from ContractBreakout
Group By JobCode
	, Disability) CB
Group By  JobCode
