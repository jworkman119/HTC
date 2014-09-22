
USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spReturnUserTime' AND TYPE='P')
	DROP PROCEDURE spReturnUserTime
GO

Create Procedure spReturnUserTime
	@PersonID as int
	
As


-- Test
/*
	Declare @PersonID int
	Set @PersonID = 2176
*/
-- end Test

select
	 TbIn.ID as ID_In
	, TbIn.Time as [In]
	, TbOut.ID as ID_Out
	, TbOut.Time as Out
	, '' as ActionIn
	, '' as ActionOut
From (select * from Time where InOut = 'In')TbIn
	left join (select * from Time where InOut = 'Out')TbOut on TbOut.In_ID = TbIn.ID
where tbIn.Person_ID = @PersonID

GRANT EXECUTE ON spReturnUserTime TO TimeClock 