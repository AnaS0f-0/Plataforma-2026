using Unity.VectorGraphics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _puntosVida = 100;
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private float vidaActual;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] public GameObject panelDerrota;
    [SerializeField] public bool _invencibilidad;
 
  
    public GameManager gameManager;
   

   

 

    public void Start()
    {
    
        vidaActual = _vidaMaxima;
    }

    

    public void SumarInvencibilidad(int  vida)
    {
        _puntosVida = Mathf.Clamp(_puntosVida + vida, 0, _vidaMaxima);
    }





    public void RestarVida(int daño)
    {
        if (_invencibilidad == false)
        {
            _puntosVida = _puntosVida - daño;
        }

      
    }


    public void SumarVida(int daño)
    {

        _puntosVida = _puntosVida + daño;
        if (_puntosVida > _vidaMaxima)
        {
            _puntosVida = _vidaMaxima;
        }
    }
    private void Update()
    {

        if (_puntosVida <= 0)
        {
            Time.timeScale = 0;
            panelDerrota.SetActive(true);
        }
    }

    public void sumarVida(int salud)
    {
        if (_vidaMaxima >= 30.0f)
        {
            return;
        }

    }



   
}
