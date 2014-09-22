
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
	, rtrim(Family.Fam1) + '.jpg'  as ImageLocation
	, rtrim(Family.Fam1) + '.jpg'  as MainImage
	, rtrim(Family.Fam1) + '.jpg' as LargeImage
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Web Base Price]
	, 'Standard' as [Web Availability Calculation]
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Soi Base Price]
	, rtrim(Family.Fam1) + '.jpg' as [Soi Image Location]
into #Temp
From Items
	join zzzhtc_family as Family on items.itemcode = Family.item
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
--	Join cicmpy as Vendors on Location.vend_no = Vendors.cmp_code
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
	Join ItemCountries on Items.ItemCode = ItemCountries.ItemCode
	left Join xscItems/*zcolor */ on Items.ItemCode = xscItems.[Part No.]
where items.warehouse = 700
	and ItemCountries.countrycode is null
	and [FS Item] = 'FS841'
	/*
	in
	
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
	, #Temp.[Web Availability Calculation]
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
Where CountryCode is Null
	Order by [Part Number]
		, Label

drop table #Temp