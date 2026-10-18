using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Este script actualiza la interfaz del juego (UI)

public class UIManager : MonoBehaviour
{
    // Textos de la pantalla
    public TMP_Text textoVidas;
    public TMP_Text textoPuntos;
    public TMP_Text textoTiempo;

    // Barra de vida (imagen tipo Filled)
    public Image barraVida;

    // Icono que aparece cuando el escudo esta activo
    public GameObject iconoEscudo;

    // Paneles de la UI
    public GameObject panelPausa;
    public GameObject panelGameOver;
    public GameObject panelVictoria;

    // Botones de los paneles
    public Button botonReanudar;
    public Button botonReiniciar;
    public Button botonMenu;

    void Start()
    {
        // Ocultar todos los paneles al inicio
        OcultarPaneles();

        // Conectar los botones con sus funciones
        if (botonReanudar != null)
            botonReanudar.onClick.AddListener(ClickReanudar);

        if (botonReiniciar != null)
            botonReiniciar.onClick.AddListener(ClickReiniciar);

        if (botonMenu != null)
            botonMenu.onClick.AddListener(ClickMenu);
    }

    void Update()
    {
        // Actualizar la UI cada frame con los datos del GameManager
        if (GameManager.instance == null) return;

        // Mostrar vidas
        if (textoVidas != null)
            textoVidas.text = "Vidas: " + GameManager.instance.vidas;

        // Mostrar puntos
        if (textoPuntos != null)
            textoPuntos.text = "Puntos: " + GameManager.instance.puntos;

        // Mostrar tiempo en formato mm:ss
        if (textoTiempo != null)
        {
            float t = GameManager.instance.tiempo;
            int minutos = (int)(t / 60);
            int segundos = (int)(t % 60);
            textoTiempo.text = minutos + ":" + segundos.ToString("00");
        }
    }

    // Actualiza la barra de vida visualmente
    // Se llama desde PlayerStats cuando cambia la vida
    public void ActualizarBarraVida(int vidaActual, int vidaMaxima)
    {
        if (barraVida != null)
            barraVida.fillAmount = (float)vidaActual / vidaMaxima;
    }

    // Muestra u oculta el icono del escudo
    public void MostrarEscudo(bool activo)
    {
        if (iconoEscudo != null)
            iconoEscudo.SetActive(activo);
    }

    // Muestra el panel de pausa
    public void MostrarPausa()
    {
        OcultarPaneles();
        if (panelPausa != null)
            panelPausa.SetActive(true);
    }

    // Muestra el panel de game over
    public void MostrarGameOver()
    {
        OcultarPaneles();
        if (panelGameOver != null)
            panelGameOver.SetActive(true);
    }

    // Muestra el panel de victoria
    public void MostrarVictoria()
    {
        OcultarPaneles();
        if (panelVictoria != null)
            panelVictoria.SetActive(true);
    }

    // Oculta todos los paneles
    public void OcultarPaneles()
    {
        if (panelPausa != null) panelPausa.SetActive(false);
        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

    // Funciones de los botones
    void ClickReanudar()
    {
        GameManager.instance.ResumeGame();
        OcultarPaneles();
    }

    void ClickReiniciar()
    {
        GameManager.instance.RestartCurrentLevel();
    }

    void ClickMenu()
    {
        GameManager.instance.QuitToMainMenu();
    }
}
