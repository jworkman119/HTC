USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spAddPerson' AND TYPE='P')
	DROP PROCEDURE spAddPerson
GO


Create Procedure spAddPerson(@FirstName varchar(20), @LastName varchar(30), @Role varchar(10), @Path varchar(500) = NULL) 

as 

/*
declare @Role as varchar(10)
declare @FirstName as varchar(20)
declare @LastName as varchar(30)
Set @Role = 'janitor'
Set @FirstName = 'jeremy'
Set @LastName = 'patterson'
*/

declare @RoleKey as varchar(3);

Select @RoleKey =  ID
from Role
where Description = @Role


insert into Person(FirstName,LastName,Role_ID, PicPath)
values(@FirstName, @LastName, @RoleKey, @Path)

GRANT EXECUTE ON spAddPerson TO TimeClock 