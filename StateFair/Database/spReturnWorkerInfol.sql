/* 
	drop procedure returnWorkerInfo
*/

CREATE PROCEDURE returnWorkerInfo (IN WorkerID int)

	Select concat(FirstName,' ' , LastName) as Person
		, replace(PicPath,'/','@') as PicPath
		, Case
			When Gender='f' then
				'female'
			else
		 		'male'
			End as Gender
		, Role.Description as Job
		, Case 
			When Under18=false then
				'No'
			Else
				'Yes'
		 End as Under18
		, Case When Disabled=false then
			'No'
		  Else
		  	'Yes'
		  End as Disabled
		, Phone
		, Case
			When Driver=false then
				'No'
			Else
				'Yes'
		 End as Driver
		
	from Person
		Join Role on Person.Role_ID = Role.ID
	Where Person.ID = WorkerID
			

	
	
		
	
