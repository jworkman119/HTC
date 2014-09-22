select  question, count(question)
from form
  join question on form.id = question.form_id
where form.name in(
	'Apointment Form (standard)'
	, 'Appointment Sheet (screening)'
	, 'Discharge Summary Service Plan'
	,'Incident Report'
	,'Intake Form (client)'
	,'Opening Note'
	,'Patient Open, Close or Withdraw'
	,'Intake Information'
	,'Intake Information - Health Screen'
)
group by question
order by question
-----------------------------------
select Question.question
	, form.name
from form
	join question on form.id = question.form_id
----------------------------------------
update question
set 'Client Name' = 'Patient Name'
from question
where form_id in(
		select form.id
		from form
		where name in(
		'Apointment Form (standard)'
		, 'Appointment Sheet (screening)'
		, 'Discharge Summary Service Plan'
		,'Incident Report'
		,'Intake Form (client)'
		,'Opening Note'
		,'Patient Open, Close or Withdraw'
		,'Intake Information'
		,'Intake Information - Health Screen'
		)
)	
----------------------------------------------
update question
set question = 'SSN'
where form_id in ('25', '32', '37', '41', '42', '44', '47', '52', '53')
and question = 'Social Security Number'

---------------------------------------------
select form.id 
,question
,name
from question
join form on question.form_id = form.id
where question = 'City/State'

----------------------------------------------------
select distinct form_id
from question
order by form_id
