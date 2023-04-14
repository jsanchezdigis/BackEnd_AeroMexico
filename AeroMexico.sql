CREATE DATABASE JSanchezAeroMexico
USE JSanchezAeroMexico
GO

CREATE TABLE Usuario(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL,
	Password VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Vuelo(
	IdVuelo INT IDENTITY(1,1) PRIMARY KEY,
	NumeroVuelo VARCHAR(4),
	Origen VARCHAR(2),
	Destino VARCHAR(2),
	FechaSalida DATETIME --yyyy/MM/dd hh:mm:ss
)
GO

CREATE TABLE Pasajero(
	IdPasajero INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	ApellidoPaterno VARCHAR(50),
	ApellidoMaterno VARCHAR(50)
)
GO

CREATE TABLE Reservacion(
	IdReservacion INT IDENTITY(1,1) PRIMARY KEY,
	IdVuelo INT NOT NULL,
	IdPasajero INT NOT NULL
	CONSTRAINT fk_ReservacionVuelo FOREIGN KEY (IdVuelo) REFERENCES Vuelo (IdVuelo),
	CONSTRAINT fk_ReservacionPasajero FOREIGN KEY (IdPasajero) REFERENCES Pasajero (IdPasajero)
)
GO

CREATE PROCEDURE VueloGetAll
AS
SELECT IdVuelo,NumeroVuelo,Origen,Destino,FechaSalida FROM Vuelo
GO

CREATE PROCEDURE VueloGetByFecha --'2023-04-01 00:00:00','2023-05-01 00:00:00'
@FechaInicio VARCHAR(50),
@FechaFin VARCHAR(50)
AS
SELECT IdVuelo,NumeroVuelo,Origen,Destino,FechaSalida FROM Vuelo
WHERE FechaSalida BETWEEN @FechaInicio AND @FechaFin
GO

CREATE PROCEDURE ReservacionAdd
@IdVuelo INT,
@IdPasajero INT
AS
INSERT INTO Reservacion(IdVuelo,IdPasajero)VALUES(@IdVuelo,@IdPasajero)
GO

CREATE PROCEDURE PasajeroAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50)
AS
INSERT INTO Pasajero(Nombre,ApellidoPaterno,ApellidoMaterno)VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno)
GO

CREATE PROCEDURE UsuarioGetByUserName --'jsanchez'
@UserName VARCHAR(50)
AS
SELECT 
IdUsuario,
UserName,
Password
FROM Usuario
WHERE UserName=@UserName
GO

INSERT INTO Usuario(UserName,Password)VALUES('lperez','54321')
INSERT INTO Vuelo(NumeroVuelo,Origen,Destino,FechaSalida)VALUES('5423','BZ','US','2023/08/15 02:30:00')
INSERT INTO Pasajero(Nombre,ApellidoPaterno,ApellidoMaterno)VALUES('Luis','Perez','Montiel')
INSERT INTO Reservacion(IdVuelo,IdPasajero)VALUES(2,1)
GO

SELECT IdUsuario,UserName,Password FROM Usuario
SELECT IdVuelo,NumeroVuelo,Origen,Destino,FechaSalida FROM Vuelo
SELECT IdPasajero,Nombre,ApellidoPaterno,ApellidoMaterno FROM Pasajero
SELECT IdReservacion,IdVuelo,IdPasajero FROM Reservacion
GO