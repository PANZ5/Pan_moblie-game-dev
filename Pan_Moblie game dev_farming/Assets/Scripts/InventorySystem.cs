using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    static InventorySystem instance;

    public Inventory bag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public TMP_Text itemDescription;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        
        instance = this;
    }

    public static void CreateNewItem(Items item)
    {
        // when get a new item, appending a new slot
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform);
        // set this newSlot as child of slotGrid
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);

        // assign scriptable object data to slot
        newItem.slotItem = item;
        // newItem.slotIcon.sprite = item.itemIcon;
        // newItem.slotAmount.text = item.itemHold.ToString();
    }
}
