using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUpdater : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSize;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Node")
        {
            collision.gameObject.GetComponent<Nodes>().constructed = true;
            if (_prefabSize.GetComponent<PreviewPrefabSize>().CanConstruct() == true)
            {
                BuildManager.dameReferencia.buildCD = false;
            }
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.tag == "Node")
        {
            
            collision.gameObject.GetComponent<Nodes>().constructed = false;
        }
        if(this.gameObject.tag == "Wall")
        {
            
        }

    }
}
