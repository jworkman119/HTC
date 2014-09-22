/**** sql server 2008 ******/
SELECT sc.name +'.'+ ta.name TableName
	, c.name AS ColName
	, ta.name AS TableName
,SUM(pa.rows) RowCnt
FROM sys.columns c
	Join sys.tables ta ON c.object_id = ta.object_id
	JOIN sys.partitions pa ON pa.OBJECT_ID = ta.OBJECT_ID
	JOIN sys.schemas sc ON ta.schema_id = sc.schema_id
WHERE ta.is_ms_shipped = 0 AND pa.index_id IN (1,0)
	 and c.name LIKE '%FIRST_NAME%'
GROUP BY sc.name
	,ta.name
	,c.name
ORDER BY SUM(pa.rows) DESC

/***** sql server < 2008  *******/
  Select Columns.table_name , columns.column_name
  FROM Information_Schema.Columns as Columns
  Where Columns.Column_Name = 'ClassID'
--	and left(column_name, 4) <> 'user'
  order by table_name
		/*and*/ table_name like 'product'
	
select *
from usfsjobcodes


select *
from oehdraud_sql
where ltrim(ord_no)in ('95122','95123','95124','95125') 


select *
from PartClass





-- gives you rowcount for all tables in DB
SELECT 
    [TableName] = so.name, 
    [RowCount] = MAX(si.rows)  
FROM 
    sysobjects so, 
    sysindexes si 
WHERE 
    so.xtype = 'U' 
    AND 
    si.id = OBJECT_ID(so.name) 
GROUP BY 
    so.name 
ORDER BY 
    [RowCount] DESC

select top 20 *
from 
