Select XF$Name As TableName, F1.XE$ID As FID, F1.XE$Name As FieldName, F2.XE$ID As NotNullable
FROM X$File
INNER JOIN X$Field F1 On
F1.XE$File = XF$ID
LEFT OUTER JOIN X$Field F2 On
F1.XE$ID = F2.XE$Offset And
F1.XE$File = F2.XE$File
WHERE F1.XE$Name Not Like 'NN_%' And
F1.XE$DataType <> 255
and F1.XE$Name like '%Date%'
Order By XF$Name, F1.XE$Offset