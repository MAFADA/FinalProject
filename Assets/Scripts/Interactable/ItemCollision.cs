using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollision : MonoBehaviour
{
    public UnityEvent OnCollidePlayer = new UnityEvent();
    public UnityEvent OnLeavePlayer = new UnityEvent();

    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    bool collected = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnCollidePlayer.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.F))
            {
                if(!collected)
                {
                    collected = true;
                    PickUpItem(0);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            OnLeavePlayer.Invoke();
        }
    }

    public void PickUpItem(int id)
    {
        inventoryManager.AddItem(itemsToPickUp[id]);
        Destroy(this.gameObject);
    }
}
