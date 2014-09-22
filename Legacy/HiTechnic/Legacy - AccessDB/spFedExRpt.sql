select *
from dailyfinal2
where ts >= date()
	and PickedFullIndicator = true
order by ts desc

