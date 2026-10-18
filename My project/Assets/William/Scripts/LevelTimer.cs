using UnityEngine;

// Este script lleva la cuenta regresiva del nivel
 
public class LevelTimer : MonoBehaviour
{
    // Tiempo total del nivel en segundos
    public float tiempoTotal = 120f;

    // Tiempo restante
    private float tiempoRestante;

    // Para que el aviso de poco tiempo solo salga una vez
    private bool avisoMostrado = false;

    // Cuantos segundos quedan para mostrar el aviso
    public float segundosAviso = 10f;

    void Start()
    {
        tiempoRestante = tiempoTotal;
    }

    void Update()
    {
        // Si el juego no esta activo no contar
        if (GameManager.instance == null) return;
        if (!GameManager.instance.juegoActivo) return;

        // Bajar el tiempo
        tiempoRestante -= Time.deltaTime;

        // Sincronizar con el GameManager
        GameManager.instance.tiempo = tiempoRestante;

        // Aviso cuando quedan pocos segundos
        if (!avisoMostrado && tiempoRestante <= segundosAviso)
        {
            avisoMostrado = true;
            Debug.Log("Quedan pocos segundos!");
        }

        // Si llego a 0 el jugador pierde
        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            Debug.Log("Se acabo el tiempo");
            GameManager.instance.OnPlayerLose();
        }
    }
}
