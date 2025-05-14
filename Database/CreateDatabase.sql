-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Retete')
BEGIN
    CREATE DATABASE Retete;
END
GO

USE Retete;
GO

-- Create Categories Table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Description NVARCHAR(200)
);

-- Create Recipes Table
CREATE TABLE Recipes (
    RecipeId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    PrepTime INT, -- in minutes
    CookTime INT, -- in minutes
    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
    ImageUrl NVARCHAR(200),
    Instructions NVARCHAR(MAX),
    Ingredients NVARCHAR(MAX),
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Insert Sample Categories
INSERT INTO Categories (Name, Description) VALUES 
('Appetizer', 'Light dishes to start your meal'),
('Main Course', 'Primary dishes for your meal');

-- Insert Sample Recipes
INSERT INTO Recipes (Name, Description, PrepTime, CookTime, CategoryId, ImageUrl, Instructions, Ingredients) VALUES
('Egg Manchurian', 'Delicious Indo-Chinese fusion appetizer', 15, 15, 1, '/img/recepie/recpie_1.png', 
'1. Boil and slice eggs
2. Prepare manchurian sauce
3. Coat eggs with cornflour
4. Deep fry
5. Toss in sauce', 
'6 eggs, Cornflour, Soy sauce, Ginger, Garlic'),

('Pure Vegetable Bowl', 'Healthy vegetarian appetizer', 20, 10, 1, '/img/recepie/recpie_2.png',
'1. Chop all vegetables
2. Prepare dressing
3. Mix and serve', 
'Mixed vegetables, Olive oil, Lemon juice, Salt, Pepper'),

('Chicken Curry', 'Traditional spicy chicken curry', 20, 25, 2, '/img/recepie/recpie_4.png',
'1. Marinate chicken
2. Prepare curry base
3. Cook chicken
4. Simmer in sauce', 
'Chicken, Onions, Tomatoes, Spices, Yogurt');
GO 