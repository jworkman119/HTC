/*
	ToDo - Add sql server email feature to email the results to Missy
*/
USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Patient' AND TYPE='P')
	DROP PROCEDURE spFill_Patient
GO

Create Procedure spFill_Patient as

-- inserting comma between first and last name
update datadump
set [patient name] = stuff([patient name],charindex(char(9), [patient name]), 1,',' ) 

-- removing '>'
 update datadump
 set [patient name] = replace([patient name],'>','')

-- removing '*'
update datadump
set [patient name] = replace([patient name], '*','')

-- removing '.'
update datadump
set [patient name] = replace([patient name], '.','')

-- removing '%'
update datadump
set [patient name] = replace([patient name], '%','')

-- removing '#'
update datadump
set [patient name] = replace([patient name], '#','')

-- removing '+'
update datadump
set [patient name] = replace([patient name], '+','')

-- removing '"'
update datadump
set [patient name] = replace([patient name], '"','')
-- removing spaces in commas
/*

update datadump
set [patient name] = replace([patient name],' ,', ',')

update datadump
set [patient name] = replace([patient name],', ', ',')
*/


-- doing rtrim on all names
update datadump
set [patient name] = rtrim([patient name])


-- removing middle initial
update datadump
set [patient name] = left([patient name], len([patient name]) -2)
from datadump
where charindex(' ', rtrim([patient name]),1) > 1
and charindex(' ', rtrim([patient name]),1) = len(rtrim([patient name])) -1

--removing 'iii'
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

--Insert Into Patient(account, FirstName, LastName, DOB, Sex)
SELECT cast(rtrim(account) as int)AS account
	, rtrim(substring([patient name],charindex(',', rtrim([patient name]), 1) +1, len(rtrim([patient name])) - charindex(',', rtrim([patient name]), 1))) AS FirstName
	, rtrim(left([patient name], charindex(',', rtrim([patient name]), 1) - 1)) AS lastname
	, rtrim(DOB) AS DOB
	, rtrim(Sex) AS Sex
INTO #tblTemp
FROM datadump
WHERE charindex(',', rtrim([patient name]), 1) > 0
GROUP BY account
	, [patient name]
	, dob
	, sex

-- Storing Bad Names in table, going to have to send to missy for fixing because they are typos
select Account, FirstName, LastName
Into #tblTemp2
from #tblTemp
where account in (select account
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

Insert Into Patient(Account, FirstName, LastName, DOB, Sex)
Select Distinct Account, FirstName, LastName, DOB, Sex
from #tblTemp


-- updating patient table, have to add a condition where it won't add a patient if he's already entered
--insert into patient
select *
from #tblTemp2

