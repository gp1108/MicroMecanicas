using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyColor : MonoBehaviour
{
    private GameObject canvas;
    [SerializeField] private Material changeColor;
    private Color originalColor;

    private void Start()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer childRenderer in childRenderers)
        {
            originalColor = childRenderers[0].material.color;
            childRenderer.material.color = originalColor;
        }
    }

    private void OnMouseEnter()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (canvas.GetComponent<BuildMenuButton>().destroyModeActive == true)
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
    }

    private void OnMouseExit()
    {
        Renderer[] childRenderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer childRenderer in childRenderers)
        {
            originalColor = childRenderers[0].material.color;
            childRenderer.material.color = originalColor;
        }
    }
}
