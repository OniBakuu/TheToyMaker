using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

   private static DontDestroy Instance;
   
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

