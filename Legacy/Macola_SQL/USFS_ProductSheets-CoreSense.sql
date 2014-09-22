select distinct 
	 '' as ID
	, Items.ItemCode as [Label]
	, Items.Description as [Internal Sku]
	, Items.Description
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
	, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as Default_Cost
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
	, left(Right(Items.ItemCode,3), 2)as Waist
	, '' as [Custom Waist Size Price]
	, Inseam
	, '' as [Custom Inseam Size Price]	
	, Right(Items.ItemCode,1) as Rise /* need to add case statemtn */
	, '' as [Custom Rise Price]
	, xscItems.Color
	, '' as [Color Price]
	, Family.Fam2 as Product_Name
	, 1 as Active
	, xscItems.Description as [Product Description]
	, Family.Fam1 as [Part Number]
	, 1 as [Manufacturer ID]
	, cast(rtrim(Family.Fam1) as varchar) + '.jpg'  as ImageLocation
	, cast(rtrim(Family.Fam1) as varchar) + '.jpg'  as MainImage
	, cast(rtrim(Family.Fam1) as varchar) + '.jpg' as LargeImage
	, '' as [Commission Rate]
	, '' as [Commission Rate Type]
	, '' as [Technical Specifications]
	, '' as [Care Instructions]
	, 1 as [Web Active]
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Web Base Price]
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
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Soi Base Price]
	, Items.Description as [Soi Description Text]
	, cast(rtrim(Family.Fam1) as varchar) + '.jpg' as [Soi Image Location]
From Items
	join zzzhtc_family as Family on items.itemcode = Family.item
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
	left Join xscItems/*zcolor */ on Items.ItemCode = xscItems.[Part No.]
where items.warehouse = 700
	and (
		 left(items.itemcode,6) in ('FS0176',  'FS610A')
			or
		 left(items.itemcode,5) in ('FS300', 'FS314', 'FS240', 'FS245', 'FS250', 'FS820', 'FS882')
		)






