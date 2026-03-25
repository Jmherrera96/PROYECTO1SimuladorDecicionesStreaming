## PROYECTO: SIMULADOR DE DECISIONES PARA PLATAFORMA DE STREAMING
El programa simula una consola donde el equipo de una plataforma de streaming analiza solicitudes de contenido una por una para decidir qué materiales pueden publicarse semanalmente. El sistema no almacena listas; evalúa cada solicitud en el momento y mantiene estadísticas generales de la sesión.

### Manual de Usuario
Para iniciar se le mostrara un menu con lo siguiente:

"Simulador de Streaming"
1. Evaluar nuevo contenido
2. Ver reglas 
3. Mostrar estadisticas
4. Reiniciar estadisticas
5. Salir
Ingrese opcion:

Para ingresar una opcion el usuario tiene que ingresar el numero de la opcion que quiera escoger. 

#### Opción 1: Ingresar contenido
El usuario ingresara el nombre del contenido que quiera subir; seguido se le pedira el tipo:
  1 para pelicula
  2 para serie
  3 para documental
  4 para evento

Despues se le pedira que ingrese la duracion en minutos del contenido que quiera subir. Se le pedira que ingrese el tipo de contenido que quiere subir: 
  1 para contenido apto para todo publico
  2 para contenido apto para mayores de 13 años
  3 para contenido solo para mayores de 18 años

Se le pedira la hora a la que piensa subir el contenido en formato de 24 horas y de ultimo el nivel de produccion: 
  1 para bajo
  2 para medio
  3 para alto

Despues de esto se le mostrara la desicion tomada al usuario sobre la publicacion de su contenido. Al pasar esta parte se le volvera a mostrar el menu principal.

#### Opcion 2: Ver reglas
Al ingresar esta opcion se le desplegaran todas las normas establecidas para la publicacion de un video, por que seran rechazados y por que se pondran en lista de espera.

#### Opción 3: Mostrar estadísticas
Esta opcion le muestra al usuario todas las estadisticas disponibles sobre las desiciones que se han tomado, cuantos videos se han aceptado, cuantos han sido puestos en espera y cuantos se han rechazado. 

#### Opcion 4: Reiniciar estadísticas
Con esta opcion el usuario vaciara las estadisticas del programa iniciando la cuenta de cero. 

#### Opcion 5: Salir
Esta opcion finalizara el programa.

## Podcasts
- [Podcast 1](https://github.com/user-attachments/assets/d0f143cd-ed16-4a0d-95e2-1de674726b87)
- [Podcast 2](https://github.com/user-attachments/assets/09f93abb-f2b7-4067-bcfe-36c713381460) 
- [Podcast 3](https://github.com/user-attachments/assets/3e2d2e12-cb3d-48d7-860d-d2d02d2b9802) 
- [Podcast 4](https://github.com/user-attachments/assets/a8265b06-b17e-404f-a5a6-b04dace81a08)

## Diagrama de flujos
<details> 
<summary>Funciones de Validación (Horario, Duración y Producción)</summary>
<div align="center">
  <p>
    <img src="Diagramas/FUNCION%20ValidarHorario.png" width="400" alt="Validar Horario">
    <br>
    Diagrama: Validar Horario
  </p>
  <br>
  <p>
    <img src="Diagramas/Funcion%20ValidarDuracion%20.png" width="400" alt="Validar Duración">
    <br>
    Diagrama: Validar Duración
  </p>
  <br>
  <p>
    <img src="Diagramas/Funcion%20ValidarProduccion.png" width="400" alt="Validar Producción">
    <br>
    Diagrama: Validar Producción
  </p>
</div>
</details>

<details>
<summary>Lógica de Impacto y Decisión final</summary>
<div align="center">
  <p>
    <img src="Diagramas/Funcion%20CalcularImpacto.png" width="400" alt="Calcular Impacto">
    <br>
    Diagrama: Calcular Impacto
  </p>
  <br>
  <p>
    <img src="Diagramas/Funcion%20DecisionFinal.png" width="400" alt="Decisión Final">
    <br>
    Diagrama: Decisión Final
  </p>
</div>
</details>

## Casos de Prueba y Errores
<details>
<summary>Tabla de valores de prueba</summary>
<div align="center">
<br></br>
  
| ID | Tipo | Duración | Clasif. | Hora | Prod. | Válido? | Impacto | Decisión |
|:--:|:---:|:---:|:---:|:---:|:---:|:---:|:---:|:---|
| 1 | Pelicula | 120 | Todo público | 12 | Medio | ✅ Sí | Medio | Publicar |
| 2 | Serie | 45 | +13 | 8 | Bajo | ✅ Sí | Bajo | Publicar |
| 3 | Doc. | 90 | +18 | 23 | Alto | ❌ No | - | Rechazado (Horario) |
| 4 | Evento | 240 | +13 | 22 | Medio | ✅ Sí | Medio | Publicar (Ajustes) |
| 5 | Pelicula | 60 | Todo público | 6 | Alto | ✅ Sí | Alto | Enviar a revision |
| 6 | Serie | 20 | +13 | 6 | Bajo | ✅ Sí | Bajo | Publicar (Ajustes) |
| 7 | Doc. | 30 | +18 | 22 | Medio | ✅ Sí | Medio | Publicar (Ajustes) |
| 8 | Evento | 30 | Todo público | 23 | Alto | ✅ Sí | Alto | Enviar a revision |
| 9 | Pelicula | 180 | +13 | 5 | Bajo | ❌ No | - | Rechazado (Horario) |
| 10 | Serie | 200 | +18 | 1 | Medio | ❌ No | - | Rechazado (Duración) |
| 11 | Pelicula | 50 | Todo público | 10 | Bajo | ❌ No | - | Rechazado (Duración) |
| 12 | Doc. | 150 | +18 | 23 | Alto | ❌ No | - | Rechazado (Duración) |
| 13 | Evento | 500 | +13 | 12 | Medio | ❌ No | - | Rechazado (Duración) |
| 14 | Serie | 90 | +18 | 22 | Bajo | ❌ No | - | Rechazado (Prod. Baja) |
| 15 | Pelicula | 180 | +13 | 6 | Bajo | ✅ Sí | Bajo | Publicar (Ajustes) |
| 16 | Doc. | 120 | Todo público | 5 | Alto | ✅ Sí | Alto | Enviar a revision |
| 17 | Evento | 120 | +18 | 5 | Medio | ✅ Sí | Medio | Publicar |
| 18 | Pelicula | 61 | +13 | 21 | Medio | ✅ Sí | Medio | Publicar |
| 19 | Serie | 30 | Todo público | 14 | Medio | ✅ Sí | Medio | Publicar |
| 20 | Doc. | 31 | +13 | 7 | Bajo | ✅ Sí | Bajo | Publicar |

<i>Datos generados por gemini para ver rendimiento del programa</i>
</div>
</details>
