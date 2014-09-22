USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Facility' AND TYPE='P')
	DROP PROCEDURE spFill_Facility
GO

	CREATE PROCEDURE spFill_Facility AS 
	INSERT INTO Facility(ID, Full_Name, Address, City, State, Zip)
	VALUES
		('U','Mental Health Connections - Utica', '1500 Genesee St.','Utica','NY', '13502')
	
	
	INSERT INTO Facility(ID, Full_Name, Address, City, State, Zip)
	VALUES
		('R','Mental Health Connections - Rome', '252 W. Dominick St.','Rome', 'NY', '13440')
	
	
	INSERT INTO Facility(ID, Full_Name, Address, City, State, Zip)
	VALUES
		('W', 'Mental Health Connections - Satellite Office', '','Waterville','NY','13480')
	
	INSERT INTO Facility(ID, Full_Name, Address, City, State, Zip)
	VALUES
		('N','No Listing Provided', '','', '', '')
