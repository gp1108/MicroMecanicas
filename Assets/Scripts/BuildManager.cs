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

    //Esta booleana es el nexo entre el preview system y el buildmanager, es decir , aprovecho el cambio de color para asi determinar si se puede o no construir
    private bool _canbuild;

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

                
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.material = aviableInstance;
                    _canbuild = true;
                }

            }
            else
            {
                Renderer[] childRenderers = previewPrefab.GetComponentsInChildren<Renderer>();

                
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.material = unAviableInstance;
                    _canbuild = false;
                }
                
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
        if(_canbuild == true)
        {
            Instantiate(_structures[_structureIndex], position, Quaternion.identity);

            foreach (GameObject _wall in Walls)
            {
                _wall.gameObject.GetComponent<WallCheck>().DoWallDraw();
            }
        }
        else
        {
            return;
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
