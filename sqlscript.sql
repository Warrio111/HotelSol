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
    FOREIGN KEY (ProgramaFidelizacionID) REFERENCES ProgramasFidelizacion(ProgramaFidelizacionID)
);

-- Tabla de Empleados
CREATE TABLE Empleados (
    EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Rol NVARCHAR(50),
    Horario NVARCHAR(MAX)
);

-- Tabla de Habitaciones (Tabla principal)
CREATE TABLE Habitaciones (
    HabitacionID INT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(50),
    Caracteristicas NVARCHAR(MAX),
    Tarifa FLOAT,
    EstadoActual NVARCHAR(50)  -- Nuevo campo
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
    FechaCreacion DATETIME DEFAULT GETDATE(),  -- Nuevo campo
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
    Estado NVARCHAR(50),  -- Nuevo campo
    FechaCreacion DATETIME DEFAULT GETDATE(),  -- Nuevo campo
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


-- Inclusion de datos de prueba

-- Insertar programas de fidelización en la tabla ProgramasFidelizacion
INSERT INTO ProgramasFidelizacion (Nombre, Puntos, Beneficios)
VALUES
('Gold', 1000, 'Acceso a promociones exclusivas, 5% de descuento en compras'),
('Standard', 500, 'Acceso a promociones'),
('VIP', 2000, 'Acceso a promociones exclusivas, 10% de descuento en compras, acceso a eventos VIP'),
('Platinum', 3000, 'Acceso a promociones exclusivas, 15% de descuento en compras, acceso a eventos VIP, servicio de atención al cliente personalizado');

-- Insertar clientes de prueba en la tabla Clientes
INSERT INTO Clientes (NIF, Nombre, CorreoElectronico, Telefono, ProgramaFidelizacionID)
VALUES
('12345678A', 'Prueba 1', 'prueba1@example.com', '600111222', 1),
('12345679B', 'Prueba 2', 'prueba2@example.com', '600111223', 2),
('12345680C', 'Prueba 3', 'prueba3@example.com', '600111224', 3),
('12345681D', 'Prueba 4', 'prueba4@example.com', '600111225', 4);

