using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Material highLightedColor;
    public Material defaultColor;

    private Renderer _rednerer;

    public GameObject turretPrefab;
    private Vector3 offset;
    private bool _constructed;

    private void Start()
    {
        _rednerer = GetComponent<Renderer>();
        offset = new Vector3(0, 0.5f, 0); //El offset deberia ser independiente a cada scriptable object
        _constructed = false;
    }

    private void OnMouseDown()
    {
        if (_constructed == true)
        {
            Debug.Log("Ya has contruido previamente ahi!!!");
        }
        else 
        {
            Instantiate(turretPrefab, transform.position + offset, Quaternion.identity);
            _constructed = true;
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
