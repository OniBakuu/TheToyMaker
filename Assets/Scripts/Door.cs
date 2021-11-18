using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class Door : MonoBehaviour
{
    private Scene curScene;

    public bool atDoor = false;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        curScene = SceneManager.GetActiveScene();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (atDoor && !player.GetComponent<Player>().beenOutside)
            {
                ChangeScene();
            }

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("OutSide"))
            {
                if (atDoor)
                {
                    ChangeScene();
                }
            }
            
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            atDoor = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            atDoor = false;
        }
    }


    public void ChangeScene()
    {
        if (curScene.name == "Inside")
        {
            SceneManager.LoadScene(2);
            player.GetComponent<Rigidbody2D>().position = new Vector2(-5, 0);
        }
        else
        {
            SceneManager.LoadScene(1);
            player.GetComponent<Rigidbody2D>().position = new Vector2(0, -6);

        }
    }

}
