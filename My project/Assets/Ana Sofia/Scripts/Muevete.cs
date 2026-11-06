using UnityEngine;

public class Muevete : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _velodidadMovimiento = 5f;
    [SerializeField] private Rigidbody2D _cuerpoRigido2D;
    [SerializeField] private TOCAAAA _tocaaaa;


    public float
        velocidadMovimiento { get => _velodidadMovimiento; set => _velodidadMovimiento = value; }

    private void Awake()
    {
        _cuerpoRigido2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_tocaaaa.estaEnSuelo)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _cuerpoRigido2D.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);

                Debug.Log("oprimo la tecla");
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _velodidadMovimiento * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * _velodidadMovimiento * Time.deltaTime;
        }

    }
}
