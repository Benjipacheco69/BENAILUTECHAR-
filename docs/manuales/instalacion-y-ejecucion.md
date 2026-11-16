# Manual de instalación y ejecución

## 1. Propósito

Este documento describe cómo preparar el entorno para trabajar con Benailu Tech y cómo ejecutar la primera versión local del servidor cuando su código fuente y el script de SQL Server estén incorporados al repositorio.

**Estado de reproducibilidad:** la API fue ejecutada y probada localmente por el equipo, pero actualmente el código fuente del backend y el script SQL todavía no están publicados en `src/backend/` y `src/database/`. Por eso, una persona externa todavía no puede reproducir la ejecución únicamente clonando este repositorio. Los pasos que dependen de esos archivos se identifican como pendientes y no se presentan como pruebas ya realizadas.

## 2. Componentes y herramientas

Para preparar el entorno se necesitará:

- Windows.
- Visual Studio con las herramientas de desarrollo de ASP.NET y C#.
- El SDK de .NET compatible con el proyecto. La versión exacta debe confirmarse en el archivo `.csproj` cuando se publique el backend.
- Microsoft SQL Server, con una instancia local o accesible para desarrollo.
- SQL Server Management Studio (SSMS) u otra herramienta compatible para ejecutar y revisar scripts SQL.
- Git para clonar y actualizar el repositorio.

La aplicación Android y el módulo de reconocimiento facial no son necesarios para probar la API actual, porque todavía no están implementados ni integrados.

## 3. Obtener el proyecto

Cuando el backend esté publicado:

1. Clonar el repositorio:
   
   ```bash
   git clone https://github.com/Benjipacheco69/BENAILUTECHAR-.git
   ```

2. Entrar en la carpeta del proyecto:
   
   ```bash
   cd BENAILUTECHAR-
   ```

3. Comprobar que exista el proyecto de C# dentro de `src/backend/`. Debe contener el archivo de solución (`.sln`) o de proyecto (`.csproj`) y sus archivos fuente.

**Pendiente:** actualmente `src/backend/` contiene únicamente un archivo de conservación de carpeta. El proyecto ejecutable todavía debe incorporarse.

## 4. Preparar la base de datos

Cuando se publique el script SQL:

1. Abrir SQL Server Management Studio.
2. Conectarse a la instancia de SQL Server que se utilizará para desarrollo.
3. Abrir el script de creación de base de datos ubicado en `src/database/`.
4. Revisar que el script corresponda a la versión del backend.
5. Ejecutarlo y comprobar que se hayan creado la base de datos y las tablas necesarias.

La versión local documentada utiliza información de trabajadores y marcaciones. La arquitectura también menciona una tabla `DatosFaciales` como preparación para una etapa futura; su uso no significa que el reconocimiento facial ya esté implementado.

**Pendiente:** actualmente `src/database/` contiene únicamente un archivo de conservación de carpeta. El script SQL reproducible todavía debe incorporarse. El nombre definitivo del archivo y el nombre de la base de datos deben documentarse cuando se publique el script real.

## 5. Configurar la conexión

La API local utiliza `Microsoft.Data.SqlClient` para conectarse a SQL Server.

1. Revisar en el código publicado qué nombre de configuración utiliza la aplicación para obtener la cadena de conexión.
2. Configurar la cadena para la instancia y la base de datos de desarrollo.
3. Guardar los datos de conexión en una configuración local no versionada o en un mecanismo seguro de secretos.
4. Verificar que la cuenta utilizada tenga únicamente los permisos necesarios para las operaciones de desarrollo.

No se deben subir al repositorio contraseñas, cadenas de conexión personales, nombres privados de equipos ni otros secretos. Tampoco se deben utilizar datos biométricos reales en las pruebas de desarrollo.

**Pendiente:** la clave exacta de configuración y el procedimiento concreto deben confirmarse al publicar el código fuente. No se debe inventar un nombre de clave ni copiar una cadena de conexión de otro equipo.

## 6. Restaurar y ejecutar la API

Una vez que el backend esté incorporado:

1. Abrir la solución o el proyecto desde Visual Studio.
2. Esperar a que Visual Studio restaure las dependencias de NuGet. Si se trabaja desde una terminal, ejecutar `dotnet restore` desde la carpeta del proyecto.
3. Compilar el proyecto y resolver cualquier error antes de ejecutarlo.
4. Confirmar que SQL Server esté iniciado y que la base de datos esté disponible.
5. Ejecutar el proyecto desde Visual Studio.
6. Revisar la salida de ejecución para identificar la dirección local en la que quedó escuchando la API.

En las pruebas locales documentadas se utilizó `https://localhost:7049`, pero el puerto puede cambiar según el perfil de ejecución. Se debe utilizar la dirección que muestre Visual Studio en el equipo donde se ejecuta el proyecto.

**Pendiente:** estos pasos deberán verificarse nuevamente desde una copia limpia del repositorio cuando se publiquen el proyecto y la base de datos.

## 7. Operaciones documentadas de la API

Con la API en ejecución, se pueden probar las rutas descritas en [Documentación de la API](../api/README.md).

| Método | Ruta | Uso |
|---|---|---|
| POST | `/api/Trabajadores` | Registrar un trabajador |
| GET | `/api/Trabajadores` | Listar trabajadores |
| GET | `/api/Trabajadores/{ci}` | Buscar trabajador por CI |
| PUT | `/api/Trabajadores/{id}` | Modificar datos de un trabajador |
| PATCH | `/api/Trabajadores/{id}/desactivar` | Desactivar un trabajador |
| POST | `/api/Marcaciones` | Registrar una entrada o salida de prueba |
| GET | `/api/Marcaciones` | Consultar marcaciones |
| GET | `/api/Marcaciones?fecha=AAAA-MM-DD` | Filtrar por fecha |
| GET | `/api/Marcaciones/{ci}` | Consultar historial por CI |
| GET | `/api/Marcaciones/reporte?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD` | Obtener conteos por trabajador y periodo |

Ejemplo de cuerpo JSON para registrar un trabajador:

```json
{
  "ci": "7654321",
  "nombres": "Maria Elena",
  "apellidos": "Lopez"
}
```

Ejemplo de cuerpo JSON para una marcación de prueba:

```json
{
  "ci": "7654321",
  "tipo": "ENTRADA"
}
```

El tipo debe ser `ENTRADA` o `SALIDA`. La primera marcación del día debe ser una entrada y las siguientes deben alternar entre entrada y salida, de acuerdo con las reglas descritas para la versión local.

## 8. Pruebas funcionales

Las pruebas locales documentadas abarcan:

- Registrar, listar, buscar, modificar y desactivar trabajadores.
- Registrar entradas y salidas.
- Comprobar la alternancia de las marcaciones durante el día.
- Consultar el historial de un trabajador.
- Consultar marcaciones generales.
- Filtrar marcaciones por fecha.
- Generar un resumen de entradas, salidas y total de marcaciones por trabajador dentro de un periodo.

Para repetirlas, utilizar datos ficticios y comprobar tanto la respuesta de la API como los registros guardados en SQL Server. Registrar los resultados, la fecha de ejecución y cualquier error encontrado.

Estas pruebas describen el alcance probado localmente por el equipo; no equivalen a una prueba independiente desde una instalación limpia.

## 9. Problemas frecuentes

| Problema | Qué revisar |
|---|---|
| La API no inicia | Errores de compilación, SDK de .NET compatible y dependencias restauradas |
| No se conecta a SQL Server | Servicio iniciado, instancia, nombre de base de datos, permisos y cadena de conexión local |
| La dirección local no responde | Confirmar que la API siga ejecutándose y utilizar el puerto mostrado por Visual Studio |
| Una ruta devuelve error | Método HTTP, ruta, formato JSON y datos enviados |
| La marcación es rechazada | Trabajador existente y activo, tipo permitido y alternancia de entrada/salida |

## 10. Limitaciones y seguridad

- La API actual es un prototipo local y no está desplegada para uso real.
- Las solicitudes de marcación de prueba utilizan el CI; no verifican la identidad mediante reconocimiento facial.
- La aplicación Android y la integración con el servidor están pendientes.
- El reconocimiento facial no está implementado.
- La API todavía no cuenta con autenticación ni autorización.
- El reporte cuenta marcaciones; no calcula horas trabajadas, tardanzas, ausencias ni cumplimiento de horarios.

Antes de utilizar el sistema con trabajadores reales, se deben implementar controles de acceso, protección de las comunicaciones, manejo seguro de secretos, medidas de privacidad para los datos biométricos y pruebas de seguridad.

## 11. Tareas necesarias para completar la reproducibilidad

- [ ] Publicar el proyecto C# completo en `src/backend/`.
- [ ] Incluir el archivo de solución/proyecto y documentar la versión de .NET.
- [ ] Publicar un script SQL Server de creación de la base de datos en `src/database/`.
- [ ] Incorporar un ejemplo de configuración sin contraseñas ni datos privados.
- [ ] Documentar el nombre de la base de datos y la clave de configuración real.
- [ ] Probar la instalación desde una copia limpia del repositorio.
- [ ] Registrar los resultados de las pruebas y corregir los pasos que no funcionen.

La documentación se considerará reproducible cuando una persona externa pueda clonar el repositorio, preparar SQL Server, configurar sus propios datos locales, ejecutar la API y repetir las pruebas sin depender de archivos privados del equipo.
