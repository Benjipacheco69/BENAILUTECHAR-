-- ==========================================
-- SISTEMA DE ASISTENCIA - BENAILU TECH
-- SCRIPT MAESTRO
-- Fuente: SQLQuery6.sql entregado por el equipo
-- ==========================================

-- 1. CREAR BASE DE DATOS SI NO EXISTE
IF DB_ID('SistemaAsistencia') IS NULL
    EXEC('CREATE DATABASE SistemaAsistencia');
GO

USE SistemaAsistencia;
GO

-- 2. TABLA DE TRABAJADORES
IF OBJECT_ID('Trabajadores', 'U') IS NULL
BEGIN
    CREATE TABLE Trabajadores (
        IdTrabajador INT IDENTITY(1,1) PRIMARY KEY,
        CI VARCHAR(20) NOT NULL UNIQUE,
        Nombres VARCHAR(100) NOT NULL,
        Apellidos VARCHAR(100) NOT NULL,
        Estado BIT NOT NULL DEFAULT 1
    );
END;
GO

-- 3. TABLA DE DATOS FACIALES
IF OBJECT_ID('DatosFaciales', 'U') IS NULL
BEGIN
    CREATE TABLE DatosFaciales (
        IdDatoFacial INT IDENTITY(1,1) PRIMARY KEY,
        IdTrabajador INT NOT NULL UNIQUE,
        PlantillaFacial VARBINARY(MAX) NULL,
        FechaRegistro DATETIME2 DEFAULT GETDATE(),
        FOREIGN KEY (IdTrabajador)
            REFERENCES Trabajadores(IdTrabajador)
    );
END;
GO

-- 4. TABLA DE MARCACIONES
IF OBJECT_ID('Marcaciones', 'U') IS NULL
BEGIN
    CREATE TABLE Marcaciones (
        IdMarcacion INT IDENTITY(1,1) PRIMARY KEY,
        IdTrabajador INT NOT NULL,
        FechaHora DATETIME2 NOT NULL DEFAULT GETDATE(),
        Tipo VARCHAR(10) NOT NULL,
        FOREIGN KEY (IdTrabajador)
            REFERENCES Trabajadores(IdTrabajador),
        CHECK (Tipo IN ('ENTRADA', 'SALIDA'))
    );
END;
GO

-- 5. REGISTRAR TRABAJADOR DE PRUEBA
IF NOT EXISTS (
    SELECT 1 FROM Trabajadores WHERE CI = '1234567'
)
BEGIN
    INSERT INTO Trabajadores (CI, Nombres, Apellidos)
    VALUES ('1234567', 'Juan', 'Perez');
END;
GO

-- 6. REGISTRAR UNA ENTRADA DE PRUEBA
DECLARE @Id INT;
SELECT @Id = IdTrabajador
FROM Trabajadores
WHERE CI = '1234567';

IF NOT EXISTS (
    SELECT 1 FROM Marcaciones WHERE IdTrabajador = @Id
)
BEGIN
    INSERT INTO Marcaciones (IdTrabajador, Tipo)
    VALUES (@Id, 'ENTRADA');
END;
GO

-- 7. CONSULTAR TRABAJADORES
SELECT * FROM Trabajadores;
GO

-- 8. CONSULTAR DATOS FACIALES
SELECT * FROM DatosFaciales;
GO

-- 9. CONSULTAR MARCACIONES
SELECT * FROM Marcaciones;
GO

-- 10. HISTORIAL DE ASISTENCIA
SELECT
    T.CI,
    T.Nombres,
    T.Apellidos,
    M.FechaHora,
    M.Tipo
FROM Trabajadores T
INNER JOIN Marcaciones M
    ON T.IdTrabajador = M.IdTrabajador
ORDER BY M.FechaHora DESC;
GO
