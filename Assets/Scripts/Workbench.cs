using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    private bool atWork = false;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

   
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            atWork = true;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked");
    }
}
