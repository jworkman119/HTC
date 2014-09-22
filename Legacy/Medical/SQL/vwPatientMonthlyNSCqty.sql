CREATE VIEW [qry Patient monthly NSC qty] AS 

SELECT data.[PATIENT NAME]
	, Month([date]) AS [month]
	, Year([date]) AS [year]
	, data.PROVIDER
	, Count(data.PROC) AS Booked
	, Sum(IIf([proc]="c",1,0)) AS C
	, Sum(IIf([proc]="ns",1,0)) AS NS
	, Sum(IIf([proc]="pasns",1,0)) AS PASNS
	, Sum(IIf([proc]="pasc",1,0)) AS PASC
	, Sum(IIf([proc]="sc",1,0)) AS SC
	, data.LOCATION  
FROM data 
	INNER JOIN Providers ON data.PROVIDER = Providers.PROVIDER  
GROUP BY data.[PATIENT NAME]
	, Month([date])
	, Year([date])
	, data.PROVIDER
	, data.LOCATION  
HAVING (((Year([date]))=2009) 
	AND ((Sum(IIf([proc]="c",1,0)))>0)) 
	OR 
		(((Sum(IIf([proc]="ns",1,0)))>0)) 
	OR 
		(((Sum(IIf([proc]="pasns",1,0)))>0)) 
	OR 
		(((Sum(IIf([proc]="pasc",1,0)))>0)) 
	OR 
		(((Sum(IIf([proc]="sc",1,0)))>0));
