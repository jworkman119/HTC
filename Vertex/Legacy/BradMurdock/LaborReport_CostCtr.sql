select Cost_Center.Cost_Center_ID as CostCenter_No
	 , Cost_Center.Cost_Center_Dsc as CostCenter
	, job_number as Job_No
	, job.Job_Dsc as Job
from job
	join Cost_Center on Job.Job_Cost_Center_ID = Cost_Center.Cost_Center_ID
where Job_Cost_Center_ID in (1004,1005,1006)
order by job_dsc



select *
from productivity_transaction
order by pt_job_dsc


order by Customer_Name


pay_type

1004	Proclean East
1005	Proclean West
1006	Forever Green

select *
from customer