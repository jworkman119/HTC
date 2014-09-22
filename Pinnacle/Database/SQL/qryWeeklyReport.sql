Select ReportColumns.Name
	, ReportColumns.ID as Column
	, Staff.FirstName || ' ' || Staff.LastName as Staff
	, Avg(ReviewCost.PayRate) as Avg_PayRate 
	, sum(ReviewCost.Hours) as Hours 
	, sum(ReviewCost.Cost) as Cost  
From ReportColumns, Staff
	Left Join ReviewCost on ReviewCost.Funding_ID = ReportColumns.Name 
		and ReviewCost.Date >= '2013-05-20'
		and ReviewCost.Date <= '2013-05-24'
		and ReviewCost.Staff_ID = Staff.ID 	
Where Staff.Active = 'true'
	and Staff.Role_ID = 'Stf'
Group By 
	ReportColumns.Name
	, ReportColumns.ID	
	, Staff.ID	
Order by Staff	


select *
from Pay