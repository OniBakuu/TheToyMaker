using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{

    public List<Item> toys;
    
    private static StorageManager Instance;
   
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
    
    //Adds items to storage/toybin
    public void AddItems(Item obj)
    {
        toys.Add(obj);
    }
}
