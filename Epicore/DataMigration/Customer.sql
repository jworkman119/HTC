Select [Bill Company] as Company
, [Client Id] as CustID
, [Bill First Name] || ' ' || [Bill Last Name] as Name
, [Ship Address1] as Address1
, [Ship Address2] as Address2
, null as Address3
, [Ship City] as City
, [Ship State] as State
, [Ship Zip] as Zip
, [Ship Country] as Country
, [Ship Phone] as PhoneNum
, [Ship Fax] as FaxNum
, [Ship Email] as EmailAddress
From Customer
Where [Bill First Name]  != 'USACE'
and [Bill Company] not like '%Army Corps%'
and  [Bill Company] != 'USACE'


select *
from Customer