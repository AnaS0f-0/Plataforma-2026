using UnityEngine;

public class Invencible : MonoBehaviour
{
    [SerializeField] private int Invencibilidad = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.SumarInvencibilidad(Invencibilidad);
                Destroy(gameObject);
            }
        }
    }
}
