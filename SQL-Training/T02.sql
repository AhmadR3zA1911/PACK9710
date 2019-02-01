USE AdventureWorks2016
----------------------
go
SELECT * FROM Production.ProductInventory Order By ProductID -- کالاها در انبار های مخالف

SELECT * FROM Production.Location -- اسامی انبار ها 

SELECT * FROM Production.Product

Select * FROM Production.ProductCategory

Select * FRom Production.ProductSubcategory
-------------------------
--Q1
-------------------------

SELECT L.Name ,Sum(P.ListPrice) As 'ListPrice' ,  PL.Quantity
FROM Production.Location L
inner join Production.ProductInventory PL
ON L.LocationID=PL.LocationID
Inner Join Production.Product P
ON Pl.ProductID=P.ProductID
Group by L.Name, PL.Quantity ,PL.Shelf
Order By ListPrice

-------------------------
--Q2
-------------------------
SELECT L.NAME 'Location NAME' , PC.Name as 'Cat' , SUM(PL.Quantity)/(Select Sum(Quantity) From Production.ProductInventory) as 'Percent'
FROM Production.Location L
inner Join Production.ProductInventory PL
ON L.LocationID = PL.LocationID
inner Join Production.Product P
ON PL.ProductID= P.ProductID
inner join Production.ProductSubcategory PS
ON PS.ProductSubcategoryID=P.ProductSubcategoryID
inner Join Production.ProductCategory PC
ON PC.ProductCategoryID=PS.ProductCategoryID

Group by L.Name , PC.Name


-------------------------
--Q3
-------------------------
SELECT  P.Name,p.SafetyStockLevel ,
SUM(PIN.Quantity) 'Total'
FROM Production.Product p
INNER JOIN Production.ProductInventory PIN
ON p.ProductID = PIN.ProductID
GROUP BY P.Name,p.SafetyStockLevel
HAVING SUM(PIN.Quantity) <= p.SafetyStockLevel+100

-------------------------
--Q4
-------------------------
SELECT  p.Name, p.SafetyStockLevel,
SUM(PIN.Quantity) 'Total',
CASE 
WHEN SUM(PIN.Quantity) <= p.SafetyStockLevel THEN N'حداقل موجودی'
ELSE N'موجودی نزدیک به حداقل'
END 

FROM Production.Product p
INNER JOIN Production.ProductInventory PIN
ON p.ProductID = PIN.ProductID
GROUP BY p.Name, p.SafetyStockLevel
HAVING SUM(PIN.Quantity) <= p.SafetyStockLevel + 100 

-------------------------
--Q5
-------------------------
Select P.Name , DaysToManufacture ,
CASE 
WHEN P.DaysToManufacture <=2 THEN N'دارد'
ELSE N'ندارد' END as 'Feasibility'

From Production.Product P
where ProductID = 766
Union
Select P.Name , DaysToManufacture,
CASE 
WHEN P.DaysToManufacture <=2 THEN N'دارد'
ELSE N'ندارد' END as 'Feasibility'
From Production.Product P
where ProductID = 776
Union
Select P.Name , DaysToManufacture,
CASE 
WHEN P.DaysToManufacture <=2 THEN N'دارد'
ELSE N'ندارد' END as 'Feasibility'
From Production.Product P
where ProductID = 780
Union
Select P.Name , DaysToManufacture,
CASE 
WHEN P.DaysToManufacture <=2 THEN N'دارد'
ELSE N'ندارد' END as 'Feasibility'
From Production.Product P
where ProductID = 517
Union
Select P.Name , DaysToManufacture,
CASE 
WHEN P.DaysToManufacture <=2 THEN N'دارد'
ELSE N'ندارد' END as 'Feasibility'
From Production.Product P
where ProductID = 514
Union
Select P.Name , DaysToManufacture,
CASE 
WHEN P.DaysToManufacture <=2 THEN N'دارد'
ELSE N'ندارد' END as 'Feasibility'
From Production.Product P
where ProductID = 524 

-------------------------
--Q6
-------------------------
Select P.Name , DaysToManufacture
From Production.Product P
where ProductID = 766
Union
Select P.Name , DaysToManufacture
From Production.Product P
where ProductID = 776
Union
Select P.Name , DaysToManufacture
From Production.Product P
where ProductID = 780
Union
Select P.Name , DaysToManufacture
From Production.Product P
where ProductID = 517
Union
Select P.Name , DaysToManufacture
From Production.Product P
where ProductID = 514
Union
Select P.Name , DaysToManufacture
From Production.Product P
where ProductID = 524
Except
Select P.Name , DaysToManufacture
From Production.Product P
where DaysToManufacture >2
