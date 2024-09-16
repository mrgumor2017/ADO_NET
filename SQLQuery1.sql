-- Create the database "Sales"
CREATE DATABASE Sales;
GO

-- Use the "Sales" database
USE Sales;
GO

-- Create the "Customers" table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);
GO

-- Create the "Sellers" table
CREATE TABLE Sellers (
    SellerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);
GO

-- Create the "Sales" table
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    SellerID INT NOT NULL,
    SaleAmount DECIMAL(10, 2) NOT NULL,
    SaleDate DATE NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (SellerID) REFERENCES Sellers(SellerID)
);
GO

-- Insert data into the "Customers" table
INSERT INTO Customers (FirstName, LastName) VALUES
('Alexander', 'Ivanov'),
('Maria', 'Petrenko'),
('Ivan', 'Sydorenko');
GO

-- Insert data into the "Sellers" table
INSERT INTO Sellers (FirstName, LastName) VALUES
('Olga', 'Kovalenko'),
('Andrew', 'Shevchenko'),
('Svetlana', 'Melnyk');
GO

-- Insert data into the "Sales" table
INSERT INTO Sales (CustomerID, SellerID, SaleAmount, SaleDate) VALUES
(1, 1, 1500.00, '2023-09-01'),
(2, 2, 3000.50, '2023-09-02'),
(3, 3, 500.75, '2023-09-03');
GO
