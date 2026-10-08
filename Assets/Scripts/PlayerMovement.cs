using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadCaminar = 5f;

    [Header("Configuración de Salto")]
    public float fuerzaSalto = 10f;

    private Rigidbody rb;
    private bool enSuelo = true;
    private float horizontal;
    private float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // A y D
        vertical = Input.GetAxis("Vertical");     // W y S

        // SALTO
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            enSuelo = false;
            
            // Al saltar, nos desvinculamos inmediatamente de cualquier plataforma o padre
            transform.SetParent(null);

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Movimiento físico respetando la gravedad/velocidad vertical
        Vector3 velocidadMovimiento = new Vector3(-horizontal * velocidadCaminar, rb.linearVelocity.y, -vertical * velocidadCaminar);
        rb.linearVelocity = velocidadMovimiento;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contacto in collision.contacts)
        {
            if (contacto.normal.y > 0.5f)
            {
                enSuelo = true;

                // Si lo que estamos pisando tiene la etiqueta "Plataforma", nos emparentamos aquí mismo
                if (collision.gameObject.CompareTag("Plataforma"))
                {
                    transform.SetParent(collision.transform);
                }
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Si dejamos de tocar la plataforma, nos desvinculamos
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.SetParent(null);
        }

        enSuelo = false;
    }
}