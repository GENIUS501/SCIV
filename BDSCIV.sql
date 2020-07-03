CREATE DATABASE SCIV
GO 

USE SCIV
GO

CREATE TABLE Tab_Perfiles
(
	Id_Perfil	Int PRIMARY KEY NOT NULL,
	Nombre_Perfil	VARCHAR(30) NOT NULL
);

CREATE TABLE Tab_Usuarios
(
	Cedula	INT UNIQUE NOT NULL,
	NickName	VARCHAR(25) PRIMARY KEY NOT NULL,
	Nombre	Varchar(30) NOT NULL,
	Apellido1	Varchar(30) NOT NULL,
	Apellido2	Varchar(30) NOT NULL,
	Contrasena	Varchar(max) NOT NULL,
	Genero Varchar(1),
	Id_Perfil	INT NOT NULL,
	CONSTRAINT Fk_Usuario_Perfil FOREIGN KEY(Id_Perfil) REFERENCES Tab_Perfiles(Id_Perfil)
);

CREATE TABLE Tab_Permisos
(	
	Id_Perfil	INT NOT NULL ,
	Modulo	INT NOT NULL,
	Agregar	VARCHAR(2),
	Modificar	VARCHAR(2),
	Consultar	VARCHAR(2),
	Eliminar	VARCHAR(2),
	PRIMARY KEY(Id_Perfil,Modulo),
	CONSTRAINT Fk_Permisos_Perfil FOREIGN KEY(Id_Perfil) REFERENCES Tab_Perfiles(Id_Perfil)
);

CREATE TABLE Tab_Bitacora_Sesiones
(	
	Id_Sesion	INT PRIMARY KEY IDENTITY(1,1),
	Ingreso	DATETIME NOT NULL,
	Salida	DATETIME,
	NickName	VARCHAR(25)NOT NULL,
	CONSTRAINT Fk_Bitacora_Usuario FOREIGN KEY(NickName) REFERENCES Tab_Usuarios(NickName)
);

CREATE TABLE Tab_Bitacora_Movimientos
(	
	Fecha_Hora	DATETIME NOT NULL,
	Id_Movimiento	INT PRIMARY KEY IDENTITY(1,1),
	Tipo_Movimiento	VARCHAR(16) NOT NULL,
	Modulo_Afectado	VARCHAR(25) NOT NULL,
	NickName	VARCHAR(25) NOT NULL,
	CONSTRAINT Fk_Movimientos_Usuarios FOREIGN KEY(NickName) REFERENCES Tab_Usuarios(NickName)
);

CREATE TABLE Tab_Empresa
(
	Cedula_Juridica	BIGINT PRIMARY KEY NOT NULL,
	Nombre_Empresa	VARCHAR(35) NOT NULL,
	Telefono	INT NOT NULL,
	Correo	VARCHAR(35),
	Descripcion	VARCHAR(MAX)
);

CREATE TABLE Tab_Telefono
(
	Cedula_Juridica BIGINT NOT NULL,
	Telefono INT NOT NULL,
	Contacto VARCHAR(30) NOT NULL,
	CONSTRAINT Fk_Telefono_Empresa FOREIGN KEY(Cedula_Juridica) REFERENCES Tab_Empresa(Cedula_Juridica),
	PRIMARY KEY(Cedula_Juridica,Telefono)
);

CREATE TABLE Tab_Productos
(
	Codigo	INT PRIMARY KEY NOT NULL, 
	Nombre_producto	VARCHAR(30) NOT NULL,
	Descripcion_producto	VARCHAR(max) NOT NULL,
	Precio_Costo	FLOAT NOT NULL,
	Cantidad_Unidades	INT
);

CREATE TABLE Tab_Venta_Detalle
(
	Numero_Venta INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Codigo	INT NOT NULL,
	Cantidad	INT NOT NULL,
	porcentaje_ganancia	INT NOT NULL,
	precio_costo	FLOAT NOT NULL,
	Nota_Adicional	VARCHAR(MAX),
	NickName_Creador	VARCHAR(25) NOT NULL, 
	CONSTRAINT Fk_VentaD_Usuario FOREIGN KEY(NickName_Creador) REFERENCES Tab_Usuarios(NickName),
	CONSTRAINT Fk_VentaD_Producto FOREIGN KEY(Codigo) REFERENCES Tab_Productos(Codigo)
);

CREATE TABLE Tab_Lista_Ventas
(
	--Codigo_Producto	INT,
	Cedula_Empresa	BIGINT NOT NULL,
	Fecha	DATETIME NOT NULL,
	Id_Lista	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NickName_Creador	VARCHAR(25) NOT NULL,
	Nota_Adicional	VARCHAR(MAX),
	CONSTRAINT Fk_ListaVentaD_Usuario FOREIGN KEY(NickName_Creador) REFERENCES Tab_Usuarios(NickName),
	CONSTRAINT Fk_ListaVenta_Emp FOREIGN KEY(Cedula_Empresa) REFERENCES Tab_Empresa(Cedula_Juridica)
);

CREATE TABLE Tab_Lista_Ventas_Detalles
(
	Id_Lista	INT NOT NULL,
	Codigo_Producto	INT NOT NULL,
	Paquetes	INT NOT NULL,
	Cantidad_Total	INT NOT NULL,
	Cantidad_Actual	INT,
	Precio_Costo FLOAT NOT NULL,
	Porcentaje_Ganancia	FLOAT NOT NULL,
	CONSTRAINT Fk_ListaVentaDe_Producto FOREIGN KEY(Codigo_Producto) REFERENCES Tab_Productos(Codigo),
	CONSTRAINT Fk_ListaVentaD_Producto FOREIGN KEY(Id_Lista) REFERENCES Tab_Lista_Ventas(Id_Lista),
	PRIMARY KEY (Id_Lista,Codigo_Producto)
);
INSERT INTO Tab_Perfiles(Id_Perfil,Nombre_Perfil) values(1,'Administrador')
INSERT INTO Tab_Permisos(Id_Perfil,Modulo,Agregar,Modificar,Consultar,Eliminar) values(1,1,'S','S','S','S')
INSERT INTO Tab_Usuarios (Nombre,Cedula,NickName,Apellido1,Apellido2,Contrasena,Id_Perfil) values('Administrador',123456789,'Admin','Admin','Admin','3tLBRGpA8I8o9Xxeoo06OjbXrKE=',1);