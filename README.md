# BENAILUTECHAR

## Descripción

**Benailu Tech** es un proyecto de identificación biométrica mediante huella digital, planteado como una aplicación móvil que permite identificar usuarios registrados y registrar sus accesos en una base de datos.

El sistema busca facilitar una identificación rápida y segura, reduciendo riesgos de suplantación de identidad. El flujo previsto incluye captura de huella, validación de calidad, extracción de minucias, comparación con plantillas registradas, registro del intento y respuesta al usuario.

> **Estado:** análisis de requisitos, planificación y definición de arquitectura.

## Equipo

Según la documentación disponible:

- AINHOA ALMUDENA FLORES VIDAL
- ARTURO GONZALES RUFINO
- Benji Pacheco Lafuente
- Luis Ángel Rocha Paco

**Nota:** la documentación académica recibida enumera explícitamente a Ainhoa, Benji y Luis. La composición definitiva del equipo y la asignación nominal de roles deben confirmarse.

## Roles definidos

- **Líder y Base de Datos:** crear y organizar la base de datos, gestionar usuarios y registros de acceso y conectar el sistema con la base de datos.
- **Reconocimiento de Huella Digital:** conectar el lector, capturar la huella, extraer minucias y comparar con plantillas.
- **Interfaz y Pruebas:** diseñar la interfaz móvil, mostrar resultados, probar el sistema y corregir errores.

## Objetivos

- Diseñar una aplicación móvil de reconocimiento biométrico mediante huella digital.
- Facilitar la identificación de usuarios registrados.
- Almacenar de forma segura los datos y registros.
- Diseñar una interfaz móvil táctil sencilla para administradores.
- Mantener el proceso de identificación en un tiempo objetivo de menos de 1 minuto.

## Alcance funcional inicial

1. Iniciar la aplicación.
2. Activar el lector y el reconocimiento.
3. Capturar la huella.
4. Validar la calidad de la captura.
5. Repetir la captura si no es válida.
6. Procesar la huella y extraer minucias.
7. Comparar la plantilla con las registradas.
8. Informar si el usuario está registrado o no.
9. Registrar el intento/acceso.
10. Mostrar el resultado y volver a la pantalla principal.

## Estructura

```text
BENAILUTECHAR-/
├── README.md
├── docs/
│   ├── proyecto/
│   ├── requisitos/
│   ├── arquitectura/
│   ├── api/
│   └── manuales/
├── src/
│   ├── frontend/
│   ├── backend/
│   ├── database/
│   └── shared/
├── tests/
│   ├── unit/
│   ├── integration/
│   └── e2e/
├── assets/
│   ├── images/
│   ├── logos/
│   └── screenshots/
├── scripts/
└── .github/
    ├── ISSUE_TEMPLATE/
    └── PULL_REQUEST_TEMPLATE.md
```

## Documentación

- [Proyecto y planificación](docs/proyecto/README.md)
- [Requisitos](docs/requisitos/README.md)
- [Arquitectura](docs/arquitectura/README.md)
- [Manuales](docs/manuales/README.md)

## Cronograma

El Gantt tentativo cubre octubre–diciembre de 2026:

| Actividad | Inicio | Fin | Responsable indicado |
|---|---:|---:|---|
| Análisis de requisitos | 05/10/2026 | 16/10/2026 | Todos |
| Diseño de arquitectura y prototipo de interfaz | 12/10/2026 | 30/10/2026 | Interfaz |
| Base de datos (usuarios y registros de acceso) | 19/10/2026 | 06/11/2026 | Líder / BD |
| Módulo de huella digital (lector y comparación) | 19/10/2026 | 13/11/2026 | Huella |
| Interfaz móvil y pantalla de resultados | 26/10/2026 | 20/11/2026 | Interfaz |
| Integración de módulos | 16/11/2026 | 27/11/2026 | Todos |
| Pruebas y corrección de errores | 23/11/2026 | 04/12/2026 | Interfaz |
| Documentación y presentación final | 30/11/2026 | 11/12/2026 | Todos |

## Tecnologías

La documentación académica recibida presenta una diferencia que debe resolverse antes de iniciar la implementación:

- **Documento de proyecto:** recomienda **Python**, indicando OpenCV, NumPy, SDK del lector y pyfingerprint como tecnologías/librerías posibles.
- **Presentación:** indica que el sistema estará desarrollado en **C#**.

Por ahora se mantiene esta decisión como **pendiente de confirmación**, sin asumir una tecnología definitiva.

## Hardware y recursos

Se identifican como recursos necesarios:

- Computadora o laptop.
- Teléfono celular.
- Internet.
- Lector de huellas digitales.

La documentación menciona sensores tipo **R307/AS608** como referencia y plantea validar la compatibilidad del lector con el celular.

## Privacidad y seguridad

La documentación plantea almacenar **plantillas/minucias de huella y no imágenes completas**, con acceso restringido. También contempla registrar intentos de acceso y manejar capturas de baja calidad.

## Flujo de trabajo GitHub

Usaremos Issues para tareas concretas y Pull Requests para integrar cambios.

```text
Backlog → To Do → In Progress → Review → Done
```

Convención de ramas:

- `feature/nombre-funcionalidad`
- `fix/nombre-problema`
- `docs/nombre-documentacion`
- `test/nombre-prueba`

La rama `main` se mantendrá estable y los cambios relevantes se integrarán mediante Pull Request.

## Fases

1. Organización y análisis de requisitos
2. Diseño de arquitectura y prototipo
3. Desarrollo de base de datos
4. Desarrollo del módulo biométrico
5. Desarrollo de interfaz
6. Integración
7. Pruebas y corrección
8. Documentación y presentación

## Riesgos identificados

- Calidad de la captura: dedos sucios, húmedos o mal colocados.
- Compatibilidad del lector con el celular.
- Protección de las plantillas de huella.
- Definición del lector físico que se utilizará.
- Decisión definitiva del lenguaje/stack de implementación.

## Estado del proyecto

El repositorio ya cuenta con la estructura de trabajo. El siguiente paso es cerrar requisitos, resolver las decisiones pendientes y convertir el cronograma en tareas ejecutables mediante Issues.

## GitHub

El seguimiento del trabajo se realizará mediante Issues, Pull Requests y GitHub Projects.
