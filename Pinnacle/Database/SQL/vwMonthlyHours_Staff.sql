Create View MonthlyHours_Staff

as

Select round(Administrative.Hours,2) as AdminHours
	, round(Reviews.Hours,2) as ReviewHours
	, round(Reviews.Hours + Administrative.Hours,2) as TotalHours
	, Reviews.Staff_ID
	, Reviews.Month
	, Reviews.Year
From (Select sum(round(((strftime('%s',Endtime) - strftime('%s',starttime))/60),2)/60) as hours 
	  , Staff.ID as Staff_ID
	  , strftime('%m',Administrative.Date) as Month
	  , strftime('%Y',Administrative.Date) as Year
	  , 'Administrative' as Type
		From Staff 
			Join Administrative on Administrative.Staff_ID = Staff.ID 
	 Group By Staff.ID	
) as Administrative
Join (Select sum(round(((strftime('%s',TimeOut) - strftime('%s',TimeIn))/60),2)/60) as hours 
	  , Staff.ID as Staff_ID
	  , strftime('%m',Review.Date) as Month
	  , strftime('%Y',Review.Date) as Year
	  , 'Review' as Type
		From Staff 
			Join Review on Review.Staff_ID = Staff.ID 
	 Group By Staff.ID	
) as Reviews on Reviews.Staff_ID = Administrative.Staff_ID

