--- Temp Table to get Worker's Disability 
Select *
Into #tempDBCode
From(
	Select PersonGUID 
		, DB.DisabilityDescription as DBCode
		, Disability.DisabilityDegreeCode as Degree
	from tPersonDisability as Disability
		join tDisability as DB on Disability.DisabilityCode = DB.DisabilityCode
	Where Disability.DisabilityCode <> 'N'
) as pvDBCode
Pivot(
	max(DBCode)
	for Degree in ([PRI],[SEC],[TRI],[FOUR])
) as pvt


--- Temp Table to get Worker's Disability Comments
Select *
Into #tempDBComments
From(
	Select PersonGUID 
		, Disability.Comments 
		, Disability.DisabilityDegreeCode as Degree
	from tPersonDisability as Disability
	Where Disability.DisabilityCode <> 'N'
) as pvDBComments
Pivot(
	max(Comments)
	for Degree in ([PRI],[SEC],[TRI],[FOUR])
) as pvt2



Select PayrollID as EmployeeNumber
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
	, #tempDBCode.PRI as '1DB'
	, #tempDBComments.PRI as '1DB_Comments'
	, #tempDBCode.SEC as '2DB'
	, #tempDBComments.SEC as '2DB_Comments'
	, #tempDBCode.TRI as '3DB'
	,  #tempDBComments.TRI as '3DB_Comments'
	, #tempDBCode.FOUR as '4DB'	
	,  #tempDBComments.FOUR as '4DB_Comments'
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
	Left Join #tempDBCode on Person.PersonGuid = #tempDBCode.PersonGuid
	Left Join #tempDBComments on Person.PersonGuid = #tempDBComments.PersonGuid
where EmployeeFlag = 1
-- Need to change this to work by date worked
	and StatusCode = 'ACT'
	and StatusCode = 'ACT'
		and(	 
			PersonStatusEndDate is null
				or 
			PersonStatusEndDate >= '9-1-2013' -- StartDate
			)
		and PersonStatusStartDate <= '12-30-2013' -- End Date	
	and Ethnicity.InactiveFlag = 0
Order by Employee




drop table #tempDBCode
drop table #tempDBComments

	