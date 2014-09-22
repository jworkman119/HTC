Select 	Client.ID
		, Upper(Left(Client.LAST_NAME,1)) + Lower(Right(Client.LAST_NAME, len(Client.LAST_NAME) -1)) 
		+ ', ' + Upper(Left(Client.FIRST_NAME,1)) + Lower(Right(Client.FIRST_NAME, len(Client.FIRST_NAME) -1)) as Client
		, Convert(varchar(10),ClientService.BEG_DATE,101) as Date
from CDCLIENT as Client 
	Join CDCLSVC as ClientService on ClientService.CLIENT_ID = Client.ID
where ClientService.BEG_DATE >= '2013-05-01'
	and ClientService.BEG_DATE <=	'2013-12-31'
	and ClientService.EXTENDED_PRICE is not null
	and ClientService.EXTENDED_PRICE > 0
	and VOID_FLAG is null
	and ORIG_PAYSRC_ID = 9999
order by Client, Date	

