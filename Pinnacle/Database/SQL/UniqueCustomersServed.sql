/**** - Aggregate - *****/
Select Funding_ID 
	, Count(Consumer) as '#ofConsumers'
	, Sum(Hours) as Hours
From (
Select Distinct 
	Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, Consumer.Funding_ID
	, Count(ReviewCost.Review_ID) as 'TimesVisited'
	, Sum(ReviewCost.Hours) as Hours
From ReviewCost
	Join Consumer on ReviewCost.Consumer_ID = Consumer.ID
Where ReviewCost.Date >= '2014-07-01'
	and ReviewCost.Date <= '2014-09-30'
	and Consumer.Created < '2013-11-26'
and rtrim(ReviewCost.Funding_ID) not in ('116','')
and Consumer_ID not in (460,461)
Group By Consumer.FirstName
	, Consumer.LastName
	, Consumer.Funding_ID
order by ReviewCost.Funding_ID, Consumer
	) 
where TimesVisited >1
Group by Funding_ID	 

/**** - Consumer Names - *****/
Select Distinct 
	Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, Consumer.Funding_ID
	, Count(ReviewCost.Review_ID) as '#0fTimes_Visited'
	, Sum(ReviewCost.Hours) as Hours
From ReviewCost
	Join Consumer on ReviewCost.Consumer_ID = Consumer.ID
Where ReviewCost.Date >= '2014-07-01'
	and ReviewCost.Date <= '2014-09-30'
	and Consumer.Created < '2013-11-26'
and rtrim(ReviewCost.Funding_ID) not in ('116','')
and Consumer_ID not in (460,461)
Group By Consumer.FirstName
	, Consumer.LastName
	, Consumer.Funding_ID
order by ReviewCost.Funding_ID, Consumer

/****** - Detailed - *****/
Select  Consumer.FirstName || ' ' || Consumer.LastName as Consumer
	, ReviewCost.Date
	, Case 
	  		When (strftime('%H', ReviewCost.TimeIn) - 12) = -12 Then  
	  			'12:' || strftime('%M', ReviewCost.TimeIn) ||' '|| 'am'
	  		When (strftime('%H', ReviewCost.TimeIn) - 12) = 0 Then 
	  			'12:' || strftime('%M', ReviewCost.TimeIn) ||' '|| 'pm'
	  		When (strftime('%H', ReviewCost.TimeIn) - 12) < 0 Then  
	  			strftime('%H',  ReviewCost.TimeIn) ||':'|| strftime('%M', ReviewCost.TimeIn) ||' '|| 'am'
	  		ELSE
	    		(cast(strftime('%H', ReviewCost.TimeIn) as integer) - 12) ||':'|| strftime('%M', ReviewCost.TimeIn) ||' '|| 'pm'
  		END as TimeIn
		, Case 
				When (strftime('%H', ReviewCost.TimeOut) - 12) = -12 Then  
					'12:' || strftime('%M', ReviewCost.TimeOut) ||' '|| 'am'
				When (strftime('%H', ReviewCost.TimeOut) - 12) = 0 Then 
					'12:' || strftime('%M', ReviewCost.TimeOut) ||' '|| 'pm'
				When (strftime('%H', ReviewCost.TimeOut) - 12) < 0 Then  
					strftime('%H',  ReviewCost.TimeOut) ||':'|| strftime('%M', ReviewCost.TimeOut) ||' '|| 'am'
				Else
				(cast(strftime('%H', ReviewCost.TimeOut) as integer) - 12) ||':'|| strftime('%M', ReviewCost.TimeOut) ||' '|| 'pm'
		END as TimeOut
		, round(round(((strftime('%s',ReviewCost.TimeOut) - strftime('%s',ReviewCost.TimeIn))/60),2)/60,2) as Hours
		, ReviewCost.Funding_ID
		, Staff.FirstName || ' ' || Staff.LastName as Staff 	
From ReviewCost
	Join Consumer on ReviewCost.Consumer_ID = Consumer.ID
	Join Staff on ReviewCost.Staff_ID = Staff.ID
Where ReviewCost.Date >= '2014-07-01'
	and ReviewCost.Date <= '2014-09-30'
	and Consumer.Created < '2013-11-26'
and rtrim(ReviewCost.Funding_ID) not in ('116','')
and Consumer_ID not in (460,461)
Order By Staff, ReviewCost.Funding_ID, Consumer, Date	