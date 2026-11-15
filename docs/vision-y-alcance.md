# Visión y alcance

## Visión
Benailu Tech propone una aplicación móvil de identificación biométrica mediante huella digital para identificar usuarios registrados y registrar accesos.

## Problema
Los procesos manuales de identificación pueden ser lentos y menos confiables. El proyecto plantea agilizar la verificación mediante reconocimiento de huellas.

## Usuarios objetivo
- Usuarios registrados.
- Personal administrativo o de seguridad.
- Instituciones que necesitan controlar el ingreso.

## Funcionalidades contempladas
1. Iniciar la aplicación y preparar el lector.
2. Capturar la huella.
3. Validar la calidad de captura.
4. Procesar la huella y extraer minucias.
5. Comparar con plantillas registradas.
6. Informar si existe coincidencia.
7. Registrar intento o acceso.
8. Mostrar el resultado.

## Límites y pendientes
La documentación aún no confirma enrolamiento, reportes avanzados ni sincronización externa. Deben definirse el lector, la compatibilidad móvil, el lenguaje (Python o C#), el motor de base de datos y la protección de plantillas.

Estas funciones describen el alcance propuesto, no necesariamente lo implementado.

## Documentos relacionados
- [Requisitos](requisitos.md)
- [Arquitectura](arquitectura.md)
- [Planificación](planificacion/planificacion.md)
