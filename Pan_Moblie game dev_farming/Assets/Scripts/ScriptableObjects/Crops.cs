using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop")]
public class Crops : ScriptableObject
{
    public string cropName;
    
    public List<Sprite> cropSprites;

    public float sprout_gtime;
    public float small_gtime;
    public float medium_gtime;
    public float mature_gtime;

    public int sellGold;
}
