# Proyecto y planificación

## Identificación

- **Proyecto:** Benailu Tech
- **Sistema:** identificación biométrica por huella digital en una aplicación móvil.
- **Materia:** Programación II
- **Carrera:** Ingeniería en Sistemas
- **Universidad:** Universidad Privada Franz Tamayo
- **Docente:** Ing. Diego Patrick Cardenas Sejas
- **Ubicación indicada en el documento:** Cochabamba, Bolivia.

## Descripción

El proyecto plantea una forma de identificación mediante tecnologías biométricas de reconocimiento de huella digital. El objetivo es facilitar y acelerar el registro/identificación de personas y fortalecer la seguridad frente a la suplantación de identidad.

## Usuarios finales

La documentación identifica como usuarios finales:

- **Usuarios registrados:** personas autorizadas que acceden mediante huella digital.
- **Personal administrativo/de seguridad:** gestiona accesos y verifica identidades mediante registros.
- **Instituciones:** buscan mejorar seguridad, reducir costos operativos y fortalecer la confianza.

## Gantt

Consulta el [Gantt completo](GANTT.md), con el diagrama y el detalle de fechas/responsables.

## Cronograma tentativo

| Actividad | Inicio | Fin | Responsable |
|---|---|---|---|
| Análisis de requisitos | 05/10/2026 | 16/10/2026 | Todos |
| Diseño de arquitectura y prototipo de interfaz | 12/10/2026 | 30/10/2026 | Interfaz |
| Base de datos (usuarios y registros de acceso) | 19/10/2026 | 06/11/2026 | Líder / BD |
| Módulo de huella digital (lector y comparación) | 19/10/2026 | 13/11/2026 | Huella |
| Interfaz móvil y pantalla de resultados | 26/10/2026 | 20/11/2026 | Interfaz |
| Integración de módulos | 16/11/2026 | 27/11/2026 | Todos |
| Pruebas y corrección de errores | 23/11/2026 | 04/12/2026 | Interfaz |
| Documentación y presentación final | 30/11/2026 | 11/12/2026 | Todos |

## Recursos

### Hardware

- Computadora o laptop.
- Teléfono celular.
- Internet.
- Lector de huellas digitales.

### Software y librerías mencionadas

- Python.
- SDK del lector.
- OpenCV.
- NumPy.
- pyfingerprint para sensores tipo R307/AS608.

## Decisión tecnológica pendiente

Existe una diferencia entre los materiales recibidos:

- El documento académico concluye que **Python** es la tecnología más adecuada para el desarrollo inicial y evolución futura.
- La presentación indica que el sistema estará desarrollado en **C#**.

Esta decisión debe confirmarse con el equipo/docente antes de implementar la estructura definitiva del código.

## Riesgos

- Calidad de la captura.
- Compatibilidad del lector con el celular.
- Protección de las plantillas.
- Selección del lector de huellas.

## Próximos pasos indicados

1. Definir el lector de huellas a utilizar.
2. Cerrar requisitos.
3. Cerrar arquitectura.
4. Iniciar la base de datos.
5. Iniciar el módulo de huella.
6. Avanzar con interfaz, integración, pruebas y documentación según el Gantt.
