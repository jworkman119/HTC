select 
	Case Disabled
		When False Then
			'Non-Disabled'
		Else
			'Disabled'
	End as Disabled
	, count(Janitors.ID) as Janitors
	, sum(JanHours.TotalHours) as Janitor_Hours
from vwTotalHours as JanHours
	Join Person as Janitors on JanHours.Person_ID = Janitors.ID
Where TotalHours>0
	and Janitors.Role_ID = 'jan'
Group by Disabled 

