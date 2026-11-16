# Manual de instalación y ejecución

## 1. Componentes y alcance

El material fuente entregado por el equipo contiene dos proyectos:

- **Aplicación móvil:** .NET MAUI, proyecto `BenailuTech`, dirigido a Android (`net10.0-android`). El código solicita permiso de cámara, captura una fotografía y la muestra en pantalla.
- **Backend:** ASP.NET Core Web API, proyecto `SistemaAsistenciaAPI`, dirigido a `net10.0`. Utiliza `Microsoft.Data.SqlClient` y la cadena de conexión `ConnectionStrings:ConexionSQL`.
- **Base de datos:** SQL Server. El script `src/database/01_crear_base_datos.sql` corresponde al archivo SQLQuery6.sql entregado por el equipo.

La cámara no implica reconocimiento facial: en el código móvil revisado no se identificó un motor biométrico ni comunicación HTTP con la API. La integración móvil-backend, el reconocimiento facial y la autenticación/autorización siguen pendientes.

> **Disponibilidad en este repositorio:** se publicó el script SQL y la documentación. El código de los proyectos MAUI y ASP.NET Core todavía debe incorporarse bajo `src/mobile/` y `src/backend/` para que la ejecución pueda hacerse únicamente después de clonar el repositorio. Mientras tanto, utilice los ZIP fuente originales entregados por el equipo.

## 2. Requisitos

- Windows 10/11.
- .NET SDK 10.0.
- Visual Studio con las cargas de trabajo de ASP.NET y .NET MAUI.
- SQL Server (por ejemplo, SQL Server Express) y SQL Server Management Studio (SSMS) o herramienta equivalente.
- Android SDK, emulador o dispositivo Android para ejecutar la aplicación móvil.
- Git.

Compruebe la versión del SDK:

```bash
dotnet --list-sdks
```

Los proyectos entregados apuntan a `net10.0` (API) y `net10.0-android` (MAUI).

## 3. Crear la base de datos

1. Inicie el servicio de SQL Server.
2. Abra SSMS y conéctese a su instancia de desarrollo.
3. Abra y ejecute `src/database/01_crear_base_datos.sql`.
4. Compruebe que se creó la base `SistemaAsistencia` y las tablas `Trabajadores`, `DatosFaciales` y `Marcaciones`.

El script es el SQLQuery6.sql entregado por el equipo. Además de crear las tablas, inserta el trabajador de prueba CI `1234567` y una marcación ENTRADA si aún no existen. Revise el script antes de ejecutarlo en una base que contenga datos: está diseñado para desarrollo/prueba y no sustituye un procedimiento de migración de producción.

## 4. Configurar la conexión del backend

En el proyecto API, la clave utilizada es `ConnectionStrings:ConexionSQL`. Configure la cadena para su propia instancia SQL Server. Ejemplo para SQL Server Express con autenticación integrada:

```json
{
  "ConnectionStrings": {
    "ConexionSQL": "Server=localhost\\SQLEXPRESS;Database=SistemaAsistencia;Integrated Security=True;TrustServerCertificate=True;"
  }
}
```

Puede usar User Secrets o variables de entorno para evitar guardar credenciales. No suba contraseñas, cadenas de conexión personales ni secretos al repositorio.

## 5. Ejecutar el backend

Con el proyecto fuente disponible localmente, abra `SistemaAsistenciaAPI.csproj` en Visual Studio o ejecute desde la carpeta del proyecto:

```bash
dotnet restore
dotnet build
dotnet run
```

La URL efectiva se muestra en la consola. El perfil de desarrollo entregado incluye `https://localhost:7049`; el puerto puede variar según el perfil y el equipo.

La API expone `/api/conexion` para comprobar la conexión con SQL Server. En desarrollo también se configura OpenAPI mediante `MapOpenApi`; no se identificó una interfaz Swagger UI explícita en los paquetes/código revisados.

## 6. Endpoints identificados

| Método | Ruta | Descripción |
|---|---|---|
| POST | `/api/Trabajadores` | Registrar trabajador |
| GET | `/api/Trabajadores` | Listar trabajadores |
| GET | `/api/Trabajadores/{ci}` | Buscar por CI |
| PUT | `/api/Trabajadores/{id}` | Modificar trabajador |
| PATCH | `/api/Trabajadores/{id}/desactivar` | Desactivar trabajador |
| POST | `/api/Marcaciones` | Registrar entrada o salida |
| GET | `/api/Marcaciones` | Consultar marcaciones |
| GET | `/api/Marcaciones?fecha=AAAA-MM-DD` | Filtrar por fecha |
| GET | `/api/Marcaciones/{ci}` | Consultar historial por CI |
| GET | `/api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD` | Conteos por trabajador y periodo |

Ejemplo de solicitud para crear un trabajador:

```http
POST /api/Trabajadores
Content-Type: application/json

{
  "ci": "7654321",
  "nombres": "Maria",
  "apellidos": "Lopez"
}
```

Ejemplo para registrar una entrada:

```http
POST /api/Marcaciones
Content-Type: application/json

{
  "ci": "7654321",
  "tipo": "ENTRADA"
}
```

Para una salida, use `SALIDA`. La lógica de la API exige que la primera marcación del día sea ENTRADA y que las siguientes alternen entre ENTRADA y SALIDA.

## 7. Ejecutar la aplicación MAUI

1. Abra `BenailuTech.csproj` en Visual Studio.
2. Seleccione un emulador o dispositivo Android.
3. Restaure paquetes, compile y ejecute.
4. Conceda el permiso de cámara.
5. Pruebe los controles de captura y repetición de captura.

El comportamiento observado es captura y visualización de fotografía. No se debe presentar como identificación facial ni como registro de asistencia integrado.

## 8. Pruebas y reproducibilidad

El material entregado incluye un archivo `SistemaAsistenciaAPI.http` para pruebas manuales de endpoints. No se encontró un proyecto de pruebas automatizadas en los archivos revisados.

Para una verificación manual:
- Crear un trabajador de prueba.
- Consultarlo por CI y listar trabajadores.
- Registrar ENTRADA y luego SALIDA.
- Comprobar que la API rechaza una secuencia que no respete la alternancia.
- Consultar historial, filtro por fecha y reporte.
- Verificar los registros en SQL Server.

Estas instrucciones describen pruebas manuales; no constituyen evidencia de una ejecución automatizada ni de una validación independiente en un equipo limpio.

## 9. Limitaciones y tareas pendientes

- Publicar el código fuente MAUI y ASP.NET Core en sus carpetas del repositorio.
- Verificar la instalación completa desde un clon limpio.
- Incorporar pruebas automatizadas.
- Integrar la app móvil con la API.
- Implementar reconocimiento facial si continúa siendo requisito.
- Añadir autenticación, autorización, auditoría y protección de datos personales/biométricos antes de cualquier uso real.
- El reporte actual cuenta marcaciones; no calcula horas trabajadas, tardanzas ni ausencias.
