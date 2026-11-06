using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Llave controlLlave;
    public GameObject Victoria;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Llave.TieneLlave == true)
            {
                Destroy(gameObject);
                Debug.Log("Puerta desbloqueada");

            }

            else
            {
                Debug.Log("necesitas una llave para pasar");
            }
        }
    }

}
