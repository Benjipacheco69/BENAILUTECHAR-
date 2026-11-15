# Visión y alcance

## Visión

Benailu Tech propone un sistema de control de asistencia mediante reconocimiento facial. Se utilizará un teléfono Android compartido, ubicado en la entrada de la empresa, como terminal para que los trabajadores registren su asistencia. Un servidor desarrollado en C# gestionará las operaciones y SQL Server almacenará los datos.

## Problema

Los registros manuales de asistencia pueden requerir tiempo y dificultar la consulta ordenada de entradas y salidas. El proyecto busca centralizar las marcaciones y facilitar la identificación de los trabajadores mediante reconocimiento facial.

## Usuarios objetivo

- **Trabajadores:** utilizan el teléfono Android compartido para registrar su entrada o salida.
- **Personal administrativo autorizado:** registra y administra los datos de trabajadores y consulta las asistencias.
- **Responsables de la empresa:** revisan los registros y reportes para el control de asistencia.

## Funcionamiento general

1. El personal autorizado registra los datos básicos del trabajador.
2. Se realiza el enrolamiento facial del trabajador.
3. El trabajador utiliza el teléfono Android ubicado en la entrada.
4. El sistema realiza la identificación facial.
5. Si se confirma la identidad, se registra la marcación con fecha y hora.
6. El servidor C# gestiona la operación y SQL Server conserva los datos.
7. El personal autorizado consulta las asistencias y los reportes.

La regla que determinará si una marcación corresponde a entrada o salida debe acordarse antes de implementar el sistema.

## Funcionalidades contempladas

- Registro de trabajadores y sus datos básicos.
- Enrolamiento facial de trabajadores autorizados.
- Identificación facial desde el teléfono Android compartido.
- Registro de entrada y salida con fecha y hora.
- Consulta de historial de asistencia.
- Reportes básicos por trabajador y periodo.
- Mensajes cuando no se logra identificar a una persona o existe un problema de conexión.

## Alcance y límites

El servidor se desarrollará en C# y la base de datos será SQL Server. La tecnología concreta de la aplicación Android, la biblioteca y el algoritmo de reconocimiento facial, la ubicación del procesamiento biométrico y el mecanismo de comunicación entre el teléfono y el servidor quedan pendientes de diseño.

El proyecto no contempla como dispositivo principal un lector físico de huellas. El reconocimiento facial está propuesto, pero todavía no se encuentra implementado. Las funcionalidades descritas representan el alcance previsto y deberán validarse mediante pruebas.

## Privacidad

Los datos faciales requieren protección especial. Se debe restringir su acceso, proteger su almacenamiento y evaluar alternativas que no requieran conservar fotografías completas. Los detalles técnicos y las autorizaciones necesarias se definirán antes del enrolamiento y la programación.

## Documentos relacionados

- [Requisitos](requisitos.md)
- [Arquitectura](arquitectura.md)
- [Planificación](planificacion/planificacion.md)
