/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.checkPassword;

*/

CREATE PROCEDURE checkPassword(IN UserName varchar(25),IN Pass varchar(100), Out Status varchar(6))
Begin

       Declare PassWd varchar(100);

 

       Select Pwd

       Into PassWd

       from Users

       where Users.Username = UserName;

      

	
	If(md5('htc') = PassWd) then
		Set Status = 'Update';
	ElseIf (Pass=Passwd) then

    	Set Status = 'OK';	
    Else
        Set Status = 'Fail';      
    end if;

 

       Select Status;

End

