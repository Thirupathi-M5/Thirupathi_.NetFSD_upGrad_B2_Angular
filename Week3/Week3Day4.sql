USE EcommAppDb;

----Problem 1 – Product Analysis Using Nested Queries-----

SELECT 
    product_name + ' (' + CAST(model_year AS VARCHAR(10)) + ')' AS product_details,
    list_price,
    list_price - (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS price_difference
FROM products p1
WHERE list_price > (
    SELECT AVG(list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
);

----Problem 2 – Customer Activity Classification----
SELECT 
    c.first_name + ' ' + c.last_name AS full_name,
    t.total_value,
    CASE 
        WHEN t.total_value > 10000 THEN 'Premium'
        WHEN t.total_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_type
FROM customers c
JOIN
(
    SELECT 
        o.customer_id, 
        SUM(oi.quantity * oi.list_price) AS total_value
    FROM orders o
    INNER JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) t
ON c.customer_id = t.customer_id

UNION

SELECT 
    first_name + ' ' + last_name AS full_name,
    0 AS total_value,
    'No Orders' AS customer_type
FROM customers
WHERE customer_id NOT IN (SELECT customer_id FROM orders);


---Problem 3 – Store Performance and Stock Validation--

SELECT 
    s.store_name,
    p.product_name,
    SUM(sales.quantity) AS total_quantity_sold,
    SUM((sales.quantity * sales.list_price) - sales.discount) AS total_revenue
FROM
(
    SELECT 
        o.store_id, 
        oi.product_id, 
        oi.quantity, 
        oi.list_price, 
        oi.discount
    FROM orders o
    INNER JOIN order_items oi 
        ON o.order_id = oi.order_id
) AS sales
INNER JOIN stores s 
    ON sales.store_id = s.store_id
INNER JOIN products p 
    ON sales.product_id = p.product_id
GROUP BY 
    s.store_name, 
    p.product_name;

	---------- Problem 4 – Order Cleanup and Data Maintenance ----------
-- Create Archived Orders Table
SELECT *
INTO archived_orders
FROM orders
WHERE 1 = 0;


-- Insert Archived Orders
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


-- Delete Rejected Orders older than one year
DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


-- Customers whose all orders are completed
SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
    SELECT COUNT(*)
    FROM orders o2
    WHERE o2.customer_id = orders.customer_id
    AND o2.order_status = 4
);


-- Order Processing Delay
SELECT 
    order_id,
    DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;


-- Mark Orders as Delayed or On Time
SELECT 
    order_id,
    order_date,
    required_date,
    shipped_date,
    CASE
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status
FROM orders;
