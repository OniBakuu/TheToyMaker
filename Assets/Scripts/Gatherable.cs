using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatherable : MonoBehaviour
{
    public int hits = 0;
    public int hitsRequired;

    public GameObject[] gatherItems;
    private GameObject player;

    public String itemType;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    //Tracks clicks on object
    public void OnMouseDown()
    {
        if (hits < hitsRequired-1)
        {
            hits++;
        }
        else
        {
            Gathered();
        }
    }

    //Checks what item is gathered then adds it to inv
    public void Gathered()
    {
        //Replace with switch statement
        if (itemType.Equals("Tree"))
        {
            player.GetComponent<Inventory>().AddItems(gatherItems[0]);
        }
        
        Destroy(gameObject);
    }
}
