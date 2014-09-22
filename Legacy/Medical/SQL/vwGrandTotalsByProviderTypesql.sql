CREATE VIEW [qry grandtotals by provider type] AS 
SELECT [qry monthly totals].month
	, [qry monthly totals].Type
	, Sum([qry monthly totals].SumOfBooked) AS SumOfSumOfBooked
	, Sum([qry monthly totals].NSC) AS SumOfNSC  
FROM [qry monthly totals]  
GROUP BY [qry monthly totals].month
	, [qry monthly totals].Type;