using UnityEngine;

// Este script va en los items del nivel  


public class PowerUp : MonoBehaviour
{
    // Tipo de efecto que aplica este item
    public string tipo = "puntos"; // puede ser: "puntos", "vida", "escudo"

    // Cuantos puntos vale (si tipo es "puntos")
    public int valorPuntos = 10;

    // Cuanta vida restaura (si tipo es "vida")
    public int cantidadVida = 30;

    // Cuanto tiempo dura el escudo (si tipo es "escudo")
    public float duracionEscudo = 5f;

    // Cuantos golpes aguanta el escudo (si tipo es "escudo")
    public int golpesEscudo = 1;

    void OnTriggerEnter2D(Collider2D otro)
    {
        // Solo reaccionar si lo toca el jugador
        if (!otro.CompareTag("Player")) return;

        // Buscar el script de vida en el jugador
        PlayerStats statsJugador = otro.GetComponent<PlayerStats>();

        // Aplicar el efecto segun el tipo
        if (tipo == "vida")
        {
            if (statsJugador != null)
                statsJugador.Heal(cantidadVida);

            Debug.Log("PowerUp: vida restaurada");
        }
        else if (tipo == "escudo")
        {
            if (statsJugador != null)
                statsJugador.ActivateShield(duracionEscudo, golpesEscudo);

            Debug.Log("PowerUp: escudo activado");
        }
        else if (tipo == "puntos")
        {
          
            Debug.Log("PowerUp: puntos");
        }

        // Destruir el item despues de recogerlo
        Destroy(gameObject);
    }
}
