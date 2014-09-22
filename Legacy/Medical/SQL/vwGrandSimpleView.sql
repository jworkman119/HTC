CREATE VIEW [qry grand for simple view] AS 
SELECT [qry monthly totals].year
	, Sum([qry monthly totals].SumOfBooked) AS SumOfSumOfBooked
	, Sum([qry monthly totals].NSC) AS SumOfNSC
	, [qry monthly totals].location  
FROM [qry monthly totals]  
GROUP BY [qry monthly totals].year
	, [qry monthly totals].location;