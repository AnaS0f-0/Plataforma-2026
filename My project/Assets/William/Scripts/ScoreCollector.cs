using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public int puntosParaGanar = 100;
    public GameObject llave;
    public GameObject meta;

    private bool llaveMostrada = false;

    void Start()
    {
        llaveMostrada = false;

        if (llave != null)
            llave.SetActive(false);

        if (meta != null)
            meta.SetActive(false);
    }

    void Update()
    {
        if (!llaveMostrada && GameManager.instance != null && GameManager.instance.puntos >= puntosParaGanar)
        {
            MostrarLlave();
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Goal"))
        {
            GameManager.instance.OnPlayerWin();
        }
    }

    void MostrarLlave()
    {
        llaveMostrada = true;

        if (llave != null)
            llave.SetActive(true);
    }
}
