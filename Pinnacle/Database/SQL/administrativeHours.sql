Select Count(DIAG_ID) as [#ofCases]
	, xpw.A4_10 as ICD9_Code
	, Lower([DESC]) as Diagnosis
FROM CDCLIENT
	Join CDCLDIAG on CDCLDIAG.CLIENT_ID = CDCLIENT.ID  
	Join CDTBL1 as xpw on CDCLDIAG.DIAG_ID = xpw.ID
WHERE /* LAST_SERVICE_DT > '2013-01-1 00:00:00.0'*/
		CDCLDIAG.BEG_DATE > '2013-01-1 00:00:00.0'
		and xpw.TYPE in ('AXISIV', 'DIAG','DIAGBT','DIAGCL')
		and xpw.ACTIVE_FLAG = 'Y'
		and xpw.A4_10 is not null
Group By xpw.ID,xpw.A4_10,[DESC]
Order by xpw.ID,xpw.A4_10,[DESC]





