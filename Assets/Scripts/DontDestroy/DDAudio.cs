using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAudio : MonoBehaviour
{
    
    private static DDAudio Instance;

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
