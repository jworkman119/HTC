/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.AddTime_Manually;

*/

CREATE PROCEDURE AddTime_Manually (IN strFirst VARCHAR(25), IN strLast VARCHAR(35), IN TimeIn DATETIME, IN TimeOut DATETIME)
Begin

	Declare intPerson int;
		
		Select Person.ID
		Into intPerson
		from Person
		where FirstName = strFirst
		and LastName = strLast;
		
		if (intPerson>0) then
		   Insert into Time(Person_ID, TimeIn, TimeOut)
		   Values(intPerson,TimeIn,TimeOut);
		end if;
   
End

