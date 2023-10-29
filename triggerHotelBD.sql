-- Triggers para asegurar la integridad de los datos en las tablas de subtipos

-- Trigger para HabitacionesDobles
CREATE TRIGGER tr_CheckTipoHabitacionesDobles ON HabitacionesDobles
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Habitaciones h ON i.HabitacionID = h.HabitacionID
        WHERE h.Tipo != 'Doble'
    )
    BEGIN
        ROLLBACK;
        THROW 50000, 'Tipo de Habitación no coincide con la tabla HabitacionesDobles', 1;
    END
END;
GO

-- Trigger para HabitacionesSencillas
CREATE TRIGGER tr_CheckTipoHabitacionesSencillas ON HabitacionesSencillas
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Habitaciones h ON i.HabitacionID = h.HabitacionID
        WHERE h.Tipo != 'Sencilla'
    )
    BEGIN
        ROLLBACK;
        THROW 50000, 'Tipo de Habitación no coincide con la tabla HabitacionesSencillas', 1;
    END
END;
GO

-- Trigger para HabitacionesSuite
CREATE TRIGGER tr_CheckTipoHabitacionesSuite ON HabitacionesSuite
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Habitaciones h ON i.HabitacionID = h.HabitacionID
        WHERE h.Tipo != 'Suite'
    )
    BEGIN
        ROLLBACK;
        THROW 50000, 'Tipo de Habitación no coincide con la tabla HabitacionesSuite', 1;
    END
END;
GO


-- Crear el trigger para actualizar el estado de la habitación
CREATE TRIGGER tr_UpdateEstadoActual ON Habitaciones
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @HabitacionID INT;
    DECLARE @Ocupado_desde DATETIME;
    DECLARE @Ocupado_hasta DATETIME;

    SELECT @HabitacionID = i.HabitacionID, @Ocupado_desde = i.Ocupado_desde, @Ocupado_hasta = i.Ocupado_hasta
    FROM inserted i;

    IF @Ocupado_desde IS NULL OR @Ocupado_hasta IS NULL OR @Ocupado_hasta < GETDATE() OR @Ocupado_desde > GETDATE()
    BEGIN
        UPDATE Habitaciones
        SET EstadoActual = 'Libre'
        WHERE HabitacionID = @HabitacionID;
    END
    ELSE
    BEGIN
        UPDATE Habitaciones
        SET EstadoActual = 'Ocupado'
        WHERE HabitacionID = @HabitacionID;
    END
END;
