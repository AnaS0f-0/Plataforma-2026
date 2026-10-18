using UnityEngine;

// Este script hace que la camara siga al jugador
// Va en la Main Camera de la escena

public class CameraFollow : MonoBehaviour
{

    public Transform jugador;

    public float velocidadSeguimiento = 0.15f;

    // Desplazamiento de la camara respecto al jugador
    public Vector3 offset = new Vector3(0f, 1f, -10f);

    void LateUpdate()
    {
        // Si no hay jugador asignado buscarlo por tag
        if (jugador == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                jugador = playerObj.transform;
            else
                return; // si no hay jugador no hacer nada
        }

        Vector3 posicionDeseada = jugador.position + offset;

        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, posicionDeseada, ref velocity, velocidadSeguimiento);
    }
}
