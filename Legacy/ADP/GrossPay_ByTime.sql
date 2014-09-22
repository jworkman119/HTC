
Select CompanyCode 	
	, distribpaidindept as Dept 
	, SocialSecurity# as SSN
	, Name
	, LastName
	, FirstName
	, CheckViewPayDate as PayDate
	,  distribreghours as Hours
	, distribgrosspaya as GrossPay
from Reports.V_DIST_VW_EARNINGs
where checkviewyear#=2013
and CheckViewPayDate > to_date('2013-01-01','yyyy-mm-dd')
Order by LastName




/* Getting disability from HRReport */
select SocialSecurity# as SSN
	, First_Name
	, Last_Name
	, Disabled
	, Disabled_Comments
from HRReport.v_PERS_BASIC
where Disabled_Comments is not null
and SocialSecurity# is not null
order by SSN, Last_Name


select *
from Reports.V_DIST_VW_EARNINGs

