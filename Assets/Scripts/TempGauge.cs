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
    public GameObject wocheManager;
    public GameObject door;


    public void Start()
    {
        player = GameObject.Find("Player");
        wocheManager = GameObject.Find("WocheManager");
        door = GameObject.Find("Door");
        
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
            player.GetComponent<Inventory>().ClearInventory();
            door.GetComponent<Door>().ChangeScene();
            //start coroutine for display YOU FROZE 
            wocheManager.GetComponent<WocheManager>().EndDay();
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
