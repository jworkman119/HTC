# Getting the mulplier, which is the no. of business days in month * 7.5
library(lubridate)
 mth = ifelse(month(Sys.time())==1,12,month(Sys.time()) -1)
#mth = 11
 yr = ifelse(mth==12,year(Sys.time())-1,year(Sys.time()))
# yr=2013
yr<-paste(yr,"-01-01",sep="")
library(plyr)
Days<-seq(as.Date(yr), by="1 day", length.out=365)
dfDays <- data.frame(Date=Days,  Month=month(Days))
dfDays$BusinessDay<-wday(dfDays$Date)
dfDays<-subset(dfDays,dfDays$Month==mth & dfDays$BusinessDay>1 & dfDays$BusinessDay<7)
Multiplier<-nrow(dfDays)*7.5
StartDay<-as.character.Date(min(dfDays$Date))
EndDay<-as.character.Date(max(dfDays$Date))
rm(dfDays)
rm(Days)
rm(mth)

# Retrieving sql
library(stringr)
setwd("C:/Users/jeremyp.HTC/Documents/Development/Vertex/R/FTE")
SQL<-paste(readLines("fte_rVertex.sql",encoding="UTF-8"),collapse=' ')
SQL<-str_replace_all(SQL[1],'\t','')
SQL<-str_replace(SQL[1],'@StartDay',paste("\'",StartDay,"\'",sep=""))
SQL<-str_replace(SQL[1],'@EndDay',paste("\'",EndDay,"\'",sep=""))
# SQL<-str_replace(SQL[1],'@Multiplier',Multiplier)

#Returning data set to 
library("RODBC", lib.loc="C:/Program Files/R/R-2.15.2/library")
odbc<-odbcConnect("Vertex",uid="sysdba",pwd="masterkey")
FTE<-data.frame(sqlQuery(odbc,SQL[1]))
FTE$HOURS<-round(FTE$HOURS,digits=2)
odbcCloseAll()
rm(odbc)

#dfHours<-data.frame(aggregate(FTE$HOURS,by=list(CostCenter=FTE$COSTCENTER,Job=FTE$JOB,Description=FTE$JOBDESCRIPTION, DisabilityCode=FTE$DISABILITYCODE),FUN=sum))
colnames(FTE)<- c("CostCenter","Job","Description", "Disability", "Hours")


# breaking up data between Disabled, Non-Disabled
FTE$Disability= ifelse(FTE$Disability!=3,"Disabled","NonDisabled")
FTE<-data.frame(aggregate(FTE$Hours,by=list(CostCenter=FTE$CostCenter,Job=FTE$Job,Description=FTE$Description,Disabled=FTE$Disability), FUN=sum))

#performing calculation to get FTE
names(FTE)[5]<-"FTE"
FTE$FTE<-round(FTE$FTE/Multiplier, digits=2)


# Merging data so I can pivot
FTE<-data.frame(within(FTE, Value <- paste(CostCenter, Job,Description, sep='|')))

# Removing Cost Center & Job, reordering columns so I can pivot dataset
FTE<-FTE[,c(6,4,5)]

library("reshape", lib.loc="C:\\Program Files\\R\\R-2.15.2\\library")
FTE <- data.frame(cast(FTE, Value ~ Disabled,value="FTE"))

FTE= data.frame(transform(FTE, new= colsplit(FTE$Value, split = "\\|", names = c('CostCenter', 'JobCode','Description'))))
FTE<-FTE[,c(4,5,6,2,3)]
colnames(FTE)<- c("CostCenter","Job","Description", "Disabled", "NonDisabled")


write.csv(FTE,"C:/Users/jeremyp.HTC/Documents/Temp/FTE.csv",row.names=FALSE,na="0")

# removing objects from memory
rm(FTE,StartDay,EndDay,Multiplier,SQL,yr)
