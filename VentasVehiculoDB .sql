CREATE DATABASE VentasVehiculoDB;
GO
USE VentasVehiculoDB;
GO

/*CREATE TABLE TipoUsuarios
(
   ID INT IDENTITY(1,1) NOT NULL,
   Nombre VARCHAR(50) NOT NULL,
   CONSTRAINT pk_tipoUsuario
   PRIMARY KEY(ID) 
  );*/

  CREATE TABLE Usuarios
  (
     ID INT IDENTITY(1,1) NOT NULL,
	 NombreUsuario VARCHAR(20) NOT NULL,
	 PasswordUsuario VARCHAR(20) NOT NULL,
	 CONSTRAINT PK_usuario 
	 PRIMARY KEY(ID),
	);

	/*CREATE TABLE AgenteOrden
	(
	   ID INT IDENTITY(1,1) NOT NULL,
	   Id_Cliente INT NOT NULL
	   CONSTRAINT pk_agenteOrden
	  PRIMARY KEY(ID)
	  CONSTRAINT fk_cliente
	  FOREIGN KEY(Id_Cliente)
	  REFERENCES Usuarios(ID)
	);*/

	CREATE TABLE EstadoOrden
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Nombre VARCHAR(50) NOT NULL,
	  CONSTRAINT pk_estadoOrden
	  PRIMARY KEY(ID)
	);

	CREATE TABLE Empleados
	(
		ID INT IDENTITY(1,1) NOT NULL,
		Nombre VARCHAR(50) NOT NULL,
		Apellido VARCHAR(50) NOT NULL,
		Cedula  VARCHAR(11) NOT NULL,
		FechaRegistro DATE NOT NULL,
		Direccion VARCHAR(100) NOT NULL,
		Correo VARCHAR(50) NOT NULL,
		Genero CHAR NOT NULL,
		Telefono VARCHAR(10) NOT NULL,
		Jefe INT NOT NULL,
		Id_Usuario INT NOT NULL,
		CONSTRAINT fk_Empleado
		PRIMARY KEY(ID),
		CONSTRAINT fk_Jefe
		FOREIGN KEY(Jefe)
		REFERENCES Empleados(ID),
		CONSTRAINT fk_Usuario
		FOREIGN KEY(Id_Usuario)
		REFERENCES Usuarios(ID),
		CONSTRAINT ck_generoEmpleado
	    CHECK (Genero in ('M','F'))
	);

	CREATE TABLE Clientes
	(
		ID INT IDENTITY(1,1) NOT NULL,
		Nombre VARCHAR(50) NOT NULL,
		Apellido VARCHAR(50) NOT NULL,
		Cedula  VARCHAR(11) NOT NULL,
		FechaRegistro DATE NOT NULL,
		Direccion VARCHAR(100) NOT NULL,
		Correo VARCHAR(50) NOT NULL,
		Genero CHAR NOT NULL,
		Telefono VARCHAR(10) NOT NULL,
		Id_Usuario INT NOT NULL,
		CONSTRAINT fk_Cliente
		PRIMARY KEY(ID),
		CONSTRAINT Usuario_fk
		FOREIGN KEY(Id_Usuario)
		REFERENCES Usuarios(ID),
		CONSTRAINT ck_generoCliente
	    CHECK (Genero in ('M','F'))
	);

	CREATE TABLE Orden
	(
	   ID INT IDENTITY(1,1) NOT NULL,
	   Id_Cliente INT NOT NULL,
	   Id_Empleado INT NOT NULL,
	   Id_TipoOrden INT NOT NULL,
	   Id_EstadoOrden INT NOT NULL,
	   Fecha DATE NOT NULL,
	   SubTotal DECIMAL NOT NULL,
	   Itbis DECIMAL NOT NULL,
	   Total DECIMAL NOT NULL,
	   CONSTRAINT pk_orden
	   PRIMARY KEY(ID),
	   CONSTRAINT cliente_fk
	   FOREIGN KEY(Id_Cliente)
	   REFERENCES Clientes(ID),
	   CONSTRAINT fk_estadoOrden
	   FOREIGN KEY(Id_EstadoOrden)
	   REFERENCES EstadoOrden(ID)
	   
	);
	

	CREATE TABLE TipoVehiculos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Tipo VARCHAR(30) NOT NULL,
	  CONSTRAINT pk_tipoVehiculo
	  PRIMARY KEY(ID)
	);

	CREATE TABLE TraccionVehiculos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Traccion VARCHAR(30) NOT NULL,
	  CONSTRAINT pk_traccion
	  PRIMARY KEY(ID)
	);

	CREATE TABLE AsientosVehiculos
	(
	   ID INT IDENTITY(1,1) NOT NULL,
	   CantidadAsiento INT NOT NULL,
	   CONSTRAINT pk_asiento
	   PRIMARY KEY(ID)
	);

	CREATE TABLE CombustibleVehiculos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Tipo VARCHAR(15) NOT NULL,
	  CONSTRAINT pk_combustible
	  PRIMARY KEY(ID)
	);

	CREATE TABLE EstadoVehiculos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Estado VARCHAR(15) NOT NULL,
	  CONSTRAINT pk_estado
	  PRIMARY KEY(ID)
	);



	CREATE TABLE Marcas
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Nombre VARCHAR(50) NOT NULL,
	  CONSTRAINT pk_Marca
	  PRIMARY KEY(ID)
	);

	CREATE TABLE Modelos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Nombre VARCHAR(50) NOT NULL,
	  Id_Marca INT NOT NULL,
	  Id_Traccion INT NOT NULL,
	  CONSTRAINT pk_Modelo
	  PRIMARY KEY(ID),
	  CONSTRAINT fk_Marca
	  FOREIGN KEY(Id_Marca)
	  REFERENCES Marcas(ID),
	  CONSTRAINT fk_traccion
	  FOREIGN KEY(Id_Traccion)
	  REFERENCES TraccionVehiculos(ID),
	);

	CREATE TABLE Suplidores
	(
	   ID INT IDENTITY(1,1) NOT NULL,
	   NombreEmpresa VARCHAR(100) NOT NULL,
	   Direccion VARCHAR(150) NOT NULL,
	   Telefono VARCHAR(10) NOT NULL,
	   CONSTRAINT pk_Suplidor
	   PRIMARY KEY(ID)
	);

	CREATE TABLE Vehiculos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Precio DECIMAL NOT NULL,
	  Kilometraje DECIMAL NOT NULL,
	  Color  VARCHAR NOT NULL,
	  Año DATE NOT NULL,
	  Id_Combustible INT NOT NULL,
	  Id_TipoVehiculo INT NOT NULL,
	  Id_Asiento INT NOT NULL,
	  Id_Estado INT NOT NULL,
	  Id_Modelo INT NOT NULL,
	  Id_Suplidor INT Not NULL,
	  CONSTRAINT pk_Vehiculo
	  PRIMARY KEY(ID),
	  CONSTRAINT fk_Combustible
	  FOREIGN KEY(Id_Combustible)
	  REFERENCES CombustibleVehiculos(ID),
	  CONSTRAINT fk_tipoVehiculo
	  FOREIGN KEY(Id_TipoVehiculo)
	  REFERENCES TipoVehiculos(ID),
	  CONSTRAINT fk_Asiento
	  FOREIGN KEY(Id_Asiento)
	  REFERENCES AsientosVehiculos(ID),
	  CONSTRAINT fk_Estado
	  FOREIGN KEY(Id_Estado)
	  REFERENCES EstadoVehiculos(ID),
	  CONSTRAINT fk_Suplidor
	  FOREIGN KEY(Id_Suplidor)
	  REFERENCES Suplidores(ID),
	  CONSTRAINT fk_VehicuModelo
	  FOREIGN KEY(Id_Modelo)
	  REFERENCES Modelos(ID),
	);

	CREATE TABLE InvetarioVehiculo
	(
	   ID INT IDENTITY(1,1) NOT NULL,
	   Cantidad INT NOT NULL,
	   Id_Vehiculo INT NOT NULL,
	   CONSTRAINT fk_Invetario
	   PRIMARY KEY(ID),
	   CONSTRAINT fk_vehiculo
	   FOREIGN KEY(Id_Vehiculo)
	   REFERENCES Vehiculos(ID)

	);

	CREATE TABLE DetalleOrden
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  Cantidad INT NOT NULL,
	  TotalDetalle DECIMAL NOT NULL,
	  Id_Orden INT NOT NULL,
	  Id_Vehiculo INT NOT NULL,
	  CONSTRAINT pk_detalleOrden
	  PRIMARY KEY(ID),
	  CONSTRAINT fk_Orden
	  FOREIGN KEY(Id_Orden)
	  REFERENCES Orden(ID),
	  CONSTRAINT fk_Vehiculos
	  FOREIGN KEY(Id_Vehiculo)
	  REFERENCES Vehiculos(ID),
	);

	CREATE TABLE ImagenVehiculos
	(
	  ID INT IDENTITY(1,1) NOT NULL,
	  RutaImagen VARCHAR(150) NOT NULL,
	  Id_Vehiculo INT NOT NULL,
	  CONSTRAINT pk_imagen
	  PRIMARY KEY(ID),
	  CONSTRAINT Vehiculo_fk
	  FOREIGN KEY(Id_Vehiculo)
	  REFERENCES Vehiculos(ID)
	  
	 );

	 CREATE TABLE FacturasOrdenes(
	 
	 ID INT IDENTITY(1,1) NOT NULL,
	 Fecha DATE NOT NULL,
	 Id_Empleado INT NOT NULL,
	 Id_Orden INT NOT NULL,
	 TipoPago VARCHAR(50) NOT NULL,
	 Cambio DECIMAL NOT NULL,
	 CONSTRAINT Empleado_fk
	 FOREIGN KEY(Id_Empleado)
	 REFERENCES Empleados(ID),
	 CONSTRAINT fk_OrdenFactura
	 FOREIGN KEY(Id_Orden)
	 REFERENCES Orden(ID)
	 );

	