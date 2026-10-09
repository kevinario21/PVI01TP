using UnityEngine;
using System.Collections;

public class SpawnerRangoAleatorio : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject proyectilPrefab;
    public float primerDelay = 2f;
    public float intervalo = 3f;

    [Header("Rango Aleatorio en el Eje Z")]
    public float rangoMinZ = -40.58f;
    public float rangoMaxZ = -77.65f;

    void Start()
    {
        
        StartCoroutine(RutinaGeneracion());
    }

    IEnumerator RutinaGeneracion()
    {
        
        yield return new WaitForSeconds(primerDelay);

        while (true) 
        {
            CrearEnRangoZ();

           
            yield return new WaitForSeconds(intervalo);
        }
    }

    void CrearEnRangoZ()
    {
        if (proyectilPrefab == null)
        {
            Debug.LogWarning("¡El prefab del proyectil no está asignado en el Spawner!");
            return;
        }

        Vector3 posicionSpawn = transform.position;
        posicionSpawn.z += Random.Range(rangoMinZ, rangoMaxZ);

     
        Instantiate(proyectilPrefab, posicionSpawn, Quaternion.identity);
    }
}