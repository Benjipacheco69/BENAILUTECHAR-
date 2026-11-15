# Requisitos del sistema

## Objetivo

Definir los requisitos iniciales de un sistema de control de asistencia que utilice reconocimiento facial desde un teléfono Android compartido, un servidor desarrollado en C# y una base de datos SQL Server.

## Requisitos funcionales iniciales

### RF-01 — Registro de trabajadores
El sistema debe permitir al personal autorizado registrar los datos básicos de cada trabajador, como código de empleado, nombres, apellidos y número de identificación. El equipo debe confirmar los campos definitivos.

### RF-02 — Enrolamiento facial
El sistema debe permitir registrar los datos biométricos faciales de un trabajador autorizado para utilizarse posteriormente en la identificación. El procedimiento y la tecnología se definirán durante el diseño técnico.

### RF-03 — Terminal de marcación
El sistema debe ofrecer una interfaz en un teléfono Android compartido, ubicado en la entrada de la empresa, para que los trabajadores realicen sus marcaciones.

### RF-04 — Captura para identificación
Al iniciar una marcación, el terminal debe utilizar la cámara del teléfono para obtener la información necesaria para intentar identificar al trabajador.

### RF-05 — Identificación facial
El sistema debe comparar la información obtenida durante la marcación con los registros biométricos autorizados y determinar si existe una identidad coincidente. El algoritmo y el lugar donde se ejecutará el procesamiento quedan pendientes de definición.

### RF-06 — Persona no identificada
Si el sistema no logra identificar al trabajador, debe mostrar un mensaje claro y no registrar una asistencia como si la identidad estuviera confirmada.

### RF-07 — Registro de asistencia
Cuando la identidad se confirme, el sistema debe registrar la marcación correspondiente del trabajador.

### RF-08 — Fecha y hora
Cada marcación confirmada debe conservar la fecha y hora del registro.

### RF-09 — Consulta de asistencias
El personal autorizado debe poder consultar los registros de asistencia de los trabajadores.

### RF-10 — Reportes
El sistema debe permitir obtener reportes básicos de asistencia por trabajador y por periodo, de acuerdo con los filtros que se definan.

### RF-11 — Gestión de errores
El sistema debe informar cuando exista un problema de conexión, captura o identificación, sin presentar una marcación fallida como exitosa.

## Requisitos no funcionales iniciales

### RNF-01 — Tiempo de respuesta
El proceso de marcación debe ser ágil. Como objetivo inicial se propone que el proceso habitual no supere un minuto; este valor deberá comprobarse mediante pruebas.

### RNF-02 — Seguridad y privacidad
Los datos personales y biométricos deben almacenarse con protección y acceso restringido. Se debe evaluar el uso de representaciones biométricas protegidas y evitar conservar imágenes faciales completas si no son necesarias.

### RNF-03 — Usabilidad
La interfaz del teléfono Android debe ser sencilla, legible y fácil de utilizar por los trabajadores.

### RNF-04 — Comunicación
El terminal debe comunicarse con el servidor para realizar las operaciones necesarias. La política de funcionamiento cuando no exista conexión debe definirse durante el diseño.

### RNF-05 — Mantenibilidad
El servidor debe desarrollarse en C# y mantener separadas, en lo posible, las reglas de negocio, el acceso a datos y la comunicación con el terminal.

### RNF-06 — Persistencia
La información de trabajadores y asistencias debe almacenarse en SQL Server.

## Datos que debe manejar el sistema

- Código del trabajador.
- Nombres y apellidos.
- Número de identificación, si el equipo confirma que será requerido.
- Datos biométricos faciales protegidos para identificación.
- Fecha y hora de cada marcación.
- Tipo de marcación (entrada o salida).
- Información necesaria para consultas y reportes.

## Criterios de validación iniciales

- El personal autorizado puede registrar los datos de un trabajador.
- El sistema permite completar el enrolamiento facial de un trabajador autorizado.
- El teléfono Android permite iniciar el proceso de marcación.
- Una identidad reconocida permite registrar una marcación asociada al trabajador correcto.
- Una identidad no reconocida no genera una asistencia confirmada.
- Cada marcación confirmada conserva fecha y hora.
- El personal autorizado puede consultar registros y generar reportes.
- Los datos biométricos y personales no quedan disponibles para usuarios no autorizados.

Estos criterios deberán convertirse en pruebas cuando exista una primera versión programada.

## Decisiones pendientes

- Confirmar los campos definitivos del registro del trabajador.
- Definir cómo se determinará si la marcación es entrada o salida.
- Elegir la tecnología para desarrollar la aplicación Android.
- Seleccionar la biblioteca y el método de reconocimiento facial.
- Definir si el procesamiento facial se realizará en el teléfono, en el servidor o mediante una combinación.
- Diseñar la comunicación entre Android y el servidor C#.
- Adaptar y validar el modelo de datos existente para SQL Server.
- Definir el almacenamiento y la protección de los datos biométricos.
- Definir permisos, administración de usuarios y política ante pérdida de conexión.
