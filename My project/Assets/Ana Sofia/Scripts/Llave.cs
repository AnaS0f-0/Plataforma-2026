using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameObject Player;
    public GameObject llave;
    public bool llaveObtenida = false;

    public static bool TieneLlave = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TieneLlave = true;
            Destroy(gameObject);
            Debug.Log("Has recogido la llave");
        }
    }

}
