using UnityEngine;

public class TOCAAAA : MonoBehaviour

{
    public bool estaEnSuelo;

    private void OnTriggerStay2D(Collider2D collision)
    {
        estaEnSuelo = true;
        Debug.Log("tocó el suelo");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        estaEnSuelo = false;
        Debug.Log("Estoy saltando");
    }
}
