using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyColor : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Material changeColor;
    private Color originalColor;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer childRenderer in childRenderers)
        {
            originalColor = childRenderers[0].material.color;
            childRenderer.material.color = originalColor;
        }
    }

    private void OnMouseEnter()
    {
        
        if (canvas.GetComponent<BuildMenuButton>().destroyModeActive == true)
        {
            Debug.Log("Modo destruir");
            cambiarColor();
        }
        else
        {
            return;
        }
    }

    private void OnMouseExit()
    {
        volverColorOri();
    }

    public void cambiarColor()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer childRenderer in childRenderers)
            {
            if (gameObject.tag == "Wall")
            {
                    Debug.Log("Enter");
                    childRenderer.enabled = true;
                    childRenderer.material = changeColor;
            }
            else
            {
                if (gameObject.tag == "BaseTurret")
                {
                    Debug.Log("Enter");
                    childRenderer.material = changeColor;
                }
                else if (this.gameObject.tag == "OtherTurret")
                {
                    Debug.Log("Enter");
                    childRenderer.material = changeColor;
                }
                else if (this.gameObject.tag == "Taller")
                {
                    Debug.Log("Enter");
                    childRenderer.material = changeColor;
                }
                else if (this.gameObject.tag == "SniperTurret")
                {
                    Debug.Log("Enter");
                    childRenderer.material = changeColor;
                }
                else if (this.gameObject.tag == "LaserTurret")
                {
                    Debug.Log("Enter");
                    childRenderer.material = changeColor;
                }
                else if (this.gameObject.tag == "Mine")
                {
                    Debug.Log("Enter");
                    childRenderer.material = changeColor;
                }
            }
        }
    }

    public void volverColorOri()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer childRenderer in childRenderers)
        {
            originalColor = childRenderers[0].material.color;
            childRenderer.material.color = originalColor;
        }
    }
}
