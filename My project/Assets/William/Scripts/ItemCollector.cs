using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemCollector : MonoBehaviour
{
    private Tilemap tilemap;
    private Transform playerTransform;
    private float tiempoUltimoItem = 0f;
    private float delayEntreItems = 0.3f;
    private int puntosItem = 20;

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

        DetectarItem();
    }

    void DetectarItem()
    {
        Vector3 posJugador = playerTransform.position;
        Vector3Int cellPos = tilemap.WorldToCell(posJugador);
        TileBase tile = tilemap.GetTile(cellPos);

        if (tile != null)
        {
            if (Time.time - tiempoUltimoItem >= delayEntreItems)
            {
                RecogerItem(cellPos);
            }
        }
    }

    void RecogerItem(Vector3Int posicion)
    {
        tiempoUltimoItem = Time.time;

        if (GameManager.instance != null)
            GameManager.instance.SumarPuntos(puntosItem);
        
        tilemap.SetTile(posicion, null);
    }
}
