
select PT.Pt_Emp_Number  as Employee_No
	, Pt_Emp_Last_Name || ', ' || Pt_Emp_First_Name  as Employee
	, PT.PT_EMP_COST_CENTER_DSC as Department
	, PT.pt_job_number as JobNumber
	, PT.pt_job_dsc as JobDescription
	, PT.PT_Job_Step_Number as StepNumber
	, PT.PT_Job_Step_Name as StepName
	, PT.PT_Time_Date as DateWorked
	, PT.Pt_Time_Hours * 24 as HoursWorked
	, PT.PT_JOB_STEP_WAGE_RATE as WageRate
	, PT.PT_TIME_EARNINGS as Earnings
from Productivity_Transaction PT
where PT.PT_Time_Date >= '1/1/2012' 
	and PT.PT_Time_Date <=  '1/31/2012' 
	and PT.Pt_Time_Hours is not null
	and PT.PT_Emp_Cost_Center_Code in (003100 
									, 003200
									, 003300 
									, 003000
									, 003400
									, 003500
								   )

order by Pt_Emp_Last_Name, PT.PT_Time_Date

