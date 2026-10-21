using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

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
        BuscarElementos();
    }

    void BuscarElementos()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) return;

        Transform canvasTransform = canvas.transform;

        if (textoVidas == null)
            textoVidas = canvasTransform.Find("TextoVidas")?.GetComponent<TextMeshProUGUI>();
        
        if (textoPuntos == null)
            textoPuntos = canvasTransform.Find("TextoPuntos")?.GetComponent<TextMeshProUGUI>();
        
        if (textoTiempo == null)
            textoTiempo = canvasTransform.Find("TextoTiempo")?.GetComponent<TextMeshProUGUI>();

        if (panelPausa == null)
            panelPausa = canvasTransform.Find("PanelPausa")?.gameObject;
        
        if (panelGameOver == null)
            panelGameOver = canvasTransform.Find("PanelGameOver")?.gameObject;
        
        if (panelVictoria == null)
            panelVictoria = canvasTransform.Find("PanelVictoria")?.gameObject;

        BuscarBotones(canvasTransform);
    }

    void BuscarBotones(Transform canvasTransform)
    {
        Transform boton = canvasTransform.Find("PanelPausa/BotonReanudar");
        if (boton == null)
            boton = canvasTransform.Find("PanelGameOver/BotonReanudar");
        if (boton == null)
            boton = canvasTransform.Find("PanelVictoria/BotonReanudar");
        botonReanudar = boton?.GetComponent<Button>();

        boton = canvasTransform.Find("PanelPausa/BotonReiniciar");
        if (boton == null)
            boton = canvasTransform.Find("PanelGameOver/BotonReiniciar");
        if (boton == null)
            boton = canvasTransform.Find("PanelVictoria/BotonReiniciar");
        botonReiniciar = boton?.GetComponent<Button>();

        boton = canvasTransform.Find("PanelPausa/BotonMenu");
        if (boton == null)
            boton = canvasTransform.Find("PanelGameOver/BotonMenu");
        if (boton == null)
            boton = canvasTransform.Find("PanelVictoria/BotonMenu");
        botonMenu = boton?.GetComponent<Button>();
    }

    void Update()
    {
        if (GameManager.instance == null) return;

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            Transform canvasTransform = canvas.transform;

            if (textoVidas == null)
                textoVidas = canvasTransform.Find("TextoVidas")?.GetComponent<TextMeshProUGUI>();
            
            if (textoPuntos == null)
                textoPuntos = canvasTransform.Find("TextoPuntos")?.GetComponent<TextMeshProUGUI>();

            if (textoTiempo == null)
                textoTiempo = canvasTransform.Find("TextoTiempo")?.GetComponent<TextMeshProUGUI>();

            if (panelPausa == null)
                panelPausa = canvasTransform.Find("PanelPausa")?.gameObject;
            
            if (panelGameOver == null)
                panelGameOver = canvasTransform.Find("PanelGameOver")?.gameObject;
            
            if (panelVictoria == null)
                panelVictoria = canvasTransform.Find("PanelVictoria")?.gameObject;

            BuscarBotones(canvasTransform);
        }

        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + GameManager.instance.vidas;
        }

        if (textoPuntos != null)
        {
            textoPuntos.text = "Puntos: " + GameManager.instance.puntos;
        }

        if (textoTiempo != null)
        {
            float t = GameManager.instance.tiempo;
            int minutos = (int)(t / 60);
            int segundos = (int)(t % 60);
            textoTiempo.text = minutos + ":" + segundos.ToString("00");
        }

        DetectarClicsBotones();
    }

    void DetectarClicsBotones()
    {
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame)
            return;

        if (EventSystem.current == null)
            return;

        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Mouse.current.position.ReadValue();
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            string buttonName = result.gameObject.name;
            
            if (buttonName == "BotonReanudar")
            {
                ClickReanudar();
                return;
            }
            else if (buttonName == "BotonReiniciar")
            {
                ClickReiniciar();
                return;
            }
            else if (buttonName == "BotonMenu")
            {
                ClickMenu();
                return;
            }
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
        Time.timeScale = 1;
        GameManager.instance.ResumeGame();
        OcultarPaneles();
    }

    void ClickReiniciar()
    {
        Time.timeScale = 1;
        GameManager.instance.RestartFromButton();
    }

    void ClickMenu()
    {
        Time.timeScale = 1;
        GameManager.instance.QuitToMainMenu();
    }
}
