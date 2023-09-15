using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Walls : MonoBehaviour
{
    //RIGHT
    Ray rayRight;
    RaycastHit hitRight;
    //LEFT
    Ray rayLeft;
    RaycastHit hitLeft;
    //FORWARD
    Ray rayForward;
    RaycastHit hitForward;
    //BACK
    Ray rayBack;
    RaycastHit hitBack;
    //DOWN
    Ray rayDown;
    RaycastHit hitDown;

    private int _index;

    [SerializeField]private GameObject[] _walls;

    private void Start()
    {
        //RIGHT
        rayRight = new Ray(transform.position, Vector3.right);
        //LEFT
        rayLeft = new Ray(transform.position, Vector3.left);
        //FORWARD
        rayForward = new Ray(transform.position, Vector3.forward);
        //BACK
        rayBack = new Ray(transform.position, Vector3.back);

        _index = 1;
        
    }

    /*
    private void Update()
    {
        //RIGHT
        if (!Physics.Raycast(rayRight, out hitRight, 1))
        {

            Debug.DrawRay(rayRight.origin, rayRight.direction * 1, Color.yellow);
            //Hacerse primero asi mismo
            //SI CHOCHAS , ALMACENAR NOMBRE Y ACTIVAR FUNCION WALL UPDATE DEL NOMBRE CHOCADO
        }

        //LEFT
        if (!Physics.Raycast(rayLeft, out hitLeft, 1))
        {

            Debug.DrawRay(rayLeft.origin, rayLeft.direction * 1, Color.yellow);
        }

        //FORWARD
        if (!Physics.Raycast(rayForward, out hitForward, 1))
        {

            Debug.DrawRay(rayForward.origin, rayForward.direction * 1, Color.yellow);
        }

        //BACK
        if (!Physics.Raycast(rayBack, out hitBack, 1))
        {

            Debug.DrawRay(rayBack.origin, rayBack.direction * 1, Color.yellow);
        }
    }
    */

    public void IsConstructed()
    {
        
        
        
        Vector3 mousePosition = Input.mousePosition;
        Camera mainCamera = Camera.main;
        Ray rayDown = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitDown;
        
        //DOWN
        if (Physics.Raycast(rayDown, out hitDown))
        {
            if(hitDown.transform.gameObject.GetComponent<Nodes>().constructed == false)
            {
                Debug.Log("HOLA");
                DoWallUpdate();
                Instantiate(_walls[_index], hitDown.transform.position + new Vector3(0,0.29f,0), Quaternion.identity);
            }
            else
            {
                return;
            }
            Debug.DrawRay(rayDown.origin, rayDown.direction * 1, Color.yellow);
           
        }
    }
    public void DoWallUpdate()
    {

        //0 HIT RAYCAST
        if (!Physics.Raycast(rayRight, out hitRight, 1) && !Physics.Raycast(rayLeft, out hitLeft, 1) && !Physics.Raycast(rayForward, out hitForward, 1) && !Physics.Raycast(rayBack, out hitBack, 1))
        {

            Debug.DrawRay(rayRight.origin, rayRight.direction * 1, Color.yellow);
            
            _index = 0;
            //Hacerse primero asi mismo
            //SI CHOCHAS , ALMACENAR NOMBRE Y ACTIVAR FUNCION WALL UPDATE DEL NOMBRE CHOCADO
        }

        //HORIZONTAL WALL(X) r y l
        if (Physics.Raycast(rayRight, out hitRight, 1) || Physics.Raycast(rayLeft, out hitLeft, 1) && !Physics.Raycast(rayForward, out hitForward, 1) && !Physics.Raycast(rayBack, out hitBack, 1))
        {
            
            hitRight.transform.gameObject.GetComponent<Walls>().DoWallUpdate();
            hitLeft.transform.gameObject.GetComponent<Walls>().DoWallUpdate();

            
            Debug.DrawRay(rayLeft.origin, rayLeft.direction * 1, Color.yellow);

            _index = 1;
        }

        //HORIZONTAL WALL(Z) f y b
        if (!Physics.Raycast(rayRight, out hitRight, 1) && !Physics.Raycast(rayLeft, out hitLeft, 1) && Physics.Raycast(rayForward, out hitForward, 1) || Physics.Raycast(rayBack, out hitBack, 1))
        {
            
            hitForward.transform.gameObject.GetComponent<Walls>().DoWallUpdate();
            hitBack.transform.gameObject.GetComponent<Walls>().DoWallUpdate();

            Debug.DrawRay(rayLeft.origin, rayLeft.direction * 1, Color.yellow);
            _index = 2;
        }

        //CORNER WALL(-X,-Z) l y b
        if (Physics.Raycast(rayBack, out hitBack, 1) && Physics.Raycast(rayLeft, out hitLeft, 1) && !Physics.Raycast(rayRight, out hitRight, 1) && !Physics.Raycast(rayForward, out hitForward, 1))
        {
            
            hitLeft.transform.gameObject.GetComponent<Walls>().DoWallUpdate();
            hitBack.transform.gameObject.GetComponent<Walls>().DoWallUpdate();


            Debug.DrawRay(rayBack.origin, rayBack.direction * 1, Color.yellow);
            _index = 3;
        }

        

    }
}


