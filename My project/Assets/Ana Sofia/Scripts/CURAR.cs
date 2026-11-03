using UnityEngine;

public class CURAR : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private UiManager _uiManager;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerStats.SumarVida(33);
            _uiManager.SumarFillAmount(0.3f);
            Destroy(this.gameObject);
        }

    }



}
