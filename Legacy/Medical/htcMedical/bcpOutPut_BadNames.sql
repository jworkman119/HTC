DECLARE @sql varchar(8000)

SELECT @sql = 'bcp "SELECT account
					FROM htcMedical..tblTemp
					GROUP BY account
					HAVING count(account) > 1
				" 
				queryout c:\bcpTest.csv -c -t, -T -Ssqlserver01'

EXEC master..xp_cmdshell @sql


