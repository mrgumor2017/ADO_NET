-- Create the database
CREATE DATABASE Sales;

-- Use the created database
USE Sales;

-- Create the Customers table
CREATE TABLE Customers (
    id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

-- Create the Sellers table
CREATE TABLE Sellers (
    id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

-- Create the Sales table
CREATE TABLE Sales (
    id INT PRIMARY KEY,
    customer_id INT,
    seller_id INT,
    amount DECIMAL(10, 2),
    sale_date DATE,
    FOREIGN KEY (customer_id) REFERENCES Customers(id),
    FOREIGN KEY (seller_id) REFERENCES Sellers(id)
);

-- Populate the Customers table with data
INSERT INTO Customers (id, first_name, last_name) VALUES
(1, 'Alexander', 'Ivanov'),
(2, 'Maria', 'Koval'),
(3, 'Andrew', 'Shevchenko'),
(4, 'Irina', 'Petrenko'),
(5, 'Dmitry', 'Sidorenko');

-- Populate the Sellers table with data
INSERT INTO Sellers (id, first_name, last_name) VALUES
(1, 'Oleg', 'Honchar'),
(2, 'Svetlana', 'Kovalenko'),
(3, 'Sergey', 'Boyko'),
(4, 'Natalia', 'Melnik'),
(5, 'Victor', 'Tkachenko');

-- Populate the Sales table with data
INSERT INTO Sales (id, customer_id, seller_id, amount, sale_date) VALUES
(1, 1, 1, 1500.00, '2024-01-01'),
(2, 2, 2, 2500.00, '2024-01-02'),
(3, 3, 3, 3500.00, '2024-01-03'),
(4, 4, 4, 4500.00, '2024-01-04'),
(5, 5, 5, 5500.00, '2024-01-05');

Select * from Sales