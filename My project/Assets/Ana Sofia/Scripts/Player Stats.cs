using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _puntosVida = 100;
    [SerializeField] private int _vidaMaxima = 100;
    [SerializeField] private float vidaActual;



    private void Start()
    {
        vidaActual = _vidaMaxima;
    }


    public void RestarVida(int daño)
    {
        _puntosVida = _puntosVida - daño;
    }
}
