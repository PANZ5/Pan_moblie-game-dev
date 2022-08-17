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
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && crop.growStage <= 3)
        {
            crop.Growing();
            timer = crop.growGap;
            crop.Print();
        }
    }

    public void Reset()
    {
        crop.growStage = 0;
        crop.SetUpGrowGap(0);
        timer = crop.growGap;
        isMature = false;
        crop.Print();
    }

    // check if crop is mature
    public void CheckHarvest()
    {
        if (crop.growStage == 4)
        {
            isMature = true;
        }
    }

    // optimize harvesting
    private void OnMouseDown()
    {
        plot.GetComponent<PlotsManager>().Harvesting();
    }
}
