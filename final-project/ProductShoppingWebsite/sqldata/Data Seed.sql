DELETE FROM Sellers WHERE SellerId = 10;
DELETE FROM Sellers WHERE SellerId = 11;
DELETE FROM Sellers WHERE SellerId = 12;
DELETE FROM Sellers WHERE SellerId = 13;

DELETE FROM Customers WHERE CustomerId = 20;
DELETE FROM Customers WHERE CustomerId = 21;

DELETE FROM Reports WHERE ReportId = 30;
DELETE FROM Reports WHERE ReportId = 31;
DELETE FROM Reports WHERE ReportId = 32;
DELETE FROM Reports WHERE ReportId = 33
DELETE FROM Reports WHERE ReportId = 34;

SET IDENTITY_INSERT Customers OFF;
SET IDENTITY_INSERT Reports OFF;
SET IDENTITY_INSERT Sellers OFF;

SET IDENTITY_INSERT Sellers ON;

INSERT INTO Sellers
(SellerId, UniqueSellerIdentificator, SellerNickname, Email, PhoneNumber, Address, BankAccountNumber, IsAuthorized, IsArchived, IsBanned, ServiceUserId, FirstName, LastName, BirthDate)
VALUES
(10, 4578, 'Michael Tomys', 'michaeltomys@gmail.com', 784699892, 'Zlota 44 Warsaw, Poland','166884773483', 1, 0, 0, 54789, 'Michal', 'Tomys', '2000-8-27');

INSERT INTO Sellers
(SellerId, UniqueSellerIdentificator, SellerNickname, Email, PhoneNumber, Address, BankAccountNumber, IsAuthorized, IsArchived, IsBanned, ServiceUserId, FirstName, LastName, BirthDate)
VALUES
(11, 6785493, 'Adam Smith', 'adamsmith@gmail.com', 598543798, 'Valley of warrios 1, Uganda','888549047843720', 1, 0, 0, 23455, 'Adam', 'Smith', '1980-3-29');

INSERT INTO Sellers
(SellerId, UniqueSellerIdentificator, SellerNickname, Email, PhoneNumber, Address, BankAccountNumber, IsAuthorized, IsArchived, IsBanned, ServiceUserId, FirstName, LastName, BirthDate)
VALUES
(12, 28971, 'Antoni Smolinski', 'antoni.smolinski@gmail.com', 778989532, 'Polna 1, Konstancin-Jeziorna, Poland','1667678393478', 1, 0, 0, 389127, 'Antoni', 'Smolinski', '2000-1-17');


INSERT INTO Sellers
(SellerId, UniqueSellerIdentificator, SellerNickname, Email, PhoneNumber, Address, BankAccountNumber, IsAuthorized, IsArchived, IsBanned, ServiceUserId, FirstName, LastName, BirthDate)
VALUES
(13, 782345, 'Sebastian Fors', 'forsen@gmail.com', 678569447, 'snus street 1, Stockholm, Sweden','25555839302784', 1, 0, 1, 45689, 'Sebastian', 'Fors', '1990-12-16');

SET IDENTITY_INSERT Sellers OFF;


SELECT * FROM Sellers;


SET IDENTITY_INSERT Customers ON;

INSERT INTO Customers
(CustomerId, UniqueCustomerIdentificator, CustomerNickname, Email, PhoneNumber, BankAccountNumber, IsAuthorized, ServiceUserId, FirstName, LastName, BirthDate)
VALUES
(20, 843928, 'Tomasz Kaczynski', 'tomaszkaczynski@wp.pl', 754897327, '16445378208123', 1, 5870233, 'Tomasz', 'Kaczynski', '1960-11-18');

INSERT INTO Customers
(CustomerId, UniqueCustomerIdentificator, CustomerNickname, Email, PhoneNumber, BankAccountNumber, IsAuthorized, ServiceUserId, FirstName, LastName, BirthDate)
VALUES
(21, 347812, 'Janusz Kowalski', 'januszkowalski@o2.pl', 643228901, '16534807107012', 1, 123879, 'Janusz', 'Kowalski', '1970-6-15');

SET IDENTITY_INSERT Customers OFF;


SELECT * FROM Customers;


SET IDENTITY_INSERT Reports ON;

Insert INTO Reports
(ReportId, UniqueReportIdentificator, ReportDescription, ReportDate, IssuerId, ReportedSellerId)
VALUES
(30, 2310874, 'This seller scammed me 50 times', '2021-5-22', 20, 10);

Insert INTO Reports
(ReportId, UniqueReportIdentificator, ReportDescription, ReportDate, IssuerId, ReportedSellerId)
VALUES
(31, 74539872, 'Please ban this guy... did not deliver on many occasions', '2021-6-15', 20, 10);

Insert INTO Reports
(ReportId, UniqueReportIdentificator, ReportDescription, ReportDate, IssuerId, ReportedSellerId)
VALUES
(32, 23980127, 'Scamming.', '2021-5-23', 21, 11);

Insert INTO Reports
(ReportId, UniqueReportIdentificator, ReportDescription, ReportDate, IssuerId, ReportedSellerId)
VALUES
(33, 68457340, 'Permaban', '2021-5-26', 21, 11);

Insert INTO Reports
(ReportId, UniqueReportIdentificator, ReportDescription, ReportDate, IssuerId, ReportedSellerId)
VALUES
(34, 38473784, 'Did not deliver on time', '2021-5-27', 21, 11);

SET IDENTITY_INSERT Reports OFF;

SELECT * FROM Reports;
