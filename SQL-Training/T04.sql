USE AdventureWorks2016
----------------------


/***************************************************************
جواب سوالات تمرین شماره 4
****************************************************************
*/
use AdventureWorks2017
-------------------------------
--Q1
-------------------------------
Select * From Sales.SalesOrderDetail
Select * FRom Sales.SalesOrderHeader
Select * FRom Sales.Customer
Select * FRom Person.Person

Select * From Production.ProductCategory
Select * From Production.ProductInventory
Select * From Production.Product
Select * From INFORMATION_SCHEMA.COLUMNS Where COLUMN_NAME='CustomerID'

go 

-------------------------------
--Q2
-------------------------------


Select Top 1 R.ProductName , R.CatName
FROM 
(
Select Top 10 P.Name As 'ProductName' , PC.Name As 'CatName' , S.OrderQty , S.LineTotal 
FROM Sales.SalesOrderDetail S
Inner Join Production.Product P
ON s.ProductID=P.ProductID
Inner Join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
Inner Join Production.ProductCategory PC
ON PS.ProductCategoryID=PC.ProductCategoryID
Order By S.LineTotal Desc
) R
Order By R.OrderQty


-------------------------------
--Q3
-------------------------------


Select  PC.Name As 'CatName' , Format ((Sum (S.LineTotal) / (Select Sum(LineTotal) FROM Sales.SalesOrderDetail)) * 100.0,'#.##') As 'Total Percent'
FROM Sales.SalesOrderDetail S
Inner Join Production.Product P
ON s.ProductID=P.ProductID
Inner Join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
Inner Join Production.ProductCategory PC
ON PS.ProductCategoryID=PC.ProductCategoryID
Group By PC.NAME




-------------------------------
--Q4
-------------------------------

Select  R.ProductNAme , R.CatName
From
(
Select P.NAME as 'ProductNAme', PC.Name As 'CatName'  , S.LineTotal as 's', Row_Number() over (Partition by PC.Name Order By S.LineTotal) as 'R0W'
FROM Sales.SalesOrderDetail S
Inner Join Production.Product P
ON s.ProductID=P.ProductID
Inner Join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
Inner Join Production.ProductCategory PC
ON PS.ProductCategoryID=PC.ProductCategoryID

) R
Where R.R0W=1

-------------------------------
--Q5
-------------------------------
Select R.SalesPersonID , R.CATNAME , Format ((R.SUB / R.[Cat TOTAL])*100.0,'#.##') + ' %' as 'Total Percent'
FRom 
(
Select SH.SalesPersonID as 'SalesPersonID' ,PC.Name as 'CATNAME' , Sum(SD.LineTotal) as 'SUB', ROW_NUMBER() over (Partition By PC.NAME Order BY Sum(SD.LineTotal) DESC) as 'R0W'
,Sum(SD.LineTotal) Over (Partition By PC.NAME Order By PC.NAME) As 'Cat TOTAL'
From Sales.SalesOrderHeader SH
Inner Join Sales.SalesOrderDetail SD
ON SH.SalesOrderID=SD.SalesOrderID
Inner Join Production.Product P
ON SD.ProductID=P.ProductID
Inner Join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
Inner Join Production.ProductCategory PC
ON PS.ProductCategoryID=PC.ProductCategoryID
Group By SalesPersonID , PC.Name , SD.LineTotal
Having SH.SalesPersonID is not Null

) R
Where R.R0W=1
Order By SalesPersonID

-------------------------------
--Q6
-------------------------------
SELECT  SH.CustomerID , PC.Name as 'CATNAME', SD.LineTotal
From Sales.SalesOrderHeader SH
Inner Join Sales.SalesOrderDetail SD
ON SH.SalesOrderID=SD.SalesOrderID
Inner Join Production.Product P
ON SD.ProductID=P.ProductID
Inner Join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
Inner Join Production.ProductCategory PC
ON PS.ProductCategoryID=PC.ProductCategoryID
Where SD.LineTotal = (Select Max (LineTotal) From Sales.SalesOrderDetail)
--Order By SD.LineTotal DESC

-------------------------------
--Q7
-------------------------------
Select R.[ProductNAME] , R.CATNAME , Sum(R.SumOrder) Over (Partition By R.CATNAME order By R.[ProductNAME])
FRom
(

Select 'TEST' as  'ProductNAME' ,'Bike' as 'CATNAME', Sum(50+45) as 'SumOrder'
UNion
Select P.Name as  'ProductNAME' ,PC.NAME as 'CATNAME', Sum(SD.OrderQty) as 'SumOrder' 
--,Sum(SD.OrderQty) over (Partition By PC.NAME Order by P.Name) as 'Total'
--,ROW_NUMBER() Over (Partition  By PC.NAME Order By P.NAME) as 'R0W'
From Sales.SalesOrderHeader SH
Inner Join Sales.SalesOrderDetail SD
ON SH.SalesOrderID=SD.SalesOrderID
Inner Join Production.Product P
ON SD.ProductID=P.ProductID
Inner Join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
Inner Join Production.ProductCategory PC
ON PS.ProductCategoryID=PC.ProductCategoryID
Group By P.Name ,PC.NAME
Having Sum(SD.OrderQty) < 11
--Order By SumOrder
) R 
Group By R.[ProductNAME] , R.CATNAME ,R.SumOrder
---Order By R0W
