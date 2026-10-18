using UnityEngine;
using System.Collections;

// Este script controla la vida del jugador y el escudo

public class PlayerStats : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual = 100;

    public bool escudoActivo = false;

    // Referencia al UIManager para actualizar la pantalla
    private UIManager uiManager;

    void Start()
    {
        // Buscar el UIManager en la escena
        uiManager = FindObjectOfType<UIManager>();

        // Mostrar la vida al inicio
        ActualizarUI();
    }

    // Le quita vida al jugador
    public void TakeDamage(int cantidad)
    {
         if (IsDead()) return;

         if (escudoActivo)
        {
            Debug.Log("El escudo bloqueo el daño");
            return;
        }

         vidaActual -= cantidad;

        // Que no baje de 0
        if (vidaActual < 0)
            vidaActual = 0;

        Debug.Log("Vida actual: " + vidaActual);

        // Actualizar la barra de vida en pantalla
        ActualizarUI();

        // Si no tiene vida avisar al GameManager
        if (IsDead())
        {
            Debug.Log("El jugador murio");
            GameManager.instance.OnPlayerLose();
        }
    }

    // Le da vida al jugador sin pasarse del maximo
    public void Heal(int cantidad)
    {
        if (IsDead()) return;

        vidaActual += cantidad;

        // Que no suba del maximo
        if (vidaActual > vidaMaxima)
            vidaActual = vidaMaxima;

        Debug.Log("Vida tras curar: " + vidaActual);
        ActualizarUI();
    }

    // Activa el escudo por un tiempo o por cantidad de golpes
    public void ActivateShield(float duracion, int golpes)
    {
        escudoActivo = true;

        // Mostrar el icono del escudo
        if (uiManager != null)
            uiManager.MostrarEscudo(true);

        Debug.Log("Escudo activado");

        // Si tiene duracion lo desactivamos despues de ese tiempo
        if (duracion > 0)
            StartCoroutine(DesactivarEscudoPorTiempo(duracion));
    }

    public void DesactivarEscudo()
    {
        escudoActivo = false;

        if (uiManager != null)
            uiManager.MostrarEscudo(false);

        Debug.Log("Escudo desactivado");
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

    void ActualizarUI()
    {
        if (uiManager != null)
            uiManager.ActualizarBarraVida(vidaActual, vidaMaxima);
    }
}
