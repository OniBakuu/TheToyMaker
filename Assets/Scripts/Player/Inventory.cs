using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    
    private int inventorySlots = 20;
    public List<Item> invItems;

    public List<InvSlot> invUISlots;
    public GameObject invUI;
    private bool showingInv = false;

    [NonSerialized]
    public bool mittens = false;
    [NonSerialized]
    public bool hat = false;
    [NonSerialized]
    public bool coat = false;
    

    // Start is called before the first frame update
    void Start()
    {
        invItems.Capacity = inventorySlots;
        invUISlots.Capacity = inventorySlots;
        for (int i = 0; i < inventorySlots; i++)
        {
            invItems.Add(null);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInv();
        }
    }

    //Adds items to inventory
    public void AddItems(Item obj)
    {
        for (int i = 0; i < inventorySlots; i++)
        {
            if (invItems[i] == null)
            {
                invItems[i] = obj;
                break;
            }
        }
        
    }

    public void RemoveItems(Item obj)
    {
        if (invItems.Contains(obj))
        {
            int index = invItems.IndexOf(obj);
            invItems[index] = null;
        }
    }

    private void ToggleInv()
    {
        if (showingInv)
        {
            invUI.SetActive(false);
            showingInv = false;
        }
        else
        {
            SetInvSlots();
            invUI.SetActive(true);
            showingInv = true;
        }
        
    }

    // Goes through invSlots and either turns off that slot or gives it the right info
    private void SetInvSlots()
    {
        for (int i = 0; i < inventorySlots; i++)
        {
            if (invItems[i])
            {
                invUISlots[i].invText.text = invItems[i].itemName;
                invUISlots[i].invImage = invItems[i].itemSprite;
                invUISlots[i].invPanel.SetActive(true);
            }
            else
            {
                invUISlots[i].invPanel.SetActive(false);
            }
        }
    }
}
