-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2023 16:51:53
-- Generated from EDMX file: E:\backup\Academico\UOC\FP\Tercer Semestre\Técnicas de persistencia de datos con .NET\HotelSolRepo\HotelSolRepo\Modelo\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Clientes__Progra__398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK__Clientes__Progra__398D8EEE];
GO
IF OBJECT_ID(N'[dbo].[FK__Facturas__Emplea__4BAC3F29]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facturas] DROP CONSTRAINT [FK__Facturas__Emplea__4BAC3F29];
GO
IF OBJECT_ID(N'[dbo].[FK__Facturas__NIF__4AB81AF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facturas] DROP CONSTRAINT [FK__Facturas__NIF__4AB81AF0];
GO
IF OBJECT_ID(N'[dbo].[FK__Habitacio__Habit__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HabitacionesDobles] DROP CONSTRAINT [FK__Habitacio__Habit__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__Habitacio__Habit__440B1D61]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HabitacionesSencillas] DROP CONSTRAINT [FK__Habitacio__Habit__440B1D61];
GO
IF OBJECT_ID(N'[dbo].[FK__Habitacio__Habit__46E78A0C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HabitacionesSuite] DROP CONSTRAINT [FK__Habitacio__Habit__46E78A0C];
GO
IF OBJECT_ID(N'[dbo].[FK__ReservaHa__Habit__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReservaHabitaciones] DROP CONSTRAINT [FK__ReservaHa__Habit__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__ReservaHa__Reser__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReservaHabitaciones] DROP CONSTRAINT [FK__ReservaHa__Reser__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservas__Emplea__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK__Reservas__Emplea__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservas__Habita__5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK__Reservas__Habita__5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservas__NIF__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK__Reservas__NIF__4F7CD00D];
GO
IF OBJECT_ID(N'[dbo].[FK__TareasEmp__Emple__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TareasEmpleados] DROP CONSTRAINT [FK__TareasEmp__Emple__5441852A];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO
IF OBJECT_ID(N'[dbo].[Facturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facturas];
GO
IF OBJECT_ID(N'[dbo].[Habitaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Habitaciones];
GO
IF OBJECT_ID(N'[dbo].[HabitacionesDobles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HabitacionesDobles];
GO
IF OBJECT_ID(N'[dbo].[HabitacionesSencillas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HabitacionesSencillas];
GO
IF OBJECT_ID(N'[dbo].[HabitacionesSuite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HabitacionesSuite];
GO
IF OBJECT_ID(N'[dbo].[ProgramasFidelizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgramasFidelizacion];
GO
IF OBJECT_ID(N'[dbo].[ReservaHabitaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReservaHabitaciones];
GO
IF OBJECT_ID(N'[dbo].[Reservas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservas];
GO
IF OBJECT_ID(N'[dbo].[TareasEmpleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TareasEmpleados];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [NIF] nvarchar(15)  NOT NULL,
    [Nombre] nvarchar(255)  NULL,
    [CorreoElectronico] nvarchar(255)  NULL,
    [Telefono] nvarchar(15)  NULL,
    [ProgramaFidelizacionID] int  NULL,
    [Contraseña] nvarchar(255)  NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [EmpleadoID] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(255)  NULL,
    [Rol] nvarchar(50)  NULL,
    [Horario] nvarchar(max)  NULL
);
GO

-- Creating table 'Facturas'
CREATE TABLE [dbo].[Facturas] (
    [FacturaID] int IDENTITY(1,1) NOT NULL,
    [NIF] nvarchar(15)  NULL,
    [EmpleadoID] int  NULL,
    [Detalles] nvarchar(max)  NULL,
    [Cargos] float  NULL,
    [Impuestos] float  NULL,
    [Fecha] datetime  NULL,
    [FechaCreacion] datetime  NULL,
    [TipoFactura] nvarchar(50)  NULL
);
GO

-- Creating table 'Habitaciones'
CREATE TABLE [dbo].[Habitaciones] (
    [HabitacionID] int IDENTITY(1,1) NOT NULL,
    [Tipo] nvarchar(50)  NULL,
    [Caracteristicas] nvarchar(max)  NULL,
    [Tarifa] float  NULL,
    [EstadoActual] nvarchar(50)  NULL,
    [Ocupado_desde] datetime  NULL,
    [Ocupado_hasta] datetime  NULL,
    [CodigoHabitacion] nvarchar(11)  NULL
);
GO

-- Creating table 'HabitacionesDobles'
CREATE TABLE [dbo].[HabitacionesDobles] (
    [HabitacionID] int  NOT NULL,
    [CamasDobles] int  NULL
);
GO

-- Creating table 'HabitacionesSencillas'
CREATE TABLE [dbo].[HabitacionesSencillas] (
    [HabitacionID] int  NOT NULL,
    [CamaSencilla] int  NULL
);
GO

-- Creating table 'HabitacionesSuite'
CREATE TABLE [dbo].[HabitacionesSuite] (
    [HabitacionID] int  NOT NULL,
    [SalaDeEstar] bit  NULL,
    [Minibar] bit  NULL
);
GO

-- Creating table 'ProgramasFidelizacion'
CREATE TABLE [dbo].[ProgramasFidelizacion] (
    [ProgramaFidelizacionID] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(255)  NULL,
    [Puntos] int  NULL,
    [Beneficios] nvarchar(max)  NULL
);
GO

-- Creating table 'Reservas'
CREATE TABLE [dbo].[Reservas] (
    [ReservaID] int IDENTITY(1,1) NOT NULL,
    [NIF] nvarchar(15)  NULL,
    [HabitacionID] int  NULL,
    [EmpleadoID] int  NULL,
    [FechaInicio] datetime  NULL,
    [FechaFin] datetime  NULL,
    [OpcionesPension] nvarchar(50)  NULL,
    [Estado] nvarchar(50)  NULL,
    [FechaCreacion] datetime  NULL,
    [TipoReserva] nvarchar(50)  NULL
);
GO

-- Creating table 'TareasEmpleados'
CREATE TABLE [dbo].[TareasEmpleados] (
    [TareaID] int IDENTITY(1,1) NOT NULL,
    [EmpleadoID] int  NULL,
    [Descripcion] nvarchar(max)  NULL,
    [Fecha] datetime  NULL
);
GO

-- Creating table 'ReservaHabitaciones'
CREATE TABLE [dbo].[ReservaHabitaciones] (
    [ReservaHabitacionID] int IDENTITY(1,1) NOT NULL,
    [ReservaID] int  NULL,
    [HabitacionID] int  NULL,
    [TipoPension] nvarchar(50)  NULL,
    [NumeroHabitaciones] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [NIF] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([NIF] ASC);
GO

-- Creating primary key on [EmpleadoID] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([EmpleadoID] ASC);
GO

-- Creating primary key on [FacturaID] in table 'Facturas'
ALTER TABLE [dbo].[Facturas]
ADD CONSTRAINT [PK_Facturas]
    PRIMARY KEY CLUSTERED ([FacturaID] ASC);
GO

-- Creating primary key on [HabitacionID] in table 'Habitaciones'
ALTER TABLE [dbo].[Habitaciones]
ADD CONSTRAINT [PK_Habitaciones]
    PRIMARY KEY CLUSTERED ([HabitacionID] ASC);
GO

-- Creating primary key on [HabitacionID] in table 'HabitacionesDobles'
ALTER TABLE [dbo].[HabitacionesDobles]
ADD CONSTRAINT [PK_HabitacionesDobles]
    PRIMARY KEY CLUSTERED ([HabitacionID] ASC);
GO

-- Creating primary key on [HabitacionID] in table 'HabitacionesSencillas'
ALTER TABLE [dbo].[HabitacionesSencillas]
ADD CONSTRAINT [PK_HabitacionesSencillas]
    PRIMARY KEY CLUSTERED ([HabitacionID] ASC);
GO

-- Creating primary key on [HabitacionID] in table 'HabitacionesSuite'
ALTER TABLE [dbo].[HabitacionesSuite]
ADD CONSTRAINT [PK_HabitacionesSuite]
    PRIMARY KEY CLUSTERED ([HabitacionID] ASC);
GO

-- Creating primary key on [ProgramaFidelizacionID] in table 'ProgramasFidelizacion'
ALTER TABLE [dbo].[ProgramasFidelizacion]
ADD CONSTRAINT [PK_ProgramasFidelizacion]
    PRIMARY KEY CLUSTERED ([ProgramaFidelizacionID] ASC);
GO

-- Creating primary key on [ReservaID] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [PK_Reservas]
    PRIMARY KEY CLUSTERED ([ReservaID] ASC);
GO

-- Creating primary key on [TareaID] in table 'TareasEmpleados'
ALTER TABLE [dbo].[TareasEmpleados]
ADD CONSTRAINT [PK_TareasEmpleados]
    PRIMARY KEY CLUSTERED ([TareaID] ASC);
GO

-- Creating primary key on [ReservaHabitacionID] in table 'ReservaHabitaciones'
ALTER TABLE [dbo].[ReservaHabitaciones]
ADD CONSTRAINT [PK_ReservaHabitaciones]
    PRIMARY KEY CLUSTERED ([ReservaHabitacionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProgramaFidelizacionID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK__Clientes__Progra__398D8EEE]
    FOREIGN KEY ([ProgramaFidelizacionID])
    REFERENCES [dbo].[ProgramasFidelizacion]
        ([ProgramaFidelizacionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Clientes__Progra__398D8EEE'
CREATE INDEX [IX_FK__Clientes__Progra__398D8EEE]
ON [dbo].[Clientes]
    ([ProgramaFidelizacionID]);
GO

-- Creating foreign key on [NIF] in table 'Facturas'
ALTER TABLE [dbo].[Facturas]
ADD CONSTRAINT [FK__Facturas__NIF__49C3F6B7]
    FOREIGN KEY ([NIF])
    REFERENCES [dbo].[Clientes]
        ([NIF])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Facturas__NIF__49C3F6B7'
CREATE INDEX [IX_FK__Facturas__NIF__49C3F6B7]
ON [dbo].[Facturas]
    ([NIF]);
GO

-- Creating foreign key on [NIF] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK__Reservas__NIF__4E88ABD4]
    FOREIGN KEY ([NIF])
    REFERENCES [dbo].[Clientes]
        ([NIF])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservas__NIF__4E88ABD4'
CREATE INDEX [IX_FK__Reservas__NIF__4E88ABD4]
ON [dbo].[Reservas]
    ([NIF]);
GO

-- Creating foreign key on [EmpleadoID] in table 'Facturas'
ALTER TABLE [dbo].[Facturas]
ADD CONSTRAINT [FK__Facturas__Emplea__4AB81AF0]
    FOREIGN KEY ([EmpleadoID])
    REFERENCES [dbo].[Empleados]
        ([EmpleadoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Facturas__Emplea__4AB81AF0'
CREATE INDEX [IX_FK__Facturas__Emplea__4AB81AF0]
ON [dbo].[Facturas]
    ([EmpleadoID]);
GO

-- Creating foreign key on [EmpleadoID] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK__Reservas__Emplea__5070F446]
    FOREIGN KEY ([EmpleadoID])
    REFERENCES [dbo].[Empleados]
        ([EmpleadoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservas__Emplea__5070F446'
CREATE INDEX [IX_FK__Reservas__Emplea__5070F446]
ON [dbo].[Reservas]
    ([EmpleadoID]);
GO

-- Creating foreign key on [EmpleadoID] in table 'TareasEmpleados'
ALTER TABLE [dbo].[TareasEmpleados]
ADD CONSTRAINT [FK__TareasEmp__Emple__534D60F1]
    FOREIGN KEY ([EmpleadoID])
    REFERENCES [dbo].[Empleados]
        ([EmpleadoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TareasEmp__Emple__534D60F1'
CREATE INDEX [IX_FK__TareasEmp__Emple__534D60F1]
ON [dbo].[TareasEmpleados]
    ([EmpleadoID]);
GO

-- Creating foreign key on [HabitacionID] in table 'HabitacionesDobles'
ALTER TABLE [dbo].[HabitacionesDobles]
ADD CONSTRAINT [FK__Habitacio__Habit__403A8C7D]
    FOREIGN KEY ([HabitacionID])
    REFERENCES [dbo].[Habitaciones]
        ([HabitacionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [HabitacionID] in table 'HabitacionesSencillas'
ALTER TABLE [dbo].[HabitacionesSencillas]
ADD CONSTRAINT [FK__Habitacio__Habit__4316F928]
    FOREIGN KEY ([HabitacionID])
    REFERENCES [dbo].[Habitaciones]
        ([HabitacionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [HabitacionID] in table 'HabitacionesSuite'
ALTER TABLE [dbo].[HabitacionesSuite]
ADD CONSTRAINT [FK__Habitacio__Habit__45F365D3]
    FOREIGN KEY ([HabitacionID])
    REFERENCES [dbo].[Habitaciones]
        ([HabitacionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [HabitacionID] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK__Reservas__Habita__4F7CD00D]
    FOREIGN KEY ([HabitacionID])
    REFERENCES [dbo].[Habitaciones]
        ([HabitacionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservas__Habita__4F7CD00D'
CREATE INDEX [IX_FK__Reservas__Habita__4F7CD00D]
ON [dbo].[Reservas]
    ([HabitacionID]);
GO

-- Creating foreign key on [HabitacionID] in table 'ReservaHabitaciones'
ALTER TABLE [dbo].[ReservaHabitaciones]
ADD CONSTRAINT [FK__ReservaHa__Habit__5DCAEF64]
    FOREIGN KEY ([HabitacionID])
    REFERENCES [dbo].[Habitaciones]
        ([HabitacionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ReservaHa__Habit__5DCAEF64'
CREATE INDEX [IX_FK__ReservaHa__Habit__5DCAEF64]
ON [dbo].[ReservaHabitaciones]
    ([HabitacionID]);
GO

-- Creating foreign key on [ReservaID] in table 'ReservaHabitaciones'
ALTER TABLE [dbo].[ReservaHabitaciones]
ADD CONSTRAINT [FK__ReservaHa__Reser__5CD6CB2B]
    FOREIGN KEY ([ReservaID])
    REFERENCES [dbo].[Reservas]
        ([ReservaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ReservaHa__Reser__5CD6CB2B'
CREATE INDEX [IX_FK__ReservaHa__Reser__5CD6CB2B]
ON [dbo].[ReservaHabitaciones]
    ([ReservaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
