using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStructure : MonoBehaviour
{
    private GameObject canvas;
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
                SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                Destroy(this.gameObject, 0.15f);
                if(this.gameObject.tag == "BaseTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(1, false); //basicamente el indice que ocupa en el buildmenu button y falso por que debe disminuir el precio
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                }
                else if(this.gameObject.tag == "OtherTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(2, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                }
                else if (this.gameObject.tag == "Taller")
                {
                    BuildManager.dameReferencia.PriceUpdate(3, false);
                    gameManager.giveMeReference.numberOfLabs--;
                    gameManager.giveMeReference.MaxNumberOfResearchStructures();
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                }
                else if (this.gameObject.tag == "SniperTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(4, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                }
                else if (this.gameObject.tag == "LaserTurret")
                {
                    BuildManager.dameReferencia.PriceUpdate(5, false);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                }
                else if (this.gameObject.tag == "Mine")
                {
                    BuildManager.dameReferencia.PriceUpdate(6, false);
                    gameManager.giveMeReference.numberOfMines--;
                    gameManager.giveMeReference.MaxNumberOfMines();
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "destroy2");
                }

            }
        }
        else
        {
            
            return;
            
        }
    }
}
