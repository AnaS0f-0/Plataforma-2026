using UnityEngine;

public class Invencible : MonoBehaviour
{
    [SerializeField] private int Invencibilidad = 100;
    [SerializeField] private bool _invencible;
    [SerializeField] private GameObject ActivarInvencibilidad;
    [SerializeField] private UiManager _uiManager;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats != null)
            {
                
              
              
                stats.SumarInvencibilidad(Invencibilidad);
                stats._invencibilidad = true;
               

                Destroy(gameObject);  
                
            }

           
        }
    }

} 
