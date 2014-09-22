CREATE VIEW [qry monthly view] AS 

SELECT [qry grand for simple view].year
	, [qry grand for simple view].SumOfSumOfBooked
	, [qry grand for simple view].SumOfNSC
	, [sumofnsc]/[sumofsumofbooked] AS rate
	, [qry grand for simple view].location  
FROM [qry grand for simple view];