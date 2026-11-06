using UnityEngine;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            colorOriginal = spriteRenderer.color;
    }

    public void FlashRojo()
    {
        if (spriteRenderer == null) return;

        StartCoroutine(ParpadeoRojo());
    }

    IEnumerator ParpadeoRojo()
    {
        spriteRenderer.color = Color.red;
        
        yield return new WaitForSeconds(0.1f);
        
        spriteRenderer.color = colorOriginal;
    }
}
