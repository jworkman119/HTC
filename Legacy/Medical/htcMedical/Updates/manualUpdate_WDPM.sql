select id, last_name + ', ' + first_name as physician
from provider
where last_name  in(
	'Butler'
	,'Fehlner'
	, 'Getman'
	, 'Herbst'
	, 'Johnson'
	, 'Kogut'
	, 'LaPolla'
	, 'Misiaszek' 
	, 'Olmstead'
	, 'Rhoades'
	, 'Veiz'
	, 'Volo' 
	, 'Voorhees'
	, 'Yero'
	, 'Bortiatynski'
	, 'Petty'
	, 'Phillips'
	, 'Powell'
	, 'Romano'
	, 'Veilleux')
order by last_name

insert into wdpm(MonthWorked,DateEntered,WDPM,Provider_id, year,quarter) 
values
