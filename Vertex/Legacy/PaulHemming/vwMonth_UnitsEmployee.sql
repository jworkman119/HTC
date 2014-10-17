Create View vwMonth_UnitsEmployee

as

Select MonthlyHoursEmployee.*
    ,Case 
		When Hoursworked>=5 then
			1
		When Hoursworked< 5 and  Hoursworked >=  3 then
			.5
		When Hoursworked< 3 and  Hoursworked >= .10 then
			.3
		else
			0
   end as Units
	, Case  
		When Hoursworked< 3 and  Hoursworked >= .10 then
			1
	end as Third
	, Case   
		When Hoursworked< 5 and  Hoursworked >=  3  then
			1
	end as Half
	, Case 
		When Hoursworked >=5 then
			1
	end as Full
from MonthlyHoursEmployee
Order by Employee, MonthWorked, DateWorked