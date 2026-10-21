using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 3;
    public int puntos = 0;
    public float tiempo = 60f;
    public bool juegoActivo = true;

    private UIManager uiManager;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        uiManager = FindObjectOfType<UIManager>();
        
        ResetearValores();
    }

    void Update()
    {
        if (!juegoActivo) return;

        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            tiempo = 0;
            OnPlayerLose();
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (juegoActivo)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        juegoActivo = false;
        Time.timeScale = 0;
        
        if (uiManager != null)
            uiManager.MostrarPausa();
    }

    public void ResumeGame()
    {
        juegoActivo = true;
        Time.timeScale = 1;
    }

    public void OnPlayerWin()
    {
        juegoActivo = false;
        Time.timeScale = 0;
        
        if (uiManager != null)
            uiManager.MostrarVictoria();
    }

    public void OnPlayerLose()
    {
        juegoActivo = false;
        Time.timeScale = 0;
        
        if (uiManager != null)
            uiManager.MostrarGameOver();
    }

    public void LoadScene(string nombreEscena)
    {
        Time.timeScale = 1;
        juegoActivo = true;
        ResetearValores();
        SceneManager.LoadScene(nombreEscena);
    }

    public void RestartCurrentLevel()
    {
        Time.timeScale = 1;
        juegoActivo = true;
        ResetearValores();
        
        string escenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(escenaActual);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        RestartCurrentLevel();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
    }

    void ResetearValores()
    {
        vidas = 3;
        puntos = 0;
        tiempo = 60f;
    }
}
