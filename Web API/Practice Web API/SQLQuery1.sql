USE MASTER
CREATE DATABASE RestaurantDB
GO
USE RestaurantDB
GO


CREATE TABLE Categories
(
  Id                           INT               NOT NULL PRIMARY KEY,
  [Name]                       NVARCHAR(30)      NOT NULL,
  [CreatedBy]                  INT               NOT NULL,
  [UpdatedBy]                  INT               NULL,
  [DeletedBy]                  INT               NULL,
  [CreatedDate]                DATETIME2         NOT NULL,
  [UpdatedDate]                DATETIME2         NOT NULL,
  [DeletedDate]                DATETIME2         NOT NULL,
  [IsDeleted]                  BIT               NOT NULL    DEFAULT 0,
)
GO

CREATE TABLE Products(

  Id                           INT               NOT NULL PRIMARY KEY,
  [Name]                       NVARCHAR(30)      NOT NULL,
  [Type]                       NVARCHAR(30)      NOT NULL,
  [Barcode]                    NVARCHAR(MAX)     NOT NULL,
  [Price]                      MONEY             NOT NULL CHECK([Price]>0) ,
  [OpenPrice]                  BIT               NOT NULL DEFAULT 0,
  [ButtonColor]                NVARCHAR(MAX)     NOT NULL,
  [TextColor]                  NVARCHAR(MAX)     NOT NULL,
  [InvoiceNumber]              NVARCHAR(MAX)     NOT NULL,
  [CreatedBy]                  INT               NOT NULL,
  [UpdatedBy]                  INT               NULL,
  [DeletedBy]                  INT               NULL,
  [CreatedDate]                DATETIME2         NOT NULL,
  [UpdatedDate]                DATETIME2         NOT NULL,
  [DeletedDate]                DATETIME2         NOT NULL,
  [IsDeleted]                  BIT               NOT NULL    DEFAULT 0,
)



CREATE TABLE AllergenGroups (
 				              
  Id                           INT               NOT NULL PRIMARY KEY,
  [Name]                       NVARCHAR(30)      NOT NULL,
  [Code]                       NVARCHAR(MAX)     NOT NULL,
  [CreatedBy]                  INT               NOT NULL,
  [UpdatedBy]                  INT               NULL,
  [DeletedBy]                  INT               NULL,
  [CreatedDate]                DATETIME2         NOT NULL,
  [UpdatedDate]                DATETIME2         NOT NULL,
  [DeletedDate]                DATETIME2         NOT NULL,
  [IsDeleted]                  BIT               NOT NULL    DEFAULT 0,
)



CREATE TABLE Departments
(
  Id                           INT               NOT NULL PRIMARY KEY,
  [Name]                       NVARCHAR(30)      NOT NULL,
  [CreatedBy]                  INT               NOT NULL,
  [UpdatedBy]                  INT               NULL,
  [DeletedBy]                  INT               NULL,
  [CreatedDate]                DATETIME2         NOT NULL,
  [UpdatedDate]                DATETIME2         NOT NULL,
  [DeletedDate]                DATETIME2         NOT NULL,
  [IsDeleted]                  BIT               NOT NULL    DEFAULT 0,
)


CREATE TABLE Ingredients(
  Id                           INT               NOT NULL PRIMARY KEY,
  [Name]                       NVARCHAR(30)      NOT NULL,
  [MinimumCount]               INT               NOT NULL CHECK([MinimumCount]>0),
  [MaksimumCount]              INT               NOT NULL,
  [FreeIngredientCount]        INT               NULL,
  [CreatedBy]                  INT               NOT NULL,
  [UpdatedBy]                  INT               NULL,
  [DeletedBy]                  INT               NULL,
  [CreatedDate]                DATETIME2         NOT NULL,
  [UpdatedDate]                DATETIME2         NOT NULL,
  [DeletedDate]                DATETIME2         NOT NULL,
  [IsDeleted]                  BIT               NOT NULL    DEFAULT 0,
)



CREATE TABLE Users(
  Id                           INT               NOT NULL PRIMARY KEY,
  [Name]                       NVARCHAR(30)      NOT NULL,
  [Surname]                    NVARCHAR(30)      NOT NULL,
  [Email]                      NVARCHAR(30)      NOT NULL,
  [Phone]                      NVARCHAR(30)      NOT NULL,
  [PasswordHash]               NVARCHAR(MAX)     NOT NULL,
  [CreatedBy]                  INT               NOT NULL,
  [UpdatedBy]                  INT               NULL,
  [DeletedBy]                  INT               NULL,
  [CreatedDate]                DATETIME2         NOT NULL,
  [UpdatedDate]                DATETIME2         NOT NULL,
  [DeletedDate]                DATETIME2         NOT NULL,
  [IsDeleted]                  BIT               NOT NULL    DEFAULT 0,
 )



 CREATE TABLE IngredientDepartments(
  Id                           INT               NOT NULL PRIMARY KEY,
  [IngredientId]               INT               NOT NULL,
  [DepartmentId]               INT               NOT NULL,
  CONSTRAINT FK_IngredientId FOREIGN KEY ([IngredientId])
    REFERENCES Ingredients(Id),
  CONSTRAINT FK_DepartmentId FOREIGN KEY ([DepartmentId])
    REFERENCES Departments(Id),
 )




 CREATE TABLE ProductDepartments(
  Id                           INT               NOT NULL PRIMARY KEY,
  [ProductId]                  INT               NOT NULL,
  [DepartmentId]               INT               NOT NULL,
  CONSTRAINT FK_ProductDId FOREIGN KEY ([ProductId])
    REFERENCES Products(Id),
  CONSTRAINT FK_DepartmentPId FOREIGN KEY ([DepartmentId])
    REFERENCES Departments(Id),
 )
 



 CREATE TABLE ProductIngredients(
  Id                           INT               NOT NULL  PRIMARY KEY,
  [ProductId]                  INT               NOT NULL  FOREIGN KEY REFERENCES Products(Id),
  [DepartmentId]               INT               NOT NULL  FOREIGN KEY REFERENCES Departments(Id)
 )
  



 CREATE TABLE ProductAllergenGroups(
  Id                           INT               NOT NULL PRIMARY KEY,
  [ProductId]                  INT               NOT NULL,
  [AllergenGroupId]            INT               NOT NULL,
  CONSTRAINT FK_ProductId    FOREIGN KEY ([ProductId])
    REFERENCES Products(Id),
  CONSTRAINT FK_AllergenGroupId FOREIGN KEY ([AllergenGroupId])
    REFERENCES AllergenGroups(Id),
 )











