DROP TABLE Customer
DROP TABLE PersonalInfo 
DROP TABLE LoginDetails


CREATE TABLE Customer (Id INT NOT NULL  IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(50))

CREATE TABLE PersonalInfo (CustomerId INT, Mobile VARCHAR(10), Email VARCHAR(50), Address VARCHAR(50))

CREATE TABLE LoginDetails (CustomerId INT, Password VARCHAR(50))


SELECT * FROM Customer
SELECT * FROM PersonalInfo 
SELECT * FROM LoginDetails

