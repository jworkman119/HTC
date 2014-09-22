select Provider.Last_Name + ', ' + Provider.First_Name as Provider
	, Visit.Service_ID
	, Count(Visit.Service_ID) as #Visits
from Provider
	join Visit on Provider.ID = Visit.Provider_ID
Where Last_name in ('Butler', 'Hudyncia', 'Johnson')
	and Visit.Date >= '1/1/2011'
	and Visit.Date <= '1/31/2011'
Group By Provider.Last_Name
	, Provider.First_Name
	, Visit.Service_ID
order by last_Name
	, Service_ID


select Provider.Last_Name + ', ' + Provider.First_Name as Provider
	, Count(Visit.Service_ID)
from Provider
	join Visit on Provider.ID = Visit.Provider_ID
Where Last_name in ('Butler', 'Hudyncia', 'Johnson')
	and Visit.Date >= '1/1/2011'
	and Visit.Date <= '1/31/2011'
Group By Provider.Last_Name
	, Provider.First_Name
order by last_Name
	

