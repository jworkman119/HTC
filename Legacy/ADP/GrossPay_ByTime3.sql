Select CompanyCode
	, Name
	, SSN
	, sum(Gross) as Gross
	, sum(Gross - OTEarnings) as Earnings
	, sum(RegHours + Hol_PTO) as Hours
	, Round(avg(round((Gross - OTEarnings)/(RegHours + Hol_PTO),2)),2) as HrRate
	, sum(RegHours + OTHours + Hol_PTO) as Hours_wOT
	, Round(avg(round(Gross/(RegHours + OTHours + Hol_PTO),2)),2) as HrRate_wOT
From (
		select CompanyCode
			, Name
			, SocialSecurity# as SSN
			, CheckViewPayDate as CheckDate
			, DistribGrossPaya as Gross
			, DistribRegHours as RegHours
			, DistribRegErning as RegEarnings
			, nvl(DistribOTHours,0) as OTHours
			, nvl(DistribOTEarning,0) as OtEarnings
			, sum(nvl(DistribHoursAmt,0)) as Hol_PTO
		from Reports.V_DIST_VW_HOURS
		Where 
			CheckViewPayDate > to_date('2013-01-01','yyyy-mm-dd')
			and distribgrosspaya is not null
		Group By 
			CompanyCode
			, Name
			, SocialSecurity# 
			, CheckViewPayDate
			, DistribGrossPaya
			, DistribRegHours
			, DistribRegErning 
			, DistribOTHours
			, DistribOTEarning
) Hours
Group By
	CompanyCode
	, Name
	, SSN
Order by Name
	

/* Getting disability from HRReport */
Select SocialSecurity# as SSN
	, First_Name as FirstName
	, Last_Name as LastName
	, Case 
		When Lower(Disabled_Comments) like 'mh%' then
			'Mental Health'
		When Lower(Disabled_Comments) = 'mr' then
			'Mental Retardation'
		Else
			'Other'
	 End as Disability
	 , Case 
		When Lower(Disabled_Comments) like 'mh%' then
			1
		When Lower(Disabled_Comments) = 'mr' then
			2
		Else
			4
	 End as DisabilityCode
From HRReport.v_PERS_BASIC
Where  SocialSecurity# is not null
and Disabled = -1
and Person_ID in
(
	select Person_ID
	from  HRReport.V_HR_PR_Join
	Where CO_C = '9L0'
)
Order by LastName