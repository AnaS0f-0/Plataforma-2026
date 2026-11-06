using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public float alturaMinima = -20f;

    private PlayerStats statsJugador;
    private bool yaDetectoLaCaida = false;

    void Start()
    {
        statsJugador = GetComponent<PlayerStats>();
        yaDetectoLaCaida = false;
    }

    void Update()
    {
        if (transform.position.y < alturaMinima && !yaDetectoLaCaida)
        {
            yaDetectoLaCaida = true;
            DetectarCaida();
        }

        if (transform.position.y >= alturaMinima)
        {
            yaDetectoLaCaida = false;
        }
    }

    void DetectarCaida()
    {
        if (statsJugador != null)
        {
            int danoUnaVida = statsJugador.saludPorVida;
            statsJugador.TakeDamage(danoUnaVida);

            if (!statsJugador.IsDead())
            {
                ReiniciarNivel();
            }
        }
    }

    void ReiniciarNivel()
    {
        if (GameManager.instance != null)
            GameManager.instance.RestartCurrentLevel();
    }
}
