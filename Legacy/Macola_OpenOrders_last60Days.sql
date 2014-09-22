drop view htcUPS_Orders

Create View htcUPS_Orders

as

select ltrim(Ord_No) as OrdNo
, status
, ord_dt as OrderDate
, Ship_To_Name as ShipName
, Case Contact_1
	When 'SHIP TO' then
		''
	when '--' then
		''
	else
		Contact_1
	end as Attn
, Ship_To_Addr_1 as ShipAddress1
, Ship_To_Addr_2 as ShipAddress2
, Ship_To_City as ShipCity
, Ship_To_State as ShipState
, Ship_To_Zip as ShipZip
, Ship_To_Country as  ShipCountry
, email_address as Email
, phone_number as Phone
, bill_to_addr_1 as BillAddress1
, bill_to_addr_2 as BillAddress2
, bill_to_City as BillCity
, bill_to_state as BillState
, bill_to_country as BillCountry
, bill_to_zip as BillZip
from Oeordhdr_sql
WHERE Ord_dt > GETDATE()-60

