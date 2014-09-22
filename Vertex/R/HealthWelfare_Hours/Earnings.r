StartDay="12/22/2013"
EndDay="3/15/2014"

# Retrieving sql
library(stringr)
setwd("C:/Users/jeremyp.HTC/Documents/Development/R/Earnings")
SQL<-paste(readLines("Earnings.sql",encoding="UTF-8"),collapse=' ')
SQL<-str_replace_all(SQL[1],'\t','')
SQL<-str_replace(SQL[1],'@StartDay',paste("\'",StartDay,"\'",sep=""))
SQL<-str_replace(SQL[1],'@EndDay',paste("\'",EndDay,"\'",sep=""))

#Returning data set to 
library("RODBC", lib.loc="C:/Program Files/R/R-2.15.2/library")
odbc<-odbcConnect("Vertex",uid="sysdba",pwd="masterkey")
Earnings<-data.frame(sqlQuery(odbc,SQL[1]))

odbcCloseAll()
rm(odbc)

colnames(Earnings)<- c("Employee","EmployeeNumber","JobNumber", "JobDescription", "Productivity", "Hours")
Earnings$Productivity<-round(Earnings$Productivity,digits=2)
Earnings$Hours<-round(Earnings$Hours,digits=2)

library("rJava", lib.loc="C:/Program Files/R/R-2.15.2/library")
library("xlsxjars", lib.loc="C:/Program Files/R/R-2.15.2/library")
library("xlsx", lib.loc="C:/Program Files/R/R-2.15.2/library")

setwd("C:/Users/jeremyp.HTC/Documents/Temp")

Sheet<-paste(StartDay,EndDay,sep="_")
WorkBook<-<-paste(Earnings,StartDay,EndDay,sep="_")
write.xlsx(dfFinalReport,"Earnings.xlsx",sheetName=Sheet ,col.names=TRUE,row.names=FALSE,append=FALSE)