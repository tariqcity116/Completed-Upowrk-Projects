 -- Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

--  Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    ProductDescription VARCHAR(255),
    Price DECIMAL(10, 2),
    Category VARCHAR(50)
);

--  Orders Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    EmployeeID INT,
    ProductID INT,
    OrderDate DATE,
    Quantity INT,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

--  ProductHistory Table
CREATE TABLE ProductHistory (
    HistoryID INT PRIMARY KEY,
    ProductID INT,
    EmployeeID INT,
    Action VARCHAR(20),
    Date DATE,
    Description VARCHAR(255),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

--  Bills Table
CREATE TABLE Bills (
    BillID INT PRIMARY KEY,
    ProductID INT,
    QuantityPurchased INT,
    TotalAmount DECIMAL(10, 2),
    Date DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


-- Assets Table
CREATE TABLE Assets (
    AssetID INT PRIMARY KEY,
    AssetName VARCHAR(100),
    AssetDescription VARCHAR(255),
    EmployeeID INT,
    DateIssued DATE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

