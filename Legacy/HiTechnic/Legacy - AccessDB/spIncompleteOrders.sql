Create Procedure spIncompleteOrders

as

Select Distinct MasterNotes.RefNumber
	, MasterNotes.TxnDate
	, MasterNotes.PickedFullIndicator
	, MasterNotes.ShippingNotes
	, MasterNotes.Void
	, DailyFinal2.[Ship Method]
	, DailyFinal2.[Ship To Line1] 
		+ chr(13) + chr(10) + DailyFinal2.[Ship To Line2]
		+ chr(13) + chr(10) + DailyFinal2.[Ship To City] 	
		+ ',' + iif(isNULL(DailyFinal2.[Ship To State]),'', DailyFinal2.[Ship To State])
		+ ' ' + iif(isNULL(DailyFinal2.[Ship to Country]),'US',DailyFinal2.[Ship to Country])
		+ ' ' + DailyFinal2.[Ship To Postal Code]  as ShipTo
	, ImportStamp
from MasterNotes
	inner join DailyFinal2 on DailyFinal2.RefNumber = MasterNotes.RefNumber
Where void = false
and MasterNotes.PickedFullIndicator = false
Order by importStamp 



