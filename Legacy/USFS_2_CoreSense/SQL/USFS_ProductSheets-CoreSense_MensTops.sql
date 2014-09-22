select distinct 
	 Items.ItemCode as [Label]
	, Items.Description as [Internal Sku]
	, Items.Description
	, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as Default_Cost
	, left(Right(Items.ItemCode,3), 2)as Waist
	, Neck
	, Length  as Sleeve/* need to add case statemtn */
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
into #Temp
From Items
	join zzzhtc_family as Family on items.itemcode = Family.item
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
--	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
	left Join xscItems/*zcolor */ on Items.ItemCode = xscItems.[Part No.]
where /*/ items.warehouse = 700
	and */ xscItems.[fs item] = 'FS1001IKE'
	--and xscItems.[fs item] in ('FS100C', 'FS100IKE', 'FS200', 'FS214', 'FS210', 'FS212', 'FS800A', 'FS810A', 'FS880')																																																																				



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
	, #Temp.Neck
	, '' as [Custom Neck Size Price]
	, #Temp.Sleeve
	, '' as [Custom Sleeve Price]
	, #Temp.Color
	, '' as [Color Price]
	, #Temp.Product_Name
	, 1 as Active
	, #Temp.[Product Description]
	, #Temp.[Part Number]
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
	, #Temp.[Soi Base Price]
	, 1 as [Soi Active]
	, ItemCountries.Note as [Soi Description Text]
	, #Temp.[Soi Image Location]
from #Temp
	join ItemCountries on #Temp.Label = ItemCountries.ItemCode
Where ItemCountries.CountryCode is Null
Order by [Part Number]
		,Label

Drop Table #Temp



