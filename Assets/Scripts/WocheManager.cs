using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WocheManager : MonoBehaviour
{

    public int days;
    public int week = 7;
    public int weeklyScore;

    public List<Item> toybin;
    public GameObject bed;
    public Player player;



    public void Start()
    {
    }
    
    public void EndDay()
    {
        days += 1;
        player.beenOutside = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bed = GameObject.Find("Bed");
            if (bed.GetComponent<AtBed>().atBed)
            {
                if (days > week)
                {
                    EndWeek();    
                }
                else
                {
                    EndDay();
                }
            }
        }
    }

    private void EndWeek()
    {
        days = 0;
        weeklyScore = 0;
        
        toybin = GameObject.Find("StorageManager").GetComponent<StorageManager>().toys;
        for (int i = 0; i < toybin.Count; i++)
        {
            weeklyScore += toybin[i].score;
        }
        
        // Do UI to show score here
        Debug.Log(weeklyScore);
    }

}
