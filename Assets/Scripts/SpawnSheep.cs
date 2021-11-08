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
    private Vector3 spawnCoord;

    // Start is called before the first frame update
    void Start()
    {
        // GenerateSheep();
    }

    public void GenerateSheep()
    {
        for (int i = 0; i < maxSheepNum; i++)
        {
            int rand = Random.Range(0, 10);
            if (rand <= 3)
            {
                // Change spawn for sheep to be random within a certain area
                Instantiate(sheep, Vector3.zero, quaternion.identity);
            }
        }
    }
}
