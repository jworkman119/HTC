USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_NewMonth' AND TYPE='P')
	DROP PROCEDURE spFill_NewMonth
GO

Create Procedure spFill_NewMonth

	--@File varchar(50)

as

Declare @strPath  varchar(75)
Declare @Statement varchar(120)

set @strPath = '"\\SqlServer01\imports\MedicalWeighted_' + CONVERT(VARCHAR(10), GETDATE(), 110) +  '.txt"' 

--Loading data into datadump
Set @Statement =  'Bulk Insert datadump From ' + @strPath + ' with (fieldterminator = ' + '''|''' + ')'

Exec(@Statement)


execute spFill_Patient
execute spFill_Address


-- Filling insurance table
insert into insurance(id)
select distinct carrier
from datadump
where Datadump.Carrier not in ( Select id
							    From Insurance)

execute spFill_Visit

-- Deleting rows that have been entered to the database
delete from datadump
where DataDump.BadData = 0;
