alter Procedure spFill_datadump 
	@File varchar(50)
AS
/*
set @strPath = '"\\Ntserver2\h\tmp\4_2010Charges.csv"'
Declare @File varchar(35)
set @File = '4_2010Charges.csv'
*/
Declare @strPath  varchar(50)
Declare @Statement varchar(120)

set @strPath = '"\\Ntserver2\h\tmp\' + @File + '"' 

Set @Statement =  'Bulk Insert datadump From ' + @strPath + ' with (fieldterminator = ' + '''|''' + ')'

Exec(@Statement)
