select FamilyCode
, ItemCode
, Qty_Sold
, Qty_Shipped
, Qty_Ordered
, Last_SalesPrice
, LastCostPrice
, round(Qty_Ordered * (Last_SalesPrice/LastCostPrice), 2) as WeightedCost
from mecola_items