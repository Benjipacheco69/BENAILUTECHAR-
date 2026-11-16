# Benailu Tech — Sistema de control de asistencia

Benailu Tech es un proyecto académico para gestionar trabajadores y sus marcaciones de asistencia. La solución está compuesta por una API ASP.NET Core en C#, una aplicación Android desarrollada con .NET MAUI y una base de datos SQL Server.

## Propósito y problema

El proyecto busca reducir el trabajo manual de registro de entradas y salidas, centralizar la información de asistencia y facilitar su consulta por parte del personal administrativo. El objetivo de evolución contempla utilizar reconocimiento facial desde un teléfono Android compartido en el acceso de la empresa.

**Importante:** la versión que se encuentra en este repositorio implementa una API para administrar trabajadores y marcaciones, y una app MAUI que captura y muestra una fotografía. La captura de cámara no realiza reconocimiento facial. La app móvil todavía no está integrada con la API; la identificación biométrica, autenticación y autorización siguen pendientes.

## Usuarios objetivo

- **Trabajadores:** realizarán sus marcaciones en el teléfono Android compartido cuando se implemente el flujo facial.
- **Personal administrativo autorizado:** registra y administra trabajadores y consulta asistencias.
- **Responsables de la empresa:** revisan registros y reportes de asistencia.

## Equipo

Integrantes identificados en la documentación del proyecto:

- Ainhoa Almudena Flores Vidal
- Arturo Gonzales Rufino
- Benji Pacheco Lafuente
- Luis Ángel Rocha Paco

La asignación nominal definitiva de responsabilidades debe confirmarse entre los integrantes. Las responsabilidades técnicas y acuerdos se documentan en [Integrantes y roles](docs/equipo/integrantes-y-roles.md) y [Acuerdos de trabajo](docs/equipo/acuerdos-de-trabajo.md).

## Funcionalidades y estado

| Funcionalidad | Estado |
|---|---|
| Registrar, listar y buscar trabajadores | Implementada en API |
| Modificar y desactivar trabajadores | Implementada en API |
| Registrar entradas y salidas usando CI | Implementada en API para pruebas |
| Validar alternancia ENTRADA/SALIDA | Implementada en API |
| Consultar historial y filtrar por fecha | Implementada en API |
| Reporte de conteos por trabajador y periodo | Implementado en API |
| Capturar y previsualizar fotografía en Android | Implementada en app MAUI |
| Reconocimiento facial/enrolamiento biométrico | Pendiente |
| Integración de Android con la API | Pendiente |
| Autenticación y autorización | Pendientes |
| Horarios, tardanzas, ausencias y cálculo de horas | Pendientes |

El reporte actual cuenta entradas, salidas y marcaciones; no calcula horas trabajadas, tardanzas ni ausencias. La solicitud de marcación usa CI como mecanismo de prueba y no verifica la identidad de una persona.

## Tecnologías y requisitos

- .NET SDK 10.0.
- .NET MAUI workload para Android y Android SDK.
- Visual Studio con cargas de trabajo ASP.NET y .NET MAUI (recomendado para Android).
- SQL Server y SSMS o herramienta equivalente.
- Git.

Proyectos: API `net10.0`; app móvil `net10.0-android`. La solución agregadora está en `BenailuTech.slnx`.

## Estructura del repositorio

```text
.
├── BenailuTech.slnx
├── README.md
├── .editorconfig
├── .gitignore
├── CHANGELOG.md
├── CONTRIBUTING.md
├── LICENSE
├── SECURITY.md
├── docs/
│   ├── vision-y-alcance.md
│   ├── requisitos.md
│   ├── arquitectura.md
│   ├── modelo-de-datos.md
│   ├── planificacion/
│   ├── diagramas/
│   ├── manuales/
│   └── equipo/
├── src/
│   ├── backend/SistemaAsistenciaAPI/
│   ├── mobile/BenailuTech/
│   └── database/01_crear_base_datos.sql
├── tests/
└── .github/
    ├── ISSUE_TEMPLATE/
    ├── pull_request_template.md
    └── workflows/
```

## Instalación, configuración y ejecución

1. Clona el repositorio:

   ```bash
   git clone https://github.com/Benjipacheco69/BENAILUTECHAR-.git
   cd BENAILUTECHAR-
   ```

2. En SQL Server Management Studio, ejecuta `src/database/01_crear_base_datos.sql`. Crea la base `SistemaAsistencia` y las tablas `Trabajadores`, `DatosFaciales` y `Marcaciones`. Incluye datos de prueba; revisa el script antes de usarlo en una base existente.

3. Configura `ConnectionStrings:ConexionSQL` en `src/backend/SistemaAsistenciaAPI/appsettings.json` o mediante User Secrets/variables de entorno. El valor versionado usa localhost como ejemplo; sustitúyelo por tu instancia. No publiques credenciales ni cadenas privadas.

4. Restaura y compila la API:

   ```bash
   dotnet restore src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.csproj
   dotnet build src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.csproj
   dotnet run --project src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.csproj
   ```

   El perfil HTTPS local utiliza `https://localhost:7049` y HTTP `http://localhost:5241`. La ruta `/api/conexion` permite comprobar el acceso a SQL Server.

5. Para compilar/ejecutar la aplicación Android, instala el workload MAUI Android y abre `BenailuTech.slnx` en Visual Studio o ejecuta:

   ```bash
   dotnet workload install maui-android
   dotnet build src/mobile/BenailuTech/BenailuTech.csproj -f net10.0-android
   ```

   Selecciona un emulador o dispositivo Android. La app solicita permiso de cámara y permite capturar y previsualizar una fotografía.

6. Las solicitudes de ejemplo para la API están en `src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.http`.

El equipo informa que ya verificó la compilación de los proyectos. Esta documentación no sustituye la validación de la configuración local de SQL Server en cada entorno.

## Documentación

- [Visión y alcance](docs/vision-y-alcance.md)
- [Requisitos](docs/requisitos.md)
- [Arquitectura](docs/arquitectura.md)
- [Modelo de datos](docs/modelo-de-datos.md)
- [Planificación](docs/planificacion/planificacion.md)
- [Gantt](docs/proyecto/GANTT.md)
- [Seguimiento](docs/planificacion/seguimiento.md)
- [Diagramas](docs/diagramas/README.md)
- [Manual de instalación y ejecución](docs/manuales/instalacion-y-ejecucion.md)
- [Documentación de la API](docs/api/README.md)
- [Equipo y roles](docs/equipo/integrantes-y-roles.md)

## Calidad, pruebas y seguridad

El repositorio contiene ejemplos HTTP para repetir las operaciones de la API. No se incluye actualmente un proyecto de pruebas automatizadas; la validación funcional documentada se realiza manualmente contra SQL Server. Se incorpora un workflow para compilar el backend en GitHub Actions.

No se debe utilizar con datos reales hasta implementar autenticación/autorización, protección de datos personales y biométricos, controles de acceso, auditoría y pruebas de seguridad. Reporta vulnerabilidades siguiendo [SECURITY.md](SECURITY.md).
