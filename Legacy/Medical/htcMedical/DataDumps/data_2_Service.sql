Alter Procedure spFill_Service 

As

Insert Into Service (ID, Description, AllottedTime,Units, Weight)
	Select 'BV','Brief Visit',30,2,.05
		Union all
	Select 'C','Cancelation',0,0,0
		Union all
	Select 'CM','Case Management',45,3,1	
		Union all
	Select 'CV','Crisis Visit',45,3,1
		Union all
	Select 'FVOP','Family Visit Without Patient',45,3,1
		Union all
	Select 'FVWP','Family Visit With Patient',45,3,1
		Union all
	Select 'GV','Group Visit',15,1,.35
		Union all
	Select 'ML','Medication Monitoring Long',30,2,.5
		Union all
	Select 'NS','No Show',0,0,0
		Union all
	Select 'PAS ','Pre-Admission Screening',45,3,1
		Union all
	Select 'PASC ','Pre-Admission Screening Cancel',0,0,0
		Union all
	Select 'PASNS','Pre-Admission Screening No Show', 0,0,0
		Union all
	Select 'PE','Psychological Evaluation',45, 3,1
		Union all
	Select 'PM','Medication Monitoring Short',15,1,.35
		Union all
	Select 'RV','Regular Visit',45,3,1
		Union all
	Select 'S1','Interpretive Services 1',15, 1,.35
		Union all
	Select 'S2','Interpretive Services 2',30,2,.5
		Union all
	Select 'S3','Interpretive Services 3',45,3,1
		Union all
	Select 'S4','Interpretive Services 4',60,4,1
		Union all
	Select 'SC','Staff Cancel',0,0,0


