CREATE VIEW [qry 2009 petty totals] AS

SELECT Providers.PROVIDER
	, Providers.Type
	, Sum([qry monthly data].Booked) AS SumOfBooked
	, Sum([c]+[sc]+[ns]+[pasns]+[pasc]) AS NSC
	, [qry monthly data].month
	, Providers.location
	, [qry monthly data].year  
FROM [qry monthly data] 
	INNER JOIN Providers ON [qry monthly data].PROVIDER=Providers.PROVIDER  
GROUP BY Providers.PROVIDER
	, Providers.Type
	, [qry monthly data].month
	, Providers.location
	, [qry monthly data].year  
HAVING (((Providers.PROVIDER) Like "*petty*") AND (([qry monthly data].year)=2009));