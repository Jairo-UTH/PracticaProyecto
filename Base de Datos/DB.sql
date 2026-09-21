CREATE TABLE "OrderDetail" (
    OrderDetailId INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES "Order"(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductID)
);