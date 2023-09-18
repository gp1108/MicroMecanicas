using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager Referencia;
    [SerializeField]private GameObject[] _structures;
    private int _structureIndex;

    public static BuildManager dameReferencia
    {
        get
        {
           

            if (Referencia == null)
            {
                Referencia = FindObjectOfType<BuildManager>();
                if (Referencia == null)
                {
                    GameObject go = new GameObject("BuildManager");
                    Referencia = go.AddComponent<BuildManager>();
                }
            }
            return Referencia;
        }
    }
    List<GameObject> Walls = new List<GameObject>();
    public void Muro(GameObject Wall)
    {
        Walls.Add(Wall);
        foreach (GameObject _wall in Walls)
        {
            _wall.gameObject.GetComponent<WallCheck>().DoWallDraw();
        }
    }      


    public void GetStructurePrefabIndex(int index)
    {
        _structureIndex = index;
        
    }

    public void PlaceStucture(Vector3 position)
    {

        Instantiate(_structures[_structureIndex], position, Quaternion.identity);

        foreach (GameObject _wall in Walls)
        {
            _wall.gameObject.GetComponent<WallCheck>().DoWallDraw();
        }


    }

    
}
