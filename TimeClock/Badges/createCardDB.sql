Select Person.ID as ID 
	, concat(FirstName, ' ' , LastName) as Person
	, concat('x:\\State Fair Images\\2014\\',FirstName, '_' , LastName, '.jpg') as PicPath
	, Case
		When Person.Driver = 0 then
			''
	  	else
	   		'Driver'
	  End  as Driver
from Person