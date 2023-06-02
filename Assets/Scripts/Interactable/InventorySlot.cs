using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryItem inventoryItem;

    public void ViewDescription()
    {
        if(inventoryItem.transform.childCount > 0)
        {
            Debug.Log("KLIK");
            inventoryItem = this.GetComponentInChildren<InventoryItem>();
            inventoryItem.ViewDescription();
        }
        else
        {
            Debug.Log("Item gak ada");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }

    
}
