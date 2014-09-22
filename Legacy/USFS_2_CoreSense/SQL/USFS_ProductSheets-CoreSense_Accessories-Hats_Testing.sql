select  Distinct
	Items.ItemCode as [Label]
	, Items.Description as [Internal Sku]
	, Items.Description
	, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as Default_Cost
	, xscItems.[Order Size] as [Hat Size]
	, xscItems.Color
	, Family.Fam2 as Product_Name
	, xscItems.Description as [Product Description]
	, Family.Fam1 as [Part Number]
	, xscItems.Picture + '.jpg'  as ImageLocation
	, xscItems.Picture + '.jpg'  as MainImage
	, xscItems.Picture + '.jpg' as LargeImage
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Web Base Price]
	, 'Standard' as [Web Availability Calculation]
	, 1 as [Soi Active]
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Soi Base Price]
	, xscItems.Picture + '.jpg' as [Soi Image Location]
into #Temp
From Items
	join zzzhtc_family as Family on items.itemcode = Family.item
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
	Join ItemCountries on Items.ItemCode = ItemCountries.ItemCode
	left Join xscItems/*zcolor */ on Items.ItemCode = xscItems.[Part No.]
where items.warehouse = 700
	and ItemCountries.countrycode is null
	and [FS Item] in
(	'FS229A'
	, 'FS239A'
	, 'FS326'
	, 'FS328'
	, 'FS356'
	, 'FS368'
	, 'FS010'
	, 'FS012'
	, 'FS700B'
	, 'FS701B'
	, 'FS720B'
	, 'FS721B'
	, 'FS050'
	, 'FS051'
	, 'FS369A'
	, 'FS600'
	, 'FS601'
	, 'FS605'
	, 'SM150'
	, 'SM160'
	, 'SM170'
	, 'AP450C'
	, 'FS825A'
	, 'FS841'
	, 'FS842'
	, 'FS962A'
	, 'FS990'
	, '9552'
	, '9778'
	, 'FS015'
	, 'FS520'
	, 'FS521'
	, 'FS540'																																																														
)																																																																				



select #Temp.Label
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
	, '' as [Hat Type]
	, '' as [Custom Hat Type]
	, '' as [Hat Material]
	, '' as [Hat Use]
	, '' as [Hat Features]
	, #Temp.[Hat Size]
	, '' as [Waist Size]
	, '' as [Waist Size Price]
	, #Temp.Color
	, '' as [Color Price]
	, '' as [Style]
	, '' as [Custom Style Price]
	, #Temp.Product_Name
	, #Temp.[Product Description]
	, #Temp.[Part Number]
	, #Temp.ImageLocation
	, #Temp.MainImage
	, #Temp.LargeImage
	, #Temp.[Web Base Price]
	, #Temp.[Web Availability Calculation]
	, #Temp.[Soi Active]
	, #Temp.[Soi Base Price]
	, #Temp.[Soi Image Location]
	, ItemCountries.Note
from #temp
	join ItemCountries on #Temp.Label = ItemCountries.ItemCode
Where CountryCode is Null
	

