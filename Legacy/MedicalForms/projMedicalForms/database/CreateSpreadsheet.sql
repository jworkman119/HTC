select Question
	, sum(Total)
	,ifNULL([Annual Health Screen Update],'') as [Annual Health Screen Update]


	,ifNULL([Appointment (Referral)],'') as [Appointment (Referral)]
	,ifNULL([Appointment (Referral):1],'') as [Appointment (Referral):1]
	,ifNULL([Appointment - 1st Letter Notification],'') as [Appointment - 1st Letter Notification]
	,ifNULL([Appointment - 1st Letter Notification:1],'') as [Appointment - 1st Letter Notification:1]
	,ifNULL([Appointment Letter],'') as [Appointment Letter]
	,ifNULL([Appointment Reschedule],'') as [Appointment Reschedule]
	,ifNULL([Appointment Reschedule:1],'') as [Appointment Reschedule:1]
	,ifNULL([Appointment Sheet (screening)],'') as [Appointment Sheet (screening)]
	,ifNULL([Appointment form],'') as [Appointment form]
	,ifNULL([Authorization for the Use or Disclosure of Protected Health Information],'') as [Authorization for the Use or Disclosure of Protected Health Information]
	,ifNULL([Client Referral],'') as [Client Referral]
	,ifNULL([Clinic Cash Form],'') as [Clinic Cash Form]
	,ifNULL([Customer Satisfaction Survey],'') as [Customer Satisfaction Survey]
	,ifNULL([Customer Satisfaction Survey:1],'') as [Customer Satisfaction Survey:1]
	,ifNULL([Discharge Summary Service Plan],'') as [Discharge Summary Service Plan]
	,ifNULL([Fax Transmittal Form],'') as [Fax Transmittal Form]
	,ifNULL([Group Progress Notes],'') as [Group Progress Notes]
	,ifNULL([HIPAA],'') as [HIPAA]
	,ifNULL([Incident Report],'') as [Incident Report]
	,ifNULL([Intake Form - Walk-In],'') as [Intake Form - Walk-In]
	,ifNULL([Intake Information],'') as [Intake Information]
	,ifNULL([Intake Information - Phone],'') as [Intake Information - Phone]
	,ifNULL([Medication Request],'') as [Medication Request]
	,ifNULL([Oneida County Department of Mental Health],'') as [Oneida County Department of Mental Health]
	,ifNULL([Opening Note],'') as [Opening Note]
	,ifNULL([Outside Information],'') as [Outside Information]
	,ifNULL([Patient Open, Close or Withdraw],'') as [Patient Open, Close or Withdraw]
	,ifNULL([Pre-Admission Screen],'') as [Pre-Admission Screen]
	,ifNULL([Prescriber Order Sheet],'') as [Prescriber Order Sheet]
	,ifNULL([Progress Note],'') as [Progress Note]
	,ifNULL([Proof Of Income],'') as [Proof Of Income]
	,ifNULL([Psychological Evaluation Form - Outside Agencies],'') as [Psychological Evaluation Form - Outside Agencies]
	,ifNULL([Psychosocial Assessment],'') as [Psychosocial Assessment]
	,ifNULL([Record Request - Cannot be processed],'') as [Record Request - Cannot be processed]
	,ifNULL([Record Request Letter],'') as [Record Request Letter]
	,ifNULL([Record Transfer],'') as [Record Transfer]
	,ifNULL([Referral Form - Assisted Outpatient Treatment],'') as [Referral Form - Assisted Outpatient Treatment]
	,ifNULL([Referral Form: Case Management and Residential Services],'') as [Referral Form: Case Management and Residential Services]
	,ifNULL([Referral Form: Case Management and Residential Services - Risk Assessment],'') as [Referral Form: Case Management and Residential Services - Risk Assessment]
	,ifNULL([Risk Assessment],'') as [Risk Assessment]
	,ifNULL([Section 8 & LIDH - Application for Admission],'') as [Section 8 & LIDH - Application for Admission]
	,ifNULL([Threshold Override Application (TOA)],'') as [Threshold Override Application (TOA)]
	,ifNULL([Treatment Plan (outpatient)],'') as [Treatment Plan (outpatient)]
	,ifNULL([Treatment Plan Review (outpatient)],'') as [Treatment Plan Review (outpatient)]
	,ifNULL([VESID],'') as [VESID]
	,ifNULL([Work Capacity Determination],'') as [Work Capacity Determination]

from vwspreadsheet
Group by question


select question
	, sum(Total) as Total
	 , sum([Referral Form: Case Management and Residential Services])
	, sum([Oneida County Department of Mental Health])
from vwSpreadsheet
group by question