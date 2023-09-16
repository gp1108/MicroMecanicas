using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager Referencia;

    public static BuildManager dameReferencia
    {
        get
        {
            if (Referencia == null)
            {
                GameObject nuevo = new GameObject("BuildManager");
                nuevo.AddComponent<BuildManager>();
                Referencia = nuevo.GetComponent<BuildManager>();
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
}
