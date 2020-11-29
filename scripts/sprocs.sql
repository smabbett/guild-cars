USE GuildCars;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyColorSelectAll')
   DROP PROCEDURE BodyColorSelectAll
GO

CREATE PROCEDURE BodyColorSelectAll
AS
BEGIN
	SELECT BodyColorID, BodyColorName
	FROM BodyColor
	ORDER BY BodyColorName
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyStyleSelectAll')
   DROP PROCEDURE BodyStyleSelectAll
GO

CREATE PROCEDURE BodyStyleSelectAll
AS
BEGIN
	SELECT BodyStyleID, BodyDescription
	FROM BodyStyle
	ORDER BY BodyDescription
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactSelectAll')
   DROP PROCEDURE ContactSelectAll
GO

CREATE PROCEDURE ContactSelectAll
AS
BEGIN
	SELECT ContactID, FullName, Email, Phone, [Message], Vin, DateAdded
	FROM Contact
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CustomerSelectAll')
   DROP PROCEDURE CustomerSelectAll
GO

CREATE PROCEDURE CustomerSelectAll
AS
BEGIN
	SELECT CustomerID, FullName, Email, Phone, Street1, Street2, City, [State], ZipCode
	FROM Customer
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CustomerInsert')
   DROP PROCEDURE CustomerInsert
GO

CREATE PROCEDURE CustomerInsert(
	@CustomerID INT OUTPUT,
	@FullName NVARCHAR(30),
	@Email NVARCHAR(30),
	@Phone VARCHAR(24),
	@Street1 NVARCHAR(30),
	@Street2 NVARCHAR(30),
	@City NVARCHAR(15),
	@State CHAR(2),
	@ZipCode CHAR(5))
AS
BEGIN
	INSERT INTO Customer(FullName, Email, Phone, Street1, Street2, City, [State], ZipCode)
	VALUES(@FullName, @Email, @Phone, @Street1, @Street2, @City, @State, @ZipCode);

	SET @CustomerID = SCOPE_IDENTITY();
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorSelectAll')
   DROP PROCEDURE InteriorColorSelectAll
GO

CREATE PROCEDURE InteriorColorSelectAll
AS
BEGIN
	SELECT InteriorColorID, InteriorColorName
	FROM InteriorColor
	ORDER BY InteriorColorName
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectAll')
   DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll
AS
BEGIN
	SELECT MakeID, MakeName, DateAdded, UserID
	FROM Make
	ORDER BY MakeName
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeListSelectAll')
   DROP PROCEDURE MakeListSelectAll
GO

CREATE PROCEDURE MakeListSelectAll
AS
BEGIN
	SELECT MakeID, MakeName, DateAdded, UserID, Email
	FROM Make
		INNER JOIN AspNetUsers ON Make.UserID = AspNetUsers.Id
	ORDER BY MakeName
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelSelectAll')
   DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll
AS
BEGIN
	SELECT ModelID, ModelName, MakeID, DateAdded, UserID
	FROM Model
	ORDER BY ModelName
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelListSelectAll')
   DROP PROCEDURE ModelListSelectAll
GO

CREATE PROCEDURE ModelListSelectAll
AS
BEGIN
	SELECT ModelID, ModelName, MakeName, md.DateAdded, Email
	FROM Model md
		INNER JOIN Make mk ON mk.MakeID = md.MakeID
		INNER JOIN AspNetUsers u ON md.UserID = u.Id
	ORDER BY MakeName, ModelName
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseSelectAll')
   DROP PROCEDURE PurchaseSelectAll
GO

CREATE PROCEDURE PurchaseSelectAll
AS
BEGIN
	SELECT PurchaseID, PurchaseType, PurchasePrice, PurchaseDate, CustomerID, UserID, SpecialID, VehicleID
	FROM Purchase
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelectAll')
   DROP PROCEDURE SpecialSelectAll
GO

CREATE PROCEDURE SpecialSelectAll
AS
BEGIN
	SELECT SpecialID, Title, SpecialDescription, UserID
	FROM Special
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelectByID')
   DROP PROCEDURE SpecialSelectByID
GO

CREATE PROCEDURE SpecialSelectByID(
	@SpecialID int)
AS
BEGIN
	SELECT SpecialID, Title, SpecialDescription
	FROM Special
	WHERE SpecialID = @SpecialID
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateSelectAll')
   DROP PROCEDURE StateSelectAll
GO

CREATE PROCEDURE StateSelectAll
AS
BEGIN
	SELECT StateID, StateName
	FROM [State]
	ORDER BY StateID
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TransmissionSelectAll')
   DROP PROCEDURE TransmissionSelectAll
GO

CREATE PROCEDURE TransmissionSelectAll
AS
BEGIN
	SELECT TransmissionID, Gears
	FROM Transmission
	ORDER BY Gears
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectAll')
   DROP PROCEDURE VehicleSelectAll
GO

CREATE PROCEDURE VehicleSelectAll
AS
BEGIN
	SELECT VehicleID, VehicleYear, MakeID, ModelID, Price, Mileage, Vin, MSRP, VehicleDescription, 
	VehicleType, ImageFileName, BodyStyleID, TransmissionID, BodyColorID, InteriorColorID, DateAdded, SaleStatus, IsFeatured
	FROM Vehicle
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleInsert')
   DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert(
	@VehicleID INT OUTPUT,
	@VehicleYear INT,
	@MakeID INT,
	@ModelID INT,
	@Price DECIMAL(9,2),
	@Mileage INT,
	@Vin CHAR(17),
	@MSRP DECIMAL(9,2),
	@VehicleDescription VARCHAR(300),
	@VehicleType VARCHAR(5),
	@BodyStyleID INT,
	@TransmissionID INT,
	@BodyColorID INT,
	@InteriorColorID INT,
	@SaleStatus BIT,
	@IsFeatured BIT)
AS
BEGIN
	INSERT INTO Vehicle(VehicleYear, MakeID, ModelID, Price, Mileage, Vin, MSRP, VehicleDescription, VehicleType, BodyStyleID, TransmissionID, BodyColorID, InteriorColorID, SaleStatus, IsFeatured)
	VALUES (@VehicleYear, @MakeID, @ModelID, @Price, @Mileage, @Vin, @MSRP, @VehicleDescription, @VehicleType, @BodyStyleID, @TransmissionID, @BodyColorID, @InteriorColorID, @SaleStatus, @IsFeatured);

	SET @VehicleID = SCOPE_IDENTITY();
END

GO	

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleUpdate')
   DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate(
	@VehicleID INT,
	@VehicleYear INT,
	@MakeID INT,
	@ModelID INT,
	@Price DECIMAL(9,2),
	@Mileage INT,
	@Vin CHAR(17),
	@MSRP DECIMAL(9,2),
	@VehicleDescription VARCHAR(300),
	@VehicleType VARCHAR(5),
	@ImageFileName VARCHAR(MAX),
	@BodyStyleID INT,
	@TransmissionID INT,
	@BodyColorID INT,
	@InteriorColorID INT,
	@SaleStatus BIT,
	@IsFeatured BIT)
AS
BEGIN
	UPDATE Vehicle SET
		VehicleYear = @VehicleYear,
		MakeID = @MakeId,
		ModelID = @ModelID, 
		Price = @Price, 
		Mileage = @Mileage, 
		Vin = @Vin, 
		MSRP = @MSRP, 
		VehicleDescription = @VehicleDescription, 
		VehicleType = @VehicleType, 
		ImageFileName = @ImageFileName, 
		BodyStyleID = @BodyStyleID, 
		TransmissionID = @TransmissionID, 
		BodyColorID = @BodyColorID, 
		InteriorColorID = @InteriorColorID, 
		SaleStatus = @SaleStatus, 
		IsFeatured = @IsFeatured
	WHERE VehicleID = @VehicleID
END

GO	

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactInsert')
   DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert(
	@ContactID INT OUTPUT,
	@FullName NVARCHAR(30),
	@Email NVARCHAR(30),
	@Phone VARCHAR(24),
	@Message VARCHAR(300),
	@Vin CHAR(17))
AS
BEGIN
	INSERT INTO Contact(FullName, Email, Phone, [Message], Vin)
	VALUES (@FullName, @Email, @Phone, @Message, @Vin);

	SET @ContactID = SCOPE_IDENTITY();
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseInsert')
   DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert(
	@PurchaseID INT OUTPUT,
	@PurchaseType VARCHAR(20),
	@PurchasePrice DECIMAL(9,2),
	@CustomerID INT,
	@UserID NVARCHAR(128),
	@SpecialID INT,
	@VehicleID INT,
	@SaleStatus BIT)
AS
BEGIN
	INSERT INTO Purchase(PurchaseType, PurchasePrice, CustomerID, UserID, SpecialID, VehicleID)
	VALUES (@PurchaseType, @PurchasePrice, @CustomerID, @UserID, @SpecialID, @VehicleID);

	SET @PurchaseID = SCOPE_IDENTITY();

	UPDATE Vehicle
	SET SaleStatus = @SaleStatus
	WHERE VehicleID = @VehicleID	
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
   DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert(
	@MakeID INT OUTPUT,
	@MakeName VARCHAR(20),
	@UserID NVARCHAR(128))
AS
BEGIN
	INSERT INTO Make(MakeName, UserID)
	VALUES (@MakeName, @UserID);

	SET @MakeID = SCOPE_IDENTITY();
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelInsert')
   DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert(
	@ModelID INT OUTPUT,
	@ModelName VARCHAR(20),
	@MakeID INT,
	@UserID NVARCHAR(128))
AS
BEGIN
	INSERT INTO Model(ModelName, MakeID, UserID)
	VALUES (@ModelName, @MakeID, @UserID);

	SET @ModelID = SCOPE_IDENTITY();
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialInsert')
   DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert(
	@SpecialID INT OUTPUT,
	@Title VARCHAR(100),
	@SpecialDescription VARCHAR(300),
	@UserID NVARCHAR(128))
AS
BEGIN
	INSERT INTO Special(Title, SpecialDescription, UserID)
	VALUES (@Title, @SpecialDescription, @UserID);

	SET @SpecialID = SCOPE_IDENTITY();
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialDelete')
   DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete(
	@SpecialID INT)
AS
BEGIN
	DELETE FROM Special
	WHERE SpecialID = @SpecialID
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InventoryReport')
   DROP PROCEDURE InventoryReport
GO

CREATE PROCEDURE InventoryReport(@VehicleType VARCHAR(5))
AS
BEGIN
	SELECT VehicleYear, MakeName, ModelName, Count(*) AS [Count], Sum(MSRP) AS StockValue
	FROM Vehicle
		INNER JOIN Make ON Vehicle.MakeID = Make.MakeID
		INNER JOIN Model ON Vehicle.ModelID = Model.ModelID
	WHERE VehicleType = @VehicleType AND SaleStatus = 1
	GROUP BY VehicleYear, MakeName, ModelName
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesReport')
   DROP PROCEDURE SalesReport
GO

CREATE PROCEDURE SalesReport(@UserID INT, @FromDate DATETIME, @ToDate DATETIME)
AS
BEGIN
	SELECT UserName, Sum(PurchasePrice) AS TotalSales, Count(*) AS TotalVehicles
		FROM Purchase
			INNER JOIN AspNetUsers ON Purchase.UserID = AspNetUsers.Id
		WHERE PurchaseDate >= @FromDate AND PurchaseDate <= @ToDate
		GROUP BY UserName
END
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectByID')
   DROP PROCEDURE VehicleSelectByID
GO

CREATE PROCEDURE VehicleSelectByID(
	@VehicleID INT)
AS
BEGIN
	SELECT VehicleID, VehicleYear, MakeID, ModelID, Price, Mileage, Vin, MSRP, VehicleDescription, VehicleType, ImageFileName, BodyStyleID, TransmissionID, BodyColorID, InteriorColorID, DateAdded, SaleStatus, IsFeatured
	FROM Vehicle
	WHERE VehicleID = @VehicleID
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectDetails')
   DROP PROCEDURE VehicleSelectDetails
GO

CREATE PROCEDURE VehicleSelectDetails(
	@VehicleID INT)
AS
BEGIN
	SELECT VehicleID, VehicleYear, mk.MakeName, md.ModelName, Price, Mileage, Vin, MSRP, VehicleDescription, VehicleType, ImageFileName, bs.BodyDescription, t.Gears, BodyColorName, InteriorColorName, SaleStatus
	FROM Vehicle v
		INNER JOIN Make mk ON v.MakeID = mk.MakeID
		INNER JOIN Model md ON V.ModelID = md.ModelID
		INNER JOIN BodyStyle bs ON v.BodyStyleID = bs.BodyStyleID
		INNER JOIN Transmission t ON v.TransmissionID = t.TransmissionID
		INNER JOIN BodyColor bc ON v.BodyColorID = bc.BodyColorID
		INNER JOIN InteriorColor ic ON v.InteriorColorID = ic.InteriorColorID
	WHERE VehicleID = @VehicleID
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'FeaturedVehicleSelectAll')
   DROP PROCEDURE FeaturedVehicleSelectAll
GO

CREATE PROCEDURE FeaturedVehicleSelectAll
AS
BEGIN
	SELECT VehicleID, VehicleYear, MakeName, ModelName, Price, 
	ImageFileName, IsFeatured, Vin
	FROM Vehicle v
		INNER JOIN Make mk ON mk.MakeID = v.MakeID
		INNER JOIN Model md ON md.ModelID = v.ModelID
	WHERE IsFeatured = 1
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleDelete')
   DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete(
	@VehicleID INT)
AS
BEGIN
	DELETE FROM Vehicle
	WHERE VehicleID = @VehicleID
END

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UserRoleSelectAll')
   DROP PROCEDURE UserRoleSelectAll
GO

CREATE PROCEDURE UserRoleSelectAll
	
AS
BEGIN
SELECT FirstName, LastName, Email, rl.Name, u.Id 
FROM AspNetUsers u
	INNER JOIN AspNetUserRoles r ON r.UserId = u.Id
	INNER JOIN AspNetRoles rl ON rl.Id = r.RoleId
END

GO


