
Select Distinct cdassign.CLIENT_ID
	, cdclient.CASE_NUM
	, cdcldiag.DIAG_ID
	, cdcldiag.PRIORITY
	, cdcldiag.BEG_DATE
	, cdcldiag.END_DATE
	, cdtbl.A4_10 as DiagCode
	, cdtbl.A1_60 as DiagDesc
	, Year(cdassign.DATE_OPENED) as Year
--	, cdassign.DATE_CLOSED
from CDASSIGN as cdassign
	Join CDCLIENT as cdclient on cdclient.ID = cdassign.CLIENT_ID
	Join CDCLDIAG as cdcldiag on cdclient.ID = cdcldiag.CLIENT_ID
	Join CDTBL1 as cdtbl on  cdcldiag.DIAG_ID = cdtbl.ID
WHERE cdclient.ID <> 0 
	AND cdclient.CASE_NUM <> 0 
	and YEAR(cdassign.DATE_OPENED) = 2012
	AND cdassign.VOID_FLAG IS NULL 
	and cdcldiag.PRIORITY <> 99
	AND cdassign.DATE_CLOSED <> DATE_OPENED
	and cdtbl.TYPE = 'DIAG'
	
