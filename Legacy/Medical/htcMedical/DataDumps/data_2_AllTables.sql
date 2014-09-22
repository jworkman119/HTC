USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_AllTables' AND TYPE='P')
	DROP PROCEDURE spFill_AllTables
GO

Create Procedure as spFill_AllTables

execute spFill_Patient
execute spFill_Address
execute spFill_Facility
execute spFill_Provider_Type
execute spFill_Provider

-- Filling insurance table
insert into insurance(id)
select distinct carrier
from datadump
where Datadump.Carrier not in ( Select id
							    From Insurance)

execute spFill_Service
execute spFill_Visit
