USE GuildCars;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
   DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset
AS
BEGIN
	DELETE FROM Purchase;
	DELETE FROM Vehicle;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM Special;
	DELETE FROM Customer;
	DELETE FROM InteriorColor;
	DELETE FROM BodyColor;
	DELETE FROM Transmission;
	DELETE FROM BodyStyle;
	DELETE FROM Contact;
	DELETE FROM [State];
	DELETE FROM AspNetUserRoles WHERE UserId IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111');
	DELETE FROM AspNetUsers WHERE id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111');

	DBCC CHECKIDENT ('vehicle', RESEED, 1)
	DBCC CHECKIDENT ('special', RESEED, 1)
	DBCC CHECKIDENT ('make', RESEED, 1)
	DBCC CHECKIDENT ('model', RESEED, 1)
	DBCC CHECKIDENT ('purchase', RESEED, 1)
	DBCC CHECKIDENT ('contact', RESEED, 1)
	DBCC CHECKIDENT ('customer', RESEED, 1)

	INSERT INTO AspNetUsers(FirstName, LastName, Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('John', 'Smith', '00000000-0000-0000-0000-000000000000', 0, 0, 'john@test.com',  0, 0, 0, 'john'),
	('Sally', 'Jones', '11111111-1111-1111-1111-111111111111', 0, 0, 'sally@test.com', 0, 0, 0, 'sally');
	
	INSERT INTO AspNetUserRoles(RoleId, UserId)
	VALUES('e31414d8-7cc7-4e32-bcde-2fa458ad6ca9', '00000000-0000-0000-0000-000000000000'),
	('12a936b1-787f-4332-b338-018559f929da', '11111111-1111-1111-1111-111111111111');

	INSERT INTO [State](StateID, StateName)
	VALUES ('AL','Alabama'),
	('AK', 'Alaska'),
	('AZ', 'Arizona'),
	('AR', 'Arkansas'),
	('CA', 'California'),
	('CO', 'Colorado'),
	('CT', 'Conneticut'),
	('DE', 'Delaware'),
	('FL', 'Florida'),
	('GA', 'Georgia'),
	('HI', 'Hawaii'),
	('ID', 'Idaho'),
	('IL', 'Illinois'),
	('IN', 'Indiana'),
	('IA', 'Iowa'),
	('KS', 'Kansaa'),
	('KY', 'Kentucky'),
	('LA', 'Louisiana'),
	('ME', 'Maine'),
	('MD', 'Maryland'),
	('MA', 'Massachusetts'),
	('MI', 'Michigan'),
	('MN', 'Minnesota'),
	('MS', 'Mississippi'),
	('MO', 'Missouri')

	SET IDENTITY_INSERT BodyStyle ON;
	INSERT INTO BodyStyle(BodyStyleID,BodyDescription)
	VALUES (1,'Car'),
	(2,'SUV'),
	(3,'Truck'),
	(4,'Van')
	SET IDENTITY_INSERT BodyStyle OFF;

	SET IDENTITY_INSERT Contact ON;
	INSERT INTO Contact(ContactID, FullName, Email, Phone, [Message], Vin)
	VALUES (1,'Debbie Downer', 'deb@msn.com', '612-555-5555', 'I would like to discuss the purchase of this vehicle.', '1GKUKKE30AR251404'),
	(2,'Penny Page', 'penny@msn.com', '430-444-4444', 'I need to test drive this car.', '1GKUKKE30AR251404'),
	(3,'Oscar Smith', 'oscar@msn.com', '612-333-3333', 'Beautiful car. Please contact me.', '1GKUBBE30AR251111'),
	(4,'Matt Jacobs', 'matt@msn.com', '877-222-2222', 'I want to make an offer on this vehicle.', '1GKUKKE30AR251404'),
	(5,'Stella Singer', 'stella@msn.com', '612-123-1234', 'I like cars.',null)
	SET IDENTITY_INSERT Contact OFF;

	SET IDENTITY_INSERT Transmission ON;
	INSERT INTO Transmission(TransmissionID, Gears)
	VALUES (1,'Automatic'),
	(2,'Manual')
	SET IDENTITY_INSERT Transmission OFF;

	SET IDENTITY_INSERT BodyColor ON;
	INSERT INTO BodyColor(BodyColorID,BodyColorName)
	VALUES (1,'Blue'),
	(2,'Red'),
	(3,'Black'),
	(4,'Silver'),
	(5,'Gold')
	SET IDENTITY_INSERT BodyColor OFF;

	SET IDENTITY_INSERT InteriorColor ON;
	INSERT INTO InteriorColor(InteriorColorID,InteriorColorName)
	VALUES (1,'Grey'),
	(2,'Tan'),
	(3,'Black'),
	(4,'White'),
	(5,'Gold')
	SET IDENTITY_INSERT InteriorColor OFF;

	SET IDENTITY_INSERT Customer ON;
	INSERT INTO Customer(CustomerID, FullName, Email, Phone, Street1, City, [State], ZipCode)
	VALUES (1, 'John Smith', 'john@apple.com', '970-555-4444', '123 Main Street', 'Vail', 'CO', '55444'),
	(2, 'Bob Jones', 'bob@apple.com', '612-444-2222', '111 Oak Street', 'Detroit', 'MI', '55444'),
	(3, 'Sarah Nelson', 'sarah@apple.com', '763-222-2222', '123 Main Street', 'Minneapolis', 'MN', '55111')
	SET IDENTITY_INSERT Customer OFF;

	SET IDENTITY_INSERT Special ON;
	INSERT INTO Special(SpecialID,Title, SpecialDescription, UserID)
	VALUES (1, 'Zero Down', 'Lease with zero down payment and only $250 per month!', '11111111-1111-1111-1111-111111111111'),
	(2, 'Alignment', 'Bring your car for service today! Alignment only $99.99!', '11111111-1111-1111-1111-111111111111'),
	(3, 'Prius Lease', 'Lease a 2017 Prius for $249/month for 36 months!', '11111111-1111-1111-1111-111111111111')
	SET IDENTITY_INSERT Special OFF;

	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeID,MakeName,UserID)
	VALUES ('1','Chrysler', '11111111-1111-1111-1111-111111111111'),
	('2','Ford', '11111111-1111-1111-1111-111111111111'),
	('3','Volkswagen', '00000000-0000-0000-0000-000000000000'),
	('4','Chevrolet', '00000000-0000-0000-0000-000000000000')
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelID,ModelName,MakeID, UserID)
	VALUES ('1','300', '1', '00000000-0000-0000-0000-000000000000'),
	('2','Pacifica', '1', '00000000-0000-0000-0000-000000000000'),
	('3','Beetle', '3', '00000000-0000-0000-0000-000000000000'),
	('4','Malibu', '4', '00000000-0000-0000-0000-000000000000'),
	('5','Corvette','4', '11111111-1111-1111-1111-111111111111'),
	('6','Cruze','4', '11111111-1111-1111-1111-111111111111'),
	('7','Jetta','3', '11111111-1111-1111-1111-111111111111'),
	('8','Passat','3', '11111111-1111-1111-1111-111111111111'),
	('9','Focus','2', '11111111-1111-1111-1111-111111111111'),
	('10','Fiesta','2', '11111111-1111-1111-1111-111111111111')
	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT Vehicle ON;
	INSERT INTO Vehicle(VehicleID, VehicleYear, MakeID, ModelID, Price, Mileage, Vin, MSRP, 
	VehicleDescription, VehicleType, ImageFileName, BodyStyleID, TransmissionID, BodyColorID, InteriorColorID, SaleStatus, IsFeatured)
	VALUES (1, 2008, 1, 1, 13000, 20000, '1GKUKKE30AR251404',14000,
	 'This is an amazing value!', 'Used', 'greencar.jpg', 1, 1, 1, 1, 1, 1),
	(2, 2009, 1, 2, 14000, 21000, '1KKUKKE30AR251408',15000,
	 'Buy it today!', 'Used', 'redcar.jpg', 2, 2, 2, 1, 0, 0),
	(3, 2010, 2, 9, 14500, 22000, '1GKUBBE30AR251222',15500,
	 'This is too good to be true!', 'Used', 'yellowcar.jpg', 3, 1, 3, 1, 0, 1),
	(4, 2011, 2, 10, 15000, 23000, '1GKUBBE30AR251333',16000,
	 'This is an awesome value!', 'Used', 'bluecar.jpg', 4, 2, 4, 1, 1, 0),
	(5, 2012, 3, 3, 16000, 24000, '1GKUBBE30AR251444',17000,
	 'This is a steal!', 'Used', 'purplecar.jpg', 1, 1, 5, 1, 0, 1),
	(6, 2016, 3, 7, 17000, 1000, '1GKUBBE30AR251AAA',18000,
	 'This is an amazing value!', 'New', 'browncar.jpg', 1, 1, 5, 1, 1, 0),
	(7, 2017, 4, 5, 18000, 1000, '1GKUBBE30AR25VVVV',19000,
	 'This is a super value!', 'New', 'redcar.jpg', 1, 1, 5, 1, 1, 1),
	(8, 2017, 4, 6, 19000, 1000, '1GKUBBE30AR25EE4E',20000,
	 'This is a great deal!', 'New', 'yellowcar.jpg', 1, 1, 5, 1, 1, 1)
	SET IDENTITY_INSERT Vehicle OFF;

	SET IDENTITY_INSERT Purchase ON;
	INSERT INTO Purchase(PurchaseID, PurchaseType, PurchasePrice, CustomerID, UserID, VehicleID)
	VALUES (1,'Cash', 20000, 1, '11111111-1111-1111-1111-111111111111', 2),
	(2,'Bank Finace', 15000, 2, '00000000-0000-0000-0000-000000000000', 3),
	(3, 'Dealer Finance', 18000, 3, '00000000-0000-0000-0000-000000000000', 5)
	SET IDENTITY_INSERT Purchase OFF;
END
