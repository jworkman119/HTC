select Provider.Last_Name + ', ' + Provider.First_Name as Provider 
	, MonthWorked
	, WDPM * 7.5 as HoursWorked
from provider
	Join wdpm on wdpm.Provider_id = Provider.id
where year = '2010'
	and Last_Name in ('Hudyncia','Karwacki', 'Bushan', 'Melnick','Omidian')

Union

select Provider.Last_Name + ', ' + Provider.First_Name as Provider
	, 13 as MonthWorked
	, sum(WDPM * 7.5) as HoursWorked
from provider
	Join wdpm on wdpm.Provider_id = Provider.id
where year = '2010'
	and Last_Name in ('Hudyncia','Karwacki', 'Bushan', 'Melnick','Omidian')
group by Provider.Last_Name
	, Provider.First_Name



