Drop Procedure addTimeIn

CREATE PROCEDURE addTimeIn (In PersonID int, In TimeIn datetime, In SQLiteDB_ID int)
Begin

	-- Entering new time into Time
	INSERT INTO Time(Person_ID, TimeIn,LocalDB_ID)
	VALUES(PersonID, TimeIn, SQLiteDB_ID);

	-- Returning new Time.Id to be placed in localDB
	SELECT ID
	FROM Time
	WHERE LocalDB_ID = SQLiteDB_ID;
	
End