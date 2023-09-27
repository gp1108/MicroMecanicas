using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PreviewPrefabSize : MonoBehaviour
{
    public int prefabSize;
    public bool validposition;

    //Dimensiones del prefab
    //Si el prefabSize= 0 el prefab tiene de tamaño 1xYx1
    //Si el prefabSize= 1 el prefab tiene de tamaño 2xYx2
    //Si el prefabSize= 3 el prefab tiene de tamaño 3xYx3


    

    void Update()
    {
        if (prefabSize == 0)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, -transform.up,  out hit ,0.4f ))
            {
                if(hit.collider.CompareTag("Node"))
                {
                    
                    if(hit.collider.gameObject.GetComponent<Nodes>().constructed == false)
                    {
                        Debug.Log("·esto es un nodo");
                        validposition = true;
                    }
                    else
                    {
                        validposition = false;

                    }

                }
                
                
            }
            
        }
        else if(prefabSize == 1)
        {
            //PENDIENTE DE COMPROBACION MATEMATICA
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3( transform.position.x-1,transform.position.y, transform.position.z-1), -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1), -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), -transform.up, out hit, 0.4f))
            {
                if (hit.collider.CompareTag("Node"))
                {

                    if (hit.collider.gameObject.GetComponent<Nodes>().constructed == false)
                    {
                        Debug.Log("·esto es un nodo");
                        validposition = true;
                    }
                    else
                    {
                        validposition = false;

                    }

                }


            }

        }
        else if(prefabSize ==2)
        {
            //nO FUNCIONA , DIBUJAR LOS RAYOS Y ANALIAR QUE PASA
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z - 1.5f), -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z - 1.5f), -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z + 1.5f), -transform.up, out hit, 0.4f) &&
                Physics.Raycast(new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z + 1.5f), -transform.up, out hit, 0.4f))
            {
                if (hit.collider.CompareTag("Node"))
                {

                    if (hit.collider.gameObject.GetComponent<Nodes>().constructed == false)
                    {
                        Debug.Log("·esto es un nodo");
                        validposition = true;
                    }
                    else
                    {
                        validposition = false;

                    }

                }


            }
        }
    }
}
