-- Tworzenie tabeli Cosmetics
CREATE TABLE Cosmetics (
    CosmeticId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(MAX) NOT NULL,
    Brand NVARCHAR(MAX),
    Category NVARCHAR(MAX),
    SkinType NVARCHAR(MAX)
);

INSERT INTO Cosmetics (Name, Brand, Category, SkinType)
VALUES
    ('Krem nawil¿aj¹cy', 'Nivea', 'Face Care', 'Dry Skin'),
    ('Szampon', 'Head & Shoulders', 'Hair Care', 'All Hair Types'),
    ('Tonik', 'Bielenda', 'Face Care', 'Sensitive Skin'),
    ('Pomadka', 'Maybelline', 'Makeup', 'All Skin Types'),
    ('¯el pod prysznic', 'Dove', 'Body Care', 'Normal Skin');

-- Tworzenie tabeli Customers
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX),
    SkinType NVARCHAR(MAX)
);

INSERT INTO Customers (Name, Email, SkinType)
VALUES
    ('Jan Kowalski', 'jan.kowalski@example.com', 'Oily Skin'),
    ('Anna Nowak', 'anna.nowak@example.com', 'Combination Skin'),
    ('Tomasz Nowicki', 'tomasz.nowicki@example.com', 'Dry Skin'),
    ('Katarzyna Wiœniewska', 'katarzyna.wisniewska@example.com', 'Normal Skin'),
    ('Piotr Lewandowski', 'piotr.lewandowski@example.com', 'Sensitive Skin');


-- Tworzenie tabeli Recommendations
CREATE TABLE Recommendations (
    RecommendationId INT PRIMARY KEY IDENTITY,
    CustomerId INT NOT NULL,
    CosmeticId INT NOT NULL,
    Notes NVARCHAR(MAX),
    CONSTRAINT FK_Recommendations_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    CONSTRAINT FK_Recommendations_Cosmetics FOREIGN KEY (CosmeticId) REFERENCES Cosmetics(CosmeticId)
);

INSERT INTO Recommendations (CustomerId, CosmeticId, Notes)
VALUES
    (1, 1, 'Bardzo dobry krem do twarzy.'),
    (2, 2, 'Skuteczny szampon, polecam.'),
    (3, 3, 'Delikatny tonik, idealny do skóry wra¿liwej.'),
    (4, 4, 'Piêkna kolorystyka pomadki.'),
    (5, 5, '¯el o przyjemnym zapachu i delikatnej formule.');

