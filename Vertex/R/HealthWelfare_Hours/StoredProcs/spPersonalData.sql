/***
Drop Procedure htcWorkerInfo

**/
/*
Create Procedure htcWorkerInfo

	@StartDate DateTime
	, @EndDate	DateTime

as
*/
	Declare @StartDate DateTime
	Declare @EndDate DateTime
	
	Set @StartDate = '3-16-2014'
	Set @EndDate = '6-21-2014'

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
	, Reason.TerminationReasonDescription  as SeperationReason
	, Status.TerminationTypeDescription as SeperationType
	, Disability.PRI as PrimaryDB
	, DBComments.PRI as PrimaryDB_Comments
	, Disability.SEC as SecDB
	, DBComments.SEC as SecDB_Comments
	, Disability.TRI as ThirDB
	, DBComments.TRI as ThirDB_Comments
	, Disability.FOUR as FourDB	
	, DBComments.FOUR as FourDB_Comments
	, 'Yes' as EmployeeOfNPA
	, Case PayHist.PayrollCode
		when '9LY' then
			'yes'
		else
			'no'
		End as AbilityOneDirect
	, 'No' as AbilityOneIndirect
	, PositionTitle as PrimaryJob
from tPerson as Person
	join (
			select Person.PersonGUID
					, Status.LatestHireDate 
					, null as PersonStatusEndDate
					, null as StatusCode
					, null as StatusReasonCode
			from tPerson as Person
			  Join tPersonStatusHist as Status on Person.PersonGUID = Status.PersonGUID
			Where StatusCode in ('ACT','TMP')
			and PersonStatusCurrentFlag = 1
			and PersonStatusEndDate is null
			
			UNION 
			
			Select Person.PersonGUID
				, max(Status.LatestHireDate) as LatestHireDate
				, Case When Fired.EffectiveDate > @EndDate then
					null
				  Else 
				  	Fired.EffectiveDate
				  End as PersonStatusEndDate
				, Case When Fired.EffectiveDate > @EndDate then
					null
				  Else 
				  	Fired.TerminationTypeCode
				  End as StatusCode
				, Case When Fired.EffectiveDate > @EndDate then
					null
				  Else 
				  	Fired.TerminationReasonCode
				  End as StatusReasonCode
			From tPerson as Person
				Join tPersonTermination as Fired on Fired.PersonGUID = Person.PersonGUID
				Join tPersonStatusHist as Status on Person.PersonGUID = Status.PersonGUID
			Where Fired.EffectiveDate >= @StartDate
			Group By 
				 Fired.EffectiveDate
				, Person.PersonGUID
				, Fired.TerminationReasonCode
				, Fired.TerminationTypeCode
		)as Employed on Employed.PersonGUID = Person.PersonGUID
	left join tPersonAddress as Address on Address.PersonGUID = Person.PersonGUID
	left join tPersonNationalID as SSN on SSN.PersonGUID = Person.PersonGUID
	left join tPersonal as Personal on Person.PersonGUID = Personal.PersonGUID
	Left Join tEthnicGroup as Ethnicity on Personal.EthnicGroupCode = Ethnicity.EthnicGroupCode
	Left Join tFamilyStatus as Family on Family.FamilyStatusCode = Personal.FamilyStatusCode
	Left Join tPersonVeteran as PVeteran on Person.PersonGUID = PVeteran.PersonGUID
	Left Join tVeteran as Veteran on PVeteran.VeteranCode = Veteran.VeteranCode
	Left Join tTerminationReason as Reason on Employed.StatusReasonCode = Reason.TerminationReasonCode
	Left Join tTerminationType as Status on Employed.StatusCode = Status.TerminationTypeCode
	Left Join (
			Select JobHist.PersonGuid, Position.PositionTitle
			From tPersonJobHist as JobHist
				 Join tPosition as Position on JobHist.PositionCode = Position.PositionCode
			 Join (
			 		Select History.PersonGuid ,max(History.PersonJobStartDate)as StartDate
					From tPersonJobHist as History
					Where
							(
								History.PersonJobEndDate is null
									or
								History.PersonJobEndDate >= @StartDate
							)
						and History.PersonJobStartDate <= @EndDate
					Group by History.PersonGuid
					) as maxPositionDate on JobHist.PersonGuid = maxPositionDate.PersonGuid
					and JobHist.PersonJobStartDate = maxPositionDate.StartDAte
			 ) as Position on Position.PersonGUID = Person.PersonGUID
	left Join (
				Select PayHist1.PersonGUID, PayHist1.PayrollCode
				from  tPersonBasePayHist as PayHist1
					Join (
				Select PayHist.PersonGUID, max(PersonBasePayStartDate) as StartDate
				From tPersonBasePayHist  as PayHist
				Where 
					(PayHist.PersonBasePayEndDate is null
						or 
					 PayHist.PersonBasePayEndDate >= @StartDate
					)
					and PayHist.PersonBasePayStartDate <= @EndDate	
				Group by PayHist.PersonGUID
				) as PayHist2 on PayHist1.PersonGuid = PayHist2.PersonGuid
					and PayHist2.StartDate = PayHist1.PersonBasePayStartDate	
				) as PayHist on Person.PersonGuid = PayHist.PersonGuid
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
Order by Employee