using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;


public class MapGen : MonoBehaviour
{

    [Header("Map Parameters")]
    public int mapWidth;
    public int mapHeight;
    public int maxSheepSpawns;
    public GameObject sheepSpawner;
    public List<Vector3> sheepSpawnPoints;
    public int treeSpawns;
    public GameObject treeSpawner;
    
    public Tilemap Ground;

    [Header("Tile Lists")]
    public Tile[] tiles;
    public Tile[] other;


    // Start is called before the first frame update
    void Start()
    {
        PlaceGroundTiles();
        PlaceRocks();
        PlaceSpawns();
        PlaceGrass();
        PlaceFlowers();
    }

    // Places snow tiles
    private void PlaceGroundTiles()
    {
        for (int i = -mapHeight; i < mapHeight; i++)
        {
            for (int j = -mapWidth; j < mapWidth; j++)
            {
                Ground.SetTile(new Vector3Int(j, i, 0), tiles[Random.Range(0,tiles.Length)]);
            }
        }
    }

    // Places rock tiles around 
    private void PlaceRocks()
    {
        for (int i = -mapHeight; i < mapHeight; i++)
        {
            for (int j = -mapWidth; j < mapWidth; j++)
            {
                if (Random.Range(0, 100) <= 1)
                {
                    Ground.SetTile(new Vector3Int(j, i, 0),other[0]);

                }
            }
        }
    }
    
    // Places Random Spawn zones for things
    private void PlaceSpawns()
    {
        float x;
        float y ;
        
        for (int i = 0; i < maxSheepSpawns; i++)
        {
            
            x = Random.Range(-mapWidth + 25, mapWidth - 25);
            y = Random.Range(-mapHeight + 25, mapHeight - 25);
            // Dont want to spawn trees on the cabin so we pad it out
            if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(0, 0, 0)) > 8)
            {
                Instantiate(sheepSpawner,new Vector3(x, y, 0), Quaternion.identity);
                sheepSpawnPoints.Add(new Vector3(x,y,0));
            }
            
        }

        for (int i = 0; i < treeSpawns; i++)
        {
            x = Random.Range(-mapWidth + 25, mapWidth - 25);
            y = Random.Range(-mapHeight + 25, mapHeight - 25);
            
            // Dont want to spawn trees on the cabin so we pad it out
            if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(0, 0, 0)) > 17)
            {
                Instantiate(treeSpawner,new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }
    
    // Places grass tiles where sheep are
    private void PlaceGrass()
    {
        for (int i = -mapHeight; i < mapHeight; i++)
        {
            for (int j = -mapWidth; j < mapWidth; j++)
            {
                for (int k = 0; k < sheepSpawnPoints.Count; k++)
                {
                    if (Vector3.Distance(new Vector3Int(j,i,0), sheepSpawnPoints[k]) < 10)
                    {
                        if (Random.Range(0, 100) <= 50)
                        {
                            Ground.SetTile(new Vector3Int(j,i,0), other[Random.Range(1,3)]);
                        }
                        
                    }
                }
                    
            }
        }
    }

    private void PlaceFlowers()
    {
        for (int i = -mapHeight; i < mapHeight; i++)
        {
            for (int j = -mapWidth; j < mapWidth; j++)
            { if (Vector3.Distance(new Vector3Int(j,i,0), new Vector3(-5.23f, 2.44f, 0)) < 15)
                    {
                        if (Random.Range(0, 100) <= 3)
                        {
                            Ground.SetTile(new Vector3Int(j,i,0), other[Random.Range(4,other.Length)]);
                        }
                        
                    }
                
                    
            }
        }
    }
}
