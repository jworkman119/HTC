CREATE VIEW [qry monthly grand totals with all data] AS 

SELECT [qry grandtotals].PROVIDER
	, [qry monthly data].year
	, [qry monthly data].BV
	, [qry monthly data].GV
	, [qry monthly data].FVWP
	, [qry monthly data].PAS
	, [qry monthly data].FVOP
	, [qry monthly data].CV
	, [qry monthly data].RV
	, [qry monthly data].PM
	, [qry monthly data].ML
	, [qry monthly data].PE
	, [qry grandtotals].SumOfBooked
	, [qry grandtotals].NSC
	, [qry grandtotals].NSCRate
	, [qry monthly data].LOCATION  
FROM [qry grandtotals] 
	INNER JOIN [qry monthly data] ON [qry grandtotals].PROVIDER=[qry monthly data].PROVIDER  
WHERE [qry grandtotals].PROVIDER Not Like 'screen*';