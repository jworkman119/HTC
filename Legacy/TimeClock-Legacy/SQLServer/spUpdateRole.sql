USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spUpdateRole' AND TYPE='P')
	DROP PROCEDURE spUpdateRole
GO


Create Procedure spUpdateRole
	@FirstName varchar(20)
	, @LastName varchar(35)
	, @Role varchar(15)
AS

/*Testing */
/*
Declare @Role varchar(10)
Declare @FirstName varchar(20)
Declare @LastName varchar(35)

Set @Role = 'janitor'
Set @FirstName = 'Bob'
Set @LastName = 'Hayes'
*/

Declare @RoleID varchar(3)

Select @RoleID = Role.ID
From Role
Where Role.Description = @Role


update Person
Set Person.Role_ID = @RoleID
Where Person.FirstName = @FirstName
And Person.LastName = @LastName

GRANT EXECUTE ON spUpdateRole TO TimeClock 