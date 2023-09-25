using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Material highLightedColor;
    public Material defaultColor;

    private Renderer _rednerer;

    
    public bool constructed;

    private void Start()
    {
        _rednerer = GetComponent<Renderer>();
        
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
