select '1402A' as Item_No
	, *
Into #Temp1
from xscItems
where xscItems.[fs item] = 'FS1402A'


select distinct 
	Items.ItemCode as [Label]
	, Items.Description as [Internal Sku]
	, Items.Description
	, cast(round(items.CostPriceStandard,2) as decimal(18,2)) as Default_Cost
	, left(Right(Items.ItemCode,3), 2)as Waist
	, #Temp1.[Order Size] as Size
	, #Temp1.Color
	, #Temp1.Description as Product_Name
	, #Temp1.Description as [Product Description]
	, #Temp1.Item_No as [Part Number]
	, #Temp1.Item_No + '.jpg'  as ImageLocation
	, #Temp1.Item_No + '.jpg'  as MainImage
	, #Temp1.Item_No + '.jpg' as LargeImage
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Web Base Price]
	, cast(round(ItemPrices.SalesPrice,2)as decimal(18,2)) as [Soi Base Price]
	, Items.Description as [Soi Description Text]
	, #Temp1.Item_No + '.jpg' as [Soi Image Location]
Into #Temp2
From Items
	join iminvloc_sql as Location on items.ItemCode = Location.Item_no
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
	Join #Temp1 on Items.ItemCode = #Temp1.Item_No
where #Temp1.[fs item] = 'FS1402A'

/*
select *
from xscItems
where [fs item] = 'FS1001IKE'
*/

Select
	'' as ID 
	, #Temp2.[Label]
	, #Temp2.[Internal Sku]
	, #Temp2.Description
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
	, #Temp2.Default_Cost
	, '' as [Auto Reorder]
	, '' as [Min In Stock]
	, '' as [Auto Reorder Method]
	, '' as [Auto Reorder Qty]
	, '' as [Auto Reorder Upto Qty]
	, '' as [Auto Reorder Medium]
	, '' as [Warehouse ID]
	, '' as [Auto Reorder medium ID]
	, '' as [Product Type]
	, '' as [Top Type]
	, '' as [Top Material]
	, '' as [Top Use]
	, '' as [Top Features]
	, #Temp2.Waist
	, #Temp2.Size
	, '' as [Custom Order Size Price]
	, #Temp2.Color
	, '' as [Color Price]
	, #Temp2.Product_Name
	, 1 as Active
	, #Temp2.[Product Description]
	, #Temp2.[Part Number]
	, 1 as [Manufacturer ID]
	, #Temp2.ImageLocation
	, #Temp2.MainImage
	, #Temp2.LargeImage
	, '' as [Commission Rate]
	, '' as [Commission Rate Type]
	, '' as [Technical Specifications]
	, '' as [Care Instructions]
	, 1 as [Web Active]
	, #Temp2.[Web Base Price]
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
	, #Temp2.[Soi Base Price]
	, ItemCountries.Note as [Soi Description Text]
	, #Temp2.[Soi Image Location]from #Temp2
	join ItemCountries on #Temp2.Label = ItemCountries.ItemCode
Where ItemCountries.CountryCode is Null
Order by [Part Number]
		,Label



Drop Table #Temp2

