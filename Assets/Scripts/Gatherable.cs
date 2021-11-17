using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatherable : MonoBehaviour
{
    public int hits = 0;
    public int hitsRequired;

    public bool closeEnough = false;
    public bool gathered = false;

    public Item gatherItem;
    private GameObject player;
    public SpriteRenderer sheepSelf;
    public Sprite shearedSheep;
    public Sprite shearedDSheep;

    public String itemType;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closeEnough = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            closeEnough = false;
        }
    }

    //Tracks clicks on object
    public void OnMouseDown()
    {
        
        // Only gatherable if close enough
        if (closeEnough)
        {
            if (!gathered)
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
            
        }
        
    }

    //Checks what item is gathered then adds it to inv
    private void Gathered()
    {
        
        player.GetComponent<Inventory>().AddItems(gatherItem);

        if (itemType.Equals("Sheep"))
        {
            sheepSelf.sprite = shearedSheep;
        }

        if (itemType.Equals("DumboSheep"))
        {
            sheepSelf.sprite = shearedDSheep;
        }

        if (!itemType.Equals("Sheep") && !itemType.Equals("DumboSheep"))
        {
            Destroy(gameObject);
        }

        gathered = true;

    }
}
