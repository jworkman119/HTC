/*
Create View vwFinalOutput

as
*/

Create Temporary Table tempTB as 
select Question.Question as Question
	, count(Question.Question) as Total
	, min(form.SortOrder) as SortOrder
from Question
	Join Form on Form.ID = Question.Form_ID
Group By Question.Question



SELECT Form.Name 
	, vwSpreadSheet.Question
	, tempTB.Total
	,ifNULL(sum([Annual Health Screen Update]),'') as [Annual Health Screen Update]
	,ifNULL(sum([Appointment (Referral)]),'') as [Appointment (Referral)]
	,ifNULL(sum([Appointment - 1st Letter Notification]),'') as [Appointment - 1st Letter Notification]
	,ifNULL(sum([Appointment Letter]),'') as [Appointment Letter]
	,ifNULL(sum([Appointment Reschedule]),'') as [Appointment Reschedule]
	,ifNULL(sum([Appointment Sheet (screening)]),'') as [Appointment Sheet (screening)]
	,ifNULL(sum([Appointment form]),'') as [Appointment form]
	,ifNULL(sum([Authorization for the Use or Disclosure of Protected Health Information]),'') as [Authorization for the Use or Disclosure of Protected Health Information]
	,ifNULL(sum([Client Referral]),'') as [Client Referral]
	,ifNULL(sum([Clinic Cash Form]),'') as [Clinic Cash Form]
	,ifNULL(sum([Customer Satisfaction Survey]),'') as [Customer Satisfaction Survey]
	,ifNULL(sum([Discharge Summary Service Plan]),'') as [Discharge Summary Service Plan]
	,ifNULL(sum([Fax Transmittal Form]),'') as [Fax Transmittal Form]
	,ifNULL(sum([Group Progress Notes]),'') as [Group Progress Notes]
	,ifNULL(sum([HIPAA]),'') as [HIPAA]
	,ifNULL(sum([Incident Report]),'') as [Incident Report]
	,ifNULL(sum([Intake Form - Walk-In]),'') as [Intake Form - Walk-In]
	,ifNULL(sum([Intake Information]),'') as [Intake Information]
	,ifNULL(sum([Intake Information - Phone]),'') as [Intake Information - Phone]
	,ifNULL(sum([Medication Request]),'') as [Medication Request]
	,ifNULL(sum([Oneida County Department of Mental Health]),'') as [Oneida County Department of Mental Health]
	,ifNULL(sum([Opening Note]),'') as [Opening Note]
	,ifNULL(sum([Outside Information]),'') as [Outside Information]
	,ifNULL(sum([Patient Open, Close or Withdraw]),'') as [Patient Open, Close or Withdraw]
	,ifNULL(sum([Pre-Admission Screen]),'') as [Pre-Admission Screen]
	,ifNULL(sum([Prescriber Order Sheet]),'') as [Prescriber Order Sheet]
	,ifNULL(sum([Progress Note]),'') as [Progress Note]
	,ifNULL(sum([Proof Of Income]),'') as [Proof Of Income]
	,ifNULL(sum([Psychological Evaluation Form - Outside Agencies]),'') as [Psychological Evaluation Form - Outside Agencies]
	,ifNULL(sum([Psychosocial Assessment]),'') as [Psychosocial Assessment]
	,ifNULL(sum([Record Request - Cannot be processed]),'') as [Record Request - Cannot be processed]
	,ifNULL(sum([Record Request Letter]),'') as [Record Request Letter]
	,ifNULL(sum([Record Transfer]),'') as [Record Transfer]
	,ifNULL(sum([Referral Form - Assisted Outpatient Treatment]),'') as [Referral Form - Assisted Outpatient Treatment]
	,ifNULL(sum([Referral Form: Case Management and Residential Services]),'') as [Referral Form: Case Management and Residential Services]
	,ifNULL(sum([Referral Form: Case Management and Residential Services - Risk Assessment]),'') as [Referral Form: Case Management and Residential Services - Risk Assessment]
	,ifNULL(sum([Risk Assessment]),'') as [Risk Assessment]
	,ifNULL(sum([Section 8 & LIDH - Application for Admission]),'') as [Section 8 & LIDH - Application for Admission]
	,ifNULL(sum([Threshold Override Application (TOA)]),'') as [Threshold Override Application (TOA)]
	,ifNULL(sum([Treatment Plan (outpatient)]),'') as [Treatment Plan (outpatient)]
	,ifNULL(sum([Treatment Plan Review (outpatient)]),'') as [Treatment Plan Review (outpatient)]
	,ifNULL(sum([VESID]),'') as [VESID]
	,ifNULL(sum([Work Capacity Determination]),'') as [Work Capacity Determination]
FROM vwspreadsheet
	Join tempTB on vwSpreadSheet.Question = tempTB.Question
	Join Form on tempTB.SortOrder = Form.SortOrder
	Join Question on vwSpreadsheet.Question = Question.Question
	
GROUP BY vwSpreadSheet.question
Order by Form.Name, vwSpreadSheet.question

drop table tempTB