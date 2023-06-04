using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItem = 5;

    public InventorySlot[] inventorySlots;
    // private List<InventoryItem> inventoryItems;

    public GameObject inventoryItemPrefab;

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                // inventoryItems.Add(itemInSlot);
                itemInSlot = SpawnNewItem(item, slot);
                slot.AddOnClickListener(itemInSlot.ViewDescription);
                return true;
            }
        }
        return false;
    }

    private InventoryItem SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
        return inventoryItem;
    }
}
