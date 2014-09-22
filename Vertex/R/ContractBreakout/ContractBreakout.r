StartDay="4-1-2013"
EndDay="6-1-2013"

# Retrieving sql
library(stringr)
setwd("C:/Users/jeremyp.HTC/Documents/Development/Vertex/R/contractBreakout")
SQL<-paste(readLines("ContractBreakout.sql",encoding="UTF-8"),collapse=' ')
SQL<-str_replace_all(SQL[1],'\t','')
SQL<-str_replace(SQL[1],'@StartDay',paste("\'",StartDay,"\'",sep=""))
SQL<-str_replace(SQL[1],'@EndDay',paste("\'",EndDay,"\'",sep=""))

#Returning data set to 
library("RODBC", lib.loc="C:/Program Files/R/R-2.15.2/library")
odbc<-odbcConnect("Vertex",uid="sysdba",pwd="masterkey")
ContractBreakout<-data.frame(sqlQuery(odbc,SQL[1]))
colnames(ContractBreakout)<- c("JobCode", "Disability","DisabilityCount", "Employee","HoursWorked")
# ContractBreakout[5]<-round(ContractBreakout[5],digits=2)
odbcCloseAll()
rm(odbc)

dfHours <-	data.frame(aggregate(ContractBreakout$HoursWorked,by=list(JobCode=ContractBreakout$JobCode),FUN=sum))
names(dfHours)[2]<-"Hours"
dfHours[2]<-round(dfHours[2],digits=2)

library("reshape", lib.loc="C:\\Program Files\\R\\R-2.15.2\\library")
ContractBreakout$Employee<-NULL
ContractBreakout$HoursWorked<-NULL
dfDisability <-data.frame(cast(ContractBreakout, JobCode ~ Disability,fun.aggregate = sum, margins="grand_col"))
colnames(dfDisability)<- c("JobCode", "MentalHealth","MentalRetardation", "NonDisabled","Other", "Employees")

dfFinalReport <-merge(dfDisability,dfHours)

setwd("C:\\Users\\jeremyp.HTC\\Documents\\Temp")

library("rJava", lib.loc="C:/Program Files/R/R-2.15.2/library")
library("xlsxjars", lib.loc="C:/Program Files/R/R-2.15.2/library")
library("xlsx", lib.loc="C:/Program Files/R/R-2.15.2/library")

# Saving Health Welfare data to spreadsheet
wsName<-paste(StartDay,"_",EndDay,sep="")
wbName<-paste("ContractBreakout_",wsName,".xlsx",sep="")

WB<- createWorkbook()
shtCB<-createSheet(WB,sheetName=wsName)

rowStyle <- CellStyle(WB) + Font(WB, name='Courier New',heightInPoints=8) 
hdrStyle <- CellStyle(WB) + Font(WB, isBold=TRUE, name='calibri',underline=TRUE,heightInPoints=10)# header
addDataFrame(dfFinalReport, shtCB, startRow=1, startColumn=1, colnamesStyle=hdrStyle, row.names=FALSE,showNA=FALSE,  colStyle=list('1'=rowStyle,'2'=rowStyle,'3'=rowStyle,'4'=rowStyle,'5'=rowStyle,'6'=rowStyle,'7'=rowStyle))
autoSizeColumn(shtCB,colIndex=1:7)
#write.xlsx(dfFinalReport,"ContractBreakout_Final.xlsx",sheetName="10-1-2012_12-31-2012" ,col.names=TRUE,row.names=FALSE,append=FALSE)

# Don't forget to save the workbook ...
setwd("C:/Users/jeremyp.HTC/Documents/Temp")
saveWorkbook(WB, wbName)

rm(ContractBreakout, dfDisability, dfHours, dfFinalReport, EndDay, SQL, StartDay, WB, hdrStyle, rowStyle, shtCB, wbName, wsName)