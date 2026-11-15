# Arquitectura propuesta

## Componentes principales

### 1. Terminal Android

Teléfono compartido ubicado en la entrada de la empresa. Presenta la interfaz de marcación y utiliza su cámara para iniciar la identificación facial. La tecnología concreta para desarrollar esta aplicación queda pendiente.

### 2. Servidor

El servidor se desarrollará en **C#**. Recibirá las solicitudes del terminal, coordinará las operaciones, aplicará las reglas de asistencia y se comunicará con SQL Server.

### 3. Base de datos

**SQL Server** almacenará los datos básicos de los trabajadores, la información biométrica protegida y las marcaciones de asistencia. El modelo de datos actual debe revisarse y adaptarse al nuevo alcance antes de modificarlo.

### 4. Módulo de reconocimiento facial

Este módulo permitirá enrolar a los trabajadores autorizados y realizar su identificación durante la marcación. La biblioteca, el algoritmo y la ubicación del procesamiento (teléfono, servidor o combinación) se decidirán durante el diseño técnico y la programación.

### 5. Consultas y reportes

El sistema permitirá al personal autorizado consultar las marcaciones y obtener reportes por trabajador y periodo.

## Flujo propuesto de registro de trabajador

```text
Personal autorizado
        |
        v
Registrar datos básicos del trabajador
        |
        v
Realizar enrolamiento facial
        |
        v
Enviar/guardar información mediante el servidor C#
        |
        v
SQL Server conserva los datos necesarios
```

## Flujo propuesto de marcación

```text
Trabajador se acerca al teléfono Android
        |
        v
Inicia la marcación
        |
        v
La cámara obtiene la información facial
        |
        v
Módulo de reconocimiento intenta identificar
        |
        v
¿Identidad confirmada?
   |                  |
  No                 Sí
   |                  |
Mostrar mensaje    Registrar marcación
y no confirmar     con fecha y hora
asistencia             |
                       v
                 Servidor C#
                       |
                       v
                  SQL Server
                       |
                       v
               Mostrar resultado
```

El flujo es conceptual. La forma exacta de enviar los datos, el lugar del procesamiento facial y la regla para distinguir entrada y salida deben definirse antes de la implementación.

## Responsabilidad de cada componente

| Componente | Responsabilidad |
|---|---|
| Terminal Android | Interacción con el trabajador y uso de la cámara |
| Servidor C# | Reglas de negocio, coordinación y acceso a datos |
| Módulo facial | Enrolamiento e identificación |
| SQL Server | Persistencia de trabajadores y asistencias |
| Consultas y reportes | Presentación de información al personal autorizado |

## Decisiones confirmadas

- El dispositivo de marcación será un teléfono Android compartido.
- La identificación prevista será mediante reconocimiento facial.
- El servidor será desarrollado en C#.
- La base de datos será SQL Server.

## Decisiones pendientes

- Tecnología y estructura de la aplicación Android.
- Biblioteca y método de reconocimiento facial.
- Lugar donde se ejecutará el procesamiento biométrico.
- Contratos y mecanismo de comunicación entre Android y el servidor.
- Modelo de datos definitivo y adaptación de las tablas existentes.
- Reglas para registrar entrada y salida.
- Funcionamiento ante pérdida de conexión.
- Medidas concretas de protección, permisos y conservación de datos biométricos.

## Seguridad y privacidad

El acceso a los datos de trabajadores y a la información biométrica debe estar restringido. Se evaluará almacenar representaciones biométricas protegidas en lugar de fotografías completas, siempre que la solución técnica elegida lo permita. No se debe implementar ni publicar el manejo de datos biométricos sin definir previamente su protección y los permisos correspondientes.

## Estado de implementación

Esta arquitectura describe la propuesta del sistema. No confirma que el terminal Android, el servidor, la base de datos o el reconocimiento facial ya estén programados o integrados.
