select provider.last_name + ', ' + provider.first_name
from wdpm
	join provider on wdpm.provider_id = provider.id
where monthworked = 5 and year = 2010
order by last_name


















































