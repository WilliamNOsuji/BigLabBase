USE master

IF EXISTS(SELECT * FROM sys.databases WHERE name='R22_Billeterie')
BEGIN 
	DROP DATABASE R22_Billeterie 
END

CREATE DATABASE R22_Billeterie
GO
USE R22_Billeterie
GO



/*
 Configuring the FileStream using SQL SERVER 
*/
EXEC sp_configure filestream_access_level, 2 RECONFIGURE

ALTER DATABASE R22_Billeterie
ADD FILEGROUP FG_Images CONTAINS FILESTREAM;
GO
ALTER DATABASE R22_Billeterie
ADD FILE (
	NAME = FG_Images,
	FILENAME = 'C:\EspaceLabo\FG_Images'
)
TO FILEGROUP FG_Images
GO

/*
 Create a Master Key with which every Decryption of information will be done
*/
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'P4ssw0rd!P4ssw0rd12345';
GO
CREATE CERTIFICATE MonCertificat WITH SUBJECT = 'ChiffrementCarteBancaire';
GO
CREATE SYMMETRIC KEY MaSuperCle WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE MonCertificat;
GO