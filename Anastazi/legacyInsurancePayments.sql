/***** Individual Insurance Payments ******/
select  top 128 Upper(Left(Client.FIRST_NAME,1)) + Lower(Right(Client.FIRST_NAME, len(Client.FIRST_NAME) -1)) 
		+ ' ' + Upper(Left(Client.LAST_NAME,1)) + Lower(Right(Client.LAST_NAME, len(Client.LAST_NAME) -1)) as Client 
	, PaySource."DESC" as Provider
	, Pay.PAY_APPLIED_AMT as Payments
	, Pay.SVC_BALANCE as AmountOwed
	, ClientService.EXTENDED_PRICE as ExtendedPrice
	, Service."DESC" as Service
	, ClientService.ID
	, Convert(varchar(10),ClientService.BEG_DATE,101) as ServiceDate
	, ClientService.MINS
	, 	Upper(Left(Emp.FIRST_NAME,1)) + Lower(Right(Emp.FIRST_NAME, len(Emp.FIRST_NAME) -1)) 
	 + ' ' + Upper(Left(Emp.LAST_NAME,1)) + Lower(Right(Emp.LAST_NAME, len(Emp.LAST_NAME) -1)) as Employee
from CDCLSVC as ClientService 
	Join CDCLIENT as Client on ClientService.CLIENT_ID = Client.ID
	Join CDSVC Service on ClientService.SVC_ID = Service.ID
	Join CAEMP Emp on ClientService.EMP_ID = Emp.ID
	Left Join (Select *
		  From CDPAYAPP
		  Where PAY_APPLIED_AMT is not null
		  ) as Pay on Pay.CLSVC_ID = ClientService.ID
	Left Join CDPAYSRC PaySource on PaySource.ID = Pay.PAY_SRC_ID
	Left Join CDPAY PayDetail on Pay.PAY_ID = PayDetail.ID
 Where 
 	cast(ClientService.MINS as int) > 0	
	and ClientService.CLIENT_ID = 3339
	and ClientService.EXTENDED_PRICE is not null
	and ClientService.EXTENDED_PRICE > 0
	and ClientService.BEG_DATE >= '2013-6-01'
	and ClientService.BEG_DATE <=	'2013-10-30'
ORDER BY Client	
, ServiceDate


	
	
/***** Aggregate By Insurance *****/
select Case 
			When PaySource.ID is null then
				'Not Billed'
			Else
				PaySource."DESC"
	End as Provider
	,  Pay.Payments 
	, Pay.AdjustedAmt 

	, Pay.SlideAmt  
	, Pay.AmountClaimed
	, ClientService.EXTENDED_PRICE as ExtendedPrice
	, ClientService.ID as Service_ID
	, Case When Pay.AdjustedAmt < 0 then
		abs(Pay.AdjustedAmt)
	  End as AmountOverPaid
	, Case
		When (Pay.Crossed = 'Y' and Pay.Payments <= Pay.AmountClaimed) then
			PaySource2."DESC" 
	  End as CrossedTo
	, Case
		When (Pay.Crossed = 'Y' and Pay.Payments <= Pay.AmountClaimed) then
			 Pay.AmountClaimed - (ISNULL(Pay.Payments,0) + ISNULL(Pay.AdjustedAmt,0) + IsNull(Pay.SlideAmt,0))  
		End as AmountOutStanding
from CDCLSVC as ClientService 
--	Join CDCLIENT as Client on ClientService.CLIENT_ID = Client.ID
	Join (
			Select CDPAYAPP.CLSVC_ID AS ServiceID
								, CDPAYAPP.PAY_SRC_ID as PaySource
								, sum(CDPAYAPP.PAY_APPLIED_AMT) as Payments
								, sum(CDPAYAPP.ADJ_AMT) as AdjustedAmt
								, sum(CDPAYAPP.SLIDE_AMT) as SlideAmt
								, sum(CLAIM_AMT) as AmountClaimed
								, Crossed
			From CDPAYAPP
				Left Join (
						Select CDPAYAPP.CLSVC_ID as ID
							, CROSS_FLAG as Crossed
						From CDPAYAPP
						Where CROSS_FLAG is not null
					) as Crossed on CDPAYAPP.CLSVC_ID = Crossed.ID
			Group by 
				CDPAYAPP.CLSVC_ID
				, CDPAYAPP.PAY_SRC_ID 
				, Crossed
		  ) as Pay on Pay.ServiceID = ClientService.ID
	Left Join CDPAYSRC PaySource on PaySource.ID = Pay.PaySource
	Left Join CDPAYSRC PaySource2 on ClientService.CURR_PAYSRC_ID = PaySource2.ID
 Where 
 	cast(ClientService.MINS as int) > 0	
	and ClientService.EXTENDED_PRICE is not null
	and ClientService.EXTENDED_PRICE > 0
	and ClientService.BEG_DATE >= '2013-6-01'
	and ClientService.BEG_DATE <=	'2013-10-30'
	and rtrim(ClientService.VOID_FLAG) is null
	and (
			(Pay.Crossed = 'Y' and Payments is not null)
			or
			Pay.Crossed is null
		)
order by ClientService.ID



	 