select Question
, count(question.question) as Total
, case 
	when form.name = 'Annual Health Screen Update' then
		count(question.question)
	End as 'Annual Health Screen Update'

, case 
	when form.name = 'Appointment - 1st Letter Notification' then
		count(question.question)
	End as 'Appointment - 1st Letter Notification'

, case 
	when form.name = 'Appointment (Referral)' then
		count(question.question)
	End as 'Appointment (Referral)'
, case 
	when form.name = 'Appointment (Referral)' then
		count(question.question)
	End as 'Appointment (Referral)'

, case 
	when form.name = 'Appointment - 1st Letter Notification' then
		count(question.question)
	End as 'Appointment - 1st Letter Notification'
, case 
	when form.name = 'Appointment Letter' then
		count(question.question)
	End as 'Appointment Letter'
, case 
	when form.name = 'Appointment Reschedule' then
		count(question.question)
	End as 'Appointment Reschedule'

, case 
	when form.name = 'Appointment Reschedule' then
		count(question.question)
	End as 'Appointment Reschedule'
, case 
	when form.name = 'Appointment Sheet (screening)' then
		count(question.question)
	End as 'Appointment Sheet (screening)'
, case 
	when form.name = 'Appointment form' then
		count(question.question)
	End as 'Appointment form'

, case 
	when form.name = 'Authorization for the Use or Disclosure of Protected Health Information' then
		count(question.question)
	End as 'Authorization for the Use or Disclosure of Protected Health Information'
, case 
	when form.name = 'Client Referral' then
		count(question.question)
	End as 'Client Referral'
, case 
	when form.name = 'Clinic Cash Form' then
		count(question.question)
	End as 'Clinic Cash Form'

, case 
	when form.name = 'Customer Satisfaction Survey' then
		count(question.question)
	End as 'Customer Satisfaction Survey'

, case 
	when form.name = 'Customer Satisfaction Survey' then
		count(question.question)
	End as 'Customer Satisfaction Survey'

, case 
	when form.name = 'Discharge Summary Service Plan' then
		count(question.question)
	End as 'Discharge Summary Service Plan'

, case 
	when form.name = 'Fax Transmittal Form' then
		count(question.question)
	End as 'Fax Transmittal Form'

, case 
	when form.name = 'Group Progress Notes' then
		count(question.question)
	End as 'Group Progress Notes'
, case 
	when form.name = 'HIPAA' then
		count(question.question)
	End as 'HIPAA'
, case 
	when form.name = 'Incident Report' then
		count(question.question)
	End as 'Incident Report'
, case 
	when form.name = 'Intake Form - Walk-In' then
		count(question.question)
	End as 'Intake Form - Walk-In'

, case 
	when form.name = 'Intake Information' then
		count(question.question)
	End as 'Intake Information'
, case 
	when form.name = 'Intake Information - Phone' then
		count(question.question)
	End as 'Intake Information - Phone'
, case 
	when form.name = 'Medication Request' then
		count(question.question)
	End as 'Medication Request'
, case 
	when form.name = 'Oneida County Department of Mental Health' then
		count(question.question)
	End as 'Oneida County Department of Mental Health'
, case 
	when form.name = 'Opening Note' then
		count(question.question)
	End as 'Opening Note'
, case 
	when form.name = 'Outside Information' then
		count(question.question)
	End as 'Outside Information'
, case 
	when form.name = 'Patient Open, Close or Withdraw' then
		count(question.question)
	End as 'Patient Open, Close or Withdraw'
, case 
	when form.name = 'Pre-Admission Screen' then
		count(question.question)
	End as 'Pre-Admission Screen'
, case 
	when form.name = 'Prescriber Order Sheet' then
		count(question.question)
	End as 'Prescriber Order Sheet'
, case 
	when form.name = 'Progress Note' then
		count(question.question)
	End as 'Progress Note'
, case 
	when form.name = 'Proof Of Income' then
		count(question.question)
	End as 'Proof Of Income'

, case 
	when form.name = 'Psychological Evaluation Form - Outside Agencies' then
		count(question.question)
	End as 'Psychological Evaluation Form - Outside Agencies'

, case 
	when form.name = 'Psychosocial Assessment' then
		count(question.question)
	End as 'Psychosocial Assessment'
, case 
	when form.name = 'Record Request - Cannot be processed' then
		count(question.question)
	End as 'Record Request - Cannot be processed'

, case 
	when form.name = 'Record Request Letter' then
		count(question.question)
	End as 'Record Request Letter'
, case 
	when form.name = 'Record Transfer' then
		count(question.question)
	End as 'Record Transfer'
, case 
	when form.name = 'Referral Form - Assisted Outpatient Treatment' then
		count(question.question)
	End as 'Referral Form - Assisted Outpatient Treatment'
, case 
	when form.name = 'Referral Form: Case Management and Residential Services' then
		count(question.question)
	End as 'Referral Form: Case Management and Residential Services'

, case 
	when form.name = 'Referral Form: Case Management and Residential Services - Risk Assessment' then
		count(question.question)
	End as 'Referral Form: Case Management and Residential Services - Risk Assessment'
, case 
	when form.name = 'Risk Assessment' then
		count(question.question)
	End as 'Risk Assessment'
, case 
	when form.name = 'Section 8 & LIDH - Application for Admission' then
		count(question.question)
	End as 'Section 8 & LIDH - Application for Admission'

, case 
	when form.name = 'Threshold Override Application (TOA)' then
		count(question.question)
	End as 'Threshold Override Application (TOA)'
, case 
	when form.name = 'Treatment Plan (outpatient)' then
		count(question.question)
	End as 'Treatment Plan (outpatient)'
, case 
	when form.name = 'Treatment Plan Review (outpatient)' then
		count(question.question)
	End as 'Treatment Plan Review (outpatient)'

, case 
	when form.name = 'VESID' then
		count(question.question)
	End as 'VESID'
, case 
	when form.name = 'Work Capacity Determination' then
		count(question.question)
	End as 'Work Capacity Determination'

from Question
	left join Form on Question.Form_ID = form.id
group by question.question
order by question.question


