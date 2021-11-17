using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{

    public List<Item> toys;
    
    private static StorageManager Instance;

    void Start()
    {
        toys.Capacity = 40;
        for (int i = 0; i < toys.Capacity; i++)
        {
            toys.Add(null);
        }
    }
    
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
        for (int i = 0; i < toys.Capacity; i++)
        {
            if (toys[i] == null)//loop logic wrong made 40 ducks
            {
                toys[i] = obj;
                break;
            }
        }
    }
}
