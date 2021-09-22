CREATE DATABASE LPII
Go
 
 USE LPII

 CREATE TABLE Suplidor(
	 EmpresaId INT primary key identity (1,1) NOT NULL,
	NombreEmpresa  varchar (100) NOT NULL,
	PersonaRepresentante varchar (100) NOT NULL,
	RNC varchar (15) NOT NULL,
	Direccion varchar (500) NOT NULL,
	Telefono varchar (15) NULL,
	 proveedorEstado BIT NULL,
	 NoproveedorEstado varchar (50) NULL,
	 Borrar bit null
 )
 GO

 SELECT  * FROM Suplidor 