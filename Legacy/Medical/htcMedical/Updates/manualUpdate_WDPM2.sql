select Provider.Id, Last_Name + ', ' + First_Name
		  from Provider
Where /* first_name = 'pamela'
and */ Last_Name = 'Bortiatynski'


Insert Into WDPM(Provider_ID, WDPM, MonthWorked, [Year])
Values (1009,18, 10,2010)


select *
from wdpm


select Last_Name + ', ' + First_Name as Provider
	, wdpm
from WDPM
	Join Provider on WDPM.Provider_ID = Provider.ID
	
where monthworked = 10
	and year = 2010
order by dateentered

select *
from visit
order by date desc

