Create PROCEDURE "UpdateDailyFinal2" 
AS INSERT INTO DailyFINAL2 ( 
	TxnId
	, Customer
	, [Customer Account Number]
	, TxnDate
	, RefNumber
	, Class
	, ARAccount
	, BalanceRemaining
	, [Bill To Line1]
	, [Bill To Line2]
	, [Bill To Line3]
	, [Bill To Line4]
	, [Bill To City]
	, [Bill To State]
	, [Bill To Postal Code]
	, [Bill To Country]
	, [Ship To Line1]
	, [Ship To Line2]
	, [Ship To Line3]
	, [Ship To Line4]
	, [Ship To City]
	, [Ship To State]
	, [Ship To Postal Code]
	, [Ship To Country]
	, [PO Number]
	, Terms
	, [Sales Rep]
	, [Ship Date]
	, [Due Date]
	, [Ship Method]
	, FOB
	, Class1
	, [Memo]
	, SalesTaxCode
	, SalesTaxItem
	, SalesTaxPercentage
	, SalesTaxTotal
	, Other
	, [TxnLine Service Date]
	, [TxnLine Quantity]
	, [TxnLine Item]
	, [TxnLine Description]
	, [TxnLine Other1]
	, [TxnLine Other2]
	, [TxnLine Cost]
	, [TxnLine Amount]
	, [TxnLine SalesTaxCode]
	, [TxnLine Class]
	, [TxnLine TaxCode]
	, [TxnLine CDNTaxCode]
	, SubTotal
	, [Cust Email Addr]
	, [FedEx Acc No]
	, TelephoneNbr
	, AltPhone
	, ThirdPartyMarker
	, EmailMarker
	, ForeignAddressMarker
	, AESNumber
	, AESNumberMarker
	, ValidItemMarker
	, TS
	, PrintMarker
	, SectionB_Code
	, SectionB_Description 
	, CountryCode
    , Weight
)
select DailyFinal.[TxnId]
,DailyFinal.[Customer]	
,DailyFinal.[Customer Account Number]
,DailyFinal.[TxnDate]	
,DailyFinal.[RefNumber]	
,DailyFinal.[Class]	
,DailyFinal.[ARAccount]	
,DailyFinal.[BalanceRemaining]	
,DailyFinal.[Bill To Line1]	
,DailyFinal.[Bill To Line2]	
,DailyFinal.[Bill To Line3]	
,DailyFinal.[Bill To Line4]	
,DailyFinal.[Bill To City]	
,DailyFinal.[Bill To State]	
,DailyFinal.[Bill To Postal Code]	
,DailyFinal.[Bill To Country]	
,DailyFinal.[Ship To Line1]	
,DailyFinal.[Ship To Line2]	
,DailyFinal.[Ship To Line3]	
,DailyFinal.[Ship To Line4]	
,DailyFinal.[Ship To City]	
,DailyFinal.[Ship To State]	
,DailyFinal.[Ship To Postal Code]	
,DailyFinal.[Ship To Country]	
,DailyFinal.[PO Number]	
,DailyFinal.[Terms]	
,DailyFinal.[Sales Rep]	
,DailyFinal.[Ship Date]	
,DailyFinal.[Due Date]	
,DailyFinal.[Ship Method]	
,DailyFinal.[FOB]	
,DailyFinal.[Class1]	
,DailyFinal.[Memo]	
,DailyFinal.[SalesTaxCode]	
,DailyFinal.[SalesTaxItem]	
,DailyFinal.[SalesTaxPercentage]	
,DailyFinal.[SalesTaxTotal]	
,DailyFinal.[Other]	
,DailyFinal.[TxnLine Service Date]
,DailyFinal.[TxnLine Quantity]	
,DailyFinal.[TxnLine Item]	
,DailyFinal.[TxnLine Description]
,DailyFinal.[TxnLine Other1]	
,DailyFinal.[TxnLine Other2]	
,DailyFinal.[TxnLine Cost]	
,DailyFinal.[TxnLine Amount]	
,DailyFinal.[TxnLine SalesTaxCode]	
,DailyFinal.[TxnLine Class]	
,DailyFinal.[TxnLine TaxCode]	
,DailyFinal.[TxnLine CDNTaxCode]	
,DailyFinal.[SubTotal]	
,DailyFinal.[Cust Email Addr]	
,DailyFinal.[FedEx Acc No]	
,DailyFinal.[TelephoneNbr]	
,DailyFinal.[AltPhone]	
,DailyFinal.[ThirdPartyMarker]	
,DailyFinal.[EmailMarker]	
,DailyFinal.[ForeignAddressMarker]	
,DailyFinal.[AESNumber]	
,DailyFinal.[AESNumberMarker]	
,DailyFinal.[ValidItemMarker]	
, Now () AS XX
, -1 AS CC
, iif(DailyFinal.[Ship To Country] = 'Great Britain', '8473300002', '9503000000') AS SectionB_Code
, iif(DailyFinal.[Ship To Country] = 'Great Britain', 'Electronic Sensor', 'TOY parts - LEGO toy robotic accessories') AS SectionB_Description
, iif(DailyFinal.ForeignAddressMarker = 'Y', ShipTo.Code,'US') AS CountryCode
, Parts.Weight
FROM (((dailyfinal LEFT JOIN CountryTrans AS ShipTo ON DailyFinal.[Ship To Country] = ShipTo.Country) LEFT JOIN CountryTrans AS BillTo ON DailyFinal.[Bill To Country] = BillTo.Country) LEFT JOIN [SELECT refnumber,ts FROM dailyfinal2]. AS B ON DailyFinal.Refnumber = B.RefNumber) LEFT JOIN Parts ON DailyFINAL.[TxnLine Item] = Parts.Part
Where B.Refnumber is null