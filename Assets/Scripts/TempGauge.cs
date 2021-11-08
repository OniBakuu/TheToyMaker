using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempGauge : MonoBehaviour
{

    public float gauge = 180;
    public Text tempGauge;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Warmth gauge ticks down over time
        if (gauge > 0)
        {
            gauge -= Time.deltaTime;
            tempGauge.text = "Warmth:"+Mathf.Round(gauge);
        }
        else
        {
            // Put passout/gameover script here
            Debug.Log("ded");
        }
    }
}
