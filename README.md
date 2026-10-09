## Mecánicas Principales

* **Movimiento y Plataformas Móviles (`PlayerMovement`):** 
  * Desplazamiento fluido en entornos 3D utilizando físicas basadas en `Rigidbody` (`linearVelocity`).
  * Sistema de emparentamiento dinámico (`transform.SetParent`) que permite al jugador viajar de forma sincronizada sobre plataformas móviles.
* **Sistema de Doble Salto Temporal (`DoubleJumpPowerUp`):**
  * El personaje comienza el juego con un único salto básico por defecto.
  * Al recolectar un power-up especial temporal, se desbloquea la capacidad de dar un segundo salto en el aire (`fuerzaDoble`) gestionado mediante corrutinas con tiempos configurables.
* **Power-Up de Velocidad (`SpeedBoost`):**
  * Ítems coleccionables repartidos por el nivel que incrementan temporalmente la velocidad de caminata del jugador antes de restablecerla de forma automática.
* **Generador de Proyectiles con Rango Aleatorio (`SpawnerRangoZMovimientoX` y `MovimientoLinealX`):**
  * Spawners automáticos que instancian proyectiles (piedras/obstáculos) variando su posición de manera aleatoria a lo largo del **eje Z**.
  * Los proyectiles se trasladan de forma lineal y constante a lo largo del **eje X** utilizando un script independiente de movimiento y un sistema de autodestrucción por tiempo de vida (`vidaUtil`) para optimizar el rendimiento de la escena.




---

## Requisitos Técnicos y Configuración

* **Versión de Unity:** Compatible con Unity 6 (o versiones que utilicen físicas con `Rigidbody.linearVelocity`).
* **Tags obligatorios en el proyecto:**
  * `Player`: Asignado al GameObject del personaje principal.
  * `Plataforma`: Asignado a las superficies móviles del nivel.

---

##  Controles del Teclado

| Acción | Tecla / Control |
| :--- | :--- |
| **Moverse** | Teclas `W`, `A`, `S`, `D` o Flechas Direccionales |
| **Saltar** | Barra Espaciadora (`Space`) |
| **Doble Salto** | Presionar Espacio dos veces en el aire *(Requiere tener el Power-Up activo)* |

---

##  Arquitectura de Scripts Principales

* **`PlayerMovement.cs`**: Gestiona los ejes de movimiento, las restricciones físicas de rotación, la detección de suelo mediante normales de colisión, el emparentamiento con plataformas y la lógica de conteo de saltos.
* **`SpawnerRangoZMovimientoX.cs`**: Controla mediante corrutinas (`IEnumerator`) la generación en bucle de proyectiles en intervalos de tiempo configurables, aplicando variaciones aleatorias en el eje Z.
* **`MovimientoLinealX.cs`**: Asignado al prefab del proyectil para imprimirle velocidad constante en el eje X y asegurar su limpieza en memoria mediante un temporizador de destrucción.
* **`DoubleJumpPowerUp.cs` / `SpeedBoost.cs`**: Scripts de interacción coleccionable que modifican de manera temporal los atributos del jugador mediante temporizadores internos.