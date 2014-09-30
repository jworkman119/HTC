Select 
	Case Role_ID
		When 'jan' then
			'Janitor'
		Else
			'Supervisor'
	End as Job
	,Count(Person_ID) as TotalWorkers
	,Sum(Disabled) as Disabled
	, Round(Sum(Disabled)/Count(Person_ID)*100,2) as Percent_Disabled
	,Sum(NonDisabled) as NonDisabled 
	, Round(Sum(NonDisabled)/Count(Person_ID)*100,2) as Percent_NonDisabled
	, Sum(TotalHours) as TotalHours
	, Sum(NonLaborDay) as NonLaborDay_Hours
	, Case Role_ID
		When 'jan' then
			Round(Sum(NonLaborDay)* 13.38,2)
		Else
			Round(Sum(NonLaborDay)* 14.00,2)
		End
	  as Wages_NonLaborDay
	, Sum(LaborDay) as LaborDay_Hours
	,  Round(Sum(LaborDay) * 23.58,2) as Wages_LaborDay
	, Case Role_ID
		When 'jan' then
			Round(Sum(NonLaborDay)* 13.38,2) + Round(Sum(LaborDay) * 23.58,2)
		Else
			Round(Sum(NonLaborDay)* 14.00,2) + Round(Sum(LaborDay) * 23.58,2)
		End
	  as TotalWages	
From tempTotalHours
Group By Role_ID

Union

Select 
	 'Totals' as Job
	,Count(Person_ID) as TotalWorkers
	,Sum(Disabled) as Disabled
	, Round(Sum(Disabled)/Count(Person_ID)*100,2) as Percent_Disabled
	,Sum(NonDisabled) as NonDisabled 
	, Round(Sum(NonDisabled)/Count(Person_ID)*100,2) as Percent_NonDisabled
	, Sum(TotalHours) as TotalHours
	, Sum(NonLaborDay) as NonLaborDay_Hours
	, '' as Wages_NonLaborDay
	, Sum(LaborDay) as LaborDay_Hours
	, '' as Wages_LaborDay
	, ''  as TotalWages	
From tempTotalHours








