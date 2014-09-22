USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spUpdate_WDPM' AND TYPE='P')
	DROP PROCEDURE spUpdate_WDPM
GO


CREATE Procedure spUpdate_WDPM 

	@FirstName varchar(25)
	, @LastName varchar(35)
	, @WDPM float
	, @month int
	, @year int
AS

Declare @ID int
Declare @Qtr int
/*	----- Testing
Declare @FirstName varchar(25)
Declare @LastName  varchar(35)


set @FirstName = 'Bahram'
set @LastName = 'Omidian'
*/

Set @ID = (select Provider.Id
		  from Provider
		  Where first_name = @FirstName
			and Last_Name = @LastName)

Set @Qtr = (Select Quarters.ID
			from Quarters
			where Startmonth <= @month
			and EndMonth >= @month
			)

if @ID is not null
	Insert Into WDPM(Provider_ID, WDPM, MonthWorked, Year, Quarter)
	values(@ID, @WDPM, @Month, @Year, @Qtr)

