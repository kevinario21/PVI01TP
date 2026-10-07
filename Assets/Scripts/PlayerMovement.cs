using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocity = 5f;

    [Header("Salto")]
    public float fuerza1 = 7f;
    public float fuerza2 = 10f;
    private int saltos = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        rb.freezeRotation = true;
    }

    void Update()
    {
        Movement();
        Jump();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 direccion = new Vector3(-vertical, 0f, horizontal);

        if (direccion.magnitude > 0.1f)
        {
            transform.LookAt(transform.position + direccion);
            transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.Self);
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && saltos < 1)
        {
            
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

            
            rb.AddForce(Vector3.up * (saltos == 0 ? fuerza1 : fuerza2), ForceMode.Impulse);
            saltos++;
        }
    }

    void OnCollisionEnter(Collision c)
    {
       
        if (c.contacts[0].normal.y > 0.5f)
        {
            saltos = 0;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, Mathf.Min(rb.linearVelocity.y, 0), rb.linearVelocity.z);
        }
    }
}
    