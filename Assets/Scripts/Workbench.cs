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

    public Item[] workableItems;
    public Item[] finishedItems;


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
                for (int i = 0; i < finishedItems[0].woodCost; i++) 
                {
                   player.GetComponent<Inventory>().RemoveItems(workableItems[0]);
                }
                
                toyBin.GetComponent<StorageManager>().AddItems(finishedItems[0]);
                break;
        }
    }
    
    public void ShowWork()
    {
        workUI.SetActive(true);
        toysPanel.SetActive(true);
    }

    public void ShowMatsPanel()
    {
        matsPanel.SetActive(true);
        toysPanel.SetActive(false);
    }
    
    public void ShowToysPanel()
    {
        matsPanel.SetActive(false);
        toysPanel.SetActive(true);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            atWork = true;
        }
    }
    
}
