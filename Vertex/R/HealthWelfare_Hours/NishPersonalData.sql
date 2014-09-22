Select PayrollID as EmployeeNumber
	, Personal.GenderCode as Gender
	, Year(Personal.BirthDate) as BirthDate
	, Address.PostalCode as Zip
	, Ethnicity.EthnicGroupDescription as Ethnicity
	, Case Personal.FamilyStatusCode
		When 'M' then
			'Married'
		Else
			'Not Married'
		End as MaritalStatus
	, Case 
		When Veteran.VeteranCode in ('-','N')  then
			null
		When Veteran.VeteranCode is null then
			null
		Else
			'x'
		end as Veteran 
	, Case 
		When Veteran.VeteranCode in ('D','DO','DV') then
			'x'
		End as Veteran
	, convert(varchar(10),Employed.LatestHireDate,101) as HireDate
	, Case
		When Disability.PRI is not null then
			'yes'
		Else
			'no'
	  End as AbilityOne_Eligible
	, Case
		When Disability.PRI is not null then
			'yes'
		Else
			'no'
	  End as Disability
	, Disability.PRI as PrimaryDisability
	, Disability.SEC as AdditionalDisability1
	, Disability.TRI as AdditionalDisability2
	, SSN.NationalID as SSN
	, Person.LastName + ', ' +  Person.FirstName as Employee
	, convert(varchar(10),Personal.BirthDate,101) as BirthDate
	, Family.FamilyStatusDescription as FamilyStatus

	, convert(varchar(10),Employed.PersonStatusEndDate,101) as EndDate
	, Case
		When Employed.PersonStatusEndDate is not null then
			Reason.StatusReasonDescription
		end  as SeperationReason

	, DBComments.PRI as PrimaryDB_Comments

	, DBComments.SEC as SecDB_Comments

	, DBComments.TRI as ThirDB_Comments
	, Disability.FOUR as FourDB	
	, DBComments.FOUR as FourDB_Comments
	, PositionTitle as PrimaryJob
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
	Left Join tPersonJobHist as History on Person.PersonGuid = History.PersonGuid
	Left Join tPosition as Position on History.PositionCode = Position.PositionCode
	left Join (
			Select *
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
		) as Disability on Person.PersonGUID = Disability.PersonGUID
	Left Join
		(		
			Select *
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
		) as DBComments on Person.PersonGUID = DBComments.PersonGUID
where EmployeeFlag = 1
	and StatusCode = 'ACT'
		and(	 
			PersonStatusEndDate is null
				or 
			PersonStatusEndDate >= '1-1-2014' --@StartDate
			)
		and PersonStatusStartDate <= '3-1-2014' --@EndDate	
		and History.PersonJobEndDate is null
Order by Employee


