using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    
    private int inventorySlots = 20;
    public List<Item> invItems;

    public List<InvSlot> invUISlots;
    public GameObject invUI;
    public Text invCounter;
    private bool showingInv = false;

    public int heldMarkers = 0;
    public Item wood;
    public GameObject marker;
    public Text markerText;
    public GameObject player;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlaceMarkers();
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
            SetMarkersText();
            invUI.SetActive(true);
            showingInv = true;
        }
        
    }

    public void ClearInventory()
    {
        for (int i = 0; i < inventorySlots; i++)
        {
            invItems[i] = null;
        }
    }

    // Goes through invSlots and either turns off that slot or gives it the right info
    private void SetInvSlots()
    {
        int count = 0;
        
        for (int i = 0; i < inventorySlots; i++)
        {
            if (invItems[i])
            {
                invUISlots[i].invText.text = invItems[i].itemName;
                invUISlots[i].invImage.overrideSprite = invItems[i].GetComponent<SpriteRenderer>().sprite;
                invUISlots[i].invPanel.SetActive(true);
                count++;
            }
            else
            {
                invUISlots[i].invPanel.SetActive(false);
            }
        }

        invCounter.text = count + "/20";
    }

    public void MakeMarkers()
    {
        if (invItems.Contains(wood))
        {
            int index = invItems.IndexOf(wood);
            invItems[index] = null;
            SetInvSlots();
            heldMarkers += 4;
            SetMarkersText();
        }

        
    }

    private void PlaceMarkers()
    {
        if (heldMarkers >= 1)
        {
            Instantiate(marker, player.transform.position, quaternion.identity);
            heldMarkers--;
        }
    }

    private void SetMarkersText()
    {
        markerText.text = "Markers:" + heldMarkers;
    }
}
