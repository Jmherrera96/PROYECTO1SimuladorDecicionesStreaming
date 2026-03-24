## PROYECTO: SIMULADOR DE DECISIONES PARA PLATAFORMA DE STREAMING

El programa simula una consola donde el equipo de una plataforma de streaming analiza solicitudes de contenido una por una para decidir qué materiales pueden publicarse semanalmente. El sistema no almacena listas; evalúa cada solicitud en el momento y mantiene estadísticas generales de la sesión.

### Requisitos Técnicos
* Implementación de estructuras `switch`, `do-while`, `while`, `for`, `if/else` encadenados e `if` anidados.
* Organización del código en funciones.
* Prohibición del uso de arreglos o listas.

## Funcionamiento y Menú
El sistema debe integrarse en C# y presentar las siguientes opciones:
* **Evaluar nuevo contenido:** Solicita tipo (película, serie, documental, evento en vivo), duración, clasificación (todo público, +13, +18), hora programada y nivel de producción.
* **Mostrar reglas del sistema:** Describe las reglas obligatorias de validación técnica.
* **Mostrar estadísticas:** Incluye total de evaluados, publicados, rechazados, en revisión, impacto predominante y porcentaje de aprobación.
* **Reiniciar estadísticas**.
* **Salir:** Muestra un resumen final de la sesión.

### Reglas de Validación y Decisión
1. **Validación Técnica:** Verifica que la duración coincida con el tipo de contenido (ej. Película: 60-180 min) y que la clasificación sea apta para el horario (ej. +18: entre 22 y 5 horas).
2. **Impacto:** Determina si el contenido es de impacto Bajo, Medio o Alto según su producción, duración oprime time.
3. **Decisión Final:** El sistema dictamina entre Publicar, Publicar con ajustes, Enviar a revisión o Rechazar, mostrando siempre la razón del resultado.

# Diagrama de flujo Principal

<img width="4520" height="8192" alt="Evaluación de Contenido y-2026-03-24-013711" src="https://github.com/user-attachments/assets/f5ad37f4-e6a6-40f1-a5cd-4c3c9f96de69" />

##  Diagramas de flujo individual

<details>
<summary>📸 Ver Flujo Principal</summary>
<p align="center">
<img src="Diagramas/FLUJO%20PRINCIPAL%20–%20SIMULADOR%20DE%20STREAMING.png" width="400" alt="Flujo Principal">
</p>
</details>

<details>
<summary>📸 Ver Subflujo: Evaluar Contenido</summary>
<p align="center">
<img src="Diagramas/SUBFLUJO%20EVALUAR%20CONTENIDO-opción1.png" width="400" alt="Evaluar Contenido">
</p>
</details>

<details>
<summary>⚙️ Ver Funciones de Validación (Horario, Duración y Producción)</summary>
<p align="center">
<img src="Diagramas/FUNCION%20ValidarHorario.png" width="350" alt="Validar Horario">
<img src="Diagramas/Funcion%20ValidarDuracion%20.png" width="350" alt="Validar Duración">
<img src="Diagramas/Funcion%20ValidarProduccion.png" width="350" alt="Validar Producción">
</p>
</details>

<details>
<summary>📊 Ver Lógica de Impacto y Decisión Final</summary>
<p align="center">
<img src="Diagramas/Funcion%20CalcularImpacto.png" width="350" alt="Calcular Impacto">
<img src="Diagramas/Funcion%20DecisionFinal.png" width="350" alt="Decisión Final">
<img src="Diagramas/Flujo%20final.png" width="350" alt="Flujo Final">
</p>
</details>

# Podcasts 
