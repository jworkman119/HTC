Select Distinct Service.Cust_no
	, Service.Cust_Name 
	, Service.due_date
	, Service.amount
	, Service.doc_date
	, Service.Invoice_Date
--	, Service.po_number 
	, Service.doc_no
	, History.item_desc_1
	, Service.*
from arsrvhsh_sql as Service
	Join arsrvhst_sql as History on Service.doc_no = History.doc_no
where Invoice_Date >= '2014-01-01'
and rtrim(History.item_no) = 'JANITORIAL CFM - IDIQ'
--and left(History.item_desc_1,1) = 'J'
order by Invoice_Date



select *
from arsrvhst_sql
where rtrim(item_no) = 'JANITORIAL CFM - IDIQ'
and item_desc_1 like 'J764GL'

select *
from arsrvfil_sql

