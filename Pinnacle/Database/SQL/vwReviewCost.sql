/*
	drop view ReviewCost

*/

Create View ReviewCost

as

Select Pay.Staff_ID
	, Review.ID as Review_ID
	, '' as Administrative_ID
	, Review.Consumer_ID
	, Review.Date
	, Pay.Rate as PayRate
	, TimeIn
	, TimeOut
	, round(round(((strftime('%s',Review.TimeOut) - strftime('%s',Review.TimeIn))/60),2)/60,2) as Hours
	, round((round(((strftime('%s',Review.TimeOut) - strftime('%s',Review.TimeIn))/60),2)/60) * Max(Pay.Rate),2) as Cost
	, Case
		When Review.Funding_ID = 'OMH' and Review.Job_ID is null  and Review.Date <= '2013-07-01' then
			'OMH - ACE'
		When Review.Funding_ID = 'OMH' then	
			'OMH - OISE'
		else 
			Review.Funding_ID
	 End as Funding_ID
from Review
	Join Pay on Review.Staff_ID = Pay.Staff_ID
		and  Review.Date >= Pay.Date
	Left Join Job on Review.Consumer_ID = Job.Consumer_ID
		and (
				(Review.Date <= Job.EndDate	and Review.Date >= Job.PlacementDate)
					or 
				(Job.EndDate is null and Review.Date >= Job.PlacementDate)
			)
Where (
		(Review.Date >= Pay.Date and Review.Date <= Pay.EndDate)
			or 
		(Review.Date >= Pay.Date and Pay.EndDate is null)
	)
Group By
	Review.ID
	
UNION

Select Administrative.Staff_ID
	, '' as Review_ID
	, Administrative.ID as Admin_ID
	, null as Consumer_ID
	, Administrative.Date
	, Pay.Rate as PayRate
	, Administrative.StartTime as TimeIn
	, Administrative.EndTime
	, round(((strftime('%s',Administrative.EndTime) - strftime('%s',Administrative.StartTime))/60),2)/60 as Hours
	, (round(((strftime('%s',Administrative.EndTime) - strftime('%s',Administrative.StartTime))/60),2)/60) * Max(Pay.Rate) as Cost
	, 'ADM' as Funding_ID
from Administrative
	Join Pay on Administrative.Staff_ID = Pay.Staff_ID
Where Administrative.Date >= Pay.Date
Group By Administrative.ID
Order by Review.Date desc	
						
