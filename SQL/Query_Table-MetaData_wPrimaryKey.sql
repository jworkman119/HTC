Declare @TableName varchar(25)
Declare @Database varchar(25)

set @Database = '001'
set @TableName = 'ordlev'


  Select Columns.Column_Name
        , Case tc.CONSTRAINT_TYPE
            When 'Primary Key' then 'x'
            Else ''
          End  as PrimaryKey
  --      , Columns.Table_Name 
  FROM Information_Schema.Columns as Columns
        left Join INFORMATION_SCHEMA.KEY_COLUMN_USAGE cu
            on CU.Column_Name = Columns.Column_Name
        left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
            on tc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME    
  Where Columns.Table_Name = @TableName


    
