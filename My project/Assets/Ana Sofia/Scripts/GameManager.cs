using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _PaneldeMuerte;


    private void CargarEscenaMuerte(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
