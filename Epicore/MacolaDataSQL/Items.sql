-- Testing for git import
Select ItemCode
	, Description
	, CostPriceStandard as Cost
	, SalesPackagePrice as MSRP
from Items
where ItemCode in
(
select distinct item_no
from oeordlin_sql
where request_dt >= '2011-01-01'
)