using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;
    public bool navmeshON;
    

    public void doNavMeshBake()
    { 
        navMeshSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        navmeshON = false;
    }

    private void Update()
    {
        if(navmeshON == true)
        {
            navmeshON=false;
            doNavMeshBake();
        }

    }
}
