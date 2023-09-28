using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUpdater : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Node")
        {
            
            collision.gameObject.GetComponent<Nodes>().constructed = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.tag == "Node")
        {
            
            collision.gameObject.GetComponent<Nodes>().constructed = false;
        }

    }
}
