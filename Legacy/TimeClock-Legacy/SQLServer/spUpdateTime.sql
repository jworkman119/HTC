
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spUpdateTime2' AND TYPE='P')
	DROP Procedure spUpdateTime2
GO

Create Procedure spUpdateTime2
	@Action as varchar(1)
	, @RowID as int
	, @Time as datetime
AS


-- Testing
-- spUpdateTime2 'Ou','0','8/27/2010 6:00:00 PM','2196'
/*
	Declare	@Action as varchar(3)
	Declare @RowID as int
	Declare @Time as datetime
	Declare @PersonID as int

	Set @Action = 'Ou'
	Set @RowID = 0
	Set @Time =  '8/27/2010 10:00:00 PM'
	Set @PersonID = 2196
*/
-- End Testing
if @Action = 'C'
	Update Time
	set Time = @Time
	where Time.ID = @RowID
	
if @Action = 'D'
	Delete from Time
	Where Time.ID = @RowID

GRANT EXECUTE ON spUpdateTime2 TO TimeClock 