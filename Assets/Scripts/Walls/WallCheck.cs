using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField]private GameObject _wallCubeX;
    [SerializeField] private GameObject _wallCubeMinusX;
    [SerializeField] private GameObject _wallCubeZ;
    [SerializeField] private GameObject _wallCubeMinusZ;
    private void Start()
    {

        BuildManager.dameReferencia.Muro(this.gameObject);
        
    }
    public void DoWallDraw()
    {
        //RIGHT
        Ray rayRight = new Ray(transform.position + new Vector3(0.45f, 0, 0), Vector3.right);
        RaycastHit hitRight;

        if (Physics.Raycast(rayRight,out hitRight, 0.55f))
        {

            _wallCubeX.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
            _wallCubeX.transform.gameObject.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            _wallCubeX.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            _wallCubeX.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

       

        //LEFT
        Ray rayLeft;
        RaycastHit hitLeft;
        rayLeft = new Ray(transform.position + new Vector3(-0.45f, 0, 0), Vector3.left);

        if (Physics.Raycast(rayLeft, out hitLeft, 0.55f))
        {
            _wallCubeMinusX.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
            _wallCubeMinusX.transform.gameObject.GetComponent<BoxCollider>().enabled = true;
            
        }
        else
        {
            _wallCubeMinusX.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            _wallCubeMinusX.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        //FORWARD
        Ray rayForward;
        RaycastHit hitForward;
        rayForward = new Ray(transform.position + new Vector3(0, 0, 0.45f), Vector3.forward);
 
        if (Physics.Raycast(rayForward, out hitForward, 0.55f))
        {
            _wallCubeZ.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
            _wallCubeZ.transform.gameObject.GetComponent<BoxCollider>().enabled = true;
            
        }
        else
        {
            _wallCubeZ.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            _wallCubeZ.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        //BACK
        Ray rayBack;
        rayBack = new Ray(transform.position + new Vector3(0, 0, -0.45f), Vector3.back);
        RaycastHit hitBack;

        if (Physics.Raycast(rayBack, out hitBack, 0.55f))
        {
            _wallCubeMinusZ.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
            _wallCubeMinusZ.transform.gameObject.GetComponent<BoxCollider>().enabled = true;

        }
        else
        {
            _wallCubeMinusZ.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            _wallCubeMinusZ.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        
    }
}
