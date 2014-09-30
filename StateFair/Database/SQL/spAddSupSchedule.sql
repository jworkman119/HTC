Drop Procedure addSupSchedule
Create Procedure addSupSchedule(strFirstName varchar(35), strLastName varchar(50), Day varchar(10), intJob varchar(25), intShift varchar(50))
Begin
	Declare intWorker int;
	
	Select ID
	Into intWorker
	From Person 
	Where  concat(Person.FirstName, ' ', Person.LastName) = concat(strFirstName, ' ' , strLastName)
		and Person.Role_ID = 'sup';	
		
	-- Inserting into db
	If(intWorker > 0) Then
		Insert Into Schedule(Person_ID, Day,Shift_ID,Job_ID)
		Values (intWorker,Date_Format(Day,'%Y-%m-%d'),intShift,intJob);
	End If;
End;



 