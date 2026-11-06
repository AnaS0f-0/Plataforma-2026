using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _PaneldeMuerte;
   
    public void CargarEscena(int scene)
    {
        SceneManager.LoadScene(scene);
    }


    private void CargarEscenaMuerte(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SalirDelJuego()
    {
#if !UNITY_WEBGL
        Application.Quit();
#endif
    }

    public void PausarElJuego()
    {
        Time.timeScale = 0;
    }

    public void ReanudarElJuego()
    {
        Time.timeScale = 1;
    }

    public void ReiniciarElJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
