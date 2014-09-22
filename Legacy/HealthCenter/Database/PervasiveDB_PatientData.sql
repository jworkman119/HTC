Select PAT_FIRST_NAME  as FirstName
	, PAT_LAST_NAME as LastName
	, PAT_CHART_NUMBER as ID
	, PAT_DATE_OF_BIRTH as DOB
	, PowerFile.PF_Field_07 AS tpDate 
	, PAT_ATTENDING as Resource_ID
from Patient
	Inner Join PowerFile on Patient.PAT_UNIQUE_ID = PowerFile.PF_PAT_UNIQUE_ID
Where LENGTH(PF_FIELD_07)>0
Order by PAT_LAST_NAME

