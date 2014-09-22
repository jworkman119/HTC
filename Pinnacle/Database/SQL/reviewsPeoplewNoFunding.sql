select Review.Date
	, Consumer.FirstName || ' ' || Consumer.LastName as Consumer 
	, Note
	, TimeIn
	, TimeOut
	, round(round(((strftime('%s',Review.TimeOut) - strftime('%s',Review.TimeIn))/60),2)/60,2) as Hours 
from Review
	Join Consumer on Review.Consumer_ID = Consumer.ID
	Join Staff on Review.Staff_ID = Staff.ID
where Consumer.Funding_ID is null
and Review.Date >= '2014-01-01'
and Review.Date <= '2014-04-01'
and Staff.FirstName || ' ' || Staff.LastName = 'Teresa Cucchiara'
Order by Date