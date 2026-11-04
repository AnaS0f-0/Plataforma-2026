using UnityEngine;

public class LlaveCollector : MonoBehaviour
{
    public GameObject meta;

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            if (meta != null)
                meta.SetActive(true);
        }
    }
}
