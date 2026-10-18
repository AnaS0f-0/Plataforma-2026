using UnityEngine;
using UnityEngine.SceneManagement;

// Este script controla el juego completo

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int vidas = 3;
    public int puntos = 0;
    public float tiempo = 120f;

    // Para saber si el juego esta pausado
    public bool juegoActivo = true;

    void Awake()
    {
        // Si ya existe un GameManager no creamos otro
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // que no se destruya al cambiar escena
    }

    void Update()
    {
        // Si el juego no esta activo no hacemos nada
        if (!juegoActivo) return;

        // Bajar el tiempo poco a poco
        tiempo -= Time.deltaTime;

        // Si se acabo el tiempo el jugador pierde
        if (tiempo <= 0)
        {
            tiempo = 0;
            OnPlayerLose();
        }

        // Pausar con Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    // Pausa el juego
    public void PauseGame()
    {
        juegoActivo = false;
        Time.timeScale = 0; // congela todo
        Debug.Log("Juego pausado");
    }

    // Reanuda el juego
    public void ResumeGame()
    {
        juegoActivo = true;
        Time.timeScale = 1; // vuelve a la velocidad normal
        Debug.Log("Juego reanudado");
    }

    // El jugador gano
    public void OnPlayerWin()
    {
        juegoActivo = false;
        Time.timeScale = 0;
        Debug.Log("Ganaste!");
    }

    // El jugador perdio
    public void OnPlayerLose()
    {
        juegoActivo = false;
        Time.timeScale = 0;
        Debug.Log("Perdiste!");
    }

    // Carga una escena por nombre
    public void LoadScene(string nombreEscena)
    {
        Time.timeScale = 1;
        juegoActivo = true;
        ResetearValores();
        SceneManager.LoadScene(nombreEscena);
    }

    // Reinicia el nivel actual
    public void RestartCurrentLevel()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        LoadScene(escenaActual);
    }

    // Vuelve al menu principal
    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    // Suma puntos al marcador
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log("Puntos: " + puntos);
    }

    // Reinicia las variables al valor inicial
    void ResetearValores()
    {
        vidas = 3;
        puntos = 0;
        tiempo = 120f;
    }
}
