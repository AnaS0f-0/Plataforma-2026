using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public int puntosParaGanar = 100;
    public GameObject meta;

    private bool metaDesbloqueada = false;

    void Start()
    {
        metaDesbloqueada = false;
        if (meta != null)
            meta.SetActive(false);
    }

    void Update()
    {
        if (!metaDesbloqueada && GameManager.instance != null && GameManager.instance.puntos >= puntosParaGanar)
        {
            DesbloquearMeta();
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Goal") && metaDesbloqueada)
        {
            GameManager.instance.OnPlayerWin();
        }
    }

    void DesbloquearMeta()
    {
        metaDesbloqueada = true;

        if (meta != null)
            meta.SetActive(true);
    }
}
