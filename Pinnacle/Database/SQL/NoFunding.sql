select Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, Date
	, round(round(((strftime('%s',Review.TimeOut) - strftime('%s',Review.TimeIn))/60),2)/60,2) as Hours
	, Review.ID
	, Review.Funding_ID
from Review
	Join Staff on Review.Staff_ID = Staff.ID
	Join Consumer on Review.Consumer_ID = Consumer.ID
where Staff.FirstName = 'Teresa' 
and Date > '2014-07-01'
and Date < '2014-09-30'
and Review.Funding_ID is null
Order by Date



