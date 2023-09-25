using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField][Range(1,10)]private float _cameraSpeed;
    [SerializeField][Range(1,10)]private float _cameraSpeedHorizontal;
    private float _scrollInputAmount;
    public float velocidadRotacion = 60.0f;
    [SerializeField]private Camera _mainCamera;

    private void Start()
    {
        _cameraSpeed = 8;
        
    }

    private void Update()
    {
        //Control de velocidad de la camara
        //Conseguir que se mueva mas suavemente la camara
        if (_cameraSpeed > 10)
        {
            _cameraSpeed = 10;
        }
        if (_cameraSpeedHorizontal > 10)
        {
            _cameraSpeedHorizontal = 10;
        }

        
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
                _cameraSpeedHorizontal = 0;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
                _cameraSpeed = 0;
        }

        //MOVIMIENTO DE LA CAMARA

        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            _cameraSpeed += 0.2f;
            transform.Translate(new Vector3(0,1,1) * Time.deltaTime * _cameraSpeed, Space.Self);
        }
        
        //Backwards
        if (Input.GetKey(KeyCode.S))
        {
            _cameraSpeed += 0.2f;
            transform.Translate(new Vector3(0, -1, -1) * Time.deltaTime * _cameraSpeed, Space.Self);
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            _cameraSpeedHorizontal += 0.2f;
            //transform.position += Vector3.left * Time.deltaTime * _cameraSpeedHorizontal;
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * _cameraSpeedHorizontal, Space.Self);
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            _cameraSpeedHorizontal += 0.2f;
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * _cameraSpeedHorizontal, Space.Self);
        }

        



        //ZOOM

        _scrollInputAmount = Input.GetAxis("Mouse ScrollWheel") *1;
        
        if( _scrollInputAmount < 0 && transform.position.y < 20)
        {
            
            transform.position -= transform.forward;
        }
        else if(_scrollInputAmount > 0 && transform.position.y > 10)
        {
            transform.position += transform.forward;
        }

        CameraRotation();

    }



    private void CameraRotation()
    {

        Ray rayFromMouse = _mainCamera.ScreenPointToRay(Input.mousePosition);

        // Variable para almacenar informaci�n sobre la colisi�n.
        RaycastHit hit;

        // Realiza la detecci�n de colisiones con la capa del suelo.
        if (Physics.Raycast(rayFromMouse, out hit))
        {
            
            Vector3 puntoImpacto = hit.point;

            if(Input.GetKey(KeyCode.Q))
            {
                
                transform.RotateAround(puntoImpacto, Vector3.up, 2);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.RotateAround(puntoImpacto, Vector3.up, -2);
            }
        }
    }

}
