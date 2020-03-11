BULK INSERT <TableName>
FROM 'C:\personal\<FileName>.csv'
WITH
( 
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    TABLOCK
)