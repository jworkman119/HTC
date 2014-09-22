UPDATE DailyFinal2 
INNER JOIN DailyFinal ON DailyFinal2.RefNumber=DailyFinal.RefNumber 
SET DailyFinal2.PrintMarker = true
;
