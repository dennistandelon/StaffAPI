--CREATE DATABASE StaffDB

GO
USE StaffDB

GO
CREATE TABLE MsStaff(
	picture VARCHAR(255),
	StaffID VARCHAR(15),
	StaffName VARCHAR(255),
	Gender CHAR(1),
	DOB DATE,
	Position VARCHAR(5),
	Email VARCHAR(64),
	[Address] VARCHAR(255)
);

GO
INSERT INTO MsStaff VALUES
('https://res.cloudinary.com/dnoibyqq2/image/upload/v1617899636/genshin-app/characters/Amber/card.jpg', '13972139112', 'Amber', 'F', '2004-10-2','AM','amber@hoyo.ac.id','-' )


SELECT * FROM MsStaff