USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Visit' AND TYPE='P')
	DROP PROCEDURE spFill_Visit
GO



CREATE PROCEDURE spFill_Visit 

AS

INSERT INTO Visit(date,Patient_Account,Insurance_ID, Provider_ID, Service_ID, Facility_ID)
SELECT datadump.date
	,  datadump.account AS Patient_Account
	,  datadump.carrier AS insurance_ID
	,  Provider.ID AS Provider_ID
	,  datadump.[proc] AS Service_ID
	,  CASE datadump.location 
		WHEN ''  THEN
			'N'
		ELSE
			datadump.location
		END AS Facility_ID
FROM datadump
	JOIN Provider ON DataDump.Provider_Last = Provider.Last_Name 
	JOIN Patient ON DataDump.Account = Patient.Account
	JOIN Facility ON DataDump.Location = Facility.ID
	Join Service on DataDump.[proc] = Service.ID
--WHERE [Proc] <> 'Nsa'
ORDER BY facility_id

