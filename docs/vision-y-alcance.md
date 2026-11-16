# Visión y alcance

## Visión

Benailu Tech es un sistema académico de control de asistencia de trabajadores. La solución actual contiene una API ASP.NET Core en C#, una aplicación .NET MAUI dirigida a Android y una base de datos SQL Server. La visión futura es utilizar un teléfono Android compartido en la entrada de la empresa para realizar marcaciones mediante reconocimiento facial.

## Problema y propósito

Los registros manuales pueden requerir tiempo y dificultar la consulta ordenada de entradas y salidas. El proyecto busca centralizar las marcaciones, facilitar la administración de trabajadores y ofrecer consultas y reportes básicos.

## Usuarios objetivo

- **Trabajadores:** utilizarán el terminal Android para registrar entrada o salida cuando se implemente la identificación facial.
- **Personal administrativo autorizado:** registrará y administrará trabajadores y consultará asistencias.
- **Responsables de la empresa:** revisarán los registros y reportes.

## Funcionalidades implementadas

- Registro, listado, búsqueda, modificación y desactivación de trabajadores mediante API.
- Registro de entradas y salidas mediante CI como dato de prueba.
- Validación de que la primera marcación diaria sea ENTRADA y las siguientes alternen.
- Consulta general e historial de marcaciones.
- Filtro de marcaciones por fecha.
- Reporte de cantidades de entradas, salidas y marcaciones por trabajador y periodo.
- Aplicación MAUI Android con permiso de cámara y captura/previsualización de fotografía.

## Funcionalidades previstas y pendientes

- Enrolamiento e identificación facial.
- Integración de la aplicación Android con la API.
- Registro de marcaciones desde la app tras confirmar identidad.
- Autenticación, autorización y roles de usuarios.
- Reportes de horas, tardanzas, ausencias y cumplimiento de horarios.

La captura de una fotografía no equivale a reconocimiento facial. La API de prueba recibe el CI del trabajador y no verifica identidad.

## Alcance técnico

- Backend: C# / ASP.NET Core Web API, .NET 10.
- App móvil: .NET MAUI, destino Android `net10.0-android`.
- Base de datos: SQL Server.
- Acceso a datos: Microsoft.Data.SqlClient.

La biblioteca y el algoritmo de reconocimiento facial, la ubicación del procesamiento biométrico y el contrato seguro entre el teléfono y el servidor quedan pendientes de decisión.

## Límites

El sistema no está preparado para uso productivo. No dispone de autenticación/autorización y no implementa reconocimiento facial ni integración móvil-backend. El reporte actual solo cuenta marcaciones y no calcula horas trabajadas, tardanzas ni ausencias.

## Privacidad

Los datos faciales requieren protección especial. Antes de implementar el enrolamiento se deben definir permisos, controles de acceso, almacenamiento seguro, retención y la necesidad de conservar fotografías o plantillas biométricas.

## Documentos relacionados

- [Requisitos](requisitos.md)
- [Arquitectura](arquitectura.md)
- [Modelo de datos](modelo-de-datos.md)
- [Planificación](planificacion/planificacion.md)
