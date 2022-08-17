using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotsManager : MonoBehaviour
{
    bool isPlanting = false;
    public GameObject plant;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isPlanting)
        {
            Harvesting();
            
            Debug.Log("Growing");
        }
        else
        {
            isPlanting = true;
            // reset plant/crop data before planted again
            plant.GetComponent<CropsManager>().Reset();
            plant.SetActive(true);

            Debug.Log("Planting");
        }
    }

    public void Harvesting()
    {
        plant.GetComponent<CropsManager>().CheckHarvest();

        // if the crop is mature, harvest it
        if (plant.GetComponent<CropsManager>().isMature)
        {
            plant.SetActive(false);
            isPlanting = false;
        }
    }
    
}
