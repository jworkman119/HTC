USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_DefTables' AND TYPE='P')
	DROP PROCEDURE spFill_DefTables
GO

Create Procedure spFill_DefTables

AS

execute spFill_Facility
execute spFill_Provider_Type
execute spFill_Provider
execute spFill_Service

