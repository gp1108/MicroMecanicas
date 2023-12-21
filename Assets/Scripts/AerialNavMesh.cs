using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class AerialNavMesh : MonoBehaviour
{
    public GameObject perlingNoiseGen;
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.gameObject.transform.localScale = new Vector3(perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeX + 15, 0.1f, perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeZ + 15);
        //this.gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();
        transform.position = new Vector3((perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeX)/2, 6, (perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeZ)/2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
