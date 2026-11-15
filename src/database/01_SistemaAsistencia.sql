-- ==========================================
-- SISTEMA DE ASISTENCIA - BENAILU TECH
-- Esquema inicial de SQL Server
-- Ejecutar en SQL Server Management Studio.
-- ==========================================

IF DB_ID(N'SistemaAsistencia') IS NULL
    EXEC(N'CREATE DATABASE SistemaAsistencia');
GO

USE SistemaAsistencia;
GO

IF OBJECT_ID(N'dbo.Trabajadores', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Trabajadores
    (
        IdTrabajador INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CI VARCHAR(20) NOT NULL UNIQUE,
        Nombres VARCHAR(100) NOT NULL,
        Apellidos VARCHAR(100) NOT NULL,
        Estado BIT NOT NULL CONSTRAINT DF_Trabajadores_Estado DEFAULT (1)
    );
END;
GO

IF OBJECT_ID(N'dbo.DatosFaciales', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DatosFaciales
    (
        IdDatoFacial INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        IdTrabajador INT NOT NULL UNIQUE,
        PlantillaFacial VARBINARY(MAX) NULL,
        FechaRegistro DATETIME2 NOT NULL CONSTRAINT DF_DatosFaciales_Fecha DEFAULT (GETDATE()),
        CONSTRAINT FK_DatosFaciales_Trabajadores
            FOREIGN KEY (IdTrabajador) REFERENCES dbo.Trabajadores(IdTrabajador)
    );
END;
GO

IF OBJECT_ID(N'dbo.Marcaciones', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Marcaciones
    (
        IdMarcacion INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        IdTrabajador INT NOT NULL,
        FechaHora DATETIME2 NOT NULL CONSTRAINT DF_Marcaciones_FechaHora DEFAULT (GETDATE()),
        Tipo VARCHAR(10) NOT NULL,
        CONSTRAINT FK_Marcaciones_Trabajadores
            FOREIGN KEY (IdTrabajador) REFERENCES dbo.Trabajadores(IdTrabajador),
        CONSTRAINT CK_Marcaciones_Tipo CHECK (Tipo IN ('ENTRADA', 'SALIDA'))
    );
END;
GO

-- Consultas de verificación
SELECT * FROM dbo.Trabajadores ORDER BY Apellidos, Nombres;
SELECT * FROM dbo.DatosFaciales;
SELECT * FROM dbo.Marcaciones ORDER BY FechaHora DESC;
