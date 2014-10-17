Declare @StartDay DateTime;
Declare @EndDay DateTime;

Set @StartDay = '7/1/2014';
Set @EndDay = '9/30/2014';

select  Employee
	, EmpNumber
	, Disability
	, CostCenter
	, Month
	, Year
	, round(sum(Hours),2) as Hours
	, round(sum(Units),2) as Units
	, sum(Third) as Third
	, sum(Half) as Half
	, sum(FullTime) as FullTime
From	
(
	Select VertexData.*
		,Case 
			When Hours>=5 then
				1
			When Hours< 5 and  Hours >=  3 then
				.5
			When Hours< 3 and  Hours >= .10 then
				.3
			else
				0
	   	end as Units
		, Case  
			When Hours< 3 and  Hours >= .10 then
				1
		end as Third
		, Case   
			When Hours< 5 and  Hours>=  3  then
				1
		end as Half
		, Case 
			When Hours >=5 then
				1
		end as FullTime
	
	from (
			Select 
				Pers.Last_Name + ', ' + Pers.First_Name  as Employee
				, Employee.emp_number * 1 as EmpNumber
				, pp.payroll_program_name as Disability
				, pp.payroll_program_code as DisabilityCode
				
				, pt.pt_emp_cost_center_dsc as CostCenter
				, month(pt.pt_Time_Date) as Month
				, day(pt.pt_time_date) as Date
				, year(pt.pt_time_date) as Year
				, Round(sum(PT.Pt_Time_Hours * 24),1) as Hours
			From INTERBASE_VERTEXREHABMANAGEMENT...employee
				Join INTERBASE_VERTEXREHABMANAGEMENT...payroll_program PP on PP.payroll_program_id = employee.emp_payroll_program_id
				Join INTERBASE_VERTEXREHABMANAGEMENT...Productivity_Transaction pt on pt.pt_emp_number = Employee.emp_number
				Join INTERBASE_VERTEXREHABMANAGEMENT...T$Person Pers on (Employee.emp_number * 1) = Pers.Person_ID
			Where PT.PT_Time_Date >= @StartDay
				and PT.PT_Time_Date <=  @EndDay 
				and PP.payroll_program_id = employee.emp_payroll_program_id
			Group by
				Pers.Last_Name 
				, Pers.First_Name  
				, Employee.emp_number
				, pp.payroll_program_name 
				, pp.payroll_program_code 
				, pt.pt_emp_cost_center_dsc
				, pt.pt_Time_Date
	
		) as VertexData
	) as CalculatedData
group by
	Employee
	, EmpNumber
	, Disability
	, CostCenter
	, Month
	, Year
	

Union

select  Employee
	, EmpNumber
	, Disability
	, CostCenter
	, Month
	, Year
	, round(sum(Hours),2) as Hours
	, round(sum(Units),2) as Units
	, sum(Third) as Third
	, sum(Half) as Half
	, sum(FullTime) as FullTime
From

(	
	(
		Select 
			Person.LastName + ', ' + Person.FirstName as Employee
			, Employee.EmployeeNumber as EmpNumber
			, PP.PayrollProgramName as Disability
			, Dept.DepartmentName as CostCenter
			, convert(varchar,TimeDate,101) as Day
			, sum(Hours * 24) as Hours
			, month(TimeDate) as 'Month'
			, year(TimeDate) as 'Year'
			,Case 
					When sum(Hours * 24) >=5 then
						1
					When sum(Hours * 24)< 5 and  sum(Hours * 24) >=  3 then
						.5
					When sum(Hours * 24)< 3 and  sum(Hours * 24) >= .10 then
						.3
					else
						0
			   	end as Units
				, Case  
					When sum(Hours * 24)< 3 and  sum(Hours * 24) >= .10 then
						1
				end as Third
				, Case   
					When sum(Hours * 24)< 5 and  sum(Hours * 24)>=  3  then
						1
				end as Half
				, Case 
					When sum(Hours * 24) >=5 then
						1
				end as FullTime
		from Person
			Join Employee on Person.PersonID = Employee.EmployeeID
			Join PayrollProgram as PP on Employee.PayrollProgramId = PP.PayrollProgramID
			Join Department as Dept on Employee.DepartmentID = Dept.DepartmentID
			Join LaborHistory on Employee.EmployeeId = LaborHistory.EmployeeID	
		Where  LaborHistory.TimeDate >= @StartDay
			and LaborHistory.TimeDate <= @EndDay
		Group By Employee.EmployeeNumber
			, Person.LastName
			, Person.FirstName 
			, PP.PayrollProgramName
			, Dept.DepartmentName
			, LaborHistory.TimeDate
	)  
	Union
	 (
			Select Person.LastName + ', ' + Person.FirstName as Employee
			, Employee.EmployeeNumber as EmpNumber
			, PP.PayrollProgramName as Disability
			, Dept.DepartmentName as CostCenter
			, convert(varchar,TimeRecordDate,101) as Day
			, sum(Hours * 24) as Hours
			, month(TimeRecordDate) as 'Month'
			, year(TimeRecordDate) as 'Year'
	
			,Case 
					When sum(Hours * 24) >=5 then
						1
					When sum(Hours * 24)< 5 and  sum(Hours * 24) >=  3 then
						.5
					When sum(Hours * 24)< 3 and  sum(Hours * 24) >= .10 then
						.3
					else
						0
			   	end as Units
				, Case  
					When sum(Hours * 24)< 3 and  sum(Hours * 24) >= .10 then
						1
				end as Third
				, Case   
					When sum(Hours * 24)< 5 and  sum(Hours * 24)>=  3  then
						1
				end as Half
				, Case 
					When sum(Hours * 24) >=5 then
						1
				end as FullTime
			From Person
				Join Employee on Person.PersonID = Employee.EmployeeID
				Join PayrollProgram as PP on Employee.PayrollProgramId = PP.PayrollProgramID
				Join Department as Dept on Employee.DepartmentID = Dept.DepartmentID
				Join TimeRecord on Person.PersonID = TimeRecord.PersonID
			Where TimeRecordDate >= @StartDay
				and TimeRecordDate <= @EndDay
			Group By Employee.EmployeeNumber
					, Person.LastName
					, Person.FirstName 
					, PP.PayrollProgramName
					, Dept.DepartmentName
					, TimeRecord.TimeRecordDate	
	) 
) as TSQL_Data	
group by
	Employee
	, EmpNumber
	, Disability
	, CostCenter
	, Month
	, Year
Order by Employee