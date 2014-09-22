/* Vendors */
Select *
from cicmpy as Company 
where DivisionCreditorID is not null
and cmp_status = 'A'

/* Customers */
Select *
from cicmpy as Company 
where DivisionDebtorID is not null
and cmp_status = 'A'