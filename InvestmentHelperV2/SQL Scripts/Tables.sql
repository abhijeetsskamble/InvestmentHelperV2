DROP TABLE Customer
DROP TABLE PersonalInfo 
DROP TABLE LoginDetails


CREATE TABLE Customer (Id INT NOT NULL  IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(50))

CREATE TABLE PersonalInfo (CustomerId INT, Mobile VARCHAR(10), Email VARCHAR(50), Address VARCHAR(50))

CREATE TABLE LoginDetails (CustomerId INT, Password VARCHAR(50))

CREATE TABLE InvestmentInfo (CustomerId INT, DOB DATE, Income FLOAT, OtherIncome FLOAT, RENT FLOAT, EF VARCHAR(20), NPS BIT, Risk VARCHAR(20))


SELECT * FROM Customer
SELECT * FROM PersonalInfo 
SELECT * FROM LoginDetails

