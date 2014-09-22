SELECT sc.name +'.'+ ta.name TableName
	, c.name AS ColName
	, ta.name AS TableName
,SUM(pa.rows) RowCnt
FROM sys.columns c
	Join sys.tables ta ON c.object_id = ta.object_id
	JOIN sys.partitions pa ON pa.OBJECT_ID = ta.OBJECT_ID
	JOIN sys.schemas sc ON ta.schema_id = sc.schema_id
WHERE ta.is_ms_shipped = 0 AND pa.index_id IN (1,0)
	 and c.name LIKE '%EMP_ID%'
GROUP BY sc.name
	,ta.name
	,c.name
ORDER BY SUM(pa.rows) DESC



SELECT Distinct  CAEMP.ID as Resource_ID
	, CDCLIENT.ID as Client_ID
	, Upper(Left(CDCLIENT.FIRST_NAME,1)) + Lower(Right(CDCLIENT.FIRST_NAME, len(CDCLIENT.FIRST_NAME) -1)) as FirstName
	, Upper(Left(CDCLIENT.LAST_NAME,1)) + Lower(Right(CDCLIENT.LAST_NAME, len(CDCLIENT.LAST_NAME) -1)) as LastName
	, REPLACE(CONVERT(VARCHAR(10), DOB, 111), '/', '-') AS DOB
	, HOME_PHONE
	, max(CAST(END_HR as FLOAT) + CAST(END_MIN as Float)/100) as EndTime
FROM CDCLIENT
	JOIN CDCLSVC on CDCLIENT.LAST_SERVICE_DT= CDCLSVC.BEG_DATE
		AND CDCLSVC.CLIENT_ID = CDCLIENT.ID
	JOIN CAEMP ON CAEMP.ID = CDCLSVC.EMP_ID  
WHERE LAST_SERVICE_DT > '2013-01-1 00:00:00.0'
Group By
	CAEMP.ID
	, CDCLIENT.ID
	, CDCLIENT.FIRST_NAME
	, CDCLIENT.LAST_NAME
	, DOB
	, HOME_PHONE
	, CDCLIENT.LAST_SERVICE_DT
	, CDCLSVC.BEG_DATE
Order by FirstName



Select CLIENT_ID
	, EMP_ID
	, END_DATE
	, END_HR
	, END_MIN
FROM CDCLSVC