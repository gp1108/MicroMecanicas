using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUpdater : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger enter");
        if(other.gameObject.tag=="Node")
        {
            Debug.Log("trigger enter cambiando funcion del nodo");
            other.gameObject.GetComponent<Nodes>().constructed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Node")
        {
            other.gameObject.GetComponent<Nodes>().constructed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter");
        if (collision.gameObject.tag == "Node")
        {
            Debug.Log("collision enter78577");
            collision.gameObject.GetComponent<Nodes>().constructed = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision enter");
        if (collision.gameObject.tag == "Node")
        {
            Debug.Log("collision enter78577");
            collision.gameObject.GetComponent<Nodes>().constructed = false;
        }

    }
}
