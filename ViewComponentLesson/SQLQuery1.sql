CREATE DATABASE ProductDb
GO
Use ProductDb

CREATE TABLE Categories(
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(50) NOT NULL
)
GO

INSERT INTO Categories([Title])
VALUES
    ('Drink'),
    ('Beverages'),
    ('Junks'),
    ('HotMeals')
GO

SELECT * FROM Categories