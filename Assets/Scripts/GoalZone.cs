using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private Transform goal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickItem pickItem = other.GetComponent<PickItem>();
            if (pickItem != null)
            {
                GameObject item = pickItem.DropItem();
                if (item != null)
                {
                    ItemInZone(item);
                    Debug.Log("Felicidades por completar el circuito");
                }
                else
                {
                    Debug.Log("Debes traer el item para ganar");
                }
            }
        }
    }
    private void ItemInZone(GameObject moneda)
    {
        moneda.transform.SetParent(goal);
        moneda.transform.localPosition = Vector3.zero;
        moneda.transform.localRotation = Quaternion.identity;

        Collider col = moneda.GetComponent<Collider>();
        Rigidbody rb = moneda.GetComponent<Rigidbody>();

        if (col != null) col.enabled = true;
        if (rb != null) rb.isKinematic = true;
    }
}
