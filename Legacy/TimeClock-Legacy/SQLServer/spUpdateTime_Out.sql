USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spUpdateTime_Out' AND TYPE='P')
	DROP Procedure spUpdateTime_Out
GO

Create Procedure spUpdateTime_Out
	 @Time as datetime
	, @PersonID as int
As

Declare @RowID as int

	Select top 1 @RowID = Time.ID
	From Time
	Where Time.Person_ID = @PersonID
		and Time.Time < @Time
		and Time.InOut = 'In'
	Order by Time desc

	Alter Table Time Disable Trigger trgAddTime 
		Insert into Time (Time.Person_ID, Time.Time, InOut, In_ID)
		Values (@PersonID, @Time, 'Out', @RowID)
	Alter Table Time Enable Trigger trgAddTime 

GRANT EXEC ON spUpdateTime_Out TO TimeClock 