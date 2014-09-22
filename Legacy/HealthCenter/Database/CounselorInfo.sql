SELECT    ta.name TableName
		,  c.name AS ColName
        ,SUM(pa.rows) RowCnt
FROM    sys.tables ta
	INNER JOIN    sys.partitions pa    ON    pa.OBJECT_ID = ta.OBJECT_ID
	INNER JOIN    sys.schemas sc        ON    ta.schema_id = sc.schema_id
	Join sys.columns c ON c.object_id = ta.object_id
WHERE    ta.is_ms_shipped = 0    
	AND pa.index_id IN (1,0)
	AND c.name LIKE '%NAME%'
--	AND ta.name like 'CD%'
GROUP BY    ta.name, c.Name
	Having SUM(pa.rows)>10
--	and SUM(pa.rows)<100
ORDER BY    SUM(pa.rows), TableName DESC


Select CASE_NUM as Case#
,Upper(Left(FIRST_NAME,1)) +  Lower(right(FIRST_NAME,len(FIRST_NAME)-1)) as FirstName
,Upper(Left(LAST_NAME,1)) +  Lower(right(LAST_NAME,len(LAST_NAME)-1)) as LastName
, convert(char(10),DOB,126) as DOB
, *
from CDCLIENT


Select *
from CDASSIGN

select SERVER_ID
	, CAEMP.LAST_NAME + ', ' + CAEMP.FIRST_NAME AS Staff
	, COUNT(CDASSIGN.ID)
from CDASSIGN
	Join CAEMP on CDASSIGN.SERVER_ID= CAEMP.ID
Group by SERVER_ID
, LAST_NAME, FIRST_NAME	