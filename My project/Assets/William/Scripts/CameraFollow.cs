using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public float velocidadSeguimiento = 0.15f;
    public Vector3 offset = new Vector3(0f, 1f, -10f);

    void LateUpdate()
    {
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                jugador = playerObj.transform;
            else
                return;
        }

        Vector3 posicionDeseada = jugador.position + offset;
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, posicionDeseada, ref velocity, velocidadSeguimiento);
    }
}
