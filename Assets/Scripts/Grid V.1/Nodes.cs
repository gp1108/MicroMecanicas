using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Material highLightedColor;
    public Material defaultColor;

    private Renderer _rednerer;

    public GameObject prefab;
    

    private Vector3 offset;
    public bool constructed;

    private void Start()
    {
        _rednerer = GetComponent<Renderer>();
        offset = new Vector3(0, 0.0f, 0); //El offset deberia ser independiente a cada scriptable object
        constructed = false;

    }

    private void OnMouseDown()
    {
        
        if (constructed == true)
        {
            Debug.Log("Ya has contruido previamente ahi!!!");
        }
        else 
        {
            
            BuildManager.dameReferencia.PlaceStucture(transform.position);
            //Instantiate(prefab, transform.position + offset, Quaternion.identity);
            constructed = true;
        }
        
    }

    private void OnMouseEnter()
    {
        _rednerer.material = highLightedColor;
    }
    private void OnMouseExit()
    {
        _rednerer.material = defaultColor;
    }


}
