using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    private int maxTreeNum = 15;

    public GameObject tree;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public GameObject spawnPoint;
    
    private Vector3 spawnCoord;

    // Start is called before the first frame update
    void Start()
    {
        spawnCoord = spawnPoint.transform.position;
        GenerateTrees();
    }

    public void GenerateTrees()
    {
        for (int i = 0; i < maxTreeNum; i++)
        {
            int rand = Random.Range(0, 100);
            if (rand <= 50)
            {
                Instantiate(tree, GetRandomPos(), tree.transform.rotation);
            }
        }
    }

    public Vector3 GetRandomPos()
    {
        Vector3 spawn = Vector3.zero;
        float xOffset = Random.Range(xMin, xMax);
        float yOffset = Random.Range(yMin, yMax);

        spawn = new Vector3(spawnCoord.x + xOffset, spawnCoord.y+yOffset, spawnCoord.z);
        

        return spawn;
    }
}
