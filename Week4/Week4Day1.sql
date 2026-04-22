-----Level-2 Problem 1: Stored Procedures and User-Defined Functions Scenario----------

-------Create a stored procedure to generate total sales amount per store.--------
create procedure total_Sales_Amount 
AS
BEGIN
	select order_id,sum(quantity*list_price) as 'total_Sales' from order_items group by order_id
END

exec total_Sales_Amount


ALTER PROCEDURE total_Sales_Amount
AS
BEGIN
	SELECT 
		s.store_name,
		SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
	FROM stores s
	INNER JOIN orders o
		ON s.store_id = o.store_id
	INNER JOIN order_items oi
		ON o.order_id = oi.order_id
	GROUP BY s.store_name
END

EXEC total_Sales_Amount;


----Create a stored procedure to retrieve orders by date range.--

CREATE PROCEDURE GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_date,
        order_status
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
    ORDER BY order_date;
END;


EXEC GetOrdersByDateRange '2017-01-01', '2017-12-31';

------Create a scalar function to calculate total price after discount.------
CREATE FUNCTION CalculateTotalPriceAfterDiscount
(
    @list_price DECIMAL(10,2),
    @quantity INT,
    @discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @total DECIMAL(10,2)

    SET @total = @list_price * @quantity * (1 - @discount)

    RETURN @total
END

SELECT 
    order_id,
    dbo.CalculateTotalPriceAfterDiscount(list_price, quantity, discount) AS total_price_after_discount
FROM order_items;


-----Create a table-valued function to return top 5 selling products.----------

CREATE FUNCTION GetTop5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS total_quantity_sold
    FROM order_items oi
    INNER JOIN products p
        ON oi.product_id = p.product_id
    GROUP BY 
        p.product_id,
        p.product_name
    ORDER BY 
        total_quantity_sold DESC
);

SELECT * FROM GetTop5SellingProducts();

--------Problem 2: Stock Auto-Update Trigger Scenario -------

USE EcommAppDb;

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM stocks s
            JOIN inserted i 
                ON s.product_id = i.product_id
            JOIN orders o
                ON o.order_id = i.order_id
            WHERE s.store_id = o.store_id
            AND s.quantity < i.quantity
        )
        BEGIN
            THROW 50001, 'Stock is insufficient for this order.', 1;
        END

        -- Update stock
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i 
            ON s.product_id = i.product_id
        JOIN orders o
            ON o.order_id = i.order_id
        WHERE s.store_id = o.store_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH
END;

