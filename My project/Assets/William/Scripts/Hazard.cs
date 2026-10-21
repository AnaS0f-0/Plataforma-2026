using UnityEngine;
using UnityEngine.Tilemaps;

public class Hazard : MonoBehaviour
{
    public int daño = 50;
    public float tiempoEntreGolpes = 1f;
    public float radioDeteccion = 0.5f;

    private float tiempoUltimoGolpe = 0f;
    private Tilemap tilemap;
    private Grid grid;
    private PlayerStats playerStats;
    private Transform playerTransform;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        grid = GetComponentInParent<Grid>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
            playerStats = playerObj.GetComponent<PlayerStats>();
        }
    }

    void Update()
    {
        if (playerTransform == null || playerStats == null) return;

        DetectarColision();
    }

    void DetectarColision()
    {
        Vector3 posJugador = playerTransform.position;
        Vector3Int cellPos = tilemap.WorldToCell(posJugador);
        TileBase tile = tilemap.GetTile(cellPos);

        if (tile != null)
        {
            if (Time.time - tiempoUltimoGolpe >= tiempoEntreGolpes)
            {
                AplicarDanio();
            }
        }
    }

    void AplicarDanio()
    {
        if (playerStats == null || playerStats.IsDead()) return;

        playerStats.TakeDamage(daño);
        tiempoUltimoGolpe = Time.time;
    }
}
