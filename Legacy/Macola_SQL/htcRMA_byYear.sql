use [001]

select Family.Fam1
	, Reason.code_desc
	, Family.Fam2
	, cast(sum(qty_rtrn_to_stk) as int) as Items_Returned
--	, count(Reason.sy_code) as Items
from oelinaud_sql as OE
	join SYCDEFIL_SQL as Reason on OE.Reason_CD = Reason.sy_code
	join zzzhtc_family as Family on OE.item_no = Family.item 
where reason_cd is not null
	and billed_dt > '1/1/2009'
	and family.fam1 in ('coe033', 'coe032')
Group by Family.Fam1, Family.Fam2, Reason.code_desc


