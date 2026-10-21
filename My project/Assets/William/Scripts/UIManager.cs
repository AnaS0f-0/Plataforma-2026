using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text textoVidas;
    public TMP_Text textoPuntos;
    public TMP_Text textoTiempo;

    public Image barraVida;
    public GameObject iconoEscudo;

    public GameObject panelPausa;
    public GameObject panelGameOver;
    public GameObject panelVictoria;

    public Button botonReanudar;
    public Button botonReiniciar;
    public Button botonMenu;

    void Start()
    {
        OcultarPaneles();

        if (botonReanudar != null)
            botonReanudar.onClick.AddListener(ClickReanudar);

        if (botonReiniciar != null)
            botonReiniciar.onClick.AddListener(ClickReiniciar);

        if (botonMenu != null)
            botonMenu.onClick.AddListener(ClickMenu);
    }

    void Update()
    {
        if (GameManager.instance == null) return;

        if (textoVidas != null)
            textoVidas.text = "Vidas: " + GameManager.instance.vidas;

        if (textoPuntos != null)
            textoPuntos.text = "Puntos: " + GameManager.instance.puntos;

        if (textoTiempo != null)
        {
            float t = GameManager.instance.tiempo;
            int minutos = (int)(t / 60);
            int segundos = (int)(t % 60);
            textoTiempo.text = minutos + ":" + segundos.ToString("00");
        }
    }

    public void ActualizarBarraVida(int vidaActual, int vidaMaxima)
    {
        if (barraVida != null)
            barraVida.fillAmount = (float)vidaActual / vidaMaxima;
    }

    public void MostrarEscudo(bool activo)
    {
        if (iconoEscudo != null)
            iconoEscudo.SetActive(activo);
    }

    public void MostrarPausa()
    {
        OcultarPaneles();
        if (panelPausa != null)
            panelPausa.SetActive(true);
    }

    public void MostrarGameOver()
    {
        OcultarPaneles();
        if (panelGameOver != null)
            panelGameOver.SetActive(true);
    }

    public void MostrarVictoria()
    {
        OcultarPaneles();
        if (panelVictoria != null)
            panelVictoria.SetActive(true);
    }

    public void OcultarPaneles()
    {
        if (panelPausa != null) panelPausa.SetActive(false);
        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

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
