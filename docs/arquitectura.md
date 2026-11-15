# Arquitectura

La descripción del flujo y de los componentes se encuentra en [Arquitectura propuesta](arquitectura/README.md).

## Componentes previstos

- **Terminal Android:** interfaz compartida ubicada en la entrada de la empresa; utiliza la cámara para iniciar la marcación facial.
- **Servidor C#:** gestiona las solicitudes, aplica las reglas de negocio y coordina el acceso a los datos.
- **Base de datos SQL Server:** almacena los datos de trabajadores, información biométrica protegida y registros de asistencia.
- **Módulo de reconocimiento facial:** realiza el enrolamiento y la identificación. La biblioteca, el algoritmo y la ubicación del procesamiento todavía deben definirse.
- **Consultas y reportes:** permiten al personal autorizado revisar las asistencias.

## Separación general

La aplicación Android funciona como terminal de interacción. El servidor C# concentra la lógica del sistema y la comunicación con SQL Server. La base de datos conserva la información de manera persistente.

## Estado

Arquitectura conceptual propuesta, todavía no implementada. El servidor C# y SQL Server ya son decisiones del proyecto. La tecnología Android, la biblioteca facial, la distribución del procesamiento biométrico, los contratos de comunicación y las medidas concretas de protección deben definirse antes de programar.

El reconocimiento facial sustituye el planteamiento anterior de lector físico de huellas como dispositivo principal de marcación.

Consultar también [diagramas](diagramas/README.md).
