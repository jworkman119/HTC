select	HW.pt_job_number as JobNumber
	, HW.pt_job_dsc as JobDescription
	, sum(HW.PT_TIME_EARNINGS) as HealthWelfare_Premium
from Productivity_Transaction HW
where	HW.Pt_Time_Hours is null
		and HW.PT_Time_Date >= '1/1/2012'
		and HW.PT_Time_Date <=  '6/30/2012' 
		and HW.Pt_Time_Hours is null
		and HW.PT_Emp_Cost_Center_Code in (
											003100 
											, 003200
											, 003300 
											, 003000
											, 003400
											, 003500
											, 003700
)	
group by
	HW.pt_job_number 
	, HW.pt_job_dsc


***************************************************



select  PT.pt_job_number as JobNumber
	, PT.pt_job_dsc as JobDsc
	, sum(PT.Pt_Time_Hours * 24) as HoursWorked
	, sum(PT.PT_TIME_EARNINGS) as Earnings
from Productivity_Transaction PT
where PT.PT_Time_Date >= '1/1/2012'
	and PT.PT_Time_Date <=  '6/30/2012' 

	and PT.Pt_Time_Hours is not null
	and PT.PT_Emp_Cost_Center_Code in (003100 
									, 003200
									, 003300 
									, 003000
									, 003400
									, 003500
									, 003700
								   )
group by
	PT.pt_job_number 
	, PT.pt_job_dsc






