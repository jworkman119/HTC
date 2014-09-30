CREATE PROCEDURE AddShift(IN varName VARCHAR(35), IN varTimeIn TIME, IN varTimeOut TIME)
Begin	
	Declare isShift varchar(35);

	Select Name
	into isShift
	from Shift
	where Shift.Name = varName;

	If (isShift is NULL) Then
			Insert into Shift(Name, TimeIn, TimeOut)
			values(varName, varTimeIn, varTimeOut);
	Else
			Update Shift
			Set TimeIn = varTimeIn
			, TimeOut = varTimeOut
			Where Name = varName;
	End If;

End