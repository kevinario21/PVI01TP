using UnityEngine;

public class MovimientoLinealX : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadX = 10f;
    public float vidaUtil = 8f;   
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {

            rb.useGravity = false;

            
            rb.linearVelocity = new Vector3(velocidadX, 0f, 0f);
        }

        Destroy(gameObject, vidaUtil);
    }
}