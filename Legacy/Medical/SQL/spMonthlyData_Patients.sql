SELECT Month([date]) AS [month]
	, Year([date]) AS [year]
	, data.PROVIDER
	, data.[PATIENT NAME]
	, Count(data.PROC) AS Booked
	, Sum(IIf([PROC]="bv",1,0)) AS BV
	, Sum(IIf([proc]="gv",1,0)) AS GV
	, Sum(IIf([proc]="fvwp",1,0)) AS FVWP
	, Sum(IIf([proc]="pas",1,0)) AS PAS
	, Sum(IIf([proc]="fvop",1,0)) AS FVOP
	, Sum(IIf([proc]="cv",1,0)) AS CV
	, Sum(IIf([proc]="rv",1,0)) AS RV
	, Sum(IIf([proc]="pm",1,0)) AS PM
	, Sum(IIf([proc]="ml",1,0)) AS ML
	, Sum(IIf([proc]="pe",1,0)) AS PE
	, Sum(IIf([proc]="c",1,0)) AS C
	, Sum(IIf([proc]="ns",1,0)) AS NS
	, Sum(IIf([proc]="pasns",1,0)) AS PASNS
	, Sum(IIf([proc]="pasc",1,0)) AS PASC
	, Sum(IIf([proc]="sc",1,0)) AS SC
	, data.LOCATION, Providers.Type
FROM data 
	INNER JOIN Providers ON data.PROVIDER = Providers.PROVIDER
GROUP BY Month([date])
	, Year([date])
	, data.PROVIDER
	, data.[PATIENT NAME]
	, data.LOCATION
	, Providers.Type
HAVING (((Month([date])) Between [enter First month] 
	And [enter last month]) 
	AND ((Year([date]))=[enter year]))
ORDER BY data.[PATIENT NAME]
;
