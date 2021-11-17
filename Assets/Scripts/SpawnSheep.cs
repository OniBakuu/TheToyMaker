using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSheep : MonoBehaviour
{

    private int maxSheepNum = 7;

    public GameObject sheep;
    public GameObject dumboSheep;
    public GameObject deer;
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
        GenerateDeer();
    }

    public void GenerateSheep()
    {
        for (int i = 0; i < maxSheepNum; i++)
        {
            int rand = Random.Range(0, 100);
            if (rand <= 30)
            {
                rand = Random.Range(0, 100);
                if (rand <= 10)
                {
                    Instantiate(dumboSheep, GetRandomPos(), quaternion.identity);
                }
                else
                {
                    Instantiate(sheep, GetRandomPos(), quaternion.identity);
                }
                
            }
            
        }
    }

    public void GenerateDeer()
    {
        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(0, 100);
            if (rand <= 5)
            {
                Instantiate(deer, GetRandomPos(), quaternion.identity);
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
