using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int vidasMaximas = 2;
    public int saludPorVida = 100;
    
    [HideInInspector] public int vidaMaxima;
    [HideInInspector] public int vidaActual;

    public bool escudoActivo = false;

    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        
        int vidasActualesEnGameManager = 2;
        if (GameManager.instance != null)
        {
            vidasActualesEnGameManager = GameManager.instance.vidas;
        }
        
        vidaMaxima = vidasActualesEnGameManager * saludPorVida;
        vidaActual = vidaMaxima;

        ActualizarUI();
    }

    public void TakeDamage(int cantidad)
    {
        if (IsDead()) return;

        if (escudoActivo)
        {
            return;
        }

        vidaActual -= cantidad;

        if (vidaActual < 0)
            vidaActual = 0;

        DamageFlash flash = GetComponent<DamageFlash>();
        if (flash != null)
            flash.FlashRojo();

        ActualizarUI();

        if (IsDead())
        {
            if (GameManager.instance != null)
                GameManager.instance.OnPlayerLose();
        }
    }

    public void Heal(int cantidad)
    {
        if (IsDead()) return;

        vidaActual += cantidad;

        if (vidaActual > vidaMaxima)
            vidaActual = vidaMaxima;

        ActualizarUI();
    }

    public void ActivateShield(float duracion, int golpes)
    {
        escudoActivo = true;

        if (uiManager != null)
            uiManager.MostrarEscudo(true);

        if (duracion > 0)
            StartCoroutine(DesactivarEscudoPorTiempo(duracion));
    }

    public void DesactivarEscudo()
    {
        escudoActivo = false;

        if (uiManager != null)
            uiManager.MostrarEscudo(false);
    }

    IEnumerator DesactivarEscudoPorTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        DesactivarEscudo();
    }

    public bool IsDead()
    {
        return vidaActual <= 0;
    }

    public int ObtenerVidasRestantes()
    {
        if (vidaActual <= 0) return 0;
        return (vidaActual + saludPorVida - 1) / saludPorVida;
    }

    void ActualizarUI()
    {
        if (uiManager != null)
            uiManager.ActualizarBarraVida(vidaActual, vidaMaxima);
        
        if (GameManager.instance != null)
        {
            int vidasRestantes = ObtenerVidasRestantes();
            GameManager.instance.vidas = vidasRestantes;
        }
    }
}
