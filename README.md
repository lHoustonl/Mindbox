# Mindbox

SQL-запрос для выборки:
SELECT Products.Name AS ProductName, Categories.Name AS CategoryName
  FROM Products
  LEFT JOIN ProductCategories
    ON Products.Id = ProductCategories.ProductId
  LEFT JOIN Categories
    ON ProductCategories.CategoryId = Categories.Id;
