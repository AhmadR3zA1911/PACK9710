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
Select PL.Name 'Location Name' , PC.Name 'Cat NAME' , Format (Sum(PR.Quantity) * 100.0 / (Select Sum(Quantity) From Production.ProductInventory),'0.000') as 'Percent Quantity'

From Production.Location PL
inner join Production.ProductInventory PR
ON PL.LocationID=PR.LocationID
Inner Join Production.Product P
ON PR.ProductID=P.ProductID
inner join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
inner Join Production.ProductCategory PC
on PS.ProductCategoryID=PC.ProductCategoryID

Group By PL.Name , PC.Name


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


/***************************************************************
جواب سوالات تمرین شماره 3
****************************************************************
*/

--T03-Q1
SELECT
  FirstName,
  EmailAddress
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World';

--T03-Q2
SELECT
  CompanyName
FROM SalesLT.Customer
INNER JOIN SalesLT.CustomerAddress
  ON Customer.CustomerID = CustomerAddress.CustomerID
INNER JOIN SalesLT.Address
  ON CustomerAddress.AddressID = Address.AddressID
WHERE Address.City = 'Dallas';

--T03-Q3
SELECT
  COUNT(*) AS Total
FROM SalesLT.SalesOrderDetail
INNER JOIN SalesLT.Product
  ON SalesOrderDetail.ProductID = Product.ProductID
WHERE Product.ListPrice > 1000;
--T03-Q4
SELECT
  Customer.CompanyName
FROM SalesLT.SalesOrderHeader
INNER JOIN SalesLT.Customer
  ON SalesOrderHeader.CustomerID = Customer.CustomerID
WHERE SalesOrderHeader.SubTotal + SalesOrderHeader.TaxAmt + SalesOrderHeader.Freight > 100000;

--T03-Q5
SELECT
  SUM(SalesOrderDetail.OrderQty) AS Total
FROM SalesLT.SalesOrderDetail
INNER JOIN SalesLT.Product
  ON SalesOrderDetail.ProductID = Product.ProductID
INNER JOIN SalesLT.SalesOrderHeader
  ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
INNER JOIN SalesLT.Customer
  ON SalesOrderHeader.CustomerID = Customer.CustomerID
WHERE Product.Name = 'Racing Socks, L'
AND Customer.CompanyName = 'Riding Cycles';

--T03-Q6

SELECT
  SalesOrderID,
  UnitPrice
FROM SalesLT.SalesOrderDetail
WHERE OrderQty = 1;

--T03-Q7
SELECT
  Product.name,
  Customer.CompanyName
FROM SalesLT.ProductModel
INNER JOIN SalesLT.Product
  ON ProductModel.ProductModelID = Product.ProductModelID
INNER JOIN SalesLT.SalesOrderDetail
  ON SalesOrderDetail.ProductID = Product.ProductID
INNER JOIN SalesLT.SalesOrderHeader
  ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID
INNER JOIN SalesLT.Customer
  ON SalesOrderHeader.CustomerID = Customer.CustomerID
WHERE ProductModel.Name = 'Racing Socks';
--T03-Q8
SELECT
  ProductDescription.Description
FROM SalesLT.ProductDescription
INNER JOIN SalesLT.ProductModelProductDescription
  ON ProductDescription.ProductDescriptionID = ProductModelProductDescription.ProductDescriptionID
INNER JOIN SalesLT.ProductModel
  ON ProductModelProductDescription.ProductModelID = ProductModel.ProductModelID
INNER JOIN SalesLT.Product
  ON ProductModel.ProductModelID = Product.ProductModelID
WHERE ProductModelProductDescription.culture = 'fr'
AND Product.ProductID = '736';

--T03-Q9
SELECT
  Customer.CompanyName,
  SalesOrderHeader.SubTotal,
  SUM(SalesOrderDetail.OrderQty * Product.weight) AS TotalWeight
FROM SalesLT.Product
INNER JOIN SalesLT.SalesOrderDetail
  ON Product.ProductID = SalesOrderDetail.ProductID
INNER JOIN SalesLT.SalesOrderHeader
  ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesorderID
INNER JOIN SalesLT.Customer
  ON SalesOrderHeader.CustomerID = Customer.CustomerID
GROUP BY SalesOrderHeader.SalesOrderID,
         SalesOrderHeader.SubTotal,
         Customer.CompanyName
ORDER BY SalesOrderHeader.SubTotal DESC;

--T03-Q10
SELECT
  SUM(SalesOrderDetail.OrderQty) AS total
FROM SalesLT.ProductCategory
INNER JOIN SalesLT.Product
  ON ProductCategory.ProductCategoryID = Product.ProductCategoryID
INNER JOIN SalesLT.SalesOrderDetail
  ON Product.ProductID = SalesOrderDetail.ProductID
INNER JOIN SalesLT.SalesOrderHeader
  ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesorderID
INNER JOIN SalesLT.Address
  ON SalesOrderHeader.ShipToAddressID = Address.AddressID
WHERE Address.City = 'London'
AND ProductCategory.Name = 'Cranksets';

--T03-Q11
SELECT
  Customer.CompanyName,
  MAX(CASE
    WHEN AddressType = 'Main Office' THEN AddressLine1
    ELSE ''
  END) AS 'Main Office Address',
  MAX(CASE
    WHEN AddressType = 'Shipping' THEN AddressLine1
    ELSE ''
  END) AS 'Shipping Address'
FROM SalesLT.Customer
JOIN SalesLT.CustomerAddress
  ON Customer.CustomerID = CustomerAddress.CustomerID
JOIN SalesLT.Address
  ON CustomerAddress.AddressID = Address.AddressID
WHERE Address.City = 'Dallas'
GROUP BY Customer.CompanyName;

--T03-Q12
SELECT
  SalesOrderHeader.SalesOrderID,
  SalesOrderHeader.SubTotal,
  SUM(SalesOrderDetail.OrderQty * SalesOrderDetail.UnitPrice) AS 'Sum of OrderQty*UnitPrice',
  SUM(SalesOrderDetail.OrderQty * Product.ListPrice) AS 'Sum of OrderQty*ListPrice'
FROM SalesLT.SalesOrderHeader
INNER JOIN SalesLT.SalesOrderDetail
  ON SalesOrderHeader.SalesOrderID = SalesOrderDetail.SalesOrderID
INNER JOIN SalesLT.Product
  ON SalesOrderDetail.ProductID = Product.ProductID
GROUP BY SalesOrderHeader.SalesOrderID,
         SalesOrderHeader.SubTotal;

--T03-Q13
SELECT
  Product.Name,
  SUM(SalesOrderDetail.OrderQty * SalesOrderDetail.UnitPrice) AS 'Total Sale Value'
FROM SalesLT.Product
JOIN SalesLT.SalesOrderDetail
  ON Product.ProductID = SalesOrderDetail.ProductID
GROUP BY Product.Name
ORDER BY 'Total Sale Value' DESC;

--T03-Q14
SELECT
  t.range AS 'RANGE',
  COUNT(t.Total) AS 'Num Orders',
  SUM(t.Total) AS 'Total Value'
FROM (SELECT
  CASE
    WHEN
      SalesOrderDetail.UnitPrice * SalesOrderDetail.OrderQty BETWEEN 0 AND 99 THEN '0-99'
    WHEN
      SalesOrderDetail.UnitPrice * SalesOrderDetail.OrderQty BETWEEN 100 AND 999 THEN '100-999'
    WHEN
      SalesOrderDetail.UnitPrice * SalesOrderDetail.OrderQty BETWEEN 1000 AND 9999 THEN '1000-9999'
    WHEN
      SalesOrderDetail.UnitPrice * SalesOrderDetail.OrderQty > 10000 THEN '10000-'
    ELSE 'Error'
  END AS 'Range',
  SalesOrderDetail.UnitPrice * SalesOrderDetail.OrderQty AS Total
FROM SalesLT.SalesOrderDetail) t
GROUP BY t.range;