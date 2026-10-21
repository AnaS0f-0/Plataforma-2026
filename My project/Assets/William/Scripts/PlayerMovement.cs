using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 6f;
    public float fuerzaSalto = 12f;
    public Transform puntoSuelo;
    public float radioSuelo = 0.15f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float movimientoX;
    private bool estaEnSuelo;
    private bool quiereSaltar;

    private float tiempoSalto = 0f;
    private float ventanaSalto = 0.15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movimientoX > 0)
            spriteRenderer.flipX = false;
        else if (movimientoX < 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        if (puntoSuelo != null)
            estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        bool dentroDeLaVentana = Time.time - tiempoSalto <= ventanaSalto;
        if (quiereSaltar && estaEnSuelo && dentroDeLaVentana)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            quiereSaltar = false;
        }

        if (!dentroDeLaVentana)
            quiereSaltar = false;
    }

    public void OnMove(InputValue value)
    {
        movimientoX = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            quiereSaltar = true;
            tiempoSalto = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (puntoSuelo == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
    }
}
