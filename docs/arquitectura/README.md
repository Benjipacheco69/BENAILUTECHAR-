# Arquitectura propuesta

## Componentes principales

### 1. Terminal Android
Teléfono compartido ubicado en la entrada de la empresa. Presentará la interfaz de marcación y utilizará su cámara para iniciar la identificación facial. La tecnología concreta para desarrollar esta aplicación queda pendiente.

### 2. Servidor C#
La primera versión del servidor se desarrolló como una API ASP.NET Core en C#. Se probó localmente y permite registrar, consultar, modificar y desactivar trabajadores; registrar entradas y salidas; consultar historiales; filtrar marcaciones por fecha y generar conteos por trabajador y periodo.

El código fuente todavía debe incorporarse a src/backend en este repositorio. La API local se comunica con SQL Server mediante Microsoft.Data.SqlClient.

### 3. Base de datos
SQL Server almacena los datos básicos de los trabajadores y las marcaciones. En la versión local se utilizaron las tablas Trabajadores y Marcaciones. También se creó una tabla DatosFaciales para una futura etapa, pero el enrolamiento y el reconocimiento facial todavía no están implementados.

El script SQL reproducible debe incorporarse a src/database. No se deben publicar cadenas de conexión personales ni datos biométricos reales.

### 4. Módulo de reconocimiento facial
Este módulo permitirá enrolar a los trabajadores autorizados y realizar su identificación durante la marcación. La biblioteca, el algoritmo y la ubicación del procesamiento (teléfono, servidor o combinación) se decidirán durante el diseño técnico y la programación.

### 5. Consultas y reportes
La API local ya permite consultar todas las marcaciones, filtrar por fecha, consultar el historial de un trabajador por CI y generar un resumen de entradas, salidas y total de marcaciones por trabajador en un periodo.

El reporte actual cuenta marcaciones; todavía no calcula horas trabajadas, tardanzas, ausencias ni cumplimiento de horarios.

## Flujo actual de administración de trabajadores

    Personal autorizado / solicitud de prueba
                 |
                 v
       API C# - módulo de trabajadores
                 |
                 v
         Validar y procesar datos
                 |
                 v
        SQL Server - Trabajadores

## Flujo actual de marcación de prueba

    Solicitud HTTP con CI y tipo
                 |
                 v
       API C# - módulo de marcaciones
                 |
                 v
     Comprobar trabajador activo y alternancia
                 |
                 v
        SQL Server - Marcaciones
                 |
                 v
          Respuesta de confirmación

Este es el flujo probado localmente. No realiza reconocimiento facial y no debe utilizarse como prueba de identidad del trabajador.

## Flujo futuro con Android y reconocimiento facial

    Trabajador utiliza el teléfono Android
                 |
                 v
       La cámara captura información facial
                 |
                 v
       Módulo de reconocimiento intenta identificar
                 |
                 v
            ¿Identidad confirmada?
              /             \
            No               Sí
            |                |
      Mostrar mensaje   Enviar solicitud segura
      y no marcar       al servidor C#
                               |
                               v
                       Validar autorización
                               |
                               v
                           SQL Server
                               |
                               v
                        Mostrar resultado

El flujo futuro es conceptual. La forma exacta de enviar los datos, el lugar del procesamiento facial y la regla para distinguir entrada y salida deben definirse antes de la integración.

## Responsabilidad de cada componente

| Componente | Responsabilidad |
|---|---|
| Terminal Android | Interacción con el trabajador y uso de la cámara |
| Servidor C# | Reglas de negocio, coordinación y acceso a datos |
| Módulo facial | Enrolamiento e identificación |
| SQL Server | Persistencia de trabajadores y asistencias |
| Consultas y reportes | Presentación de información al personal autorizado |

## Decisiones confirmadas
- El dispositivo de marcación será un teléfono Android compartido.
- La identificación prevista será mediante reconocimiento facial.
- El servidor será desarrollado en C#.
- La base de datos será SQL Server.
- Existe una primera versión local de la API C# probada con SQL Server.

## Decisiones pendientes
- Tecnología y estructura de la aplicación Android.
- Biblioteca y método de reconocimiento facial.
- Lugar donde se ejecutará el procesamiento biométrico.
- Contratos y mecanismo seguro de comunicación entre Android y el servidor.
- Incorporación del código backend y del script SQL al repositorio.
- Autenticación, autorización y protección de los datos.
- Reglas adicionales para horarios, tardanzas, ausencias y excepciones.
- Funcionamiento ante pérdida de conexión.

## Seguridad y privacidad
El acceso a los datos de trabajadores y a la información biométrica debe estar restringido. Se evaluará almacenar representaciones biométricas protegidas en lugar de fotografías completas, siempre que la solución técnica elegida lo permita. No se debe implementar ni publicar el manejo de datos biométricos sin definir previamente su protección y los permisos correspondientes.

La API local actual es un prototipo de desarrollo y no implementa autenticación ni autorización. Antes de utilizarla con trabajadores reales se deben incorporar controles de acceso, protección de comunicaciones, manejo seguro de secretos y pruebas de seguridad.

## Estado de implementación
El backend C# y su conexión con SQL Server están implementados y probados localmente, pero su código fuente todavía no está en este repositorio. La aplicación Android, el reconocimiento facial y la integración completa siguen pendientes.
