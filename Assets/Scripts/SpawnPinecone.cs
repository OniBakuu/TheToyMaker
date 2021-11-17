using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPinecone : MonoBehaviour
{
    public GameObject pinecone;
    public Transform tree;
    private Gatherable treeGather;

    private List<Vector3> treePoints = null;
    void Start()
    {
        treePoints.Capacity = 4;
        tree = gameObject.GetComponentInParent<Transform>();
        treeGather = GetComponentInParent<Gatherable>();
        treePoints.Add(new Vector3(tree.position.x + 1, tree.position.y, 0));
        treePoints.Add(new Vector3(tree.position.x -1, tree.position.y, 0));
        treePoints.Add(new Vector3(tree.position.x, tree.position.y + 1, 0));
        treePoints.Add(new Vector3(tree.position.x, tree.position.y - 1, 0));
    }
    
    void Update()
    {
        if (treeGather.gathered)
        {
            GeneratePinecone();
        }
    }

    private void GeneratePinecone()
    {
        int rand = 0;
        
        for (int i = 0; i < treePoints.Count; i++)
        {
            rand = Random.Range(0, 100);
            if (rand <= 30)
            {
                Instantiate(pinecone, treePoints[i], quaternion.identity);
            }
        }
        
    }
}
