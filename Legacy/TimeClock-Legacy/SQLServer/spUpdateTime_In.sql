
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spUpdateTime_In' AND TYPE='P')
	DROP Procedure spUpdateTime_In
GO

Create Procedure spUpdateTime_In
	 @Time as datetime
	 , @PersonID as int
As
	Alter Table Time Disable Trigger trgAddTime 

		Insert into Time (Time.Person_ID, Time.Time, InOut)
		Values (@PersonID, @Time, 'In')

	Alter Table Time Enable Trigger trgAddTime 

GRANT EXECUTE ON spUpdateTime_In TO TimeClock 