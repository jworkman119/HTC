StartDay="3-16-2014"
EndDay="6-21-2014"

# Retrieving sql
library(stringr)
setwd("C:/Users/jeremyp.HTC/Documents/Development/Vertex/R/HealthWelfare_Hours")
SQL<-paste(readLines("HealthWelfare.sql",encoding="UTF-8"),collapse=' ')
SQL<-str_replace_all(SQL[1],'\t','')
SQL<-str_replace(SQL[1],'@StartDay',paste("\'",StartDay,"\'",sep=""))
SQL<-str_replace(SQL[1],'@EndDay',paste("\'",EndDay,"\'",sep=""))


#Returning data set to 
library("RODBC", lib.loc="C:/Program Files/R/R-2.15.2/library")
odbc<-odbcConnect("VertexCloud",uid="1403reports",pwd="2260@Dwyer!!")
HealthWelfare<-data.frame(sqlQuery(odbc,SQL[1]))

# Retrieving sql
library(stringr)
setwd("C:/Users/jeremyp.HTC/Documents/Development/Vertex/R/HealthWelfare_Hours")
SQL<-paste(readLines("Hours.sql",encoding="UTF-8"),collapse=' ')
SQL<-str_replace_all(SQL[1],'\t','')
SQL<-str_replace(SQL[1],'@StartDay',paste("\'",StartDay,"\'",sep=""))
SQL<-str_replace(SQL[1],'@EndDay',paste("\'",EndDay,"\'",sep=""))

Hours<-data.frame(sqlQuery(odbc,SQL[1]))
colnames(Hours)<- c("EmployeeNumber", "Employee" ,"CostCenter", "JobNumber", "JobDescription" ,"Productivity","Hours","Earnings","Pieces", "TrainingWage")
Hours$Productivity<-round(Hours$Productivity,digits=2)
Hours$Hours<-round(Hours$Hours,digits=2)
Hours$Earnings<-round(Hours$Earnings,digits=2)
Hours$Productivity<-ifelse(Hours$Productivity==0.00,"",Hours$Productivity)

odbcCloseAll()
rm(odbc)


library("plyr", lib.loc="C:/Program Files/R/R-2.15.2/library")
# getting the job the employee worked the max number of hours at
maxHours <- ddply(Hours, "EmployeeNumber", summarise, Hrs=max(Hours), EmployeeNumber=EmployeeNumber[which.max(Hours)],Employee=Employee[which.max(Hours)],  CostCenter=CostCenter[which.max(Hours)], Job=JobNumber[which.max(Hours)], Description=JobDescription[which.max(Hours)], Productivity=Productivity[which.max(Hours)])
maxHours<- maxHours[,c(2,3,4,5,1,6)]


#Making Adjustments to HealthWelfare
colnames(HealthWelfare)<- c("EmployeeNumber","JobNumber", "HealthWelfare")
HealthWelfare$HealthWelfare<-round(HealthWelfare$HealthWelfare,digits=2)

Hours2 <- Hours[,!(names(Hours) %in% "Employee")]
HealthWelfare<- merge(HealthWelfare, Hours2,by=c("EmployeeNumber","JobNumber"),all.y=TRUE) 
rm(Hours2)
HealthWelfare<-HealthWelfare[,c(1,2,4,5,6,7,8,9,3)]

# Retrieving Personal Data sql
library(stringr)
setwd("C:/Users/jeremyp.HTC/Documents/Development/Vertex/R/HealthWelfare_Hours")
SQL<-paste(readLines("PersonalData.sql",encoding="UTF-8"),collapse=' ')
SQL<-str_replace_all(SQL[1],'\t','')
SQL<-str_replace(SQL[1],'@StartDay',paste("\'",StartDay,"\'",sep=""))
SQL<-str_replace(SQL[1],'@EndDay',paste("\'",EndDay,"\'",sep=""))


#Returning data set to 
library("RODBC", lib.loc="C:/Program Files/R/R-2.15.2/library")
odbc<-odbcConnect("epicorHCM") #,uid="htc\epicadmin",pwd="1YcYrwzr")
PersonalData<-data.frame(sqlQuery(odbc,SQL[1]))

odbcCloseAll()
rm(odbc)

#Getting the nish and other values
HealthWelfare<-HealthWelfare[! is.na(HealthWelfare$JobNumber),]
HealthWelfare$Job<-as.numeric(substr(HealthWelfare$JobNumber,1,1))
HealthWelfare$Job<-ifelse(HealthWelfare$Job == 1, 'Nish', ifelse(HealthWelfare$Job > 2, 'Commercial', 'NYSLD'))


Nish<-HealthWelfare[,(names(HealthWelfare) %in% c("EmployeeNumber","JobNumber", "Hours","Earnings", "HealthWelfare"))]
Nish["Job"]<-as.numeric(substr(Nish$JobNumber,1,1))
Nish$Job<-ifelse(Nish$Job == 1, 'Nish', ifelse(Nish$Job > 2, 'Commercial', 'NYSLD'))
Commercial<-Nish[apply(Nish,1,function(x) {any(!c("Nish") %in% x)}),]
Commercial <- Commercial[,!(names(Commercial) %in% c("JobNumber","Job"))]
Commercial$HealthWelfare[is.na(Commercial$HealthWelfare)]<-0 
Commercial<-ddply(Commercial, c('EmployeeNumber'), function(x) c(Hours=sum(x$Hours),Earnings=sum(x$Earnings),HealthWelfare=sum(x$HealthWelfare)))
colnames(Commercial)<- c("EmployeeNumber","Non-AbilityOne_Hours", "Non-AbilityOne_Earnings" ,"Non-AbilityOne_HealthWelfare")
Commercial['StateUseProject']<-'yes'

Nish<-Nish[apply(Nish,1,function(x) {any(c("Nish") %in% x)}),]
Nish<-Nish[,!(names(Nish) %in% c("JobNumber","Job"))]
Nish$HealthWelfare[is.na(Nish$HealthWelfare)]<-0 
Nish<-ddply(Nish, c('EmployeeNumber'), function(x) c(Hours=sum(x$Hours),Earnings=sum(x$Earnings), HealthWelfare=sum(x$HealthWelfare)))
colnames(Nish)<- c("EmployeeNumber","AbilityOne_Hours", "AbilityOne_Earnings" ,"AbilityOne_HealthWelfare")
Nish['OtherProject']<-'yes'

#Getting primary job info
PrimaryJob<-maxHours[,(names(maxHours) %in% c("EmployeeNumber","Description"))]
colnames(PrimaryJob)<- c("EmployeeNumber","JobDescription")

#Getting Training Wage
TrainingWage<-Hours[,(names(Hours) %in% c("EmployeeNumber","TrainingWage"))]
TrainingWage<-TrainingWage[(TrainingWage$TrainingWage=='yes'),]

#Creating new dataframe for productivity
Productivity <- HealthWelfare[,(names(HealthWelfare) %in% c("EmployeeNumber","Productivity", "CostCenter", "Job"))]

#Removing rows with no productivity, so we can calculate the mean
Productivity<-subset(Productivity,Productivity!="")
#casting productivity from char to numeric
Productivity<-transform(Productivity,Productivity=as.numeric(Productivity))
Productivity <- Productivity[,!(names(Productivity) %in% c("CostCenter","Job"))]
Productivity<-ddply(Productivity, c('EmployeeNumber'), function(x) c(Productivity=round(mean(x$Productivity), digits=2)))
#Adding columns "basis for Productivity", "FLSA14c Certificate"
Productivity['BasisForProductivity']<-'PR'
Productivity['FLSA14c_Certificate']<-'yes'

#dropping columngs Job and Job Description
drops <- c("JobNumber","JobDescription", "CostCenter")
HealthWelfare <- HealthWelfare[,!(names(HealthWelfare) %in% drops)]
HealthWelfare$HealthWelfare[is.na(HealthWelfare$HealthWelfare)]<-0 
HealthWelfare$Pieces[is.na(HealthWelfare$Pieces)]<-0 

HealthWelfare<-ddply(HealthWelfare, c('EmployeeNumber'), function(x) c(TotalHours=sum(x$Hours), TotalEarnings=sum(x$Earnings), Pieces=sum(x$Pieces), TotalHealthWelfare = sum(x$HealthWelfare)))

# Merging personal data, nish, commercial, productivity into final dataset

HealthWelfare<- merge(Nish,HealthWelfare,by=c("EmployeeNumber"),all.y=TRUE)
HealthWelfare<- merge(Commercial,HealthWelfare,by=c("EmployeeNumber"),all.y=TRUE)
HealthWelfare<- merge(TrainingWage,HealthWelfare,by=c("EmployeeNumber"),all.y=TRUE)
HealthWelfare<- merge(PrimaryJob,HealthWelfare,by=c("EmployeeNumber"),all.y=TRUE)
HealthWelfare<- merge(PersonalData,HealthWelfare,by=c("EmployeeNumber"),all.y=TRUE)
HealthWelfare<- merge(HealthWelfare,Productivity,by=c("EmployeeNumber"),all.x=TRUE,all.y=TRUE)


rm(Nish,Commercial, PrimaryJob,PersonalData,Productivity,drops, Hours, TrainingWage)

#Adding Elibible for Fringe Benefits
HealthWelfare['Eligible_FringeBenefits']<-NA
HealthWelfare$Eligible_FringeBenefits<-ifelse(HealthWelfare$TotalHours > 30, 'Yes','No')
#Adding 'BasisForProductivity'
HealthWelfare['BasisForProductivity']<-NA
HealthWelfare$'BasisForProductivity'<-ifelse(HealthWelfare$Productivity>0,'Yes' ,ifelse(HealthWelfare$AbilityOne_HealthWelfare > 0, 'Yes',ifelse(HealthWelfare$'Non-AbilityOne_HealthWelfare' > 0, 'Yes', 'No')))
#Reordering HealthWelfare & Hours by employee
HealthWelfare<-HealthWelfare[order(HealthWelfare[,3]),]
maxHours<-maxHours[order(maxHours[,2]),]

HealthWelfare <- unique(HealthWelfare);


# Creating spreadsheets
library("rJava", lib.loc="C:/Program Files/R/R-2.15.2/library")
library("xlsxjars", lib.loc="C:/Program Files/R/R-2.15.2/library")
library("xlsx", lib.loc="C:/Program Files/R/R-2.15.2/library")

# Saving Health Welfare data to spreadsheet
wsName<-"HealthWelfare"
wbName<-paste("HW_",wsName,".xlsx",sep="")

WB<- createWorkbook()
shtHW<-createSheet(WB,sheetName=wsName)

rowStyle <- CellStyle(WB) + Font(WB, name='Courier New',heightInPoints=8) 
hdrStyle <- CellStyle(WB) + Font(WB, isBold=TRUE, name='calibri',underline=TRUE,heightInPoints=10)# header
addDataFrame(HealthWelfare, shtHW, startRow=1, startColumn=1, colnamesStyle=hdrStyle, row.names=FALSE,showNA=FALSE,  colStyle=list('1'=rowStyle,'2'=rowStyle,'3'=rowStyle,'4'=rowStyle,'5'=rowStyle,'6'=rowStyle,'7'=rowStyle,'8'=rowStyle, '9'=rowStyle, '10'=rowStyle, '11'=rowStyle, '12'=rowStyle, '13'=rowStyle, '14'=rowStyle, '15'=rowStyle, '16'=rowStyle, '17'=rowStyle, '18'=rowStyle, '19'=rowStyle,'20'=rowStyle,'21'=rowStyle,'22'=rowStyle,'23'=rowStyle,'24'=rowStyle,'25'=rowStyle,'26'=rowStyle,'27'=rowStyle,'28'=rowStyle,'29'=rowStyle,'29'=rowStyle,'30'=rowStyle,'31'=rowStyle,'32'=rowStyle,'33'=rowStyle,'34'=rowStyle,'35'=rowStyle,'36'=rowStyle,'37'=rowStyle,'38'=rowStyle,'39'=rowStyle,'40'=rowStyle,'41'=rowStyle,'42'=rowStyle,'43'=rowStyle))
autoSizeColumn(shtHW,colIndex=1:43)

rm(HealthWelfare,SQL, wsName)

#Saving maxHours data to spreadsheet
maxHours$Pieces<-NULL
maxHours$Earnings<-NULL
wsName<-"Hours"

shtHours<-createSheet(WB,sheetName=wsName)
addDataFrame(maxHours, shtHours, startRow=1, startColumn=1, colnamesStyle=hdrStyle, row.names=FALSE,showNA=FALSE,  colStyle=list('1'=rowStyle,'2'=rowStyle,'3'=rowStyle,'4'=rowStyle,'5'=rowStyle,'6'=rowStyle,'7'=rowStyle))
autoSizeColumn(shtHours,colIndex=1:43)


# Don't forget to save the workbook ...
setwd("C:/Users/jeremyp.HTC/Documents/Temp")
saveWorkbook(WB, wbName)
rm(shtHours,shtHW, WB,wsName, EndDay, StartDay,hdrStyle,rowStyle,wbName,maxHours)
