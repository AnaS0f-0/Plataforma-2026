using UnityEngine;

// Este script va en las trampas del nivel  
// Cuando el jugador las toca recibe daño
 
public class Hazard : MonoBehaviour
{
    // Cuanto daño hace esta trampa
    public int daño = 20;

    // Para que no haga daño muchas veces seguidas
    // Tiempo que hay que esperar entre cada golpe
    public float tiempoEntreGolpes = 1f;

    // Variable interna para contar el tiempo
    private float tiempoUltimoGolpe = 0f;

    void OnTriggerEnter2D(Collider2D otro)
    {
        // Solo reaccionar si lo toca el jugador
        if (!otro.CompareTag("Player")) return;

        AplicarDanio(otro);
    }

    void OnTriggerStay2D(Collider2D otro)
    {
        // Si el jugador sigue adentro, hacerle daño cada cierto tiempo
        if (!otro.CompareTag("Player")) return;

        // Ver si ya paso suficiente tiempo desde el ultimo golpe
        if (Time.time - tiempoUltimoGolpe >= tiempoEntreGolpes)
        {
            AplicarDanio(otro);
        }
    }

    // Funcion que aplica el daño al jugador
    void AplicarDanio(Collider2D otro)
    {
        PlayerStats statsJugador = otro.GetComponent<PlayerStats>();

        if (statsJugador == null) return;
        if (statsJugador.IsDead()) return;

        // Aplicar el daño
        statsJugador.TakeDamage(daño);
        tiempoUltimoGolpe = Time.time;

        Debug.Log("Trampa hizo daño: " + daño);
    }
}
