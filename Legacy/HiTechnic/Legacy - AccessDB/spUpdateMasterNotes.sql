Create PROCEDURE UpdateMasterNotes 
AS
Update MasterNotes
	inner join dbo_arshtfil2_sql B on MasterNotes.RefNumber = B.Ord_No
Set PickedFullIndicator = True
where masternotes.pickedfullindicator = false
