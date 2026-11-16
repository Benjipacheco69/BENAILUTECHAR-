# Manual de instalación y ejecución

## 1. Alcance de esta guía

El repositorio contiene el código de una API ASP.NET Core en C#, una aplicación .NET MAUI para Android y el script SQL Server. El equipo informa que ya verificó la compilación de los proyectos. La guía describe cómo preparar una instalación local; la conexión SQL Server depende de la instancia y credenciales configuradas por cada desarrollador.

La app móvil actualmente solicita permiso de cámara y captura/previsualiza una fotografía. No realiza reconocimiento facial ni envía marcaciones a la API. La API registra marcaciones de prueba mediante CI.

## 2. Requisitos

- Windows 10/11 recomendado para Visual Studio y desarrollo Android.
- .NET SDK 10.0.
- Visual Studio con las cargas de trabajo ASP.NET y .NET MAUI.
- .NET MAUI workload Android y Android SDK.
- Emulador o dispositivo Android con cámara.
- Microsoft SQL Server y SSMS o herramienta equivalente.
- Git.

Verifica el SDK:

```bash
dotnet --list-sdks
```

## 3. Obtener el proyecto

```bash
git clone https://github.com/Benjipacheco69/BENAILUTECHAR-.git
cd BENAILUTECHAR-
```

La solución de la raíz es `BenailuTech.slnx` e incluye los proyectos backend y móvil.

## 4. Crear la base de datos

1. Inicia SQL Server y abre SSMS.
2. Conéctate a la instancia local o de desarrollo.
3. Abre y ejecuta `src/database/01_crear_base_datos.sql`.
4. Comprueba la creación de `SistemaAsistencia` y las tablas `Trabajadores`, `DatosFaciales` y `Marcaciones`.

El script crea las tablas si no existen e inserta un trabajador de prueba con CI `1234567` y una marcación ENTRADA cuando no hay una previa para ese trabajador. Revisa el contenido antes de ejecutarlo en una base que ya tenga información. No es un mecanismo de migración para producción.

## 5. Configurar SQL Server

El backend lee la cadena desde `ConnectionStrings:ConexionSQL`. El archivo versionado contiene un ejemplo local con autenticación integrada:

```json
{
  "ConnectionStrings": {
    "ConexionSQL": "Server=localhost;Database=SistemaAsistencia;Integrated Security=True;TrustServerCertificate=True;"
  }
}
```

Cambia `Server` por el nombre de tu instancia, por ejemplo `localhost\\SQLEXPRESS`. Si utilizas autenticación SQL, guarda el usuario y contraseña en User Secrets o variables de entorno, nunca en un commit.

Con User Secrets, desde la carpeta del backend:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:ConexionSQL" "Server=localhost\\SQLEXPRESS;Database=SistemaAsistencia;Integrated Security=True;TrustServerCertificate=True;"
```

Para la configuración anterior se debe utilizar el modo de autenticación compatible con la instancia SQL Server. No reutilices datos de conexión de otra persona.

## 6. Restaurar, compilar y ejecutar la API

Desde la raíz:

```bash
dotnet restore src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.csproj
dotnet build src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.csproj
dotnet run --project src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.csproj
```

Los perfiles locales están en `Properties/launchSettings.json`:

- HTTPS: `https://localhost:7049`
- HTTP: `http://localhost:5241`

La ruta `GET /api/conexion` comprueba que la API puede abrir una conexión SQL Server. En desarrollo, OpenAPI se expone en `/openapi/v1.json`; el proyecto no configura una interfaz Swagger UI.

## 7. Compilar y ejecutar la aplicación Android

Instala el workload si todavía no está disponible:

```bash
dotnet workload install maui-android
```

Compila:

```bash
dotnet restore src/mobile/BenailuTech/BenailuTech.csproj
dotnet build src/mobile/BenailuTech/BenailuTech.csproj -f net10.0-android
```

También puedes abrir `BenailuTech.slnx` en Visual Studio, seleccionar el proyecto BenailuTech y elegir un emulador o dispositivo Android.

Al iniciar la aplicación:
1. Selecciona **CAPTURAR ROSTRO**.
2. Concede permiso de cámara cuando Android lo solicite.
3. Captura una fotografía y comprueba la previsualización.
4. Usa **REPETIR CAPTURA** para limpiar la imagen.

Esta función es únicamente captura/previsualización. No compara rostros, no identifica trabajadores y no registra asistencia.

## 8. Endpoints de la API

| Método | Ruta | Descripción |
|---|---|---|
| GET | `/api/conexion` | Verificar conexión SQL Server |
| POST | `/api/Trabajadores` | Registrar trabajador |
| GET | `/api/Trabajadores` | Listar trabajadores |
| GET | `/api/Trabajadores/{ci}` | Buscar trabajador activo por CI |
| PUT | `/api/Trabajadores/{id}` | Modificar trabajador |
| PATCH | `/api/Trabajadores/{id}/desactivar` | Desactivar trabajador |
| POST | `/api/Marcaciones` | Registrar ENTRADA o SALIDA |
| GET | `/api/Marcaciones` | Consultar todas las marcaciones |
| GET | `/api/Marcaciones?fecha=AAAA-MM-DD` | Filtrar por fecha |
| GET | `/api/Marcaciones/{ci}` | Consultar historial por CI |
| GET | `/api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD` | Conteos por trabajador y periodo |

Ejemplo de trabajador:

```http
POST /api/Trabajadores
Content-Type: application/json

{
  "ci": "7654321",
  "nombres": "Maria",
  "apellidos": "Lopez"
}
```

Ejemplo de marcación:

```http
POST /api/Marcaciones
Content-Type: application/json

{
  "ci": "7654321",
  "tipo": "ENTRADA"
}
```

El tipo debe ser `ENTRADA` o `SALIDA`. La primera marcación del día debe ser ENTRADA y las posteriores deben alternar. Los ejemplos se encuentran en `src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.http`.

## 9. Pruebas y verificación

El equipo informa que verificó la compilación de los proyectos. El backend incluye solicitudes HTTP manuales para registrar/listar/buscar/modificar/desactivar trabajadores, registrar entradas/salidas, consultar historial, filtrar por fecha y generar reportes. Para repetirlas:

1. Ejecuta el script SQL.
2. Configura y ejecuta la API.
3. Abre el archivo `.http` en Visual Studio o un editor compatible.
4. Ejecuta las solicitudes de una en una, verificando respuestas y registros en SQL Server.
5. Prueba también una salida como primera marcación y dos entradas consecutivas; ambas deben ser rechazadas por las reglas de alternancia.

No se incluye aún un proyecto de pruebas automatizadas. Las pruebas manuales no equivalen a una validación de seguridad ni a una prueba integral de reconocimiento facial.

## 10. Seguridad y limitaciones

- No hay autenticación ni autorización en la API actual.
- No publiques cadenas de conexión, contraseñas, tokens ni datos personales.
- No uses información biométrica real en las pruebas.
- La app no está integrada con la API y no reconoce rostros.
- La marcación de prueba usa CI y no verifica identidad.
- El reporte cuenta entradas/salidas; no calcula horas, tardanzas, ausencias ni cumplimiento de horarios.
- Antes de uso real se requieren controles de acceso, transporte seguro, auditoría, privacidad biométrica, política de retención y pruebas de seguridad.
