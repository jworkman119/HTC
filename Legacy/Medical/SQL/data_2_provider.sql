USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Provider' AND TYPE='P')
	DROP PROCEDURE spFill_Provider
GO


Create Procedure spFill_Provider as 
INSERT INTO Provider(First_Name,Last_Name,Provider_Type_ID)
SELECT 'Barbara', 'Brooks Jarvis', 'npp-c'
 UNION ALL
SELECT 'Barbara', 'Pfendler Ruiz', 'lcsw'
 UNION ALL
SELECT 'Minhaj','Uddin Siddiqi','md'
 Union All
SELECT 'Steven', 'fries','pa'
 UNION ALL
SELECT 'Alan', 'Demoranville', 'rn'
 UNION ALL
SELECT 'Angela', 'petty', 'lcsw-r'
 UNION ALL
SELECT 'Bahram', 'omidian', 'md'
 UNION ALL
SELECT 'Benedetta', 'Melnick','NPP-C'
 UNION ALL
SELECT 'Bharat', 'Bushan', 'md'
 UNION ALL
SELECT 'Brenda', 'veilleux', 'lcsw'
 UNION ALL
SELECT 'Cara', 'Goedecker','NA'
 UNION ALL
SELECT 'Cynthia','Lapolla','BA'
 UNION ALL
SELECT 'Elaine', 'Romano' ,'lcsw-r'
 UNION ALL
SELECT 'Elizabeth' ,'antonson' ,'lcsw-r'
 UNION ALL
SELECT 'Ellen','karwacki', 'npp'
 UNION ALL
SELECT 'Francis' ,'voorhees','ba'
 UNION ALL
SELECT 'Kathy','herbst','lcsw-r'
 UNION ALL
SELECT 'Kenton','fehlner','rn'
 UNION ALL
SELECT 'Linnea','powell','lcsw-r'
 UNION ALL
SELECT 'Lisa','getman','msw'
 UNION ALL
SELECT 'Nancy','phillips','lcsw'
 UNION ALL
SELECT 'Nancy','johnson','lcsw-r'
 UNION ALL
SELECT 'Roset','khosropour','msw'
 UNION ALL
SELECT 'Stephen','hudyncia','md'
 UNION ALL
SELECT 'Susan','hauptfleisch','npp'
 UNION ALL
SELECT 'Suvada','veiz','bs'
 UNION ALL
SELECT 'Thomas','Butler ','msw'
 UNION ALL
SELECT 'Victoria','laucello','lcsw-r'
 UNION ALL
SELECT 'Walter','misiaszek','msw'



