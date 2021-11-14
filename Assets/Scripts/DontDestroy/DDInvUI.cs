using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDInvUI : MonoBehaviour
{
 
    private static DDInvUI Instance;
   
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
}
