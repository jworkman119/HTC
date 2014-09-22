IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_NAME = N'sp_dropxpwtables' 
)
   DROP PROCEDURE sp_dropxpwtables
GO

CREATE PROCEDURE sp_dropxpwtables
	@daysold int = 30 
AS
print 'Dropping XPW% tables more than '+ ltrim(str(@daysold)) +' days old'	
DECLARE @tablename VARCHAR(50)
declare @crdate varchar(12)
declare @SQLString nvarchar(2000)

SET @SQLString = 'drop table '

DECLARE xpwtables CURSOR keyset for
SELECT name, crdate
FROM sysobjects
WHERE xtype='U'
  and name like 'XPW%'
  and crdate <= getdate()-@daysold	
order by 2

open xpwtables
FETCH NEXT FROM xpwtables into @tablename, @crdate

WHILE (@@FETCH_STATUS = 0)
BEGIN
	print 'Dropping table: '+@tablename+' created on: '+@crdate
	SET @SQLString = 'drop table ' + @tablename
	EXEC sp_executesql @sqlstring 
	FETCH NEXT FROM xpwtables into @tablename, @crdate
END

CLOSE xpwtables
DEALLOCATE xpwtables
GO
