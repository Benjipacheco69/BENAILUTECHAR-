# Arquitectura inicial

## Flujo lógico

```text
Inicio
  ↓
Iniciar aplicación móvil
  ↓
Activar lector / reconocimiento
  ↓
Capturar huella
  ↓
¿Calidad válida?
  ├─ No → Mostrar mensaje → Repetir captura
  └─ Sí
       ↓
Procesar huella
       ↓
Extraer minucias
       ↓
Comparar con plantillas almacenadas
       ↓
¿Huella registrada?
  ├─ No → Mostrar "Usuario no Registrado"
  │       → Registrar intento
  │       → Volver a capturar
  └─ Sí → Recuperar datos del usuario
          → Registrar identificación
          → Mostrar "Identidad confirmada, acceso permitido"
          → Volver a pantalla principal
```

## Módulos previstos

### 1. Interfaz móvil
Responsable de iniciar el flujo, solicitar la captura y mostrar resultados.

### 2. Módulo biométrico
Responsable de comunicarse con el lector, capturar la huella, procesarla, extraer minucias y realizar la comparación.

### 3. Base de datos
Responsable de usuarios, plantillas y registros de acceso.

### 4. Integración
Conecta interfaz, módulo biométrico y persistencia.

### 5. Pruebas
Valida captura, identificación, registros, errores y tiempos del flujo.

## Decisiones pendientes

- Lenguaje/plataforma definitiva: Python aparece como recomendación en el documento académico; C# aparece en la presentación.
- Modelo de comunicación entre aplicación móvil y lector.
- Tipo y modelo definitivo del lector.
- Motor/base de datos concreta.
- Estrategia de protección de plantillas.
- Arquitectura final de despliegue.

No se deben cerrar estas decisiones como definitivas hasta confirmarlas con el equipo y/o docente.
