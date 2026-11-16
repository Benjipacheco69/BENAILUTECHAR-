# API ASP.NET Core

## Estado y configuración

La API fuente está en `src/backend/SistemaAsistenciaAPI/`. Utiliza ASP.NET Core sobre .NET 10 y SQL Server mediante `Microsoft.Data.SqlClient`. La configuración de conexión se lee desde `ConnectionStrings:ConexionSQL`.

El perfil local utiliza HTTPS `https://localhost:7049` y HTTP `http://localhost:5241`. La ruta `GET /api/conexion` comprueba la conexión. En entorno Development se publica el documento OpenAPI en `/openapi/v1.json`; no se configura Swagger UI.

Configura tu instancia SQL Server en `appsettings.json` o con User Secrets. Nunca subas credenciales.

## Trabajadores

| Método | Ruta | Descripción |
|---|---|---|
| POST | `/api/Trabajadores` | Registrar trabajador |
| GET | `/api/Trabajadores` | Listar trabajadores |
| GET | `/api/Trabajadores/{ci}` | Buscar trabajador activo por CI |
| PUT | `/api/Trabajadores/{id}` | Modificar datos |
| PATCH | `/api/Trabajadores/{id}/desactivar` | Desactivar trabajador |

Ejemplo de registro:

```http
POST /api/Trabajadores
Content-Type: application/json

{
  "ci": "7654321",
  "nombres": "Maria",
  "apellidos": "Lopez"
}
```

## Marcaciones

| Método | Ruta | Descripción |
|---|---|---|
| POST | `/api/Marcaciones` | Registrar entrada o salida |
| GET | `/api/Marcaciones` | Consultar todas las marcaciones |
| GET | `/api/Marcaciones?fecha=AAAA-MM-DD` | Filtrar por fecha |
| GET | `/api/Marcaciones/{ci}` | Consultar historial por CI |
| GET | `/api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD` | Conteos por trabajador y periodo |

Ejemplo:

```http
POST /api/Marcaciones
Content-Type: application/json

{
  "ci": "7654321",
  "tipo": "ENTRADA"
}
```

El campo `tipo` admite `ENTRADA` o `SALIDA`. El trabajador debe existir y estar activo. La primera marcación del día debe ser ENTRADA y las siguientes deben alternar entre ENTRADA y SALIDA.

El reporte devuelve total de entradas, salidas y marcaciones por trabajador. No calcula horas trabajadas, tardanzas ni ausencias.

## Pruebas manuales

Las solicitudes listas para ejecutar se encuentran en [SistemaAsistenciaAPI.http](../../src/backend/SistemaAsistenciaAPI/SistemaAsistenciaAPI.http). El equipo indica que ya verificó la compilación de los proyectos y las operaciones del backend localmente. No existe todavía un proyecto de pruebas automatizadas.

## Limitaciones

- La app Android no consume esta API.
- La captura de fotografía no es reconocimiento facial.
- La marcación utiliza CI para pruebas; no verifica identidad.
- No hay autenticación ni autorización.
- No está desplegada para producción.
