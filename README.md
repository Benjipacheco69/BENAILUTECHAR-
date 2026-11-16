# Benailu Tech — Sistema de control de asistencia

Benailu Tech es un proyecto de control de asistencia de trabajadores. El repositorio reúne una API ASP.NET Core, una aplicación .NET MAUI y el script SQL Server. El objetivo final contempla marcación desde Android y reconocimiento facial; **esas dos capacidades todavía no están integradas ni implementadas funcionalmente**.

## Estado real de la solución

| Componente | Estado |
|---|---|
| API ASP.NET Core | Implementada para operaciones de trabajadores y marcaciones |
| Persistencia SQL Server | Implementada mediante `Microsoft.Data.SqlClient` |
| Aplicación .NET MAUI | Proyecto inicial Android; la captura/visualización de cámara no equivale a reconocimiento facial |
| Integración aplicación–API | Pendiente |
| Reconocimiento facial | Pendiente |
| Autenticación/autorización | Pendiente |
| Pruebas automatizadas | No se encontró un proyecto de pruebas automatizadas; las verificaciones documentadas son manuales |

La API permite registrar, consultar, modificar y desactivar trabajadores; registrar entradas/salidas; consultar historiales y obtener conteos por periodo. El reporte no calcula horas trabajadas, tardanzas ni ausencias.

## Tecnologías y requisitos

- .NET SDK 10.0 (los proyectos fuente apuntan a `net10.0` y `net10.0-android`).
- Visual Studio 2022 actualizado con las cargas de trabajo ASP.NET y .NET MAUI, o CLI de .NET para el backend.
- SQL Server y SQL Server Management Studio (SSMS) o herramienta equivalente.
- Para ejecutar Android: Android SDK/emulador o dispositivo compatible y las herramientas MAUI correspondientes.

## Estructura

```text
.
├── docs/
│   └── manuales/
│       └── instalacion-y-ejecucion.md
├── src/
│   ├── backend/
│   │   └── SistemaAsistenciaAPI/
│   ├── database/
│   │   └── 01_crear_base_datos.sql
│   └── mobile/
│       └── BenailuTech/
├── .gitignore
├── INVENTARIO.md
└── README.md
```

## Preparación rápida

1. Instala .NET 10 SDK y SQL Server.
2. Ejecuta `src/database/01_crear_base_datos.sql` en SSMS. El script crea `SistemaAsistencia`, las tablas `Trabajadores`, `DatosFaciales` y `Marcaciones`, y agrega un registro de prueba si no existe.
3. Configura la cadena de conexión `ConexionSQL` en la configuración local de la API. No publiques contraseñas ni cadenas personales.
4. Desde `src/backend/SistemaAsistenciaAPI` ejecuta:

   ```bash
   dotnet restore
   dotnet build
   dotnet run
   ```

5. Para instrucciones completas, ejemplos HTTP, configuración y limitaciones consulta el [manual de instalación y ejecución](docs/manuales/instalacion-y-ejecucion.md).

## Rutas principales de la API

| Método | Ruta | Descripción |
|---|---|---|
| POST | `/api/Trabajadores` | Crear trabajador |
| GET | `/api/Trabajadores` | Listar trabajadores |
| GET | `/api/Trabajadores/{ci}` | Buscar por CI |
| PUT | `/api/Trabajadores/{id}` | Actualizar trabajador |
| PATCH | `/api/Trabajadores/{id}/desactivar` | Desactivar trabajador |
| POST | `/api/Marcaciones` | Crear marcación |
| GET | `/api/Marcaciones` | Listar marcaciones |
| GET | `/api/Marcaciones?fecha=AAAA-MM-DD` | Filtrar por fecha |
| GET | `/api/Marcaciones/{ci}` | Historial por CI |
| GET | `/api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD` | Conteos por trabajador y periodo |

## Configuración y seguridad

La API lee su conexión SQL Server desde la clave `ConexionSQL`. Usa una configuración local o User Secrets para credenciales; no guardes secretos en Git. El proyecto es una base de desarrollo, no un sistema listo para producción. Antes de usar datos reales se deben añadir autenticación, autorización, HTTPS correctamente configurado, protección de datos personales/biométricos, auditoría y pruebas de seguridad.

## Pruebas

No se incluye actualmente un proyecto de pruebas unitarias o de integración. El manual describe comprobaciones manuales de los endpoints y la base de datos. La ejecución debe verificarse en el entorno del desarrollador; no se afirma que haya sido ejecutada en un entorno limpio de CI.

## Alcance futuro

La identificación facial, el flujo completo desde el teléfono Android hasta la API, autenticación/autorización y cálculos avanzados de asistencia son trabajo pendiente. Los diagramas o descripciones de esas capacidades deben entenderse como diseño objetivo y no como funcionalidad entregada.
