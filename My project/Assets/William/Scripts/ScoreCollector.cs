using UnityEngine;

// Este script recoge los items del nivel y suma puntos

public class ScoreCollector : MonoBehaviour
{
    // Puntos que necesita para ganar
    public int puntosParaGanar = 100;

 
    public GameObject meta;

    // Para saber si ya se desbloqueo la meta
    private bool metaDesbloqueada = false;

    void OnTriggerEnter2D(Collider2D otro)
    {
        // Si toco un item lo recoge
        if (otro.CompareTag("Item"))
        {
            // Ver cuantos puntos vale el item
            PowerUp itemScript = otro.GetComponent<PowerUp>();
            int valorItem = 10; // valor por defecto

            if (itemScript != null)
                valorItem = itemScript.valorPuntos;

            // Sumar puntos al GameManager
            GameManager.instance.SumarPuntos(valorItem);

            // Destruir el item de la escena
            Destroy(otro.gameObject);

            Debug.Log("Item recogido! Puntos totales: " + GameManager.instance.puntos);

            // Ver si ya alcanzo los puntos para desbloquear la meta
            if (!metaDesbloqueada && GameManager.instance.puntos >= puntosParaGanar)
            {
                DesbloquearMeta();
            }
        }

        // Si llego a la meta y esta desbloqueada, gana
        if (otro.CompareTag("Goal") && metaDesbloqueada)
        {
            Debug.Log("Llego a la meta, gano!");
            GameManager.instance.OnPlayerWin();
        }
    }

    // Activa el objeto de la meta en la escena
    void DesbloquearMeta()
    {
        metaDesbloqueada = true;

        if (meta != null)
            meta.SetActive(true);

        Debug.Log("Meta desbloqueada! Llega a la puerta para ganar.");
    }
}
