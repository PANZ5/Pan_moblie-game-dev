using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Items thisItem;
    public Inventory playerBag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            // destroy this item on world
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        // if player's bag doesn't contain this item, add it to bag
        if (!playerBag.itemList.Contains(thisItem))
        {
            // add new item to inventory
            playerBag.itemList.Add(thisItem);
            // create new slot
            InventorySystem.CreateNewItem(thisItem);
        }
        // otherwise, add the amount of this item
        else
        {
            // add hold
            thisItem.itemHold++;
        }
    }
}
