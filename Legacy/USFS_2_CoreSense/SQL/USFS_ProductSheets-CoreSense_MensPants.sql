select distinct 
	Items.ItemCode as [Label]
	
	, Items.Description as [Internal Sku]
	, Items.Description
	, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as Default_Cost
	, left(Right(Items.ItemCode,3), 2)as Waist
	, Inseam
	, Right(Items.ItemCode,1) as Rise /* need to add case statemtn */
	, xscItems.Color
	, Family.Fam2 as Product_Name
	, xscItems.Description as [Product Description]
	, Family.Fam1 as [Part Number]
	, rtrim(Family.Fam1) + '.jpg'  as ImageLocation
	, rtrim(Family.Fam1) + '.jpg'  as MainImage
	, rtrim(Family.Fam1) + '.jpg' as LargeImage
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Web Base Price]
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Soi Base Price]
	, Items.Description as [Soi Description Text]
	, rtrim(Family.Fam1) + '.jpg' as [Soi Image Location]

Into #Temp
From Items
	left Join xscItems/*zcolor */ on Items.ItemCode = xscItems.[Part No.]
	join zzzhtc_family as Family on items.itemcode = Family.item 
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
--	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
where left(items.itemcode,5) = 'fs400'

/*items.warehouse = 700
	and (
		 /*left(items.itemcode,6) in ('FS0176',  'FS610A')
			or
		*/
		 left(items.itemcode,5) in ( 'fs400'/*'FS300', 'FS314', 'FS240', 'FS245', 'FS250', 'FS820', 'FS882' */)
		)
*/
select 
	'' as ID
	, #Temp.Label
	, #Temp.[Internal Sku]
	, #Temp.Description
	, '' as [Manufacturer ID]
	, '' as [Build Type]
	, '' as [Warehouse ID]
	, '' as [Default Shipping Method ID]
	, '' as [Shipping Weight]
	, '' as [Shipping Width]
	, '' as [Shipping Height]
	, '' as [Shipping Depth]
	, '' as [Needs Own Box]
	, '' as [Vendor ID] -- find out if required
	, '' as Vendor_Sku -- Dan going to fill out at later date
	, #Temp.Default_Cost
	, '' as [Auto Reorder]
	, '' as [Min In Stock]
	, '' as [Auto Reorder Method]
	, '' as [Auto Reorder Qty]
	, '' as [Auto Reorder Upto Qty]
	, '' as [Auto Reorder Medium]
	, '' as [Warehouse ID]
	, '' as [Auto Reorder medium ID]
	, '' as [Product Type]
	, '' as [Men's Pants Type]
	, '' as [Men's Pants Material]
	, '' as [Men's Pants Use]
	, '' as [Men's Pants Features]
	, #Temp.Waist
	, '' as [Custom Waist Size Price]
	, #Temp.Inseam
	, '' as [Custom Inseam Size Price]	
	, #Temp.Rise
	, '' as [Custom Rise Price]
	, #Temp.Color
	, '' as [Color Price]
	, #Temp.Product_Name
	, 1 as Active
	, #Temp.[Product Description]
	, #Temp.[Part Number]
	, 1 as [Manufacturer ID]
	, #Temp.ImageLocation
	, #Temp.MainImage
	, #Temp.LargeImage
	, '' as [Commission Rate]
	, '' as [Commission Rate Type]
	, '' as [Technical Specifications]
	, '' as [Care Instructions]
	, 1 as [Web Active]
	, #Temp.[Web Base Price]
	, 11 as Category -- Check w/ Mike
	, '' as [Web Meta Title]
	, '' as [Web Meta Description]
	, '' as [Web Meta Keywords]
	, '' as [Web meta Abstract]
	, '' as [Web Featured Categories]
	, '' as [Web Main Featured]
	, '' as [Web Page Title]
	, 'Standard' as [Web Availability Calculation]
	, '' as [Web Out of Stock Option]
	, 1 as [Soi Active]
	, #Temp.[Soi Base Price]
	, ItemCountries.Note as [Soi Description Text]
	, #Temp.[Soi Image Location]
from #temp
	join ItemCountries on #Temp.Label = ItemCountries.ItemCode
Where ItemCountries.CountryCode is Null
Order by [Part Number]
		,Label


drop table #Temp


