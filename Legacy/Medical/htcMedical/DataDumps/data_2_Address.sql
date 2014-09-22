USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spFill_Address' AND TYPE='P')
	DROP PROCEDURE spFill_Address
GO


Create Procedure spFill_Address as 

-- Adding new users to table
Insert Into Address(Patient_Account,zip)
select distinct Patient.Account
	, DataDump.zipcode
from patient
	join DataDump on Patient.Account = DataDump.Account
order by Patient.account

-- Setting Current Address for people that don't have multiple entries
update Address
set CurrentAddress = 1
from Address
where Patient_Account in(Select Patient_Account 
					From Address
					group by Patient_Account
					having count(Patient_Account) = 1
				)

-- finding last zip code
select DataDump.Account 
	 , DataDump.zipcode
	 , max(cast(DataDump.Date as datetime)) as LastVisit
into #tblTemp
from DataDump
where DataDump.Account in (
					select Patient_Account
					from Address
					group by Patient_Account
					having count(Patient_Account) > 1
)
group by DataDump.Account, DataDump.ZipCode
having zipcode is not null
	and zipcode <> '11111'

-- setting current addres for people that have multiple addresses
update Address 
Set CurrentAddress = 1
from Address
	join #tblTemp on Address.Patient_Account = #tblTemp.Account
		and #tblTemp.ZipCode = Address.Zip

drop table #tblTemp


-- people who need there zip codes updated
select Patient.Account as Account
	 , Patient.LastName + ', ' +  Patient.FirstName as Patient
	, max(cast(DataDump.Date as datetime)) as LastVisit
into #tblTemp2
from Patient
	join Address on patient.Account = Address.Patient_Account
	join DataDump on Patient.Account = DataDump.Account
where Patient.Account in (
					select Patient_Account
					from Address
					group by Patient_Account
					having count(Patient_Account) > 1
						
)
group by Patient.Account, Patient.LastName, Patient.FirstName, DataDump.ZipCode
having zipcode is null
	or zipcode = '11111'

Update Address
Set CurrentAddress = 0
from Address
	Join #tblTemp2 on #tblTemp2.Account = Address.Patient_Account
where Address.Patient_Account = #tblTemp2.Account

-- Spitting back rows that need to be updated
select patient.account
	, patient.LastName + ', ' + patient.FirstName as Patient
from patient
	join #tblTemp2 on Patient.Account = #tblTemp2.Account


drop table #tblTemp2