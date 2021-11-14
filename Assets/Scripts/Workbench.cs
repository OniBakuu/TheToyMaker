using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Workbench : MonoBehaviour
{
    private bool atWork = false;
    public GameObject player;
    public GameObject toyBin;
    
    public GameObject workUI;
    public GameObject matsPanel;
    public GameObject toysPanel;
    public GameObject equipPanel;

    public Item[] workableItems;
    public Item[] toys;


    public void Start()
    {
        player = GameObject.Find("Player");
        toyBin = GameObject.Find("StorageManager");
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowWork();
        }
    }

    public void CraftItem(string itemType)
    {
        switch (itemType)
        {
            case "Figure":
                for (int i = 0; i < toys[0].woodCost; i++) 
                {
                   player.GetComponent<Inventory>().RemoveItems(workableItems[0]);
                }
                
                toyBin.GetComponent<StorageManager>().AddItems(toys[0]);
                break;
            
            case "BallNCup":
                for (int i = 0; i < toys[1].woodCost; i++) 
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[0]);
                }
                
                for (int i = 0; i < toys[1].stringCost; i++) 
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[3]);
                }
                
                toyBin.GetComponent<StorageManager>().AddItems(toys[1]);
                break;
            
            case "String":
                for (int i = 0; i < workableItems[2].woolCost; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }
                player.GetComponent<Inventory>().AddItems(workableItems[2]);
                break;
            
            case "Mittens":
                for (int i = 0; i < 4; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }

                player.GetComponent<Inventory>().mittens = true;
                break;
            
            case "Hat":
                for (int i = 0; i < 6; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }

                player.GetComponent<Inventory>().hat = true;                break;
            
            case "Coat":
                for (int i = 0; i < 10; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }

                player.GetComponent<Inventory>().coat = true;                break;
        }
    }
    
    public void ShowWork()
    {
        if (atWork)
        {
            workUI.SetActive(true);
            toysPanel.SetActive(true);
        }
    }

    public void CloseWork()
    {
        workUI.SetActive(false);
    }

    public void ShowMatsPanel()
    {
        equipPanel.SetActive(false);
        matsPanel.SetActive(true);
        toysPanel.SetActive(false);
    }
    
    public void ShowToysPanel()
    {
        equipPanel.SetActive(false);
        matsPanel.SetActive(false);
        toysPanel.SetActive(true);
    }

    public void ShowEquipmentPanel()
    {
        matsPanel.SetActive(false);
        toysPanel.SetActive(false);
        equipPanel.SetActive(true);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            atWork = true;
        }
    }
    
}
