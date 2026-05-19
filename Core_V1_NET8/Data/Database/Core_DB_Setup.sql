-- =============================================================================
-- Script de configuración de base de datos: Core_DB
-- Proyecto: Core_V1 – Gestor de Tareas
-- =============================================================================

USE master;
GO

-- ── Crear la base de datos si no existe ───────────────────────────────────────
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Core_DB')
BEGIN
	CREATE DATABASE Core_DB;
END
GO

USE Core_DB;
GO

-- ── Crear la tabla Tareas si no existe ────────────────────────────────────────
IF NOT EXISTS (
	SELECT 1
	FROM   sys.tables  t
	JOIN   sys.schemas s ON t.schema_id = s.schema_id
	WHERE  s.name = N'dbo' AND t.name = N'Tareas'
)
BEGIN
	CREATE TABLE dbo.Tareas
	(
		-- Identificador único autoincremental
		IdTarea      INT           NOT NULL IDENTITY(1,1) CONSTRAINT PK_Tareas PRIMARY KEY,
		Titulo       NVARCHAR(200) NOT NULL,
		Descripcion  NVARCHAR(1000) NOT NULL DEFAULT '',
		FechaEntrega DATE          NOT NULL,
		HoraEntrega  TIME(0)       NOT NULL,

		-- Nivel de prioridad: 1=Urgente, 2=Importante, 3=Normal
		Prioridad    TINYINT       NOT NULL CONSTRAINT CK_Tareas_Prioridad CHECK (Prioridad IN (1, 2, 3)),
		Completada   BIT           NOT NULL DEFAULT 0
	);
END
GO

-- ── Índice para acelerar la carga inicial ordenada por prioridad/fecha ────────
IF NOT EXISTS (
	SELECT 1 FROM sys.indexes
	WHERE  name = N'IX_Tareas_Prioridad_FechaEntrega'
	  AND  object_id = OBJECT_ID(N'dbo.Tareas')
)
BEGIN
	CREATE NONCLUSTERED INDEX IX_Tareas_Prioridad_FechaEntrega
		ON dbo.Tareas (Prioridad ASC, FechaEntrega ASC)
		INCLUDE (IdTarea, Titulo, Descripcion, HoraEntrega, Completada);
END
GO

PRINT 'Core_DB configurada correctamente.';
GO
