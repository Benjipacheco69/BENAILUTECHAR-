# Cuestionario de aprobación del proyecto — Benailu Tech

**Responsable:** Benji Pacheco Lafuente  
**Proyecto:** Aplicación móvil de identificación biométrica mediante huella digital  
**Propósito:** Auditoría de preparación para iniciar el desarrollo.

## 1. Problema y valor

**1. ¿Pueden explicar el problema en menos de 30 segundos sin mencionar ninguna tecnología?**

Sí. Identificar personas y controlar sus accesos puede ser lento y presentar riesgos de suplantación de identidad. Benailu Tech busca facilitar la identificación de personas autorizadas y mantener un registro de sus accesos de manera rápida y segura.

**2. ¿Quién tiene el problema y quién utilizará la solución?**

El problema afecta a instituciones que necesitan controlar el acceso de personas. Los usuarios serán las personas registradas, el personal administrativo y de seguridad encargado de verificar identidades, y las instituciones que gestionan los accesos.

**3. ¿Qué evidencia demuestra que el problema es real, relevante o necesario?**

La necesidad se fundamenta en los riesgos de suplantación de identidad y en la importancia de controlar los accesos. Todavía debemos reunir encuestas, entrevistas o datos concretos que demuestren la magnitud del problema en las instituciones a las que nos dirigimos.

**4. ¿Qué consecuencias tiene actualmente ese problema?**

Puede generar accesos no autorizados, suplantación de identidad, demoras en la identificación y dificultades para consultar el historial de entradas y salidas.

**5. ¿Qué valor concreto aportará su solución al usuario?**

Permitirá identificar usuarios registrados mediante su huella digital, facilitar el control de acceso y guardar registros de identificación, con un tiempo objetivo inferior a un minuto.

**6. ¿Pueden explicar claramente por qué su solución es una respuesta adecuada al problema y no simplemente una aplicación interesante?**

Sí. Sus funciones responden directamente a la necesidad de verificar identidades, reducir riesgos de suplantación y mantener registros de acceso. No se limita a mostrar información, sino que busca resolver un problema concreto de seguridad.

## 2. Objetivos y éxito

**7. ¿El objetivo general describe un resultado concreto que puede comprobarse?**

Sí. El objetivo general es desarrollar una aplicación móvil que identifique usuarios registrados mediante huella digital y registre sus accesos. Se podrá comprobar mediante pruebas de identificación y registro.

**8. ¿Los objetivos específicos permiten dividir y comprobar el avance hacia ese resultado?**

Sí. Se dividen en diseñar la interfaz, configurar el lector, capturar y validar huellas, procesarlas, compararlas con las registradas, gestionar la base de datos y realizar pruebas.

**9. ¿Existe una relación clara entre problema, objetivos, solución y resultados esperados?**

Sí. El problema es la dificultad de identificar personas de forma segura; el objetivo es facilitar esa identificación; la solución es una aplicación móvil biométrica; y el resultado esperado es un control de acceso más ágil y verificable.

**10. ¿Cómo sabrán al final del proyecto que realmente tuvieron éxito?**

Cuando el sistema identifique correctamente a los usuarios registrados, rechace las huellas sin coincidencia, permita repetir capturas inválidas, registre los intentos y cumpla el tiempo objetivo inferior a un minuto.

## 3. Usuarios y requisitos

**11. ¿Los usuarios y sus necesidades están suficientemente definidos para determinar qué debe hacer el sistema?**

Parcialmente. Se identifican usuarios registrados, personal administrativo o de seguridad e instituciones. Falta precisar sus necesidades mediante entrevistas y definir sus permisos específicos.

**12. ¿Las funcionalidades principales están directamente relacionadas con necesidades reales de los usuarios?**

Sí. La captura de huellas, la identificación, la consulta de usuarios y el registro de accesos responden a la necesidad de controlar quién puede ingresar.

**13. ¿Las funcionalidades principales están suficientemente descritas para que otro integrante pueda comenzar a desarrollarlas sin tener que adivinar qué deben hacer?**

Parcialmente. El repositorio contiene requisitos funcionales iniciales y describe el flujo de identificación. Todavía faltan detalles de implementación, estructuras de datos y decisiones técnicas definitivas.

**14. ¿Cada funcionalidad principal tiene criterios de aceptación verificables?**

Sí, de manera inicial. Se establece que una huella válida debe procesarse, una captura de baja calidad debe poder repetirse, una huella no registrada debe generar un aviso y una reconocida debe permitir recuperar los datos y registrar el acceso. Falta definir pruebas más específicas.

**15. ¿Existen requisitos de calidad además de las funcionalidades, como seguridad, rendimiento, disponibilidad, facilidad de uso o compatibilidad?**

Sí. Se contemplan seguridad y privacidad de los datos biométricos, facilidad de uso, calidad de captura, funcionamiento sin dependencia total de internet y un tiempo objetivo de identificación inferior a un minuto.

## 4. Alcance

**16. ¿Está claramente definido qué desarrollará el equipo?**

Sí. Se desarrollará una aplicación móvil con interfaz de usuario, reconocimiento de huellas digitales, base de datos de usuarios y plantillas biométricas, registro de accesos e identificación de usuarios registrados.

**17. ¿Está claramente definido qué NO desarrollará?**

Todavía no completamente. Se debe delimitar expresamente qué funciones quedarán fuera del proyecto, como la integración con sistemas externos de otras instituciones o funcionalidades adicionales que no sean necesarias para la identificación.

**18. ¿Han identificado funcionalidades que podrían parecer interesantes pero que no son necesarias para cumplir el objetivo?**

Sí. Se pueden dejar para futuras versiones las estadísticas avanzadas, los reportes personalizados, la integración con otros sistemas y la administración de múltiples instituciones. La primera versión debe priorizar la identificación y el registro de accesos.

**19. ¿El alcance es realista considerando el tiempo, conocimientos y recursos disponibles?**

Es viable como prototipo académico si se limita a las funciones esenciales. Sin embargo, depende de seleccionar un lector compatible, confirmar el lenguaje de programación y resolver los aspectos de almacenamiento y protección de los datos biométricos.

**20. Si tuvieran que reducir el proyecto un 40 %, ¿qué conservarían y qué eliminarían?**

Conservaríamos la captura y validación de huellas, la comparación con usuarios registrados, los resultados de identificación y el registro de accesos. Reduciríamos los reportes adicionales, las funciones administrativas secundarias y las integraciones externas.

## 5. MVP (Producto mínimo viable)

**21. ¿Existe una primera versión funcional claramente definida?**

Sí, a nivel de planificación. El MVP contempla una aplicación que capture una huella, compruebe su calidad, la compare con las plantillas registradas, muestre el resultado y guarde el intento. Su implementación todavía está pendiente.

**22. ¿El MVP resuelve una parte real del problema y entrega valor al usuario?**

Sí. Permitirá comprobar la identidad de usuarios registrados y llevar un control básico de los accesos, que son las necesidades principales del proyecto.

**23. ¿El MVP puede estar terminado dentro del tiempo disponible?**

Se prevé que sí, si se respetan las funcionalidades esenciales y el cronograma de octubre a diciembre de 2026. No obstante, es necesario confirmar la compatibilidad del lector y resolver las decisiones técnicas pendientes para asegurar su viabilidad.

**24. ¿Las funcionalidades posteriores están claramente separadas del MVP?**

Parcialmente. Se pueden identificar como futuras mejoras los reportes avanzados, las integraciones externas y las funciones administrativas adicionales, pero todavía falta documentar formalmente esa separación.

## 6. Diseño y viabilidad técnica

**25. ¿La solución propuesta es técnicamente viable con las tecnologías, conocimientos y recursos que tiene el equipo?**

Sí, en principio. El proyecto contempla una computadora, un teléfono móvil y un lector de huellas digitales. La documentación menciona tecnologías que todavía deben confirmarse. Antes de desarrollar, el equipo debe decidir el lenguaje, el lector compatible, la base de datos y el mecanismo de protección de las plantillas biométricas.

**26. ¿Han identificado las partes técnicamente más difíciles o inciertas del proyecto?**

Sí. Las partes más difíciles son la captura y comparación de huellas digitales, la compatibilidad del lector con el dispositivo móvil y la protección de los datos biométricos.

**27. ¿Han validado, o tienen previsto validar antes de depender de ellas, las tecnologías o integraciones críticas?**

Todavía no se han validado completamente. Tenemos previsto probar el lector, comprobar su compatibilidad y evaluar las tecnologías antes de utilizarlas en el desarrollo definitivo.

**28. ¿Las principales decisiones tecnológicas tienen una justificación relacionada con las necesidades del proyecto?**

Sí, inicialmente. Se consideran tecnologías para procesar huellas, gestionar usuarios y almacenar registros. Sin embargo, debemos confirmar las tecnologías definitivas y justificar su elección según la compatibilidad, seguridad y recursos del equipo.

**29. ¿Han identificado las dependencias externas necesarias para construir y ejecutar el sistema?**

Sí. Necesitamos un lector de huellas compatible, sus controladores o SDK, las herramientas de desarrollo y una base de datos. También debemos confirmar la compatibilidad con el dispositivo móvil.

**30. ¿La solución tiene una estructura técnica inicial suficientemente clara para comenzar el desarrollo?**

Sí, contamos con una arquitectura inicial dividida en interfaz móvil, módulo biométrico, base de datos, integración y pruebas. Falta definir algunas decisiones técnicas antes de implementarla.

## 7. Datos, seguridad y calidad

**31. ¿Han identificado qué información manejará el sistema y de dónde provendrá?**

Sí. El sistema manejará datos de usuarios registrados, plantillas de huellas digitales, intentos de identificación y registros de acceso. La información provendrá del registro de usuarios y de las capturas realizadas durante la identificación.

**32. ¿Han identificado restricciones importantes relacionadas con datos, privacidad, seguridad, permisos o acceso?**

Sí. Debemos proteger los datos biométricos, restringir el acceso a la información y evitar almacenar imágenes completas de las huellas cuando sea posible utilizar plantillas biométricas protegidas.

**33. ¿Han definido cómo comprobarán que las funcionalidades principales funcionan correctamente?**

Sí, de manera inicial. Realizaremos pruebas con huellas registradas y no registradas, capturas de baja calidad y registros de acceso para comprobar que el sistema responda correctamente.

**34. ¿Existe una estrategia inicial de pruebas que acompañará el desarrollo?**

Sí. Contemplamos pruebas unitarias, de integración y de funcionamiento completo, además de comprobar la seguridad, los errores de captura y el tiempo de identificación.

## 8. Plan de desarrollo

**35. ¿El Gantt está compuesto por tareas concretas que realmente habrá que ejecutar?**

Sí. Incluye análisis de requisitos, diseño de arquitectura e interfaz, desarrollo de la base de datos y del módulo biométrico, integración, pruebas y documentación.

**36. ¿Cada tarea tiene responsable?**

Sí, el cronograma asigna responsables por áreas, como base de datos, reconocimiento de huellas, interfaz y tareas compartidas. Todavía debemos confirmar la asignación definitiva de algunas responsabilidades individuales.

**37. ¿Las tareas tienen estimaciones razonables?**

Sí, contamos con fechas tentativas entre octubre y diciembre de 2026. Sin embargo, tendremos que ajustar las estimaciones según los avances y las dificultades técnicas que encontremos.

**38. ¿Las dependencias entre tareas están identificadas?**

Parcialmente. Sabemos que la integración depende del avance de los módulos y que las pruebas requieren funcionalidades desarrolladas. Falta documentar con mayor precisión las dependencias entre todas las tareas.

**39. ¿El Gantt contempla desarrollo, integración, pruebas, correcciones y documentación?**

Sí. El cronograma contempla el desarrollo de los módulos, su integración, las pruebas y correcciones de errores, y la documentación y presentación final.

**40. ¿Han identificado qué tareas podrían bloquear al resto del equipo?**

Sí. La selección del lector, la confirmación de las tecnologías y el desarrollo del módulo de reconocimiento pueden retrasar la integración y las pruebas si no se resuelven a tiempo.

## 9. Equipo y riesgos

**41. ¿Cada integrante tiene una responsabilidad concreta y verificable?**

Sí, existen roles previstos para liderazgo y base de datos, reconocimiento de huellas, interfaz y pruebas. Debemos terminar de confirmar las responsabilidades individuales y los entregables de cada integrante.

**42. ¿El equipo tiene un mecanismo acordado para revisar e integrar el trabajo?**

Contamos con un repositorio compartido en GitHub para organizar la documentación y el trabajo. Debemos establecer o confirmar un procedimiento de revisión de cambios, integración del código y resolución de conflictos.

**43. ¿Cuáles son los tres riesgos que más podrían hacer fracasar o retrasar el proyecto?**

Los tres principales riesgos son la incompatibilidad del lector de huellas, las dificultades para conseguir una identificación biométrica confiable y los retrasos por no definir a tiempo las tecnologías y la arquitectura.

**44. ¿Cada uno de esos riesgos tiene una estrategia de mitigación?**

Sí, de manera inicial. Probaremos el lector antes de integrarlo, realizaremos pruebas con diferentes capturas y definiremos las decisiones tecnológicas lo antes posible para reducir retrasos.

**45. ¿Qué harían si una persona clave del equipo deja de estar disponible?**

Distribuiríamos sus tareas entre los demás integrantes, utilizando la documentación del repositorio para facilitar la continuidad. Para reducir el impacto, procuraremos documentar el código, las decisiones y el avance de cada módulo.

## 10. Preparación para desarrollar

**46. ¿Existe actualmente alguna decisión fundamental que todavía no hayan tomado y que pueda bloquear el inicio del desarrollo?**

Sí. Debemos confirmar el lenguaje de programación, seleccionar el lector de huellas y definir la base de datos y la forma de comunicación entre el lector y la aplicación móvil.

**47. ¿Existe algún requisito importante que todavía no comprendan suficientemente?**

Sí. Necesitamos precisar cómo se realizará la comparación biométrica, cómo se protegerán las plantillas y cómo se conectará el lector con la aplicación móvil.

**48. ¿Existe alguna dependencia técnica, información, permiso, acceso, herramienta o recurso que todavía no tengan y que sea necesario para comenzar?**

Debemos confirmar la disponibilidad del lector físico, sus controladores o SDK y las herramientas compatibles con la tecnología elegida. También debemos definir la estructura definitiva de la base de datos.

**49. Si mañana tuvieran que comenzar a programar, ¿cada integrante sabría exactamente qué debe construir primero?**

Parcialmente. Los roles generales están definidos, pero antes de comenzar necesitamos confirmar las tecnologías, dividir las funcionalidades en tareas concretas y asignar entregables individuales.

**50. Si un nuevo integrante entrara mañana y solo revisara el repositorio, ¿podría comprender qué problema están resolviendo, qué van a construir, cuál es el MVP y qué trabajo debe realizarse a continuación?**

Sí, podría comprender el problema, la solución propuesta y las funcionalidades principales gracias al README y la documentación. Sin embargo, necesitaría revisar las decisiones pendientes y las tareas específicas para saber exactamente qué implementar.

## 11. Prueba de fracaso

**51. ¿Qué tendría que ser cierto para que este proyecto fracase?**

El proyecto podría fracasar si el lector no fuera compatible, si el reconocimiento no fuera confiable, si los datos biométricos no estuvieran protegidos o si el equipo no lograra completar las funcionalidades principales dentro del plazo establecido.

**52. ¿Ya tienen una estrategia para evitar o controlar cada una de esas condiciones?**

Tenemos estrategias iniciales: probar el lector anticipadamente, validar el reconocimiento con diferentes casos, proteger las plantillas biométricas, distribuir las tareas y realizar pruebas periódicas. Debemos concretar estas medidas en un plan de trabajo y seguimiento.

**Repositorio:** [BENAILUTECHAR-](https://github.com/Benjipacheco69/BENAILUTECHAR-)
