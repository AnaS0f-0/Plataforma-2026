using UnityEngine;
using UnityEngine.InputSystem;

// Este script mueve al jugador

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Velocidad al caminar
    public float velocidad = 6f;

    // Fuerza del salto
    public float fuerzaSalto = 12f;

    // Objeto vacio que va en los pies del jugador para detectar el suelo
    public Transform puntoSuelo;

    // Radio del circulo que detecta el suelo
    public float radioSuelo = 0.15f;

    // Capa que usamos para el suelo (Layer Ground)
    public LayerMask capaSuelo;

    // Variables internas
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float movimientoX;
    private bool estaEnSuelo;
    private bool quiereSaltar;

    // Contador para no perder el salto entre frames
    private float tiempoSalto = 0f;
    private float ventanaSalto = 0.15f; // segundos que tiene para saltar

    void Start()
    {
        // Guardar referencias a los componentes
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Voltear el sprite segun la direccion
        if (movimientoX > 0)
            spriteRenderer.flipX = false;
        else if (movimientoX < 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        // Ver si esta tocando el suelo
        if (puntoSuelo != null)
            estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        // Mover al jugador en horizontal
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        // Saltar si pidio saltar y esta en el suelo
        bool dentroDeLaVentana = Time.time - tiempoSalto <= ventanaSalto;
        if (quiereSaltar && estaEnSuelo && dentroDeLaVentana)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            quiereSaltar = false;
        }

        // Si ya paso la ventana de salto, cancelarlo
        if (!dentroDeLaVentana)
            quiereSaltar = false;
    }

    // El PlayerInput llama este metodo cuando se presiona Move
    public void OnMove(InputValue value)
    {
        movimientoX = value.Get<Vector2>().x;
    }

    // El PlayerInput llama este metodo cuando se presiona Jump
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            quiereSaltar = true;
            tiempoSalto = Time.time; // guardar cuando pidio el salto
        }
    }

    // Dibuja el circulo del suelo en el editor para verlo mejor
    void OnDrawGizmosSelected()
    {
        if (puntoSuelo == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
    }
}
