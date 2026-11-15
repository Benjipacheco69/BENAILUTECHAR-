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

El proyecto propone utilizar un teléfono Android ubicado en la entrada de la empresa como terminal de marcación. Los trabajadores utilizarán la cámara del dispositivo para identificarse mediante reconocimiento facial y registrar sus entradas y salidas. Un servidor desarrollado en C# gestionará las operaciones y SQL Server almacenará los datos de trabajadores y asistencias.

El reconocimiento facial es una funcionalidad planificada para la etapa de programación; todavía no se encuentra implementada.

## Usuarios finales

- **Trabajadores:** realizan sus marcaciones en el teléfono Android compartido.
- **Personal administrativo autorizado:** registra trabajadores y consulta asistencias.
- **Responsables de la empresa:** revisan los registros y reportes.

## Componentes y tecnologías

| Componente | Definición actual |
|---|---|
| Terminal de marcación | Teléfono Android compartido |
| Identificación | Reconocimiento facial |
| Servidor | C# |
| Base de datos | SQL Server |
| Tecnología de la aplicación Android | Pendiente de definir |
| Biblioteca y algoritmo facial | Pendiente de definir |
| Comunicación Android-servidor | Pendiente de diseñar |

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

Las fechas son tentativas y deben actualizarse según el avance real del equipo.

## Recursos

### Hardware

- Computadora o laptop para desarrollo y administración.
- Teléfono Android con cámara para utilizarlo como terminal compartido.
- Conectividad necesaria para la comunicación con el servidor, según la arquitectura que se defina.

### Software

- C# para el servidor.
- SQL Server para la base de datos.
- Tecnología Android y herramientas de reconocimiento facial por seleccionar.

Ya no se considera un lector físico de huellas como dispositivo principal del sistema.

## Riesgos y aspectos por resolver

- Calidad de la captura facial y condiciones de iluminación.
- Selección de la biblioteca y método de reconocimiento facial.
- Decisión sobre el lugar donde se procesarán los datos biométricos.
- Protección de la información biométrica y personal.
- Conectividad entre el teléfono y el servidor.
- Reglas para distinguir las marcaciones de entrada y salida.
- Adaptación del modelo de datos existente.

## Próximos pasos

1. Validar los requisitos actualizados con el equipo y el docente.
2. Confirmar los datos que se registrarán de cada trabajador.
3. Definir la regla de entrada y salida.
4. Revisar y adaptar el modelo de datos SQL Server antes de modificar la base actual.
5. Elegir la tecnología de la aplicación Android y el método de reconocimiento facial.
6. Diseñar la comunicación con el servidor C#.
7. Implementar, integrar y probar los componentes.
8. Completar los manuales y la documentación final.
