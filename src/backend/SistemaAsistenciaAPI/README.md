# Backend — Sistema de Asistencia

API REST desarrollada con ASP.NET Core y C#, conectada a SQL Server.

## Estructura
- `Controllers/TrabajadoresController.cs`: registro, búsqueda, listado, modificación y desactivación lógica de trabajadores.
- `Controllers/MarcacionesController.cs`: registro de entradas/salidas, historial por CI, consulta general, filtro por fecha y reporte por periodo.
- `Program.cs`: configuración de la API y endpoint de comprobación de conexión.
- `appsettings.example.json`: plantilla de configuración local sin credenciales reales.

## Requisitos
- .NET SDK 10.
- SQL Server y SQL Server Management Studio (SSMS).

## Preparación local
1. Ejecutar el script `src/database/01_SistemaAsistencia.sql` en SSMS.
2. Copiar `appsettings.example.json` como `appsettings.json` en esta carpeta del proyecto.
3. Editar localmente `ConnectionStrings:ConexionSQL` con el nombre de la instancia SQL Server.
4. Abrir `SistemaAsistenciaAPI.csproj` en Visual Studio y restaurar los paquetes.
5. Ejecutar el proyecto.

**No subir** `appsettings.json`, contraseñas, tokens ni cadenas de conexión privadas.

## Endpoints

### Trabajadores
- `POST /api/Trabajadores`
- `GET /api/Trabajadores`
- `GET /api/Trabajadores/{ci}`
- `PUT /api/Trabajadores/{id}`
- `PATCH /api/Trabajadores/{id}/desactivar`

### Marcaciones
- `POST /api/Marcaciones`
- `GET /api/Marcaciones`
- `GET /api/Marcaciones?fecha=AAAA-MM-DD`
- `GET /api/Marcaciones/{ci}`
- `GET /api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD`

### Conexión
- `GET /api/conexion`

El reporte devuelve el total de entradas, salidas y marcaciones por trabajador para el periodo indicado. No calcula todavía horas trabajadas ni tardanzas.
