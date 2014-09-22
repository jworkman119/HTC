CREATE VIEW [qry grandtotals] AS 
SELECT [qry monthly totals].year
	, [qry monthly totals].month
	, [qry monthly totals].PROVIDER
	, [qry monthly totals].SumOfBooked
	, [qry monthly totals].NSC
	, [nsc]/[SumOfbooked] AS NSCRate
	, [qry monthly totals].location  
FROM [qry monthly totals]  
WHERE ((([qry monthly totals].PROVIDER) Not Like "screen*"));