-- Cargar datos iniciales para las Habitaciones y sus subtipos y Empleados

-- Insertar datos de los empleados
INSERT INTO Empleados ( Nombre, Rol, Horario)
VALUES
    ( 'Robert', 'Recepcionista', '08:00 - 16:00'),
    ( 'Pablo', 'Recepcionista', '16:00 - 24:00'),
    ( 'Jose', 'Recepcionista', '00:00 - 08:00');


-- Definir las fechas
DECLARE @DateNow DATETIME = CAST('2023-10-28T00:00:00' AS DATETIME);
DECLARE @FutureDate DATETIME = CAST('2023-10-30T00:00:00' AS DATETIME);

-- 15 Habitaciones Sencillas, 5 disponibles hoy
DECLARE @Counter INT = 1;
BEGIN TRANSACTION;
WHILE @Counter <= 5
BEGIN
    INSERT INTO Habitaciones (Tipo, Caracteristicas, Tarifa, EstadoActual)
    VALUES ('Sencilla', 'Una cama sencilla', 55, 'Libre');

    INSERT INTO HabitacionesSencillas (HabitacionID, CamaSencilla)
    VALUES (SCOPE_IDENTITY(), 1);

    SET @Counter = @Counter + 1;
END
COMMIT;

-- 10 disponibles a partir del 30 de octubre de 2023
SET @Counter = 1;
BEGIN TRANSACTION;
WHILE @Counter <= 10
BEGIN
    INSERT INTO Habitaciones (Tipo, Caracteristicas, Tarifa, Ocupado_desde, Ocupado_hasta, EstadoActual)
    VALUES ('Sencilla', 'Una cama sencilla', 55, @DateNow, @FutureDate, 'Ocupado');

    INSERT INTO HabitacionesSencillas (HabitacionID, CamaSencilla)
    VALUES (SCOPE_IDENTITY(), 1);

    SET @Counter = @Counter + 1;
END
COMMIT;

-- 25 Habitaciones Dobles, 2 disponibles
SET @Counter = 1;
BEGIN TRANSACTION;
WHILE @Counter <= 2
BEGIN
    INSERT INTO Habitaciones (Tipo, Caracteristicas, Tarifa, EstadoActual)
    VALUES ('Doble', 'Dos camas ', 70, 'Libre');

    INSERT INTO HabitacionesDobles (HabitacionID, CamasDobles)
    VALUES (SCOPE_IDENTITY(), 2);

    SET @Counter = @Counter + 1;
END
COMMIT;

-- 23 ocupadas hasta el 30 de octubre de 2023
SET @Counter = 1;
BEGIN TRANSACTION;
WHILE @Counter <= 23
BEGIN
    INSERT INTO Habitaciones (Tipo, Caracteristicas, Tarifa, Ocupado_desde, Ocupado_hasta, EstadoActual)
    VALUES ('Doble', 'Cama Matrimonio ', 70, @DateNow, @FutureDate, 'Ocupado');

    INSERT INTO HabitacionesDobles (HabitacionID, CamasDobles)
    VALUES (SCOPE_IDENTITY(), 2);

    SET @Counter = @Counter + 1;
END
COMMIT;

-- 4 Habitaciones Suite ocupadas hasta el 30 de octubre de 2023
SET @Counter = 1;
BEGIN TRANSACTION;
WHILE @Counter <= 4
BEGIN
    INSERT INTO Habitaciones (Tipo, Caracteristicas, Tarifa, Ocupado_desde, Ocupado_hasta, EstadoActual)
    VALUES ('Suite', 'Sala de estar y minibar', 100, @DateNow, @FutureDate, 'Ocupado');

    INSERT INTO HabitacionesSuite (HabitacionID, SalaDeEstar, Minibar)
    VALUES (SCOPE_IDENTITY(), 1, 1);

    SET @Counter = @Counter + 1;
END
COMMIT;

