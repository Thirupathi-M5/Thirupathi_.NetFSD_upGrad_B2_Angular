USE ecommappdb;
GO
--------PROB-1---------


CREATE TRIGGER trg_reduce_stock_after_insert
ON order_items
AFTER INSERT
AS
BEGIN

    BEGIN TRY

        -- Check if stock is insufficient
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN orders o ON i.order_id = o.order_id
            JOIN stocks s ON s.product_id = i.product_id 
                         AND s.store_id = o.store_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR ('Stock insufficient. Order cannot be placed.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Reduce stock
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i ON s.product_id = i.product_id
        JOIN orders o ON i.order_id = o.order_id
        WHERE s.store_id = o.store_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH

END
GO


-- transaction

BEGIN TRANSACTION;

INSERT INTO orders
(order_id, customer_id, order_status, order_date, required_date, store_id, staff_id)
VALUES
(2001, 5, 1, GETDATE(), DATEADD(day,7,GETDATE()), 1, 2);

INSERT INTO order_items
(item_id, order_id, product_id, quantity, list_price, discount)
VALUES
(1, 2001, 5, 2, 1500, 0.10),
(2, 2001, 7, 1, 800, 0.05);

COMMIT TRANSACTION;

-- Verify stock
SELECT *
FROM stocks
WHERE product_id IN (5,7);



---PROB-2------
 -- order cancellation with savepoint 
 
CREATE PROCEDURE cancel_order_atomic
    @p_order_id INT
AS
BEGIN

    BEGIN TRY

        BEGIN TRANSACTION;

        -- Savepoint before stock restoration
        SAVE TRANSACTION before_stock_restore;

        -- Restore stock quantities
        UPDATE s
        SET s.quantity = s.quantity + oi.quantity
        FROM stocks s
        JOIN orders o ON o.store_id = s.store_id
        JOIN order_items oi ON oi.product_id = s.product_id
        WHERE oi.order_id = @p_order_id
        AND o.order_id = @p_order_id;

        -- If stock restoration fails rollback to savepoint
        IF @@ROWCOUNT = 0
        BEGIN
            ROLLBACK TRANSACTION before_stock_restore;
            RAISERROR ('Stock restoration failed.',16,1);
            RETURN;
        END

        -- Update order status to Rejected (3)
        UPDATE orders
        SET order_status = 3
        WHERE order_id = @p_order_id;

        COMMIT TRANSACTION;

        SELECT 'Order cancelled successfully and stock restored.' AS message;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        SELECT 
        ERROR_MESSAGE() AS ErrorMessage;

    END CATCH

END
GO

-- execute procedure

EXEC cancel_order_atomic 2001;

-- verify order status
SELECT order_id, order_status
FROM orders
WHERE order_id = 2001;

-- verify stock restoration

SELECT product_id, store_id, quantity
FROM stocks
WHERE product_id IN
(
    SELECT product_id
    FROM order_items
    WHERE order_id = 2001
);