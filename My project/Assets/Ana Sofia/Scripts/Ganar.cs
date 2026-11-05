using UnityEngine;

public class Ganar : MonoBehaviour
{
    [SerializeField] private GameObject panelVictoria;


    private void Start()
    {
        panelVictoria.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;

        }

        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
        }
    }

}
