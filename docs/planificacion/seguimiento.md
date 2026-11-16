# Seguimiento

Actualizar esta página durante las reuniones del equipo. El estado de compilación y pruebas locales del backend fue confirmado por el equipo. Las tareas futuras deben mantenerse en GitHub Issues y sincronizarse con esta tabla.

| Actividad | Estado | Evidencia / siguiente paso |
|---|---|---|
| API C# con SQL Server | Implementada y compilada según verificación del equipo | Código en `src/backend/SistemaAsistenciaAPI` |
| Registro, consulta, modificación y desactivación de trabajadores | Implementados | Controlador `TrabajadoresController` |
| Registro de entradas y salidas con CI | Implementado para pruebas | Controlador `MarcacionesController`; no verifica identidad facial |
| Historial y consulta general de marcaciones | Implementados | Endpoints documentados en [API](../api/README.md) |
| Filtro por fecha y reporte por periodo | Implementados | El reporte cuenta marcaciones, no calcula horas ni tardanzas |
| Script SQL Server | Publicado | `src/database/01_crear_base_datos.sql` |
| Aplicación MAUI Android | Implementada como captura/previsualización | `src/mobile/BenailuTech`; no conectada con API |
| Reconocimiento facial | Pendiente | Seleccionar tecnología, algoritmo y lugar de procesamiento |
| Integración Android–API | Pendiente | Definir contrato HTTP y seguridad |
| Autenticación y autorización | Pendientes | Diseñar roles, permisos y protección de endpoints |
| Pruebas automatizadas | Pendientes | Crear pruebas unitarias e integración |
| Validación desde clon limpio | Pendiente de documentar | Repetir guía en entorno externo con SQL Server configurado |
| Revisar fechas y responsables del Gantt | Pendiente | Confirmar compromisos actuales del equipo |

## Decisiones tecnológicas confirmadas

- Terminal previsto: teléfono Android compartido.
- Backend: C# / ASP.NET Core Web API (.NET 10).
- Aplicación: .NET MAUI dirigida a Android (.NET 10).
- Base de datos: SQL Server.
- Acceso a datos: Microsoft.Data.SqlClient.

## Alcance de las pruebas

El equipo informa que verificó la compilación de los proyectos y las operaciones funcionales del backend localmente. Las solicitudes de prueba cubren trabajadores, marcaciones, historial, filtro por fecha y reporte por periodo. Esto no valida reconocimiento facial, integración móvil, despliegue ni seguridad para producción.

## Gestión de trabajo

Registrar tareas, defectos y bloqueos en GitHub Issues. Utilizar las plantillas de `.github/ISSUE_TEMPLATE/` y relacionar los Pull Requests con el Issue correspondiente.
