using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsManager : MonoBehaviour
{
    public Crops crop;
    float timer;
    public GameObject plot;

    [HideInInspector]
    public bool isMature = false;

    [HideInInspector]
    public int harvestGold = 0;

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
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && growStage <= 3)
        {
            Growing();
            RenewSprite();
            timer = growGap;
            Print();
        }
    }

    public void Reset()
    {
        growStage = 0;
        SetUpGrowGap(0);
        RenewSprite();
        timer = growGap;
        isMature = false;
        harvestGold = crop.sellGold;
        Print();
    }

    // check if crop is mature
    public void CheckHarvest()
    {
        if (growStage == 4)
        {
            isMature = true;
        }
    }

    public void RenewSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = crop.cropSprites[growStage];
    }

    public void Print()
    {
        // print info for testing
        Debug.Log($"{crop.cropName}, now is stage {currentStage}");
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
                growGap = crop.sprout_gtime;
                break;
            case (int) Grow.sprout:
                currentStage = "sprout";
                growGap = crop.small_gtime;
                break;
            case (int) Grow.small:
                currentStage = "small";
                growGap = crop.medium_gtime;
                break;
            case (int) Grow.medium:
                currentStage = "medium";
                growGap = crop.mature_gtime;
                break;
            case (int) Grow.mature:
                currentStage = "mature";
                break;
            default:
                break;
        }
    }

}
