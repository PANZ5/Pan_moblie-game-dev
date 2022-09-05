using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public string itemType;
    public int itemHold;

    public int sellGold;

    [TextArea(1, 2)]
    public string itemDescription;
    
}
