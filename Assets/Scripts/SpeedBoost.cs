using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [Header("Configuración del Power-Up")]
    public float multiplicador = 2f; // Cuánto aumenta (ej. el doble)
    public float duracion = 8f;      // Cuántos segundos durará el efecto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
                // Iniciamos la corrutina
                StartCoroutine(AplicarBoost(player));

                // Desactivamos el colisionador para que no se recoja dos veces
                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;

                // Ocultamos el cubo visualmente apagando su MeshRenderer (sin buscar hijos)
                MeshRenderer renderizador = GetComponent<MeshRenderer>();
                if (renderizador != null) renderizador.enabled = false;
            }
        }
    }

    private IEnumerator AplicarBoost(PlayerMovement player)
    {
        
        float velocidadOriginal = player.velocidadCaminar;

        
        player.velocidadCaminar *= multiplicador;
        Debug.Log("¡Velocidad aumentada!");

        yield return new WaitForSeconds(duracion);

        player.velocidadCaminar = velocidadOriginal;
        Debug.Log("¡El efecto de velocidad ha terminado!");

       
        Destroy(gameObject);
    }
}