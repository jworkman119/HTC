Vertex:
	
	Wages:
			select  pt_emp_last_name || ', ' || pt_emp_first_name as employee
				 , pt_emp_number
				, pt_emp_cost_center_dsc as Department
				, pt_job_number as Job
				, pt_job_dsc as Job
				, pt_time_date as DateWorked
				, sum(pt_time_earnings) as Earnings
				, sum(pt_time_hours * 24) as hours
			from productivity_transaction
			where pt_time_date >= '1/1/2011'
				and pt_time_date <= '10/15/2011'
				and substr(PT_USED_Dept_Code,1,3) = '003'
			group by
				 pt_emp_last_name 
				, pt_emp_first_name 
				, pt_emp_number
				, pt_emp_cost_center_dsc
				, pt_job_number
				, pt_job_dsc
				, pt_time_date

	HW:
			select pt_Emp_Number
				 , PT_Job_Number as Job
				, sum(pt_time_earnings) as Health_Welfare
			from Productivity_Transaction
			where PT_Time_Date >= '1/1/2011'
				and PT_Time_Date <= '10/15/2011'
				and pt_record_type_id in (1009, 1010, 1015, 1016)
				and substr(PT_USED_Dept_Code,1,3) = '003'
			group by
				 pt_Emp_Number
				, PT_Job_Number



*******************************************************
select Wages.Employee
		, Wages.EmpNo
		, Wages.Department
		, Wages.JobNo
		, Wages.Job
		, Date
		, Round(sum(Wages.Earnings), 2) as Earnings
		, Round(sum(Wages.Hours), 2) as Hours
		, HW.HW
from HW
	Join Wages on HW.EmpNo = Wages.EmpNo
	and HW.JobNo = Wages.JobNo
group by
		Wages.Employee
		, Wages.EmpNo
		, Wages.Department
		, Wages.JobNo
		, Wages.Job
		, HW.HW 
		
		
	Select Wages.EmpNo
		, Wages.JobNo
		, Wages.Date
	from HW
		Join Wages on HW.EmpNo = Wages.EmpNo
		and HW.JobNo = Wages.JobNo
	Order by Wages.EmpNo
		, Wages.JobNo
		, Wages.Date
