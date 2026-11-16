# Benailu Tech — Sistema de control de asistencia

Proyecto académico para gestionar trabajadores y sus marcaciones de asistencia. El objetivo contempla una aplicación Android, una API ASP.NET Core y SQL Server. La identificación facial y la integración completa entre la app y la API aún no están implementadas.

## Estado y alcance verificado

| Componente | Estado |
|---|---|
| API ASP.NET Core | Código fuente entregado por el equipo; implementa operaciones de trabajadores y marcaciones |
| Base SQL Server | Script SQLQuery6.sql publicado en este repositorio |
| Aplicación .NET MAUI | Código fuente entregado; captura y visualiza fotografías con la cámara |
| Integración app–API | Pendiente |
| Reconocimiento facial | Pendiente; captura de foto no es reconocimiento biométrico |
| Autenticación y autorización | Pendientes |
| Pruebas automatizadas | No se encontró proyecto de pruebas automatizadas en el material revisado; hay pruebas manuales HTTP |

**Importante sobre el contenido publicado:** en este repositorio ya están el README, el manual y el script SQL. Los proyectos fuente completos de MAUI y ASP.NET Core todavía deben añadirse a `src/mobile/` y `src/backend/`. Hasta entonces, las instrucciones de ejecución requieren los ZIP fuente entregados por el equipo y no se puede clonar el repositorio y ejecutar la solución completa sin esos archivos.

## Tecnologías y requisitos

- .NET SDK 10.0 (los proyectos fuente entregados apuntan a `net10.0` y `net10.0-android`).
- Visual Studio con cargas de trabajo ASP.NET y .NET MAUI.
- SQL Server y SSMS o herramienta equivalente.
- Android SDK, emulador o dispositivo Android para la app.

## Estructura publicada

```text
.
├── docs/
│   └── manuales/
│       └── instalacion-y-ejecucion.md
├── src/
│   └── database/
│       └── 01_crear_base_datos.sql
└── README.md
```

## Preparar SQL Server

1. Abre SQL Server Management Studio y conéctate a una instancia de desarrollo.
2. Ejecuta `src/database/01_crear_base_datos.sql`.
3. El script crea la base `SistemaAsistencia` y las tablas `Trabajadores`, `DatosFaciales` y `Marcaciones`.
4. Inserta un trabajador de prueba con CI `1234567` y una marcación ENTRADA si no existen registros previos para ese trabajador.

Este script es el archivo SQLQuery6.sql entregado por el equipo. Está orientado a desarrollo/prueba; revísalo antes de ejecutarlo en bases con información existente.

## Backend y aplicación móvil

Consulta el [manual de instalación y ejecución](docs/manuales/instalacion-y-ejecucion.md) para requisitos, cadena de conexión, comandos .NET, endpoints, pruebas manuales y limitaciones.

La API utiliza la clave `ConnectionStrings:ConexionSQL` para la conexión SQL Server. No publiques contraseñas ni cadenas privadas. El código móvil observado solicita permiso de cámara y muestra la fotografía capturada; no se identificó integración HTTP con la API ni un motor de reconocimiento facial.

## Endpoints de la API identificados en el código fuente entregado

| Método | Ruta | Descripción |
|---|---|---|
| POST | `/api/Trabajadores` | Crear trabajador |
| GET | `/api/Trabajadores` | Listar trabajadores |
| GET | `/api/Trabajadores/{ci}` | Buscar por CI |
| PUT | `/api/Trabajadores/{id}` | Actualizar trabajador |
| PATCH | `/api/Trabajadores/{id}/desactivar` | Desactivar trabajador |
| POST | `/api/Marcaciones` | Registrar marcación |
| GET | `/api/Marcaciones` | Listar marcaciones |
| GET | `/api/Marcaciones?fecha=AAAA-MM-DD` | Filtrar por fecha |
| GET | `/api/Marcaciones/{ci}` | Historial por CI |
| GET | `/api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD` | Conteos por trabajador y periodo |

El reporte cuenta marcaciones; no calcula horas trabajadas, tardanzas ni ausencias. Antes de utilizar el sistema con trabajadores reales se deben implementar autenticación, autorización, protección de datos personales y biométricos, auditoría y pruebas de seguridad.

## Pruebas y reproducibilidad

No se encontró un proyecto de pruebas automatizadas en el material fuente. El manual describe pruebas manuales de endpoints y comprobaciones en SQL Server. Aún falta incorporar los proyectos fuente al repositorio y verificar la instalación desde un clon limpio.
