using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildManager : MonoBehaviour
{
    [Header("BUILDMANAGER")]
    private static BuildManager Referencia;
    [SerializeField]private GameObject[] _structures;
    private int _structureIndex;

    [Header("PREVIEW SYSTEM")]
    //PreviewSystem
    [SerializeField] private GameObject[] _previewStructures;
    private GameObject previewPrefab;
    private Vector3 previewPrefabPosition;
    private int lastIndex;
    [SerializeField] private Material aviableInstance;
    [SerializeField] private Material unAviableInstance;

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


    private void Update()
    {
        if(previewPrefab != null)
        {
            previewPrefab.transform.position = previewPrefabPosition;


            //Color del prefab
            if (previewPrefab.GetComponent<PreviewPrefabSize>().validposition == true)
            {
                Renderer[] childRenderers = previewPrefab.GetComponentsInChildren<Renderer>();

                // Itera a través de los renderers y cambia su material
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.material = aviableInstance;
                }

            }
            else
            {
                Renderer[] childRenderers = previewPrefab.GetComponentsInChildren<Renderer>();

                // Itera a través de los renderers y cambia su material
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.material = unAviableInstance;
                }
                //previewPrefab.GetComponent<Renderer>().material = unAviableInstance;
            }
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

    
    //PreviewSystem
    public void GetPreviewPrefabPosition(Vector3 position)
    {
        previewPrefabPosition = position;

        

    }

    public void SetPreviewGameObject()
    {
        
        if (previewPrefab == null)
        {
            previewPrefab = Instantiate(_previewStructures[_structureIndex], previewPrefabPosition, Quaternion.identity);
            lastIndex = _structureIndex;
        }
        else if(_structureIndex != lastIndex)
        {
            lastIndex = _structureIndex;
            Destroy(previewPrefab);
            previewPrefab = Instantiate(_previewStructures[_structureIndex], previewPrefabPosition, Quaternion.identity);
        }
        else
        {
            return;
        }

    }
    public void DestroyPreviewPrefab()
    {
        Destroy(previewPrefab);
    }
    
}
