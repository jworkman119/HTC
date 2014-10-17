Select Distinct PayrollID as EmployeeNumber
	, SSN.NationalID as SSN
	, Person.LastName + ', ' +  Person.FirstName as Employee
	, Address.PostalCode as Zip
	, convert(varchar(10),Personal.BirthDate,101) as BirthDate
	, Ethnicity.EthnicGroupDescription as Ethnicity
	, Personal.GenderCode as Gender
	, Family.FamilyStatusDescription as FamilyStatus
	, Veteran.VeteranDescription as Veteran
	, convert(varchar(10),Employed.LatestHireDate,101) as StartDate
	, convert(varchar(10),Employed.PersonStatusEndDate,101) as EndDate
	, Case
		When Employed.PersonStatusEndDate is not null then
			Reason.StatusReasonDescription
		end  as SeperationReason
from tPerson as Person
	join tPersonStatusHist as Employed on Employed.PersonGUID = Person.PersonGUID
	left join tPersonAddress as Address on Address.PersonGUID = Person.PersonGUID
	left join tPersonNationalID as SSN on SSN.PersonGUID = Person.PersonGUID
	left join tPersonal as Personal on Person.PersonGUID = Personal.PersonGUID
	Left Join tEthnicGroup as Ethnicity on Personal.EthnicGroupCode = Ethnicity.EthnicGroupCode
	Left Join tFamilyStatus as Family on Family.FamilyStatusCode = Personal.FamilyStatusCode
	Left Join tPersonVeteran as PVeteran on Person.PersonGUID = PVeteran.PersonGUID
	Left Join tVeteran as Veteran on PVeteran.VeteranCode = Veteran.VeteranCode
	Left Join tStatusReason as Reason on Employed.StatusReasonCode = Reason.StatusReasonCode
	Join (
			select Distinct PayHist.PersonGUID
			from tPersonBasePayHist as PayHist
			Join tPerson as Person on PayHist.PersonGUID = Person.PersonGUID
			where (
					PersonBasePayEndDate is null
					or
					PersonBasePayEndDate >= '6-22-2014' -- StartDate
					)
				 and PersonBasePayStartDate <= '9-13-2014' -- EndDate
				 and PayrollCode = '9L0'
	) as PayHist on Person.PersonGUID = PayHist.PersonGUID
where EmployeeFlag = 1
-- Need to change this to work by date worked
	and StatusCode = 'ACT'
	and(	 
			PersonStatusEndDate is null
				or 
			PersonStatusEndDate >= '6-22-2014' -- StartDate
			)
		and PersonStatusStartDate <= '9-13-2014' -- End Date	
	and Ethnicity.InactiveFlag = 0
Order by Employee

