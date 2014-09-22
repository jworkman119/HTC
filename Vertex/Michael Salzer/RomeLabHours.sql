select 	PT.pt_job_number as JobNumber
	, PT.pt_job_dsc as JobDescription
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, avg(PT.PT_JOB_STEP_WAGE_RATE) as WageRate
	, sum(PT.PT_TIME_EARNINGS) as Earnings
from Productivity_Transaction PT
where PT.pt_job_number in (130150)
and PT.pt_job_step_number = 3
and PT.PT_Time_Date >= '1/1/2012' 
and PT.PT_Time_Date <=  '12/31/2012' 
and PT.Pt_Time_Hours is not null
Group By PT.pt_job_number, PT.pt_job_dsc

/**** - Health Welfare - ****/
select pt_emp_last_name || ', ' || pt_emp_first_name as employee
	 , PT_Job_Number as JobNumber
	 , PT_Job_Step_Number as Step
	 , PT_Job_Step_Name as StepDescription
	, sum(pt_time_earnings) as Health_Welfare
from Productivity_Transaction
where PT_Time_Date >= '1/1/2012'
	and PT_Time_Date <= '12/31/2012'
	and PT_Job_Number  in (234280,234290,234190,130150)
	and pt_record_type_id in (1009, 1010, 1015, 1016)
group by
	  pt_emp_last_name 
	, pt_emp_first_name 
	, PT_Job_Number
	, PT_Job_Step_Number
	, PT_Job_Step_Name
Order by JobNumber,Step,Employee

select *
from PRODUCTIVITY_TRANSACTION
Where PT_Time_Date >= '1/1/2012'
	and PT_Time_Date <= '12/31/2012'
	and PT_Job_Number  in (234280,234290,234190,130150)
	and pt_record_type_id in (1009, 1010, 1015, 1016)

se


