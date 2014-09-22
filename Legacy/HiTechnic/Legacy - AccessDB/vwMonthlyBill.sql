Create View vwMonthlyBill as
SELECT "Lego Toy Parts" AS Description
		, DailyFINAL2.Customer
		, DailyFINAL2.RefNumber
		, DailyFinal2.TxnDate
		, dbo_arshtfil2_sql.Tracking_No
		, Sum([TxnLine Amount]) as Amnt
		, Sum(DailyFINAL2.[TxnLine Quantity]) AS Qty
		, Sum([TxnLine Amount])/Sum([TxnLine Quantity]) as QtyAmnt
		, Sum(DailyFINAL2.Weight) AS Weight
		, First(DailyFINAL2.[Ship To Country]) AS Country
		, First(DailyFINAL2.[Bill To Line1]) AS [Bill To Line1]
		, First(DailyFINAL2.[Bill To Line2]) AS [Bill To Line2]
		, First(DailyFINAL2.[Bill To Line3]) AS [Bill To Line3]
		, First(DailyFINAL2.[Bill To Line4]) AS [Bill To Line4]
		, First(DailyFINAL2.[Bill To City]) AS [Bill To City]
		, First(DailyFINAL2.[Bill To State]) AS [Bill To State]
		, First(DailyFINAL2.[Bill To Postal Code]) AS [Bill To Postal Code]
		, First(DailyFINAL2.[Bill To Country]) AS [Bill To Country]
		, First(DailyFINAL2.[Ship To Line1]) AS [Ship To Line1]
		, First(DailyFINAL2.[Ship To Line2]) AS [Ship To Line2]
		, First(DailyFINAL2.[Ship To Line3]) AS [Ship To Line3]
		, First(DailyFINAL2.[Ship To Line4]) AS [Ship To Line4]
		, First(DailyFINAL2.[Ship To City]) AS [Ship To City]
		, First(DailyFINAL2.[Ship To State]) AS [Ship To State]
		, First(DailyFINAL2.[Ship To Postal Code]) AS [Ship To Postal Code]
		, First(DailyFINAL2.[Ship To Country]) AS [Ship To Country]
		, First(DailyFINAL2.[Cust Email Addr]) AS [Cust Email Addr]
		, First(DailyFINAL2.TelephoneNbr) AS TelephoneNbr
		, First(DailyFINAL2.ThirdPartyMarker) AS ThirdPArtyMarker
		, First(DailyFINAL2.EmailMarker) AS EmailMarker
		, First(DailyFINAL2.ForeignAddressMarker) AS ForeignAddressMarker
		, First(DailyFINAL2.AESNumber) AS AESNumber
		, First(DailyFINAL2.AESNumberMarker) AS AESNumberMarker
		, First(DailyFINAL2.[Ship Method]) AS [Ship Method]
		, First(DailyFINAL2.Complete) AS Complete
		, First(DailyFINAL2.HandCrg) AS HandCrg
		, First(DailyFINAL2.COD) AS COD
		, First(DailyFINAL2.Extra5) AS Extra5
		, First(DailyFINAL2.CountryCode) AS FirstOfCountryCode
		, Max(DailyFINAL2.[PO Number]) AS [PO Number]
		, Max(DailyFINAL2.[FedEx Acc No]) AS [MaxOfFedEx Acc No]
		, iif(isNull([MaxOfFedEx Acc No]) = false,3,1) as BillTo
		, First(DailyFinal2.TS) as TS
		, iif(isNULL(DailyFinal2.SectionB_Code)= true,'9503000000',DailyFinal2.SectionB_Code) as SectionB_Code
		, iif(isNULL(DailyFinal2.SectionB_Description)= true,'TOY parts - LEGO toy robotic accessories',DailyFinal2.SectionB_Description) as SectionB_Description
	
FROM DailyFINAL2
	  Left join dbo_arshtfil2_sql on DailyFinal2.RefNumber = dbo_arshtfil2_sql.Ord_No
GROUP BY "Lego Toy Parts"
	, DailyFINAL2.Customer
	, DailyFINAL2.RefNumber
	, SubTotal
	, DailyFinal2.TxnDate
	, DailyFinal2.TS
	, DailyFinal2.SectionB_Code
	, DailyFinal2.SectionB_Description  
	, dbo_arshtfil2_sql.Tracking_No
