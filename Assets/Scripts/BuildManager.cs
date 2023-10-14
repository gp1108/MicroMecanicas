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
    public bool buildCD;

    [Header("PREVIEW SYSTEM")]
    //PreviewSystem
    [SerializeField] private GameObject[] _previewStructures;
    private GameObject previewPrefab;
    private Vector3 previewPrefabPosition;
    private int lastIndex;
    [SerializeField] private Material aviableInstance;
    [SerializeField] private Material unAviableInstance;
    public GameObject buildPanel;
    private Canvas canvas;
    public GameObject navmeshUpdater;

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

    public void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        bool isDestroyModeActive = canvas.GetComponent<BuildMenuButton>().destroyModeActive;

        if (previewPrefab != null)
        {
            previewPrefab.transform.position = previewPrefabPosition;


            //Color del prefab
            if (previewPrefab.GetComponent<PreviewPrefabSize>().validposition == true && buildPanel.activeSelf && isDestroyModeActive == false)
            {
                Renderer[] childRenderers = previewPrefab.GetComponentsInChildren<Renderer>();

                
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.enabled = true;
                    childRenderer.material = aviableInstance;
                    _canbuild = true;
                }

            }
            else if (previewPrefab.GetComponent<PreviewPrefabSize>().validposition == false && buildPanel.activeSelf && isDestroyModeActive == false)
            {
                Renderer[] childRenderers = previewPrefab.GetComponentsInChildren<Renderer>();

                
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.enabled = true;
                    childRenderer.material = unAviableInstance;
                    _canbuild = false;
                }
                
            }
            else if(!buildPanel.activeSelf || isDestroyModeActive == true)
            {
                Renderer[] childRenderers = previewPrefab.GetComponentsInChildren<Renderer>();
                foreach (Renderer childRenderer in childRenderers)
                {
                    childRenderer.enabled = false;
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
            if (_wall != null)
            {
                _wall.gameObject.GetComponent<WallCheck>().DoWallDraw();
            }
            
            
        }
    }

    
    public void RemoveAndWallUpdate(GameObject Wall)
    {

        Walls.Remove(Wall);
        foreach (GameObject _wall in Walls)
        {
            if (_wall != null)
            {
                _wall.gameObject.GetComponent<WallCheck>().DoWallDraw();
                
            }
        }
        
    }
    

    public void GetStructurePrefabIndex(int index)
    {
        _structureIndex = index;
        
    }

    public void PlaceStucture(Vector3 position)
    {
        
        if(_canbuild == true && buildCD == false) 
        {
            Instantiate(_structures[_structureIndex], position, Quaternion.identity);

            foreach (GameObject _wall in Walls)
            {
                if(_wall != null)
                {
                    _wall.gameObject.GetComponent<WallCheck>().DoWallDraw();
                }
                
            }
            buildCD = true;
            
        }
        else
        {
            return;
        }


    }
    //NavmeshSystem
    public void NavmeshUpdate()
    {
        navmeshUpdater.GetComponent<NavMeshBake>().doNavMeshBake();
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
