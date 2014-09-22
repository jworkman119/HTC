insert into insurance(id)
select distinct carrier
from datadump
where Datadump.Carrier not in ( Select id
							    From Insurance)