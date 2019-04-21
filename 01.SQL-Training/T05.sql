use AdventureWorks2016
----------------
---------------------
--Q05-01
---------------------

Select P.NAME, PC.NAME , PS.NAME 
From Production.Product P
left join Production.ProductSubcategory PS
ON P.ProductSubcategoryID=PS.ProductSubcategoryID
left join Production.ProductCategory PC
ON PS.ProductSubcategoryID=PC.ProductCategoryID
--Where PC.NAME='Bikes'

---------------------
--Q05-02
---------------------
Select P.NAME as 'Prodoct Name', PD.Description as 'Product Desc' ,PL.Name as 'Langueage Name'
From Production.Product P
Inner join Production.ProductModelProductDescriptionCulture PM
ON P.ProductModelID=PM.ProductModelID
Inner Join Production.ProductDescription PD
ON Pm.ProductDescriptionID=PD.ProductDescriptionID
Inner Join Production.Culture  PL
ON PM.CultureID=PL.CultureID
Order By P.NAME

---------------------
--Q05-03
---------------------
Select P.NAME , B.ComponentID , U.Name
FRom 
Production.Product P
inner join Production.BillOfMaterials B
ON P.ProductID = B.PerAssemblyQty
inner join Production.UnitMeasure U
ON B.UnitMeasureCode=U.UnitMeasureCode