USE EcommAppDb;



SELECT * FROM customers;
select * from order_items;
select * from orders;


--1.Retrieve customer first name, last name, order_id, order_date, and order_status.--
SELECT 
    c.First_Name,
    c.Last_Name,
    o.Order_Id,
    o.Order_Date,
    o.Order_Status
FROM Customers c
INNER JOIN Orders o
ON c.Customer_Id = o.Customer_Id;


-- 2.Display only orders with status Pending (1) or Completed (4).--
SELECT 
    c.First_Name,
    c.Last_Name,
    o.Order_Id,
    o.Order_Date,
    o.Order_Status
FROM Customers c
INNER JOIN Orders o
ON c.Customer_Id = o.Customer_Id
WHERE o.Order_Status = 1 OR o.Order_Status = 4;

-- 3.Sort the results by order_date in descending order.------

SELECT 
    c.First_Name,
    c.Last_Name,
    o.Order_Id,
    o.Order_Date,
    o.Order_Status
FROM Customers c
INNER JOIN Orders o
ON c.Customer_Id = o.Customer_Id
WHERE o.Order_Status = 1 OR o.Order_Status = 4
ORDER BY o.Order_Date DESC;


---Problem 2 - Product Price Listing by Category--

--1. Display product_name, brand_name, category_name, model_year, and list_price.---
SELECT 
    p.Product_Name,
    b.Brand_Name,
    c.Category_Name,
    p.Model_Year,
    p.List_Price
FROM Products p
INNER JOIN Brands b
ON p.Brand_Id = b.Brand_Id
INNER JOIN Categories c
ON p.Category_Id = c.Category_Id;

-- 2. Filter products with list_price greater than 500.--

SELECT 
    p.Product_Name,
    b.Brand_Name,
    c.Category_Name,
    p.Model_Year,
    p.List_Price
FROM Products p
INNER JOIN Brands b
ON p.Brand_Id = b.Brand_Id
INNER JOIN Categories c
ON p.Category_Id = c.Category_Id
WHERE p.List_Price > 500;

--3. Sort results by list_price in ascending order.--

SELECT 
    p.Product_Name,
    b.Brand_Name,
    c.Category_Name,
    p.Model_Year,
    p.List_Price
FROM Products p
INNER JOIN Brands b
ON p.Brand_Id = b.Brand_Id
INNER JOIN Categories c
ON p.Category_Id = c.Category_Id
WHERE p.List_Price > 500
ORDER BY p.List_Price ASC;



----- Level-2: Problem 1 - Store Wise Sales Summary---------

---Display store_name and total sales amount.--
SELECT 
    s.store_name,
    SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
GROUP BY s.store_name;

------ Calculate total sales using SUM()-------
SELECT 
    SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS total_sales
FROM order_items oi;


---- Include only completed orders (order_status = 4)---

SELECT 
    s.store_name,
    SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name;


-----Group results by store_name-------
SELECT 
    s.store_name,
    SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
GROUP BY s.store_name;


--- Sort total sales in descending order--
SELECT 
    s.store_name,
    SUM(oi.list_price * oi.quantity * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o
ON s.store_id = o.store_id
INNER JOIN order_items oi
ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;


----- Display product_name, store_name, available stock quantity, and total quantity sold----

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
    ON st.product_id = p.product_id
INNER JOIN stores s
    ON st.store_id = s.store_id
LEFT JOIN order_items oi
    ON st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY p.product_name;

--- Include products even if they have not been sold (LEFT JOIN)---
SELECT 
    p.product_name,
    s.store_name,
    st.quantity,
    oi.quantity
FROM stocks st
INNER JOIN products p 
    ON st.product_id = p.product_id
INNER JOIN stores s 
    ON st.store_id = s.store_id
LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id;


	--3.Group results by product_name and store_name---

	SELECT 
    p.product_name,
    s.store_name,
    st.quantity,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p 
    ON st.product_id = p.product_id
INNER JOIN stores s 
    ON st.store_id = s.store_id
LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity;

-- Use SUM() aggregate function----



-- Sort results by product_name-

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p 
    ON st.product_id = p.product_id
INNER JOIN stores s 
    ON st.store_id = s.store_id
LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;