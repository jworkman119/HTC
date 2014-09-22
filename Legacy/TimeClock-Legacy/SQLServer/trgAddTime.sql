/*
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='trgAddTime' AND TYPE='TR')
	DROP Trigger trgAddTime
GO

Create Trigger trgAddTime

	On Time
	For Insert

as
*/
Declare @InOut varchar(3)
Declare @PersonID int
Declare @RowID timestamp
Declare @In_ID int

/* Testing
	spUpdateTime 'A','0','8/27/2010 6:00:00 PM','2196'
*/
Set @PersonID = 2196



-- End Test



Select @PersonID = Person_ID
	, @RowID = Time.ID
from Time 
where InOut is NULL

select top 1 @InOut = InOut
	, @In_ID = Time.ID
from Time
where Person_ID =  @PersonID
and InOut is not NULL
order by Time desc

select @InOut, @In_ID


If @InOut = 'Out'
	Begin
		Update Time
		Set InOut = 'In'
		Where Time.ID = @RowID
	End
If @InOut = 'In'
	Begin
		Update Time
		Set InOut = 'Out'
			, In_ID = @In_ID
		Where Time.ID = @RowID
	End
If @InOut is NULL
	Begin
		Update Time
		Set InOut = 'In'
		Where Time.ID = @RowID
	End


