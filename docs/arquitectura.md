# Arquitectura

La descripción del flujo general y de los componentes se encuentra en [Arquitectura propuesta](arquitectura/README.md).

## Componentes
- **Terminal Android:** teléfono compartido ubicado en la entrada de la empresa. La aplicación y su interfaz están pendientes.
- **Servidor C#:** primera versión de una API ASP.NET Core implementada y probada localmente. Gestiona trabajadores y marcaciones.
- **SQL Server:** base de datos utilizada por el backend local para conservar trabajadores y registros de asistencia.
- **Módulo de reconocimiento facial:** pendiente de implementación. La biblioteca, el algoritmo y la ubicación del procesamiento todavía deben definirse.
- **Consultas y reportes:** implementados en la API en una primera versión; permiten consultar marcaciones y obtener conteos por trabajador y periodo.

## Separación general
La aplicación Android será el terminal de interacción. El servidor C# concentrará la lógica del sistema y la comunicación con SQL Server. La base de datos conservará la información de manera persistente.

En la versión local probada, las solicitudes de marcación se envían mediante HTTP usando el CI del trabajador. Esto es únicamente una forma de probar el backend: todavía no existe integración con reconocimiento facial ni Android.

## Estado

| Componente | Estado |
|---|---|
| API C# y conexión SQL Server | Implementadas y probadas localmente |
| Administración de trabajadores | Implementada y probada localmente |
| Registro y consulta de marcaciones | Implementados y probados localmente |
| Filtro por fecha y reporte por periodo | Implementados y probados localmente |
| Código fuente del backend en GitHub | Pendiente de incorporar |
| Script SQL de creación de la base | Pendiente de incorporar |
| Aplicación Android | Pendiente |
| Reconocimiento facial | Pendiente |
| Integración Android, reconocimiento y servidor | Pendiente |
| Autenticación y autorización | Pendientes |

El reconocimiento facial sustituye el planteamiento anterior de lector físico de huellas como dispositivo principal de marcación.

Consultar también [diagramas](diagramas/README.md) y [documentación de la API](api/README.md).
