# Requisitos del sistema

## Objetivo

Desarrollar una aplicación móvil de identificación biométrica por huella digital que permita identificar usuarios registrados y registrar los accesos.

## Requisitos funcionales iniciales

### RF-01 — Inicio del sistema
La aplicación debe iniciar y preparar el sistema de reconocimiento.

### RF-02 — Activación del lector
El sistema debe activar/habilitar el lector de huellas y el reconocimiento.

### RF-03 — Captura de huella
El sistema debe solicitar al usuario colocar el dedo y capturar la huella.

### RF-04 — Validación de calidad
El sistema debe verificar si la captura tiene calidad suficiente. Si falla, debe mostrar un mensaje y permitir repetir la captura.

### RF-05 — Procesamiento
El sistema debe procesar la huella capturada y extraer minucias, incluyendo terminaciones y bifurcaciones de las crestas.

### RF-06 — Comparación
El sistema debe comparar la plantilla de la huella con las plantillas almacenadas.

### RF-07 — Usuario no registrado
Si no existe coincidencia, el sistema debe mostrar “Usuario no Registrado”, registrar el intento y permitir una nueva captura.

### RF-08 — Identificación confirmada
Si existe coincidencia, el sistema debe reconocer al usuario y recuperar sus datos.

### RF-09 — Registro de acceso
El sistema debe registrar la identificación/acceso en la base de datos.

### RF-10 — Resultado
El sistema debe mostrar “Identidad confirmada, acceso permitido” cuando la identificación sea exitosa.

## Requisitos no funcionales iniciales

### RNF-01 — Tiempo
El proceso de identificación debe tener como objetivo no superar 1 minuto.

### RNF-02 — Seguridad y privacidad
Se plantea almacenar plantillas/minucias de la huella y no imágenes completas, con acceso restringido.

### RNF-03 — Usabilidad
La interfaz móvil debe ser sencilla, táctil y práctica para los administradores.

### RNF-04 — Disponibilidad de conexión
La documentación plantea que el sistema funcione en el dispositivo móvil y no dependa totalmente de internet.

### RNF-05 — Calidad de captura
El sistema debe proporcionar mensajes de guía cuando el dedo esté sucio, húmedo o mal colocado.

## Datos que debe manejar el sistema

- Usuarios registrados.
- Plantillas de huella/minucias.
- Registros de acceso.
- Intentos de identificación.

## Criterios de validación iniciales

- Una huella válida permite continuar con el procesamiento.
- Una captura de baja calidad permite repetir el proceso.
- Una huella no registrada genera el resultado correspondiente y registra el intento.
- Una huella registrada permite recuperar al usuario y registrar el acceso.
- El flujo completo debe apuntar a un tiempo inferior a 1 minuto.

## Pendientes

- Definir campos exactos de usuarios.
- Definir estructura de registros de acceso.
- Definir mecanismo concreto de almacenamiento/protección de plantillas.
- Definir lector físico.
- Confirmar lenguaje y stack: Python o C#.
- Confirmar composición final del equipo y responsables nominales.
