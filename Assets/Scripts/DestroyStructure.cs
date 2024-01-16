using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStructure : MonoBehaviour
{
    private GameObject canvas;

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
        bool isDestructiveModeActive = canvas.GetComponent<BuildMenuButton>().destroyModeActive;
        if (isDestructiveModeActive == true)
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
        volverColorOri();
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

    private void OnMouseUpAsButton()
    {
        
        
        if (canvas.GetComponent<BuildMenuButton>().destroyModeActive == true)
        {
            
            if(this.gameObject.tag == "Wall")
            {
                
                BuildManager.dameReferencia.RemoveAndWallUpdate(this.gameObject);
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                Destroy(this.gameObject, 0.15f);
                BuildManager.dameReferencia.PriceUpdate(0, false);
                SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                Destroy(this.gameObject, 0.15f);
                if(this.gameObject.tag == "BaseTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(1, false); //basicamente el indice que ocupa en el buildmenu button y falso por que debe disminuir el precio
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if(this.gameObject.tag == "OtherTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(2, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if (this.gameObject.tag == "Taller")
                {
                    BuildManager.dameReferencia.PriceUpdate(3, false);
                    gameManager.giveMeReference.numberOfLabs--;
                    gameManager.giveMeReference.MaxNumberOfResearchStructures();
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if (this.gameObject.tag == "SniperTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(4, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if (this.gameObject.tag == "LaserTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(5, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if (this.gameObject.tag == "Mine")
                {
                    BuildManager.dameReferencia.PriceUpdate(6, false);
                    gameManager.giveMeReference.numberOfMines--;
                    gameManager.giveMeReference.MaxNumberOfMines();
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if (this.gameObject.tag == "SlowTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(7, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }

            }
        }
        else
        {
            
            return;
            
        }
    }
}
