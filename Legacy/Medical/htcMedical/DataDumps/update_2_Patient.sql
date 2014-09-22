/*
	ToDo - Add sql server email feature to email the results to Missy
*/
USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Patient' AND TYPE='P')
	DROP PROCEDURE spFill_Patient
GO

Create Procedure spFill_Patient as


--todo move this over to c# program
--removing 'iii'
/*
update datadump
set [patient name] = replace([patient name],substring([patient name],charindex(' ',[patient name])+1,3),'') 
from datadump
where charindex(' ', rtrim([patient name]),1) > 1
	--and substring([patient name], charindex(' ',[patient name]),2) in ('jr','sr','ii','iv')
	and substring([patient name], charindex(' ',[patient name])+1,3) = 'iii'
	
-- removing 'jr', 'sr', 'ii', 'iii', 'iv', 
update datadump
set [patient name] = replace([patient name],substring([patient name],charindex(' ',[patient name])+1 ,2), '')
from datadump
where charindex(' ', rtrim([patient name]),1) > 1
	and (right([patient name],2) in ('jr','sr','ii','iv')
		or substring([patient name], charindex(' ',[patient name])+1,2) in ('jr','sr','ii','iv'))
*/
--Insert Into Patient(account, FirstName, LastName, DOB, Sex)
SELECT cast(account as int)AS account
	, Last_Name
	, First_Name
	, DOB 
	, Sex 
INTO #tblTemp
FROM datadump
GROUP BY account
	, Last_Name
	, First_Name
	, dob
	, sex

-- Flagging Bad Names
Update datadump
Set datadump.BadData = 1
from datadump
where datadump.account in (select account
					from #tbltemp
					group by account
					having count(account) > 1
					)

-- deleting patients with typos.
delete from #tblTemp
where account in (select account
					from #tbltemp
					group by account
					having count(account) > 1
)

-- Adding data to Patient table
Insert Into Patient(Account, FirstName, LastName, DOB, Sex)
Select Distinct Account, First_Name, Last_Name, DOB, Sex
from #tblTemp
where account not in(select account from patient)

drop table #tblTemp

