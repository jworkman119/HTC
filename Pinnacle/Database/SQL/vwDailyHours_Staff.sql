Select round(Administrative.Hours,2) as AdminHours
	, round(Reviews.Hours,2) as ReviewHours
	, round(Reviews.Hours + Administrative.Hours,2) as TotalHours
	, Reviews.Staff_ID
	, Reviews.Month
	, Reviews.Year
From (
	Select sum(round(((strftime('%s',Endtime) - strftime('%s',starttime))/60),2)/60) as hours 
	  , Staff.ID as Staff_ID
	  , strftime('%m/%d/%Y',Administrative.Date) as Date
	  , 'Administrative' as Type
	From Staff 
		Join Administrative on Administrative.Staff_ID = Staff.ID 
	Group By Staff.ID
		, Administrative.Date
) as Administrative
Join (
	Select sum(round(((strftime('%s',TimeOut) - strftime('%s',TimeIn))/60),2)/60) as hours 
	  	, Staff.ID as Staff_ID
		, strftime('%m/%d/%Y',Review.Date) as Date
		, 'Review' as Type
		From Staff 
		Join Review on Review.Staff_ID = Staff.ID 
	Group By Staff.ID
		, Review.Date
) as Reviews on Reviews.Staff_ID = Administrative.Staff_ID	

