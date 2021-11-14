using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtBed : MonoBehaviour
{
    public bool atBed = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        atBed = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        atBed = false;
    }
}
