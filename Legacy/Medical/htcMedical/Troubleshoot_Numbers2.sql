select Provider.Last_Name + ', ' + Provider.First_Name
	, visit.Date
	, Time
	, Service.ID + ' - ' + Service.Description as Description
from visit
	jOin Provider on Visit.Provider_ID = Provider.ID
	join Service on visit.service_ID = Service.iD
where month(date) = 1
	and year(date) = 2011
	and Provider.Last_Name in ('Karwacki','Melnick','LaPolla','Johnson')
order by Visit.Date
	,provider.Last_Name


select [proc] 
	, count([proc]) as Numb
from DataDump
where [proc]
	not in (select id
			from Service)
group by [proc]


select id + ' - ' + Description as Service
	, units
from service