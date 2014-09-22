
select 
	 '' as ID
	, Items.ItemCode
	, Items.Description
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
	, '' as Default_Cost
	, '' as [Auto Reorder]
	, '' as [Min In Stock]
	, '' as [Auto Reorder Method]
	, '' as [Auto Reorder Qty]
	, '' as [Auto Reorder Upto Qty]
	, '' as [Auto Reorder Medium]
	, '' as [Warehouse ID]
	, '' as [Auto Reorder medium ID]
	, '' as [Product Type]
	, '' as [Women's Pants Type]
	, '' as [Women's Pants Material]
	, '' as [Women's Pants Use]
	, '' as [Women's Pants Features]
	, Case Items.ItemCode
		when 'FS45110R' then
			32 
		when 'FS45112R' then
			33
		when 'FS45114R' then
			35
		when 'FS45116R' then
			37
		when 'FS4518R' then
			30
		end as Waist
	, '' as [Custom Waist Size Price]
	, 34 as inseam
	, '' as [Custom Inseam Size Price]	
	, '' as rise/* need to add case statemtn */
	, '' as [Custom Rise Price]
	, 'Dark Green' as Color
	, '' as [Color Price]
	, 'wool pants - woman' Product_Name
	, 1 as Active
	, Items.Description
	, Items.ItemCode
	, 1 as [Manufacturer ID]
	, 'FS400_451.jpg'
	, 'FS400_451.jpg'
	, 'FS400_451.jpg'
	, '' as [Commission Rate]
	, '' as [Commission Rate Type]
	, '' as [Technical Specifications]
	, '' as [Care Instructions]
	, 1 as [Web Active]
	, 117.00
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
	, 117.00
	, ItemCountries.Note as [Soi Description Text]
	, 'FS400_451.jpg'
from items
	join ItemCountries on Items.ItemCode = ItemCountries.ItemCode
	Join ItemPrices on Items.ItemCode = ItemPrices.ItemCode
Where ItemCountries.CountryCode is Null
	and items.itemcode in ('FS45110R','FS45112R','FS45114R','FS45116R','FS4518R')
Order by Items.ItemCode
		
