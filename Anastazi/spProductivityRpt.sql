/*
Drop Procedure ProductivityRpt
*/
Create Procedure ProductivityRpt
	@FromDate DateTime
	, @ToDate	DateTime
as

Select 
	Upper(Left(Emp.FIRST_NAME,1)) + Lower(Right(Emp.FIRST_NAME, len(Emp.FIRST_NAME) -1)) 
	 + ' ' + Upper(Left(Emp.LAST_NAME,1)) + Lower(Right(Emp.LAST_NAME, len(Emp.LAST_NAME) -1)) as Employee
	, DaysWorked.Days
	, Count(ClientService.ID) as Appointments
	, Round(cast(sum(isnull(ClientService.MINS,0) + (isnull(ClientService.HRS,0) * 60)) as float)/60,1) as Hours
	, htcDailyRequired.Units as DailyUnitsRequired
	, Round(htcDailyRequired.Units * DaysWorked.Days,1) as MonthlyUnitsRequired
	, sum(htcProcCodes.Units) as Units
	, Round(sum(htcProcCodes.Units)/Round(htcDailyRequired.Units * DaysWorked.Days,1) * 100,1) as Productivity
	, sum(EXTENDED_PRICE) ExtendedPrice
from CDCLSVC as ClientService
	Join CAEMP Emp on ClientService.EMP_ID = Emp.ID
	Join CDSVC Service on ClientService.SVC_ID = Service.ID
	Join CDCLIENT Client on ClientService.CLIENT_ID = Client.ID
	Join (
			Select 	EMP_ID
			, count(Days.DayWorked) as Days
			From 
			(
			Select Distinct ClientService.EMP_ID
				, BEG_DATE as DayWorked
			from CDCLSVC as ClientService
			Where BEG_DATE >= @FromDate
				and BEG_DATE <=	@ToDate
				) as Days 
			Group by EMP_ID	
		 ) as DaysWorked on DaysWorked.EMP_ID = Emp.ID
	left Join htcProcCodes on htcProcCodes.ProcCode = ClientService.PROC_CODE
		and htcProcCodes.ServiceID = ClientService.SVC_ID
		and isnull(ClientService.MINS,0) + (isnull(ClientService.HRS,0) * 60) >= htcProcCodes.Minutes
		and ClientService.MINS < htcProcCodes.High
	Left Join htcDailyRequired on Emp.ID = htcDailyRequired.Emp_ID		
Where BEG_DATE >= @FromDate
	and BEG_DATE <=	@ToDate
	and (
		ClientService.MINS > 0
			or
		ClientService.HRS > 0
		)
	and VOID_FLAG is null
	and PROC_CODE is not null
Group By
	Emp.FIRST_NAME
	, DaysWorked.Days
	, Emp.LAST_NAME
	, htcDailyRequired.Units