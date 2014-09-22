/* drop view vwMonth_Units */

Create View vwMonth_Units

as

Select FirstQtr2014.*
    ,Case 
		When Hours>=5 then
			1
		When Hours< 5 and  Hours >=  3 then
			.5
		When Hours< 3 and  Hours >= .10 then
			.3
		else
			0
   end as Units
	, Case  
		When Hours< 3 and  Hours >= .10 then
			1
	end as Third
	, Case   
		When Hours< 5 and  Hours>=  3  then
			1
	end as Half
	, Case 
		When Hours >=5 then
			1
	end as Full
from FirstQtr2014
Order by Employee, Month, Date