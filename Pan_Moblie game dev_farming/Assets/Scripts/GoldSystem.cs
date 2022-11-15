using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldSystem : MonoBehaviour
{
    // gold managment setting
    public TMP_Text goldLabel;

    private int gold;
    public int Gold {

        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<TMP_Text>().text = gold.ToString();
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Gold = 100;
    }
}
