drop procedure AddTime_Manually

Create Procedure AddTime_Manually(strFirst varchar(25), strLast varchar(35), TimeIn DateTime, TimeOut DateTime)

Begin

	Declare intPerson int;
		
		Select Person.ID
		Into intPerson
		from Person
		where FirstName = strFirst
		and LastName = strLast;
		
		if ( Year(TimeOut) != 2011) then
		   Insert into Time(Person_ID, TimeIn, TimeOut)
		   Values(intPerson,TimeIn,null);
		else
		   Insert into Time(Person_ID, TimeIn, TimeOut)
		   Values(intPerson,TimeIn,TimeOut);
		
   End If;
   
End




select *
from Person 
where LastName like 'G%'