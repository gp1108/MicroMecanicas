using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStructure : MonoBehaviour
{
    private Canvas canvas;
    private void OnMouseUpAsButton()
    {
        
        canvas = FindObjectOfType<Canvas>();
        if (canvas.GetComponent<BuildMenuButton>().destroyModeActive == true)
        {
            
            if(this.gameObject.tag == "Wall")
            {
                
                BuildManager.dameReferencia.RemoveAndWallUpdate(this.gameObject);
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                Destroy(this.gameObject, 0.15f);
                
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
                Destroy(this.gameObject, 0.15f);
            }
        }
        else
        {
            
            return;
            
        }
    }
}
