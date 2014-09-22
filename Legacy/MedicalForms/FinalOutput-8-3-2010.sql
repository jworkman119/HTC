select vwSpreadSheet.Question
	, Form.Name
	, coalesce([Annual Health Screen Update],'') as [Annual Health Screen Update]
, coalesce([Appointment (Referral)],'') as [Appointment (Referral)]
, coalesce([Appointment - 1st Letter Notification],'') as [Appointment - 1st Letter Notification]
, coalesce([Appointment Letter],'') as [Appointment Letter]
, coalesce([Appointment Reschedule],'') as [Appointment Reschedule]
, coalesce([Appointment Sheet (screening)],'') as [Appointment Sheet (screening)]
, coalesce([Appointment form],'') as [Appointment form]
, coalesce([Authorization for the Use or Disclosure of Protected Health Information],'') as [Authorization for the Use or Disclosure of Protected Health Information]
, coalesce([Client Referral],'') as [Client Referral]
, coalesce([Clinic Cash Form],'') as [Clinic Cash Form]
, coalesce([Customer Satisfaction Survey],'') as [Customer Satisfaction Survey]
, coalesce([Discharge Summary Service Plan],'') as [Discharge Summary Service Plan]
, coalesce([Fax Transmittal Form],'') as [Fax Transmittal Form]
, coalesce([Group Progress Notes],'')  as [Group Progress Notes]
, coalesce([HIPAA],'') as [HIPAA]
, coalesce([Incident Report],'') as [Incident Report]
, coalesce([Intake Form - Walk-In],'') as [Intake Form - Walk-In]
, coalesce([Intake Information],'') as [Intake Information]
, coalesce([Intake Information - Phone],'') as [Intake Information - Phone]
, coalesce([Medication Request],'') as [Medication Request]
, coalesce([Oneida County Department of Mental Health],'') as [Oneida County Department of Mental Health]
, coalesce([Opening Note],'') as [Opening Note]
, coalesce([Outside Information],'') as [Outside Information]
, coalesce([Patient Open, Close or Withdraw],'') as [Patient Open, Close or Withdraw]
, coalesce([Pre-Admission Screen],'') as [Pre-Admission Screen]
, coalesce([Prescriber Order Sheet],'') as [Prescriber Order Sheet]
, coalesce([Progress Note],'') as [Progress Note]
, coalesce([Proof Of Income],'') as [Proof Of Income]
, coalesce([Psychological Evaluation Form - Outside Agencies],'') as [Psychological Evaluation Form - Outside Agencies]
, coalesce([Psychosocial Assessment],'') as [Psychosocial Assessment]
, coalesce([Record Request - Cannot be processed],'') as [Record Request - Cannot be processed]
, coalesce([Record Request Letter],'') as [Record Request Letter]
, coalesce([Record Transfer],'') as [Record Transfer]
, coalesce([Referral Form - Assisted Outpatient Treatment],'') as [Referral Form - Assisted Outpatient Treatment]
, coalesce([Referral Form: Case Management and Residential Services],'') [Referral Form: Case Management and Residential Services]
, coalesce([Referral Form: Case Management and Residential Services - Risk Assessment],'') as [Referral Form: Case Management and Residential Services - Risk Assessment]
, coalesce([Risk Assessment],'') as [Risk Assessment]
, coalesce([Section 8 & LIDH - Application for Admission],'') as [Section 8 & LIDH - Application for Admission]
, coalesce([Threshold Override Application (TOA)],'') as [Threshold Override Application (TOA)]
, coalesce([Treatment Plan (outpatient)],'') as [Treatment Plan (outpatient)]
, coalesce([Treatment Plan Review (outpatient)],'') as [Treatment Plan Review (outpatient)]
, coalesce([VESID],'') as [VESID]
, coalesce([Work Capacity Determination],'') as [Work Capacity Determination]
from vwSpreadSheet
	join Question on vwSpreadsheet.Question = Question.Question
	join Form on Question.Form_ID = form.ID
Group by vwSpreadSheet.Question
	, Form.Name
Order by Form.Name, vwSpreadsheet.Question


