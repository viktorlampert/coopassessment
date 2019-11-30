CREATE TABLE Product (
ID	INT	 NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(MAX),
Price FLOAT,
Description VARCHAR(MAX),
);

INSERT INTO Product (Name,Price,Description) VALUES ('Dog Shampoo',10.57,'shampoo for long hair dogs'), ('WD Red 4 TB',150.99,'NAS hard drive'), ('2018 Nissan Mourano',37866.99,'Nissan Mourano AWD with Tech Package?');

SELECT *
INTO Product_Copy
FROM Product;

DELETE FROM Product_Copy WHERE ID = 2;


