/* Getting disability from HRReport */
Select SocialSecurity# as SSN
	, First_Name
	, Last_Name
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
	from  V_HR_PR_Join
	Where CO_C = '9L0'
)