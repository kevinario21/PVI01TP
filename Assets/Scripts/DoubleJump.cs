using System.Collections;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    [Header("Configuración del Doble Salto Temporal")]
    public float duracion = 8f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();

            if (player != null)
            {
               
                StartCoroutine(AplicarDobleSaltoTemporal(player));

                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;

                MeshRenderer renderizador = GetComponent<MeshRenderer>();
                if (renderizador != null) renderizador.enabled = false;
            }
        }
    }

    private IEnumerator AplicarDobleSaltoTemporal(PlayerMovement player)
    {
        
        player.HabilitarDobleSalto();
        Debug.Log("¡Doble salto temporal activado!");

        
        yield return new WaitForSeconds(duracion);

        
        player.DeshabilitarDobleSalto();
        Debug.Log("¡El efecto de doble salto ha terminado!");

       
        Destroy(gameObject);
    }
}