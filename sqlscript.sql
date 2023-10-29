-- Crear la base de datos del Hotel
CREATE DATABASE HotelDB;
GO

USE HotelDB;
GO

-- Tabla de Programas de Fidelización
CREATE TABLE ProgramasFidelizacion (
    ProgramaFidelizacionID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Puntos INT,
    Beneficios NVARCHAR(MAX)
);

-- Tabla de Clientes
CREATE TABLE Clientes (
    NIF NVARCHAR(15) PRIMARY KEY,
    Nombre NVARCHAR(255),
    CorreoElectronico NVARCHAR(255),
    Telefono NVARCHAR(15),
    ProgramaFidelizacionID INT,
    Contraseña NVARCHAR(255),
    FOREIGN KEY (ProgramaFidelizacionID) REFERENCES ProgramasFidelizacion(ProgramaFidelizacionID)
);

-- Tabla de Empleados
CREATE TABLE Empleados (
    EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Rol NVARCHAR(50),
    Horario NVARCHAR(MAX)
);

-- Tabla principal de Habitaciones
CREATE TABLE Habitaciones (
    HabitacionID INT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(50),
    Caracteristicas NVARCHAR(MAX),
    Tarifa FLOAT,
    EstadoActual NVARCHAR(50),
    Ocupado_desde DATETIME,
    Ocupado_hasta DATETIME,
    CodigoHabitacion AS (
        CASE
            WHEN Tipo = 'Sencilla' THEN '1'
            WHEN Tipo = 'Doble' THEN '2'
            WHEN Tipo = 'Suite' THEN '3'
            ELSE '0'
        END + CAST(HabitacionID AS NVARCHAR(10))
    ) PERSISTED UNIQUE
);

-- Tablas para diferentes tipos de Habitaciones (Subclases)
CREATE TABLE HabitacionesDobles (
    HabitacionID INT PRIMARY KEY,
    CamasDobles INT,
    FOREIGN KEY (HabitacionID) REFERENCES Habitaciones(HabitacionID)
);

CREATE TABLE HabitacionesSencillas (
    HabitacionID INT PRIMARY KEY,
    CamaSencilla INT,
    FOREIGN KEY (HabitacionID) REFERENCES Habitaciones(HabitacionID)
);

CREATE TABLE HabitacionesSuite (
    HabitacionID INT PRIMARY KEY,
    SalaDeEstar BIT,
    Minibar BIT,
    FOREIGN KEY (HabitacionID) REFERENCES Habitaciones(HabitacionID)
);

-- Tabla de Facturas
CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    NIF NVARCHAR(15),
    EmpleadoID INT NULL,
    Detalles NVARCHAR(MAX),
    Cargos FLOAT,
    Impuestos FLOAT,
    Fecha DATE,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    TipoFactura NVARCHAR(50),
    FOREIGN KEY (NIF) REFERENCES Clientes(NIF),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
);

-- Tabla de Reservas
CREATE TABLE Reservas (
    ReservaID INT PRIMARY KEY IDENTITY(1,1),
    NIF NVARCHAR(15),
    HabitacionID INT,
    EmpleadoID INT NULL,
    FechaInicio DATE,
    FechaFin DATE,
    OpcionesPension NVARCHAR(50),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    TipoReserva NVARCHAR(50),
    FOREIGN KEY (NIF) REFERENCES Clientes(NIF),
    FOREIGN KEY (HabitacionID) REFERENCES Habitaciones(HabitacionID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
);

-- Tabla de Tareas de Empleados
CREATE TABLE TareasEmpleados (
    TareaID INT PRIMARY KEY IDENTITY(1,1),
    EmpleadoID INT,
    Descripcion NVARCHAR(MAX),
    Fecha DATE,
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(EmpleadoID)
);




