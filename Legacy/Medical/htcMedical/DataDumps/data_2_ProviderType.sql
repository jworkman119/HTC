USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Provider_Type' AND TYPE='P')
	DROP PROCEDURE spFill_Provider_Type
GO

CREATE PROCEDURE spFill_Provider_Type AS 

	INSERT INTO Provider_Type(ID, [Description])
	SELECT 'Appt', ''
	UNION ALL
	SELECT 'BA', 'Bachelor of Arts'
	UNION ALL
	SELECT 'BS', 'Bachelor of Science'
	UNION ALL
	SELECT 'LCSW', 'Clinical Social Worker (licensed)'
	UNION ALL
	SELECT 'LCSW-R', 'Clinical Social Worker-R (licensed)'
	UNION ALL
	SELECT 'MD', 'Doctor (medical)'
	UNION ALL
	SELECT 'MSW', 'Masters of Social Work'
	UNION ALL
	SELECT 'NA', 'Not Applicable'
	UNION ALL
	SELECT 'NPP', 'Nurse Practictioner (psychiatric)'
	UNION ALL
	SELECT 'NPP-C', 'Nurse Practictioner (certified psychiatric)'
	UNION ALL
	SELECT 'PA', 'Physician Assistant'
	UNION ALL
	SELECT 'RN', 'Registered Nurse'
	UNION ALL
	SELECT 'RNC', 'Registered Nurse (certified)'
