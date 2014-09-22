SQLServer 2000
SELECT OBJECT_NAME(id),rowcnt
FROM SYSINDEXES
WHERE OBJECTPROPERTY(id,'isUserTable')=1 AND indid < 2
ORDER BY rowcnt DESC

SQLServer >= 2005
SELECT o.name,
  ddps.row_count 
FROM sys.indexes AS i
  INNER JOIN sys.objects AS o ON i.OBJECT_ID = o.OBJECT_ID
  INNER JOIN sys.dm_db_partition_stats AS ddps ON i.OBJECT_ID = ddps.OBJECT_ID
  AND i.index_id = ddps.index_id 
WHERE i.index_id < 2  AND o.is_ms_shipped = 0 
ORDER BY row_count desc