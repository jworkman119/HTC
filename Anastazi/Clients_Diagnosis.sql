/**** Individuals ****/
SELECT Distinct  CDCLIENT.ID as Client_ID
	, CASE_NUM 
	, Upper(Left(CDCLIENT.FIRST_NAME,1)) + Lower(Right(CDCLIENT.FIRST_NAME, len(CDCLIENT.FIRST_NAME) -1)) as FirstName
	, Upper(Left(CDCLIENT.LAST_NAME,1)) + Lower(Right(CDCLIENT.LAST_NAME, len(CDCLIENT.LAST_NAME) -1)) as LastName
	, CDCLDIAG.AXIS as Axis
	, CDCLDIAG.PRIORITY as Priority
	, CDCLDIAG.DIAG_ID as DiagID
	, lower(xpw.[DESC]) Diagnosis
	, Convert(varchar(10),BEG_DATE,101) as Diagnosed
	, Convert(varchar(10),LAST_SERVICE_DT,101) as LastSeen
FROM CDCLIENT
	Join CDCLDIAG on CDCLDIAG.CLIENT_ID = CDCLIENT.ID  
	Join XPWLIV01860001CDTBL1 as xpw on CDCLDIAG.DIAG_ID = xpw.ID
WHERE CDCLDIAG.BEG_DATE > '2013-01-1 00:00:00.0'
		and xpw.TYPE in ('AXISIV', 'DIAG','DIAGBT','DIAGCL')
		and xpw.ACTIVE_FLAG = 'Y'
Order by LastName


/* Aggregate of above query */
Select Count(DIAG_ID) as [#ofCases]
	, Lower([DESC]) as Diagnosis
FROM CDCLIENT
	Join CDCLDIAG on CDCLDIAG.CLIENT_ID = CDCLIENT.ID  
	Join XPWLIV01860001CDTBL1 as xpw on CDCLDIAG.DIAG_ID = xpw.ID
WHERE /* LAST_SERVICE_DT > '2013-01-1 00:00:00.0'*/
		CDCLDIAG.BEG_DATE > '2013-01-1 00:00:00.0'
		and xpw.TYPE in ('AXISIV', 'DIAG','DIAGBT','DIAGCL')
		and xpw.ACTIVE_FLAG = 'Y'
Group By [DESC]
Order by [DESC]

