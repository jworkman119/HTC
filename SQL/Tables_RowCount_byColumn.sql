SELECT    ta.name TableName
		,  c.name AS ColName
        ,SUM(pa.rows) RowCnt
FROM    sys.tables ta
	INNER JOIN    sys.partitions pa    ON    pa.OBJECT_ID = ta.OBJECT_ID
	INNER JOIN    sys.schemas sc        ON    ta.schema_id = sc.schema_id
	Join sys.columns c ON c.object_id = ta.object_id
WHERE    ta.is_ms_shipped = 0    
	AND pa.index_id IN (1,0)
	AND c.name LIKE '%STAFF%'
GROUP BY    ta.name, c.Name
	Having SUM(pa.rows)>0
	and SUM(pa.rows)<100
ORDER BY    SUM(pa.rows) DESC


select *
from AZSCHEAD