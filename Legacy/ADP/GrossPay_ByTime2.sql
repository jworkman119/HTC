Select CompanyCode 	
	, distribpaidindept as Dept 
	, SocialSecurity# as SSN
	, Name
	, LastName
	, FirstName
	, CheckViewPayDate as PayDate
	, distribgrosspaya as Gross
	, Case
		When DistribOTHours is not null then
			distribreghours + DistribOTHours
		Else
			distribreghours	
	 End as TotalHours	
	, Case
		When DistribOTHours is not null then
			round(distribgrosspaya/(DistribOTHours + DistribRegHours),2)
		Else
			round(DistribRegErning/DistribRegHours,2)
	 End as HourlyRate
--	, DistribOTEarning as OtEarnings
--	, DistribOTHours as OTHours
--	, round(DistribOTEarning/DistribOTHours,2) as OTRate
from Reports.V_DIST_VW_EARNINGs
where checkviewyear#=2013
and CheckViewPayDate > to_date('2013-01-01','yyyy-mm-dd')
Order by LastName
