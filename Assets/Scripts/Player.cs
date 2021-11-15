using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool beenOutside = false;


    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("OutSide"))
        {
            beenOutside = true;
        }
        
    }
}
