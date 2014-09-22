/* Detailed Pinnacle Hours */
Select Review.Funding_ID
	, Date
	, Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, substr(Note, 0,100) as Description
	, TimeIn
	, TimeOut
	, round(round(((strftime('%s',Review.TimeOut) - strftime('%s',Review.TimeIn))/60),2)/60,2) as Hours
from Review
	Join Staff on Review.Staff_ID = Staff.ID
	Join Consumer on Review.Consumer_ID = Consumer.ID
where Date >= '2013-10-01'
and Date <= '2013-12-31'
and Staff.FirstName = 'Brandy'

UNION

Select 'ADM' as Funding_ID
	, Date
	, null as Consumer
	, substr(Description,0,100) as Description
	, StartTime
	, EndTime
	, round(round(((strftime('%s',Administrative.EndTime) - strftime('%s',Administrative.StartTime))/60),2)/60,2) as Hours
from Administrative
	Join Staff on Administrative.Staff_ID = Staff.ID
where Date >= '2013-10-01'
and Date <= '2013-12-31'
and Staff.FirstName = 'Brandy'
Order by Date

/* Detailed - Consumers with no Funding_ID */
Select Review.Funding_ID
	, Date
	, Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, substr(Note, 0,100) as Description
	, TimeIn
	, TimeOut
	, round(round(((strftime('%s',Review.TimeOut) - strftime('%s',Review.TimeIn))/60),2)/60,2) as Hours
from Review
	Join Staff on Review.Staff_ID = Staff.ID
	Join Consumer on Review.Consumer_ID = Consumer.ID
where Date >= '2013-10-01'
and Date <= '2013-12-31'
and Review.Funding_ID is null
and Staff.FirstName = 'Brandy'

/* SQL - for report */
Select ReportColumns.Name as Funding_ID
	, Staff.FirstName || ' ' || Staff.LastName as Staff 
	, Round(Avg(ReviewCost.PayRate),2) as Avg_PayRate 
	, Round(sum(ReviewCost.Hours),2) as Hours
	, Round(sum(ReviewCost.Cost),2) as Cost 
From ReportColumns, Staff 
	Left Join ReviewCost on ReviewCost.Funding_ID = ReportColumns.Name 
		AND strftime('%m',ReviewCost.Date) in ('12','11','10') 
		AND strftime('%Y',Date) ='2013' 
		AND ReviewCost.Staff_ID = Staff.ID 
WHERE Staff.Role_ID = 'Stf' and  Staff.Active = 'true' 
GROUP BY  ReportColumns.Name, ReportColumns.ID, Staff.ID
 Order By Staff, ReportColumns.Name