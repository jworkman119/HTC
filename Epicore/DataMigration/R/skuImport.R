productSKU <- read.csv("~/Temp/productSKU.csv")
skuImport <-productSKU[,c(2,3)]
skuImport <-unique(skuImport)
skuImport["Company"]<-"HTC"
skuImport<-skuImport[,c(3,1,2)]
colnames(skuImport)<-c("Company","SKU", "Description")
write.csv(skuImport,"~/Temp/epicorePartImport.csv",row.names=FALSE,na="")
rm(productSKU,skuImport)