using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsManager : MonoBehaviour
{
    public Crops crop;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        crop.growStage = 0;
        crop.SetUpGrowGap(0);
        timer = crop.growGap;
        crop.Print();
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
}
