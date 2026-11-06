using UnityEngine;
using UnityEngine.Tilemaps;

public class ShieldCollector : MonoBehaviour
{
    private Tilemap tilemap;
    private Transform playerTransform;
    private float tiempoUltimoEscudo = 0f;
    private float delayEntreEscudos = 0.3f;
    private float duracionEscudo = 5f;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            playerTransform = playerObj.transform;
    }

    void Update()
    {
        if (playerTransform == null || tilemap == null) return;

        DetectarEscudo();
    }

    void DetectarEscudo()
    {
        Vector3 posJugador = playerTransform.position;
        Vector3Int cellPos = tilemap.WorldToCell(posJugador);
        TileBase tile = tilemap.GetTile(cellPos);

        if (tile != null)
        {
            if (Time.time - tiempoUltimoEscudo >= delayEntreEscudos)
            {
                RecogerEscudo(cellPos);
            }
        }
    }

    void RecogerEscudo(Vector3Int posicion)
    {
        tiempoUltimoEscudo = Time.time;

        PlayerStats playerStats = playerTransform.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.ActivateShield(duracionEscudo, 0);
        }
        
        tilemap.SetTile(posicion, null);
    }
}
