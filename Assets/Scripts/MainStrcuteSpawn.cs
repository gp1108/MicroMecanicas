using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStrcuteSpawn : MonoBehaviour
{
    private bool _readyToMove;
    void Start()
    {
        _readyToMove = false;
    }

  
    void Update()
    {
        
        RaycastHit hit1, hit2, hit3, hit4, hit5, hit6, hit7, hit8, hit9;
        if (Physics.Raycast(transform.position, -transform.up, out hit1, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit2, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit3, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit4, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit5, 0.4f) &&

            Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit6, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z + 1f), -transform.up, out hit7, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit8, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z - 1f), -transform.up, out hit9, 0.4f))
        {


            if (hit1.collider.CompareTag("Node") &&
                hit2.collider.CompareTag("Node") &&
                hit3.collider.CompareTag("Node") &&
                hit4.collider.CompareTag("Node") &&
                hit5.collider.CompareTag("Node") &&
                hit6.collider.CompareTag("Node") &&
                hit7.collider.CompareTag("Node") &&
                hit8.collider.CompareTag("Node") &&
                hit9.collider.CompareTag("Node"))
            {
                Debug.Log("Posicion Correcta");
                this.gameObject.GetComponent<MainStrcuteSpawn>().enabled = false;

            }
        }
        else
        {
            if (!Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z + 1f), -transform.up, out hit7, 0.4f) && _readyToMove == true)
            {
                Debug.Log("-z");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z - 1);
                

            }
            else if (!Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z - 1f), -transform.up, out hit9, 0.4f) && _readyToMove == true)
            {
                Debug.Log("+z");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z + 1);
                
            }
            else if (!Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit8, 0.4f) && _readyToMove == true)
            {
                Debug.Log("-x");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x + 1, transform.position.y + 6, transform.position.z);
                
            }
            else if (!Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit6, 0.4f) && _readyToMove == true)
            {
                Debug.Log("+x");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x - 1, transform.position.y + 6, transform.position.z);
                
            }
            else if (!Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit5, 0.4f) && _readyToMove == true)
            {
                Debug.Log("+x+z");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x - 1, transform.position.y + 6, transform.position.z - 1);
                
            }
            else if (!Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit4, 0.4f) && _readyToMove == true)
            {
                Debug.Log("-x+z");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x + 1, transform.position.y + 6, transform.position.z - 1);
                
            }
            else if (!Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit3, 0.4f) && _readyToMove == true)
            {
                Debug.Log("+x-z");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x - 1, transform.position.y + 6, transform.position.z + 1);
                
            }
            else if (!Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit2, 0.4f) && _readyToMove == true)
            {
                Debug.Log("-x-z");
                _readyToMove = false;
                transform.position = new Vector3(transform.position.x + 1, transform.position.y + 6, transform.position.z + 1);
                
            }
        }
        /*
        else if (Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit4, 0.4f) && _readyToMove == true ||
               Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit5, 0.4f) && _readyToMove == true ||
               Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z + 1f), -transform.up, out hit7, 0.4f) && _readyToMove == true)
        {
            Debug.Log("-z");
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 1);
            _readyToMove = false;

        }
        else if (Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit2, 0.4f) && _readyToMove == true ||
                Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit3, 0.4f) && _readyToMove == true ||
                Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z - 1f), -transform.up, out hit9, 0.4f) && _readyToMove == true)
        {
            Debug.Log("+z");
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);
            _readyToMove = false;
        }
        else if (Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit8, 0.4f) && _readyToMove == true)
        {
            Debug.Log("-x");
            transform.position = new Vector3(transform.position.x - 1, transform.position.y + 2, transform.position.z);
            _readyToMove = false;
        }
        else if (Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit6, 0.4f) && _readyToMove == true)
        {
            Debug.Log("+x");
            transform.position = new Vector3(transform.position.x + 1, transform.position.y + 2, transform.position.z);
            _readyToMove = false;
        }
        */

    }

    private void OnCollisionEnter(Collision collision)
    {
        _readyToMove = true;
        Debug.Log(_readyToMove);
    }
    private void OnCollisionExit(Collision collision)
    {
        _readyToMove = false;
    }
}

