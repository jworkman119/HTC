/***
Drop Procedure htcPersonHistory



Create Procedure htcPersonHistory

	@StartDay DateTime
	, @EndDay	DateTime

as
**/

	Declare @StartDate DateTime
	Declare @EndDate DateTime
	
	Set @StartDate = '12-1-2013'
	Set @EndDate = '1-31-2014'
	

select Status.PersonGuid
	, Status.LatestHireDate
	, Status.*
	, Case 
		When Fired.EndDate is not null then
			Fired.EndDate
		Else
			null
	  End as EndDate
	 , StatusReasonCode
	 , StatusCode
from  tPersonStatusHist as Status 
	Left Join (
				Select Status.PersonGuid 
					, Status.PersonStatusEndDate as EndDate
				From  tPersonStatusHist as Status
				Where 
				 (	 
					
					Status.PersonStatusEndDate >= @StartDate
				 )
				and Status.PersonStatusStartDate <= @EndDate
				and Status.PersonStatusCurrentFlag=0
	) as Fired on Status.PersonGuid = Fired.PersonGuid
Where 
	Status.PersonStatusEndDate is null
	and Status.PersonStatusStartDate <= @EndDate
	and Status.PersonStatusCurrentFlag=1
	and (StatusCode = 'ACT'
		or 
		Fired.EndDate >= @StartDate
		and Fired.EndDate <= @EndDate
		)



