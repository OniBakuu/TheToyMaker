using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Workbench : MonoBehaviour
{
    public bool atWork = false;
    public GameObject player;
    public GameObject toyBin;

    public InvSlot[] storageUISlot;
    
    public GameObject workUI;
    public GameObject matsPanel;
    public GameObject toysPanel;
    public GameObject equipPanel;
    public GameObject storagePanel;
    //public Text success;
    //public Text fail;

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
            // Toy crafting
            case "Figure":
                if (!HasRequiredMats(toys[0]))
                {
                    //StartCoroutine(ShowCraftFail()); 
                    break;
                }
                for (int i = 0; i < toys[0].woodCost; i++) 
                {
                   player.GetComponent<Inventory>().RemoveItems(workableItems[0]);
                }
                
                //StartCoroutine(ShowCraftSuccess());
                toyBin.GetComponent<StorageManager>().AddItems(toys[0]);
                break;
            
            case "BallNCup":
                if (!HasRequiredMats(toys[1]))
                {
                    //StartCoroutine(ShowCraftFail());  
                    break;
                }
                for (int i = 0; i < toys[1].woodCost; i++) 
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[0]);
                }
                
                for (int i = 0; i < toys[1].stringCost; i++) 
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[2]);
                }
                
                //StartCoroutine(ShowCraftSuccess());
                toyBin.GetComponent<StorageManager>().AddItems(toys[1]);
                break;
            
            case "Horse":
                if (!HasRequiredMats(toys[2]))
                {
                    //StartCoroutine(ShowCraftFail());
                    break;
                }
                for (int i = 0; i < toys[2].woodCost; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[0]);
                }

                for (int i = 0; i < toys[2].stringCost; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[2]);
                }

                for (int i = 0; i < toys[2].dyeCost; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[3]);
                }
                
                //StartCoroutine(ShowCraftSuccess());
                toyBin.GetComponent<StorageManager>().AddItems(toys[2]);
                break;
            
            // Material crafting
            case "String":
                if (!HasRequiredMats(workableItems[2]))
                {
                    //StartCoroutine(ShowCraftFail()); 
                    break;
                }
                for (int i = 0; i < workableItems[2].woolCost; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }
                
                //StartCoroutine(ShowCraftSuccess());
                player.GetComponent<Inventory>().AddItems(workableItems[2]);
                break;
            
            case "Dyes":
                if (!HasRequiredMats(workableItems[3]))
                {
                    break;
                }

                for (int i = 0; i < workableItems[3].pineconeCost; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[4]);
                }
                
                player.GetComponent<Inventory>().AddItems(workableItems[3]);
                break;
            
            // Equipment crafting
            case "Mittens":
                int mittenWool = 0;
                for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
                {
                    if (player.GetComponent<Inventory>().invItems[i] != null)
                    {
                        if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Wool"))
                        {
                            mittenWool++;
                        }
                    }
            
                }

                if (mittenWool < 4) {break;}
                
                for (int i = 0; i < 4; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }
                
                //StartCoroutine(ShowCraftSuccess());
                player.GetComponent<Inventory>().mittens = true;
                break;
            
            case "Hat":
                int hatWool = 0;
                for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
                {
                    if (player.GetComponent<Inventory>().invItems[i] != null)
                    {
                        if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Wool"))
                        {
                            hatWool++;
                        }
                    }
            
                }

                if (hatWool < 6) {break;}
                
                for (int i = 0; i < 6; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }
                
                //StartCoroutine(ShowCraftSuccess());
                player.GetComponent<Inventory>().hat = true;                
                break;
            
            case "Coat":
                int coatWool = 0;
                for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
                {
                    if (player.GetComponent<Inventory>().invItems[i] != null)
                    {
                        if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Wool"))
                        {
                            coatWool++;
                        }
                    }
            
                }

                if (coatWool < 10) {break;}
                
                for (int i = 0; i < 10; i++)
                {
                    player.GetComponent<Inventory>().RemoveItems(workableItems[1]);
                }

                //StartCoroutine(ShowCraftSuccess());
                player.GetComponent<Inventory>().coat = true;                
                break;
        }
    }

    // Check inv to see if you actually have the required materials
    public bool HasRequiredMats(Item item)
    {
        int hasString = 0;
        int hasWool = 0;
        int hasWood = 0;
        int hasDyes = 0;
        int hasPinecone = 0;
        
        for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
        {
            if (player.GetComponent<Inventory>().invItems[i] != null)
            {
                if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("String"))
                {
                    hasString++;
                }
            }
            
        }
        
        for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
        {
            if (player.GetComponent<Inventory>().invItems[i] != null)
            {
                if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Wool"))
                {
                    hasWool++;
                }
            }
           
        }
        
        for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
        {
            if (player.GetComponent<Inventory>().invItems[i] != null)
            {
                if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Wood"))
                {
                    hasWood++;
                }
            }
            
        }
        
        for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
        {
            if (player.GetComponent<Inventory>().invItems[i] != null)
            {
                if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Dye"))
                {
                    hasDyes++;
                }
            }
           
        }
        
        for (int i = 0; i < player.GetComponent<Inventory>().invItems.Count; i++)
        {
            if (player.GetComponent<Inventory>().invItems[i] != null)
            {
                if (player.GetComponent<Inventory>().invItems[i].itemName.Equals("Pinecone"))
                {
                    hasPinecone++;
                }
            }
            
        }
        
        // If all the costs are met proceed with crafting
        if (hasString >= item.stringCost && hasWool >= item.woolCost && hasWood >= item.woodCost &&
            hasDyes >= item.dyeCost && hasPinecone >= item.pineconeCost)
        {
            return true;
        }
        else
        {
            return false;
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
        storagePanel.SetActive(false);
    }
    
    public void ShowToysPanel()
    {
        equipPanel.SetActive(false);
        matsPanel.SetActive(false);
        toysPanel.SetActive(true);
        storagePanel.SetActive(false);

    }

    public void ShowEquipmentPanel()
    {
        matsPanel.SetActive(false);
        toysPanel.SetActive(false);
        equipPanel.SetActive(true);
        storagePanel.SetActive(false);

    }

    public void ShowStoragePanel()
    {
        matsPanel.SetActive(false);
        toysPanel.SetActive(false);
        equipPanel.SetActive(true);
        SetStorageSlots();
        storagePanel.SetActive(true);

    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            atWork = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            atWork = false;
        }
    }

    private IEnumerator ShowCraftFail()
    {
        //fail.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        //fail.gameObject.SetActive(false);
    }
    private IEnumerator ShowCraftSuccess()
    {
        //success.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        //success.gameObject.SetActive(false);
    }
    
    private void SetStorageSlots()
    {

        for (int i = 0; i < toyBin.GetComponent<StorageManager>().toys.Count; i++)
        {
            if (toyBin.GetComponent<StorageManager>().toys[i])
            {
                Debug.Log(i);
                storageUISlot[i].invText.text = toyBin.GetComponent<StorageManager>().toys[i].itemName;
                storageUISlot[i].invImage.overrideSprite = toyBin.GetComponent<StorageManager>().toys[i].GetComponent<SpriteRenderer>().sprite;
                storageUISlot[i].invPanel.SetActive(true);
            }
            else
            {
                storageUISlot[i].invPanel.SetActive(false);
            }
        }
    }
}
