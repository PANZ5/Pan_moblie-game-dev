using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Items slotItem;
    public Image slotIcon;
    public TMP_Text slotAmount;
    //public TMP_Text slotDescription;

    int slotHold;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slotItem == null)
        {
            slotIcon.enabled = false;
        }
        else
        {
            slotHold = slotItem.itemHold;
            slotAmount.text = slotHold.ToString();
            slotIcon.enabled = true;
            slotIcon.sprite = slotItem.itemIcon;
            //slotDescription.text = slotItem.itemDescription;
        }
    }
}
