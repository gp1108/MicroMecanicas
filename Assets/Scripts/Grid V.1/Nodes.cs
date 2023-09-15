using System.Collections;
using System.Collections.Generic;
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
        //offset = new Vector3(0, 0.5f, 0); //El offset deberia ser independiente a cada scriptable object
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
            prefab.GetComponent<Walls>().IsConstructed();
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
