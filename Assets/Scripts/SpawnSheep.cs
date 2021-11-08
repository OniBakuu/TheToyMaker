using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSheep : MonoBehaviour
{

    private int maxSheepNum = 7;

    public GameObject sheep;
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
        GenerateSheep();
    }

    public void GenerateSheep()
    {
        for (int i = 0; i < maxSheepNum; i++)
        {
            int rand = Random.Range(0, 10);
            if (rand <= 3)
            {
                // Change spawn for sheep to be random within a certain area
                Instantiate(sheep, GetRandomPos(), sheep.transform.rotation);
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
