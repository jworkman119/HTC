/* Drop Table #tempTbl */

/***** - Creating temp Table to store Insurance and Payment Data - ****/
select

	 Case 
			When PaySource.ID is null then
				'Not Billed'
			When PaySource."DESC" like '%Medicare%' then
				'Medicare'
			Else
				'3rd Party'
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
Into #tempTbl
from CDCLSVC as ClientService 
--	Join CDCLIENT as Client on ClientService.CLIENT_ID = Client.ID
	Left Join (
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
									Join CDCLSVC as ClientService on ClientService.ID = CDPAYAPP.CLSVC_ID
							Where CROSS_FLAG is not null
								and  ClientService.BEG_DATE >= '2014-01-01'
								and ClientService.BEG_DATE <=	'2014-01-31'	
						) as Crossed on CDPAYAPP.CLSVC_ID = Crossed.ID
				Join CDCLSVC as ClientService on ClientService.ID = CDPAYAPP.CLSVC_ID							
				Where  ClientService.BEG_DATE >= '2014-01-01'
				and ClientService.BEG_DATE <=	'2014-01-31'	
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
	and ClientService.BEG_DATE >= '2014-01-01'
	and ClientService.BEG_DATE <=	'2014-01-31'
	and rtrim(ClientService.VOID_FLAG) is null
	and ClientService.MINS > 0
	and ClientService.BALANCE_FLAG = 'Y'
	and (
			(Pay.Crossed = 'Y' and Payments is not null)
			or
			Pay.Crossed is null
		)
order by Provider, ClientService.ID

/****** - Getting Aggregate - *******/
select Provider
	, count(Service_ID) as Claims
	, sum(Payments) as Payments
	, sum(AdjustedAmt) as AdjustedAmt
	, sum(SlideAmt) as SlideAmt
	, sum(AmountClaimed) as AmountClaimed
	, sum(ExtendedPrice) as ExtendedPrice
	, (sum(ExtendedPrice) - sum(isnull(AmountOutStanding,0))) - (sum(isnull(Payments,0))  + sum(isnull(AdjustedAmt,0)) + sum(isnull(SlideAmt,0))) as AmountShort
	, sum(AmountOutStanding) as AmountOutstanding
	, sum(AmountOverpaid) as AmountOverPaid
	, count(CrossedTo) as Crossed
from #tempTbl
Group By Provider
Order by Provider

/******* - Getting Detail View - *******/
Select  
	Upper(Left(Client.LAST_NAME,1)) + Lower(Right(Client.LAST_NAME, len(Client.LAST_NAME) -1)) 
		+ ', ' + Upper(Left(Client.FIRST_NAME,1)) + Lower(Right(Client.FIRST_NAME, len(Client.FIRST_NAME) -1)) as Client
	, ClientService.SVC_ID as ServiceID	
	,Service."DESC" as Service
	, Convert(varchar(10),ClientService.BEG_DATE,101) as Date
    , #tempTbl.*
from #tempTbl
	Join CDCLSVC as ClientService on  ClientService.ID = #tempTbl.Service_ID
	Join CDCLIENT Client on ClientService.CLIENT_ID = Client.ID 
	Join CAEMP Emp on ClientService.EMP_ID = Emp.ID
	Join CDSVC Service on ClientService.SVC_ID = Service.ID
Order by Client, Date

/****** - Drop temp table ***************************/

drop table #tempTbl