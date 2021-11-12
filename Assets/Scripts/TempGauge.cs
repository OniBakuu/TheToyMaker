using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempGauge : MonoBehaviour
{

    private float baseGauge = 90;
    private float gauge;
    public Text tempGauge;

    public GameObject player;


    public void Start()
    {
        player = GameObject.Find("Player");
        
        PlayerClothesCheck();
        gauge = baseGauge;
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

    private void PlayerClothesCheck()
    {
        if (player.GetComponent<Inventory>().mittens)
        {
            baseGauge += 25;
        }

        if (player.GetComponent<Inventory>().hat)
        {
            baseGauge += 25;
        }

        if (player.GetComponent<Inventory>().coat)
        {
            baseGauge += 40;
        }
    }

    
    public void ModifyTemp(float val)
    {
        gauge += val;
    }
    
}
