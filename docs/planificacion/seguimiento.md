# Seguimiento

Actualizar esta página durante las reuniones del equipo. Los estados reflejan avances comprobados y acuerdos conocidos; deben revisarse con todos los integrantes.

| Actividad | Estado | Bloqueos o acuerdos |
|---|---|---|
| Actualizar requisitos al reconocimiento facial desde Android | Documentación actualizada | Validar el contenido con el equipo y el docente |
| Confirmar campos del registro de trabajadores | Implementación inicial probada | La API local utiliza CI, nombres y apellidos; validar si se requieren más datos |
| Implementar conexión C# con SQL Server | Completado y probado localmente | Incorporar el proyecto y la configuración de ejemplo al repositorio sin secretos |
| Implementar registro, consulta y modificación de trabajadores | Completado y probado localmente | Código fuente aún pendiente de subir a GitHub |
| Implementar desactivación de trabajadores | Completado y probado localmente | Código fuente aún pendiente de subir a GitHub |
| Implementar registro de entradas y salidas | Completado y probado localmente | Las solicitudes de prueba utilizan CI; no existe verificación facial |
| Implementar historial y consulta general de marcaciones | Completado y probado localmente | Incorporar el código fuente al repositorio |
| Implementar filtro de marcaciones por fecha | Completado y probado localmente | Documentado en la guía de API |
| Implementar reporte por trabajador y periodo | Completado y probado localmente | El reporte cuenta entradas y salidas; no calcula horas ni tardanzas |
| Incorporar backend C# a GitHub | Pendiente | Subir el proyecto a src/backend; excluir secretos y archivos generados |
| Incorporar script de creación de SQL Server | Pendiente | Preparar un script reproducible en src/database |
| Elegir tecnología de la aplicación Android | Pendiente | El equipo debe acordar la tecnología |
| Seleccionar biblioteca y método de reconocimiento facial | Pendiente | Decidir durante el diseño técnico y la programación |
| Definir dónde se procesarán los datos faciales | Pendiente | Teléfono, servidor o combinación |
| Diseñar comunicación segura entre Android y servidor C# | Pendiente | Definir solicitudes, respuestas, autenticación y manejo de errores |
| Implementar autenticación y autorización | Pendiente | Requisito previo al uso con datos reales |
| Integrar Android, reconocimiento facial y servidor | Pendiente | Depende de las decisiones técnicas anteriores |
| Preparar pruebas integrales | Pendiente | Probar el flujo completo cuando exista una versión integrada |

## Acuerdos tecnológicos actuales
- Dispositivo de marcación previsto: teléfono Android compartido.
- Identificación prevista: reconocimiento facial.
- Servidor: C# / ASP.NET Core Web API.
- Base de datos: SQL Server.
- Acceso a datos del backend: Microsoft.Data.SqlClient.

## Alcance de las pruebas realizadas
Las pruebas del backend se realizaron localmente con datos de prueba. Se verificaron operaciones de trabajadores, registro de entrada y salida, historial, consulta general, filtro por fecha y reporte de cantidades por periodo.

Estas pruebas no validan reconocimiento facial, integración Android, despliegue en un servidor ni seguridad para producción. El código fuente del backend y el script SQL todavía deben incorporarse al repositorio.
