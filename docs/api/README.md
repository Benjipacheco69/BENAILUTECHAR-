# API del servidor

## Estado
Existe una primera versión de la API desarrollada con C# / ASP.NET Core Web API, conectada a SQL Server mediante Microsoft.Data.SqlClient. Los endpoints descritos se probaron localmente mediante solicitudes HTTP y el navegador.

El código fuente todavía no está incorporado en src/backend de este repositorio. Esta página documenta el comportamiento de la versión local probada; no significa que el backend esté publicado ni conectado con Android.

## Configuración local
La dirección base depende del perfil de ejecución de Visual Studio. En las pruebas realizadas se utilizó https://localhost:7049. Si el puerto cambia, se debe utilizar la dirección que muestra Visual Studio. La API debe permanecer ejecutándose mientras se realizan las solicitudes.

La cadena de conexión de SQL Server se configura localmente. No subir al repositorio cadenas de conexión que incluyan nombres de equipos, credenciales o datos privados.

## Trabajadores

| Método | Ruta | Descripción |
|---|---|---|
| POST | /api/Trabajadores | Registrar un trabajador |
| GET | /api/Trabajadores | Listar trabajadores |
| GET | /api/Trabajadores/{ci} | Buscar trabajador por CI |
| PUT | /api/Trabajadores/{id} | Modificar datos del trabajador |
| PATCH | /api/Trabajadores/{id}/desactivar | Desactivar un trabajador |

Ejemplo de registro:

    POST /api/Trabajadores
    Content-Type: application/json

    {
      "ci": "7654321",
      "nombres": "Maria Elena",
      "apellidos": "Lopez"
    }

## Marcaciones

| Método | Ruta | Descripción |
|---|---|---|
| POST | /api/Marcaciones | Registrar entrada o salida |
| GET | /api/Marcaciones | Consultar todas las marcaciones |
| GET | /api/Marcaciones?fecha=AAAA-MM-DD | Consultar marcaciones de una fecha |
| GET | /api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD | Obtener resumen por trabajador y periodo |
| GET | /api/Marcaciones/{ci} | Consultar historial por CI |

Ejemplo para registrar una marcación:

    POST /api/Marcaciones
    Content-Type: application/json

    {
      "ci": "7654321",
      "tipo": "ENTRADA"
    }

El campo tipo admite ENTRADA o SALIDA. La versión actual comprueba que el trabajador exista y esté activo, y que las marcaciones alternen entre entrada y salida durante el día. La primera marcación del día debe ser ENTRADA.

Ejemplo de consulta por fecha:

    GET /api/Marcaciones?fecha=2026-11-15

Ejemplo de reporte del periodo:

    GET /api/Marcaciones/reporte?fechaInicio=2026-11-01&fechaFin=2026-11-15

El reporte devuelve, por trabajador, el número de entradas, salidas y marcaciones dentro del periodo. Los trabajadores sin marcaciones en ese periodo también aparecen con cantidades en cero.

## Pruebas realizadas
Se probaron localmente las siguientes operaciones:
- Registro, consulta, modificación y desactivación de trabajadores.
- Registro de entradas y salidas.
- Consulta de historial por CI.
- Consulta general de marcaciones.
- Filtro por fecha.
- Reporte por trabajador y periodo.

Los resultados coincidieron con los registros de prueba guardados en SQL Server.

## Limitaciones actuales
- La API todavía no está integrada con la aplicación Android.
- El reconocimiento facial no está implementado ni conectado al endpoint de marcaciones.
- La solicitud de marcación de prueba utiliza el CI; por sí sola no demuestra la identidad de una persona.
- No se ha implementado autenticación ni autorización de usuarios.
- El reporte cuenta marcaciones, pero no calcula horas trabajadas, tardanzas, ausencias ni cumplimiento de horarios.
- La versión documentada se probó localmente y no está desplegada para uso real.

Antes de utilizar el sistema con datos reales se deben implementar controles de acceso, protección de datos, validaciones adicionales y pruebas de seguridad.
