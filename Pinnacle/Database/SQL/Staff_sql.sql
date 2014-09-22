select Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, Job.Title as Job
	, Job.Employer
	, max(Review.Date) as [Last Review]
	, Meeting.Description 
from Consumer
	Join Staff on Consumer.Staff_ID = Staff.ID
	Left Join Review on Consumer.ID = Review.Consumer_ID
	Left Join Job on Review.Job_ID = Job.ID
	Left Join Meeting on Review.Meeting_ID = Meeting.ID
Where consumer.Staff_ID = 6
group by 
	Consumer
	, Job.Title
	, Job.Employer




select Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, Job.Title
	, Job.Employer
	, Review.Date
	, Review.DesiredOutcome
	, Review.Barriers
	, Review.Note
from Consumer
	Join Staff on Consumer.Staff_ID = Staff.ID
	Left Join Review on Consumer.ID = Review.Consumer_ID
	Left Join Job on Review.Job_ID = Job.ID
Where consumer.Staff_ID = 6





