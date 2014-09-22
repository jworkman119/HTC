/**** Individual ****/
Select 
		Upper(Left(Emp.LAST_NAME,1)) + Lower(Right(Emp.LAST_NAME, len(Emp.LAST_NAME) -1)) 
	 + ', ' + Upper(Left(Emp.FIRST_NAME,1)) + Lower(Right(Emp.FIRST_NAME, len(Emp.FIRST_NAME) -1)) as Employee
	, Convert(varchar(10),ClientService.BEG_DATE,101) as Date
	, BALANCE
	, EXTENDED_PRICE
	, PROC_CODE
	, ClientService.ID
	, isnull(ClientService.MINS,0) + (isnull(ClientService.HRS,0) * 60)  as Minutes
	, htcProcCodes.Units as DBUnits	
	, Service.ID
	, Service."DESC" as Service
	, 	Upper(Left(Client.LAST_NAME,1)) + Lower(Right(Client.LAST_NAME, len(Client.LAST_NAME) -1)) 
		+ ' ' + Upper(Left(Client.FIRST_NAME,1)) + Lower(Right(Client.FIRST_NAME, len(Client.FIRST_NAME) -1)) as Client
	, PaySource."DESC" as Provider
from CDCLSVC as ClientService
	Join CAEMP Emp on ClientService.EMP_ID = Emp.ID
	left Join CDSVC Service on ClientService.SVC_ID = Service.ID
	Join CDCLIENT Client on ClientService.CLIENT_ID = Client.ID
	Left Join CDPAYSRC PaySource on PaySource.ID = ClientService.CURR_PAYSRC_ID
	left Join htcProcCodes on htcProcCodes.ProcCode = ClientService.PROC_CODE
		and htcProcCodes.ServiceID = ClientService.SVC_ID
		and isnull(ClientService.MINS,0) + (isnull(ClientService.HRS,0) * 60) >= htcProcCodes.Minutes
		and ClientService.MINS < htcProcCodes.High
Where BEG_DATE >= '2013-11-1'
	and BEG_DATE <=	'2013-11-30'
	and (
		ClientService.MINS > 0
			or
		ClientService.HRS > 0
			or
		ClientService.DAYS > 0
		)
		
		and (
			BALANCE_FLAG = 'Y'
				or
			(BALANCE_FLAG = 'N'
			 and CURR_PAYSRC_ID = 9999 -- customer self pay
			 and BALANCE = 0
			 )
		)
		
	and Emp.LAST_NAME = 'Misiaszek'
Order by Date,Client

	
/***** Aggregate Productivity ******/
Select Emp.ID
	, 	Upper(Left(Emp.FIRST_NAME,1)) + Lower(Right(Emp.FIRST_NAME, len(Emp.FIRST_NAME) -1)) 
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
			Where BEG_DATE >= '2013-11-01'
				and BEG_DATE <=	'2013-11-29'
				) as Days 
			Group by EMP_ID	
		 ) as DaysWorked on DaysWorked.EMP_ID = Emp.ID
	left Join htcProcCodes on htcProcCodes.ProcCode = ClientService.PROC_CODE
		and htcProcCodes.ServiceID = ClientService.SVC_ID
		and isnull(ClientService.MINS,0) + (isnull(ClientService.HRS,0) * 60) >= htcProcCodes.Minutes
		and ClientService.MINS < htcProcCodes.High
	Left Join htcDailyRequired on Emp.ID = htcDailyRequired.Emp_ID		
Where BEG_DATE >= '2013-11-01'
	and BEG_DATE <=	'2013-11-29'
	and (
		ClientService.MINS > 0
			or
		ClientService.HRS > 0
		)
	and VOID_FLAG is null
	and PROC_CODE is not null
Group By
	Emp.ID
	, Emp.FIRST_NAME
	, DaysWorked.Days
	, Emp.LAST_NAME
	, htcDailyRequired.Units
