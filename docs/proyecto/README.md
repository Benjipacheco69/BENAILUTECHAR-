# Proyecto y planificación

## Identificación

- **Proyecto:** Benailu Tech
- **Sistema:** control de asistencia mediante reconocimiento facial desde un teléfono Android compartido.
- **Materia:** Programación II
- **Carrera:** Ingeniería en Sistemas
- **Universidad:** Universidad Privada Franz Tamayo
- **Docente:** Ing. Diego Patrick Cardenas Sejas
- **Ubicación indicada en el documento:** Cochabamba, Bolivia.

## Descripción

El proyecto contempla utilizar un teléfono Android ubicado en la entrada de la empresa como terminal de marcación. Los trabajadores utilizarán la cámara del dispositivo para identificarse mediante reconocimiento facial. Un servidor desarrollado en C# gestiona las operaciones y SQL Server almacena los datos de trabajadores y asistencias.

La primera versión del backend C# ya fue implementada y probada localmente: incluye conexión con SQL Server, administración de trabajadores, registro y consulta de marcaciones, filtro por fecha y reportes básicos. El código fuente del backend y el script SQL todavía deben incorporarse al repositorio.

El reconocimiento facial, la aplicación Android y su integración con el servidor siguen pendientes.

## Usuarios finales

- **Trabajadores:** realizarán sus marcaciones en el teléfono Android compartido.
- **Personal administrativo autorizado:** registra trabajadores y consulta asistencias.
- **Responsables de la empresa:** revisan los registros y reportes.

## Componentes y tecnologías

| Componente | Definición actual |
|---|---|
| Terminal de marcación | Teléfono Android compartido, pendiente |
| Identificación | Reconocimiento facial, pendiente |
| Servidor | C# / ASP.NET Core Web API, primera versión local probada |
| Acceso a datos | Microsoft.Data.SqlClient |
| Base de datos | SQL Server, utilizada por el backend local |
| Tecnología de la aplicación Android | Pendiente de definir |
| Biblioteca y algoritmo facial | Pendiente de definir |
| Comunicación Android-servidor | Pendiente de diseñar e integrar |

## Gantt

![Diagrama de Gantt inicial de Benailu Tech](../../assets/images/gantt-benailu-tech.svg)

[Ver Gantt editable y sus fechas](GANTT.md). Las fechas son tentativas y deben revisarse según el avance real del equipo.

## Cronograma inicial

| Actividad | Inicio | Fin | Responsable |
|---|---|---|---|
| Análisis y validación de requisitos | 05/10/2026 | 16/10/2026 | Todos |
| Diseño de arquitectura y prototipo Android | 12/10/2026 | 30/10/2026 | Interfaz |
| Revisión del modelo de datos SQL Server | 19/10/2026 | 06/11/2026 | Líder / BD |
| Diseño del módulo de reconocimiento facial | 19/10/2026 | 13/11/2026 | Por confirmar |
| Diseño de interfaz del terminal Android | 26/10/2026 | 20/11/2026 | Interfaz |
| Servidor C# e integración de componentes | 16/11/2026 | 27/11/2026 | Por confirmar |
| Pruebas y corrección de errores | 23/11/2026 | 04/12/2026 | Por confirmar |
| Documentación y presentación final | 30/11/2026 | 11/12/2026 | Todos |

Las fechas son tentativas y deben actualizarse según el avance real del equipo. El backend inicial se adelantó y ya fue probado localmente; la integración completa sigue pendiente.

## Recursos

### Hardware

- Computadora o laptop para desarrollo y administración.
- Teléfono Android con cámara para utilizarlo como terminal compartido.
- Conectividad necesaria para la comunicación con el servidor, según la arquitectura que se defina.

### Software

- C# / ASP.NET Core para el servidor.
- Microsoft.Data.SqlClient para el acceso a datos.
- SQL Server para la base de datos.
- Tecnología Android y herramientas de reconocimiento facial por seleccionar.

Ya no se considera un lector físico de huellas como dispositivo principal del sistema.

## Riesgos y aspectos por resolver

- Calidad de la captura facial y condiciones de iluminación.
- Selección de la biblioteca y método de reconocimiento facial.
- Decisión sobre el lugar donde se procesarán los datos biométricos.
- Protección de la información biométrica y personal.
- Conectividad entre el teléfono y el servidor.
- Autenticación y autorización para las operaciones del sistema.
- Reglas adicionales para horarios, tardanzas y ausencias.
- Incorporación del backend y del script SQL al repositorio.

## Próximos pasos

1. Incorporar el proyecto backend C# a src/backend sin publicar secretos ni archivos generados.
2. Incorporar un script SQL reproducible a src/database.
3. Revisar y completar la documentación técnica de la API.
4. Elegir la tecnología de la aplicación Android y el método de reconocimiento facial.
5. Diseñar la comunicación segura entre Android y el servidor C#.
6. Implementar autenticación y autorización.
7. Integrar, probar y documentar el sistema completo.
