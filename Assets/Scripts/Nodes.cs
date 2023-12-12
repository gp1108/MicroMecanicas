using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nodes : MonoBehaviour
{
    public Material highLightedColor;
    public Material defaultColor;

    private Renderer _rednerer;

    
    public bool constructed;

    private void OnDisable()
    {
        _rednerer.material = defaultColor;
    }
    private void Start()
    {
       

        _rednerer = GetComponent<Renderer>();
        
        constructed = false;

        
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (constructed == true)
        {
            SoundManager.dameReferencia.PlayClipByName(clipName: "Error");
            Debug.Log("Ya has contruido previamente ahi!!!");

        }
        else
        {
            if (BuildManager.dameReferencia.buildCD == false)
            {
                BuildManager.dameReferencia.PlaceStucture(transform.position);
            }


            //constructed = true;
        }

  
    }

    private void OnMouseEnter()
    {
        _rednerer.material = highLightedColor;

        BuildManager.dameReferencia.SetPreviewGameObject();
        BuildManager.dameReferencia.GetPreviewPrefabPosition(transform.position + new Vector3(0, 0.2f, 0));
        
    }
    private void OnMouseExit()
    {
        _rednerer.material = defaultColor;
        
    }

    

}
