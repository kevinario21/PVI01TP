using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField]private Transform hand;
    private GameObject currentItem = null;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item") && currentItem == null)
        {
            if (Input.GetKeyDown(KeyCode.E)) Pick(other.gameObject);
        }
    }
    private void Pick(GameObject moneda)
    {
        currentItem = moneda;
        moneda.transform.SetParent(hand);
        moneda.transform.localPosition = Vector3.zero;
        moneda.transform.localRotation = Quaternion.identity;
    }
    public GameObject DropItem()
    {
        GameObject temp = currentItem;
        currentItem = null;
        return temp;
    }
}
