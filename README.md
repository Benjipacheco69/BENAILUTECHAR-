# BENAILU TECH

## Descripción

**Benailu Tech** es un sistema de control de asistencia mediante reconocimiento facial. La propuesta utiliza un teléfono Android compartido, ubicado en la entrada de la empresa, como terminal donde los trabajadores registran su asistencia. Un servidor desarrollado en **C#** gestiona las operaciones y **SQL Server** almacena la información de los trabajadores y sus marcaciones.

El objetivo es facilitar el registro de entradas y salidas, reducir el registro manual y permitir que el personal autorizado consulte la asistencia.

> **Estado actual:** proyecto en etapa de análisis, diseño y planificación. El reconocimiento facial y el registro desde Android están previstos para la etapa de programación; todavía no deben considerarse funcionalidades implementadas.

## Objetivos

- Registrar los datos de los trabajadores.
- Preparar el registro de sus datos faciales para identificarlos en el terminal Android.
- Registrar las marcaciones de entrada y salida con fecha y hora.
- Centralizar la información en SQL Server mediante un servidor desarrollado en C#.
- Facilitar la consulta de asistencias y la generación de reportes.

## Funcionamiento general propuesto

1. El personal autorizado registra al trabajador y sus datos básicos.
2. Se realiza el enrolamiento facial del trabajador durante la etapa de programación.
3. El trabajador se coloca frente al teléfono Android compartido en la entrada.
4. El sistema intenta identificarlo mediante reconocimiento facial.
5. Si la identidad se confirma, se registra la marcación correspondiente con fecha y hora.
6. El servidor en C# gestiona la operación y guarda los datos en SQL Server.
7. El personal autorizado puede consultar los registros y reportes.

La regla para distinguir entrada y salida, así como el tratamiento de situaciones excepcionales, debe definirse antes de implementar el registro.

## Componentes previstos

- **Terminal Android:** interfaz utilizada por los trabajadores para realizar la marcación mediante la cámara del teléfono.
- **Servidor C#:** recibe y gestiona las operaciones del sistema, aplica las reglas de negocio y se comunica con la base de datos.
- **SQL Server:** almacena los trabajadores, la información biométrica protegida y los registros de asistencia.
- **Módulo de reconocimiento facial:** permite enrolar e identificar a los trabajadores. La biblioteca, el algoritmo y el lugar exacto donde se realizará el procesamiento todavía deben definirse.

El requisito de C# corresponde al servidor. La tecnología concreta para desarrollar la aplicación Android queda pendiente de confirmación.

## Alcance funcional inicial

- Registro y consulta de trabajadores.
- Enrolamiento facial de trabajadores autorizados.
- Identificación facial desde el teléfono Android compartido.
- Registro de entrada y salida con fecha y hora.
- Consulta de asistencias.
- Reportes básicos por trabajador y periodo.

Las funciones anteriores describen el alcance propuesto; no significan que ya estén programadas.

## Tecnologías y decisiones

| Elemento | Decisión actual |
|---|---|
| Dispositivo de marcación | Teléfono Android compartido |
| Identificación | Reconocimiento facial |
| Servidor | C# |
| Base de datos | SQL Server |
| Tecnología de la aplicación Android | Pendiente de definir |
| Biblioteca y algoritmo facial | Pendiente de definir |
| Comunicación entre Android y servidor | Pendiente de diseñar |

El proyecto ya no contempla un lector físico de huellas como dispositivo principal de marcación.

## Privacidad y seguridad

Los datos faciales son información biométrica sensible. El diseño debe limitar su acceso, proteger su almacenamiento y evitar conservar fotografías completas si no son necesarias. Se evaluará el uso de representaciones biométricas protegidas y se definirán las medidas concretas antes de programar. También deberán establecerse permisos para consultar y administrar los registros.

## Estructura del repositorio

```text
BENAILUTECHAR-/
├── README.md
├── docs/
│   ├── proyecto/
│   ├── requisitos/
│   ├── arquitectura/
│   ├── diagramas/
│   ├── api/
│   └── manuales/
├── src/
│   ├── frontend/
│   ├── backend/
│   ├── database/
│   └── shared/
├── tests/
├── assets/
└── scripts/
```

Las carpetas de código y pruebas deben completarse durante la implementación. La presencia de una carpeta en el repositorio no significa que el componente ya esté desarrollado.

## Documentación

- [Visión y alcance](docs/vision-y-alcance.md)
- [Requisitos — índice](docs/requisitos.md) y [especificación detallada](docs/requisitos/README.md)
- [Arquitectura — índice](docs/arquitectura.md) y [flujo propuesto](docs/arquitectura/README.md)
- [Proyecto y planificación](docs/proyecto/README.md)
- [Planificación e hitos](docs/planificacion/planificacion.md)
- [Seguimiento](docs/planificacion/seguimiento.md)
- [Gantt](docs/proyecto/GANTT.md)
- [Diagramas](docs/diagramas/README.md)
- [Integrantes y roles](docs/equipo/integrantes-y-roles.md)
- [Acuerdos de trabajo](docs/equipo/acuerdos-de-trabajo.md)
- [Manuales](docs/manuales/README.md)

## Entorno y ejecución

Todavía no se publican instrucciones de instalación o ejecución porque la solución de programación, la aplicación Android, el servidor y sus dependencias deben implementarse y probarse. Cuando exista una versión ejecutable, se documentarán los requisitos y pasos reales para abrirla y ejecutarla.

## Cronograma

El cronograma de octubre a diciembre de 2026 es una planificación inicial. Debido al cambio de reconocimiento por huella a reconocimiento facial desde Android, el equipo debe revisar las actividades, fechas y responsables. No se debe interpretar una fecha planificada como evidencia de que una tarea ya fue completada.

Consultar el [Gantt del proyecto](docs/proyecto/GANTT.md).

## Colaboración

El trabajo se organizará mediante Issues y Pull Requests. La rama principal debe mantenerse estable y los cambios deben integrarse después de su revisión.

- [Cómo contribuir](CONTRIBUTING.md)
- [Historial de cambios](CHANGELOG.md)
- [Política de seguridad](SECURITY.md)
