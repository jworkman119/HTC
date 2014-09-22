Create Trigger AddQuarter

on wdpm
After Insert, Update

as 

set wdpm.Quarter = Quarters.id
from Quarters
	join Wdpm on WDPM.monthworked >= Quarters.StartMonth
		and wdpm.monthworked <= Quarters.EndMonth
