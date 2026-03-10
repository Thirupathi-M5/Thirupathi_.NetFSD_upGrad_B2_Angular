USE EcommAppDb
---- Problem 1: Basic Setup and Data Retrieval in EcommDb ---
 
SELECT * FROM categories
SELECT * FROM brands
SELECT * FROM products
SELECT * FROM customers

INSERT INTO categories (category_name)
VALUES
('Mountain Bikes'),
('Road Bikes'),
('Electric Bikes'),
('Accessories'),
('Kids Bikes');

INSERT INTO brands (brand_name)
VALUES
('Trek'),
('Giant'),
('Specialized'),
('Cannondale'),
('Scott');

INSERT INTO products (product_name, brand_id, category_id, model_year, list_price)
VALUES
('Marlin 7',1,1,2023,1200),
('Defy Advanced',2,2,2024,2200),
('Turbo Vado',3,3,2023,3500),
('Trail 5',4,1,2022,950),
('Aspect 940',5,1,2024,1100);

INSERT INTO customers
(first_name,last_name,phone,email,street,city,state,zip_code)
VALUES
('Thiru','Kumbar','9876543210','Thiru@gmail.com','MG Road','Delhi','DL','11000'),
('Amuktha','Vardini','9876543211','amuktha@gmail.com','Link Road','Mumbai','MH','40000'),
('Spandana','Kosuri','9876543212','spandana@gmail.com','Banjara Hills','Hyderabad','TS','50008'),
('Akhila','Royal','9876543213','akhila@gmail.com','Indiranagar','Bangalore','KA','56000'),
('Arjun','Mekala','9876543214','arjun@gmail.com','Navrangpura','Ahmedabad','GJ','38000');


INSERT INTO stores
(store_name,phone,email,street,city,state,zip_code)
VALUES
('Delhi Bike Store','9999991111','delhi@bike.com','Connaught Place','Delhi','DL','11000'),
('Mumbai Cycle Hub','9999992222','mumbai@bike.com','Andheri','Mumbai','MH','40000'),
('Hyderabad Wheels','9999993333','hyd@bike.com','Madhapur','Hyderabad','TS','50008'),
('Bangalore Riders','9999994444','blr@bike.com','Whitefield','Bangalore','KA','56006'),
('Chennai Bike Zone','9999995555','chn@bike.com','T Nagar','Chennai','TN','60001');

---PROBLEM 1-----
---RETIEVE PRODUCTS WITH BRAND AND CATEGORY---
SELECT
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id=b.brand_id
JOIN categories c
ON p.category_id=c.category_id;

----RETRIVE CUSTOMERS FROM SPECIFIC CITY---
SELECT * FROM customers
WHERE city='DELHI';

----TOTAL PRODUCTS IN EACH CATEGORY---
SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id=p.category_id
GROUP BY c.category_name;


---- Problem 2: Creating Views and Indexes for Performance---

USE EcommAppDb;
GO

CREATE TRIGGER trg_stock_auto_update
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY

IF EXISTS (
    SELECT 1
    FROM inserted i
    JOIN stocks s 
    ON i.product_id = s.product_id
    WHERE s.quantity < i.quantity
)
BEGIN
    THROW 50001, 'Insufficient stock for the ordered product.', 1;
END

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
AND s.store_id = (
        SELECT store_id 
        FROM orders 
        WHERE order_id = i.order_id
    );

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
END CATCH
END;
GO