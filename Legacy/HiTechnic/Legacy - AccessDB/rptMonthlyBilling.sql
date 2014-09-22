Create Procedure spRptMonthlyBilling (strDate string) As

select txnDate
	, RefNumber
	, sum([txnLine Quantity]) as quantity
	, '1.25' as [Per Order]
	, switch(sum([txnLine Quantity]) > 19, sum([txnLine Quantity])* 5.00, sum([txnLine Quantity]) <= 19 , format(sum([txnLine Quantity]) * .23, "standard")) as [Per Item]
	, '1.55' as Shipping
from DailyFinal2
where month(txnDate) = month(strDate)
	and year(txnDate) = year(strDate)
group by txnDate, RefNumber;
