using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStructure : MonoBehaviour
{
    private GameObject canvas;
    public GameObject destroyUI;
    public GameObject mainCamera;
    

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        destroyUI = GameObject.Find("Destroy?");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        StartCoroutine("trackCamera");
        
    }

    private void OnMouseEnter()
    {
       
        

        bool isDestructiveModeActive = canvas.GetComponent<BuildMenuButton>().destroyModeActive;
        if (isDestructiveModeActive == true)
        {
            destroyUI.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1.5f, this.gameObject.transform.position.z);
           
        }
    }


    
    private void OnMouseExit()
    {
        
        bool isDestructiveModeActive = canvas.GetComponent<BuildMenuButton>().destroyModeActive;
        if (isDestructiveModeActive == true)
        {
            destroyUI.transform.position = Vector3.zero + Vector3.down * 10;
        }
    }

    
    private void OnMouseUpAsButton()
    {
        
        canvas = GameObject.FindGameObjectWithTag("Canvas");
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
                else if (this.gameObject.tag == "ExplosiveMine")
                {
                    BuildManager.dameReferencia.PriceUpdate(8, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
                else if (this.gameObject.tag == "MachineGunTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(9, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "DestroyBuild");
                }
               

            }
        }
        else
        {
            
            return;
            
        }
    }

    IEnumerator trackCamera()
    {
        while (true)
        {
            destroyUI.transform.LookAt(mainCamera.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
       
    }
}
