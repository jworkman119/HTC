select  Location.vend_no as Vendor#
        ,isnull(Vendors.cmp_name, 'zzz No Vendor Listed') as Vendor
		, Family.fam1 as FamilyCode
   		, family.fam2 as FamilyDescription
		, cast(sum(oe.qty_ordered)as Int) as Qty
		, cast(Round(Avg(Location.Price), 2) as Decimal(18,2)) CurrentPrice
		, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
       , Year(oe.billed_dt) as Year
into #tblTemp
from  oelinhst_sql as OE 	 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
    join items on OE.item_no = items.ItemCode
    join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	left join zzzhtc_family as Family on items.itemcode = Family.item
where year(billed_dt) >= 2009
		and year(billed_dt) < year(getdate())
	and items.warehouse in (700,730)
	and Customers.ClassificationID in ('usf','ace')
	and qty_ordered = qty_to_ship
	and Orders.status = 'p'
	and Orders.rma_no is null
group by 
	Location.vend_no
	, Location.Price
	,Vendors.cmp_name
	, family.fam1
    , items.CostPriceStandard
	, family.fam2
	, year(oe.billed_dt) 
order by Vendor, Year, familycode 
			
			
-- getting boots			
			select 
				left(items.ItemCode,5) as ItemCode	
				, cast(sum(oe.qty_ordered)as Int) as Qty
				, Location.price as CurrentPrice
				, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as CostPrice
				, Year(oe.billed_dt) as Year
			into #tblTemp2
			from oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
				join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
					and oe.inv_no = orders.inv_no
				join items on OE.item_no = items.ItemCode
				join iminvloc_sql as Location on items.ItemCode = Location.Item_no	
			
			where left(items.ItemCode, 5) like 'A160%'
				and (items.Description like '%boot%'
						or items.Description like '%shoe%')
				and year(billed_dt) >= 2009
				and year(billed_dt) < year(getdate())
				and qty_ordered = qty_to_ship
				and Orders.status = 'p'
				and Orders.rma_no is null
			group by items.itemcode
				, oe.billed_dt
				, Location.price 
				, items.CostPriceStandard
				
				
				
				
				select '200400' as Vendor#
					, 'Barclay' as Vendor
					,  ItemCode as FamilyCode
					, Case ItemCode
						When 'A1605' then
							'Polishable Boots'
						When 'A1606' then
							'Work Boot'
						When 'A1608' then
							'Ladies Inmate Boot'
						When 'A1609' then
							'Work Shoe'
						End as FamilyDescription
					, sum(Qty) as Qty
					, cast(Round(Avg(CurrentPrice), 2) as Decimal(18,2)) CurrentPrice
					, cast(Round(Avg(CostPrice), 2) as Decimal(18,2)) CostPrice
					, Year
				from #tblTemp2
				group by ItemCode
					, Year
				order by ItemCode
									
				union 
				
				select Vendor#
					, Vendor
					, FamilyCode
					,FamilyDescription
					, Qty
					, CurrentPrice
					, CostPrice
					, Year
				from #tblTemp
									
				--drop table #tblTemp
				--drop table #tblTemp2