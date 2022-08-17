using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop")]
public class Crops : ScriptableObject
{
    public string cropName;

    public float sprout_gtime;
    public float small_gtime;
    public float medium_gtime;
    public float mature_gtime;

    public int sellGold;
    
    [HideInInspector]
    public int growStage = 0;

    [HideInInspector]
    public float growGap;

    [HideInInspector]
    public string currentStage;

    enum Grow
    {
        seed,
        sprout,
        small,
        medium,
        mature
    }

    

    public void Print()
    {
        // print info for testing
        Debug.Log($"{cropName}, now is stage {currentStage}");
    }

    public void Growing()
    {
        growStage++;
        SetUpGrowGap(growStage);
    }

    public void SetUpGrowGap(int growStage)
    {
        // convert enum to int solution reference:
        // https://forum.unity.com/threads/switching-enum-int.321451/
        switch (growStage)
        {
            case (int) Grow.seed:
                currentStage = "seed";
                growGap = sprout_gtime;
                break;
            case (int) Grow.sprout:
                currentStage = "sprout";
                growGap = small_gtime;
                break;
            case (int) Grow.small:
                currentStage = "small";
                growGap = medium_gtime;
                break;
            case (int) Grow.medium:
                currentStage = "medium";
                growGap = mature_gtime;
                break;
            case (int) Grow.mature:
                currentStage = "mature";
                break;
            default:
                break;
        }
    }
}
