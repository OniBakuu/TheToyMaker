using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    
    private int inventorySlots = 20;
    public List<Item> invItems;
    
    
    // Start is called before the first frame update
    void Start()
    {
        invItems.Capacity = inventorySlots;
    }

    //Adds items to inventory
    public void AddItems(Item obj)
    {
        if (invItems.Count < inventorySlots)
        {
            invItems.Add(obj);
        }
        
    }

    public void RemoveItems(Item obj)
    {
        if (invItems.Contains(obj))
        {
            invItems.Remove(obj);
        }
    }
}
