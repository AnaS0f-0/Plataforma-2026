using UnityEngine;

public class TrampaMortal : MonoBehaviour

{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private UiManager _uiManager;

    private void OnCollisionEnter2D(Collision2D collision)


    {
        if (collision.gameObject.tag == "Player")
        {
            _playerStats.RestarVida(33);
            _uiManager.RestarFillAmount(0.3f);

        }
    }
}