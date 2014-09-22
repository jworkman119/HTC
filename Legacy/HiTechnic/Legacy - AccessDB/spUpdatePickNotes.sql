UPDATE MASTERNotes 
	INNER JOIN DailyFINAL2 ON MASTERNotes.RefNumber = DailyFINAL2.RefNumber 
SET DailyFINAL2.PickedFullIndicator = MASTERNotes!PickedFullIndicator
	, DailyFINAL2.PickedPartialIndicator = MASTERNotes!PickedPartialIndicator
	, DailyFINAL2.ShippingNotes = MASTERNotes!ShippingNotes
	, DailyFINAL2.InternalNotes = MASTERNotes!InternalNotes
;
