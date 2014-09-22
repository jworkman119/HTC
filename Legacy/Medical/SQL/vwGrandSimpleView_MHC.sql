CREATE VIEW [qry grand for simple view MHC] AS
SELECT [qry monthly totals].year
	, Sum([qry monthly totals].SumOfBooked) AS SumOfSumOfBooked
	, Sum([qry monthly totals].NSC) AS SumOfNSC  
FROM [qry monthly totals]  
GROUP BY [qry monthly totals].year;