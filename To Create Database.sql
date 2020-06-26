CREATE DATABASE dbGestorProductos
GO

USE dbGestorProductos
GO

CREATE TABLE tblUsuatio
(
	idUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	NombreUsuario VARCHAR(255) NOT NULL,
	ApellidoUsuario VARCHAR(25) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    FechaRegistro DATE DEFAULT GETDATE() NOT NULL,
    Edad INT NOT NULL,
    Telefono CHAR(10) NOT NULL,
    Cedula CHAR(11) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Direccion VARCHAR(355) NOT NULL,
    Contraseña VARCHAR(50) NOT NULL
)

GO

CREATE TABLE tblCategoria
(
	idCategoria INT PRIMARY KEY IDENTITY NOT NULL,
	NombreCategoria VARCHAR(50) NOT NULL,
	DescripcionCategoria VARCHAR(100) NOT NULL

)

GO

CREATE TABLE tblProducto
(
	idProducto INT PRIMARY KEY IDENTITY NOT NULL,
	NombreProducto VARCHAR(50) NOT NULL,
	DescripcionProducto VARCHAR(100) NOT NULL,
	CantidadProducto int NOT NULL,
	PrecioProducto decimal(18,2) NOT NULL,
	idCategoria INT FOREIGN KEY REFERENCES tblCategoria(idCategoria) NOT NULL
)

