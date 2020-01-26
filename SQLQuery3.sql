

use Railway

drop table USER_ADMIN

CREATE TABLE User_Admin
(
ID int IDENTITY(101,1) PRIMARY KEY,
FirstName varchar(20) NOT NULL,
LastName varchar(10) NOT NULL,
DOB Date NOT NULL,
Sex varchar(6) NOT NULL,
Email varchar(30) NOT NULL,
MobileNo varchar(10) NOT NULL,
Password varchar(20) NOT NULL, 
Roles varchar(6) NOT NULL,
)
INSERT INTO User_Admin VALUES( 'Monika', 'Kamaraj', '1998-11-12', 'Female', 'monika@gmail.com', '7010502110', 'moni', 'Admin')
INSERT INTO User_Admin VALUES( 'Mahes', 'Kamaraj', '1965-08-12', 'Female', 'mahes@gmail.com', '9944600013', 'mahes', 'Admin')
select * from User_Admin
-----------------------------------------------------------------------------------------------------------
drop procedure user_admin_registration
CREATE PROCEDURE User_Admin_Registration	
	@firstname varchar(20),
	@lastname varchar(10),
	@dob Date,
	@sex varchar(6) ,
	@email varchar(30) ,
	@mobileno varchar(10) ,
	@password varchar(20), 
	@role varchar(6)
AS
BEGIN
	INSERT INTO User_Admin(FirstName, LastName, DOB, Sex, Email, MobileNo, Password, Roles) VALUES (@firstname, @lastname, @dob, @sex, @email, @mobileno, @password, @role)
END

exec USER_ADMIN_Registration @firstname = 'Moni', @lastname ='K',@dob = '1999-11-12', @sex='Female', @email='moni@gmail.com', @mobileno = '9944600014', @password = 'moni', @role = 'Admin'
-----------------------------------------------------------------------------------------------------------

CREATE PROCEDURE spCheckDB
	@firstname  varchar(20),
	@password varchar(20),
	@id int OUT
AS
BEGIN	
		SELECT @id = ID FROM User_Admin WHERE FirstName = @firstname AND Password = @password
		
		IF(@id > 100)
		BEGIN
			RETURN @id
		END
		ELSE
		BEGIN
			SET @id = 1
			RETURN @id
		END
END
	

CREATE PROCEDURE spFetchRole
	
	@id INT,
	@role varchar(6) OUT
AS
	SELECT @role = Roles FROM User_Admin WHERE ID = @id

drop procedure spFetchRole

CREATE TABLE TrainClass
(
ClassId int IDENTITY(1,1) PRIMARY KEY,
Category varchar(20)
)	
INSERT INTO TrainClass (Category) VALUES ('AC 1ST CLASS')
INSERT INTO TrainClass (Category) VALUES ('AC 2 TIER')
INSERT INTO TrainClass (Category) VALUES ('AC 3 TIER')
INSERT INTO TrainClass (Category) VALUES ('SLEEPER CLASS')
INSERT INTO TrainClass (Category) VALUES ('SEMI SLEEPER')
INSERT INTO TrainClass (Category) VALUES ('GENERAL')

SELECT * FROM TrainClass
drop table TrainClass
-----------------------------------------------------------------------------------------------------------------------------
CREATE TABLE TrainDetails
(
TrainNo int PRIMARY KEY,
TrainName varchar(60) NOT NULL,
TrainType varchar(20) NOT NULL,
RunDays varchar(20) NOT NULL,
ClassAvailable varchar(10) NOT NULL,
DepartureTime time NOT NULL,
ArrivalTime time NOT NULL,
TrainKM int NOT NULL
)




--CREATE TABLE BookTable
--(
--ID int NOT NULL,
--TrainNo int NOT NULL,
--BookingID int IDENTITY PRIMARY KEY,
--SourceStop varchar(30),
--Destination varchar(30),


--CONSTRAINT fk_Book_UserID
--    FOREIGN KEY (ID)
--    REFERENCES User_Admin (ID)
--ON DELETE CASCADE
--ON UPDATE CASCADE,

--CONSTRAINT fk_Book_TrainNo
--    FOREIGN KEY (TrainNo)
--    REFERENCES TrainDetails (TrainNo)
--ON DELETE CASCADE
--ON UPDATE CASCADE
--)