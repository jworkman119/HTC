/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.addSupSchedule;

*/

CREATE PROCEDURE addSupSchedule (IN strFirstName VARCHAR(35), IN strLastName VARCHAR(50), IN Day VARCHAR(10), IN TimeIn TIME, IN TimeOut TIME, IN Zone varchar(25))
Begin
	Declare intWorker int;

	
	Select ID
	Into intWorker
	From Person 
	Where  concat(Person.FirstName, ' ', Person.LastName) = concat(strFirstName, ' ' , strLastName)
		and Person.Role_ID = 'sup';	
	
	-- Inserting into db
	If(intWorker > 0) Then
		Insert Into Schedule(Person_ID, Day,TimeIn, TimeOut, Zone_ID)
		Values (intWorker ,Date_Format(Day,'%Y-%m-%d') ,TimeIn, TimeOut, Zone);
	End If;	

End
