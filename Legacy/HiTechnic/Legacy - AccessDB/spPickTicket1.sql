Create View PickTicketSpecial

as 

SELECT DailyFINAL2.TxnId
	, DailyFINAL2.Customer
	, DailyFINAL2.[Customer Account Number]
	, DailyFINAL2.TxnDate
	, DailyFINAL2.RefNumber
	, DailyFINAL2.Class
	, DailyFINAL2.ARAccount
	, DailyFINAL2.BalanceRemaining
	, DailyFINAL2.[Bill To Line1]
	, DailyFINAL2.[Bill To Line2]
	, DailyFINAL2.[Bill To Line3]
	, DailyFINAL2.[Bill To Line4]
	, DailyFINAL2.[Bill To City]
	, DailyFINAL2.[Bill To State]
	, DailyFINAL2.[Bill To Postal Code]
	, DailyFINAL2.[Bill To Country]
	, DailyFINAL2.[Ship To Line1]
	, DailyFINAL2.[Ship To Line2]
	, DailyFINAL2.[Ship To Line3]
	, DailyFINAL2.[Ship To Line4]
	, DailyFINAL2.[Ship To City]
	, DailyFINAL2.[Ship To State]
	, DailyFINAL2.[Ship To Postal Code]
	, DailyFINAL2.[Ship To Country]
	, DailyFINAL2.[PO Number]
	, DailyFINAL2.Terms
	, DailyFINAL2.[Sales Rep]
	, DailyFINAL2.[Ship Date]
	, DailyFINAL2.[Due Date]
	, DailyFINAL2.[Ship Method]
	, DailyFINAL2.FOB
	, DailyFINAL2.Class1
	, DailyFINAL2.Memo
	, DailyFINAL2.SalesTaxCode
	, DailyFINAL2.SalesTaxItem
	, DailyFINAL2.SalesTaxPercentage
	, DailyFINAL2.SalesTaxTotal
	, DailyFINAL2.Other
	, DailyFINAL2.[TxnLine Service Date]
	, DailyFINAL2.[TxnLine Quantity]
	, DailyFINAL2.[TxnLine Item]
	, DailyFINAL2.[TxnLine Description]
	, DailyFINAL2.[TxnLine Other1]
	, DailyFINAL2.[TxnLine Other2]
	, DailyFINAL2.[TxnLine Cost]
	, DailyFINAL2.[TxnLine Amount]
	, DailyFINAL2.[TxnLine SalesTaxCode]
	, DailyFINAL2.[TxnLine Class]
	, DailyFINAL2.[TxnLine TaxCode]
	, DailyFINAL2.[TxnLine CDNTaxCode]
	, DailyFINAL2.SubTotal
	, DailyFINAL2.[Cust Email Addr]
	, DailyFINAL2.[FedEx Acc No]
	, DailyFINAL2.Weight
	, DailyFINAL2.TelephoneNbr
	, DailyFINAL2.AltPhone
	, DailyFINAL2.ThirdPartyMarker
	, DailyFINAL2.EmailMarker
	, DailyFINAL2.ForeignAddressMarker
	, DailyFINAL2.AESNumber
	, DailyFINAL2.AESNumberMarker
	, DailyFINAL2.ValidItemMarker
	, DailyFINAL2.PickedFullIndicator
	, DailyFINAL2.PickedPartialIndicator
	, DailyFINAL2.ShippingNotes
	, '*'+DailyFinal2.RefNumber+'*' AS BarCode
	, '*'+DailyFINAL2.[TxnLine Item]+'*' AS BarCode_Item
	, '*'+DailyFINAL2.AESNumber+'*' AS BarCode_AES
FROM DailyFINAL2
WHERE (((DailyFINAL2.RefNumber)=Forms!PickTicketForm!Text56));
