CREATE VIEW [qry 2009 Provider grandtotals by booked and noshow rates] AS
	 SELECT [qry monthly totals].year
	, [qry monthly totals].PROVIDER
	, Sum([qry monthly totals].SumOfBooked) AS SumOfSumOfBooked
	, Sum([qry monthly totals].NSC) AS SumOfNSC
	, Avg([nsc]/[SumOfbooked]) AS NSCRate  
FROM [qry monthly totals]  
GROUP BY [qry monthly totals].year, [qry monthly totals].PROVIDER  
HAVING ((([qry monthly totals].year)=2009));