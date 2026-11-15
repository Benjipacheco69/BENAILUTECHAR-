# BENAILU TECH

## Descripción
**Benailu Tech** es un sistema de control de asistencia para trabajadores. El proyecto contempla un teléfono Android compartido en la entrada de la empresa para realizar marcaciones mediante reconocimiento facial. Un servidor en C# gestiona las operaciones y SQL Server almacena los datos.

El proyecto se desarrolla por componentes. Actualmente existe una primera API en C# conectada a SQL Server y probada localmente. La aplicación Android y el reconocimiento facial todavía están pendientes de implementación e integración.

## Objetivo
Facilitar el registro de entradas y salidas, centralizar la información y permitir al personal autorizado consultar historiales y reportes.

## Estado actual

| Componente | Estado |
|---|---|
| API/servidor en C# | Implementado y probado localmente en su primera versión |
| Conexión con SQL Server | Probada localmente |
| Registro y administración de trabajadores | Implementado y probado |
| Registro de entradas y salidas | Implementado y probado con solicitudes HTTP |
| Historial y consulta de marcaciones | Implementado y probado |
| Filtro de marcaciones por fecha | Implementado y probado |
| Reporte de cantidades por trabajador y periodo | Implementado y probado |
| Aplicación Android | Pendiente |
| Reconocimiento facial | Pendiente |
| Integración Android-servidor | Pendiente |
| Autenticación y autorización | Pendientes |
| Publicación del código backend en este repositorio | Pendiente |

**Importante:** las pruebas del servidor se realizaron localmente. El código fuente del backend y el script de base de datos todavía deben incorporarse al repositorio para que otros integrantes puedan reproducir la ejecución. El backend local no está desplegado ni integrado con Android.

## Funcionamiento previsto
1. El personal autorizado registra los datos básicos de cada trabajador.
2. Se realiza el enrolamiento facial cuando el módulo esté implementado.
3. El trabajador utiliza el teléfono Android compartido en la entrada.
4. El módulo facial intenta identificarlo.
5. Una vez integrada y validada la identificación, se solicita al servidor registrar la marcación.
6. El servidor aplica las reglas de asistencia y guarda la información en SQL Server.
7. El personal autorizado consulta el historial y los reportes.

En la versión actual del backend, las marcaciones se prueban mediante solicitudes HTTP usando el CI del trabajador. Todavía no existe verificación facial conectada a este proceso.

## Funcionalidades del servidor implementadas
- Registrar trabajadores.
- Consultar trabajadores por CI y listar trabajadores.
- Modificar datos de trabajadores.
- Desactivar trabajadores.
- Registrar marcaciones de tipo ENTRADA y SALIDA.
- Validar que las marcaciones alternen entre entrada y salida durante el día.
- Consultar el historial de marcaciones por CI.
- Consultar todas las marcaciones.
- Filtrar marcaciones por fecha.
- Generar un resumen de entradas, salidas y total de marcaciones por trabajador en un periodo.

El reporte actual cuenta marcaciones; no calcula horas trabajadas, tardanzas, ausencias ni cumplimiento de horarios.

## Tecnologías

| Elemento | Tecnología/estado |
|---|---|
| Backend | C# / ASP.NET Core Web API |
| Acceso a datos | Microsoft.Data.SqlClient |
| Base de datos | Microsoft SQL Server |
| Terminal de marcación | Teléfono Android compartido, pendiente |
| Reconocimiento | Facial, pendiente |
| Comunicación Android-servidor | Pendiente de definir e integrar |

## Privacidad y seguridad
Los datos personales y biométricos deben protegerse. No se deben subir contraseñas, cadenas de conexión locales, datos biométricos reales ni archivos de configuración con secretos. La versión actual es un prototipo de desarrollo: antes de utilizarla con trabajadores reales se debe implementar autenticación, autorización, protección de comunicaciones y controles adecuados para los datos biométricos.

## Estructura del repositorio
- docs/: documentación del proyecto.
- src/backend/: ubicación prevista para el proyecto C#.
- src/database/: ubicación prevista para scripts SQL.
- src/frontend/: ubicación prevista para la aplicación Android.
- tests/: pruebas.
- assets/: recursos.

Las carpetas src/backend y src/database están preparadas, pero el código backend y el script SQL aún deben subirse. La estructura no implica que esos archivos ya estén presentes.

## Documentación
- [Visión y alcance](docs/vision-y-alcance.md)
- [Requisitos](docs/requisitos.md)
- [Arquitectura general](docs/arquitectura.md)
- [Arquitectura propuesta y flujo](docs/arquitectura/README.md)
- [Documentación de la API y ejemplos](docs/api/README.md)
- [Proyecto y planificación](docs/proyecto/README.md)
- [Seguimiento de actividades](docs/planificacion/seguimiento.md)
- [Cronograma Gantt](docs/proyecto/GANTT.md)
- [Diagramas](docs/diagramas/README.md)
- [Integrantes y roles](docs/equipo/integrantes-y-roles.md)
- [Acuerdos de trabajo](docs/equipo/acuerdos-de-trabajo.md)
- [Manuales](docs/manuales/README.md)

## Ejecución
Las instrucciones definitivas se agregarán cuando el backend y su script de base de datos estén versionados. Para ejecutar la versión local actual se requiere Visual Studio, el SDK de .NET utilizado por el proyecto, SQL Server y una cadena de conexión configurada localmente. No se debe publicar la cadena de conexión personal.

## Colaboración
Los cambios deben organizarse mediante commits descriptivos y revisión del equipo. Cada integrante debe coordinar la integración de sus componentes para evitar sobrescribir el trabajo de los demás.
