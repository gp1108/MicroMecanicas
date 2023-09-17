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
            transform.position += Vector3.forward * Time.deltaTime *_cameraSpeed;

        }
        
        //Backwards
        if (Input.GetKey(KeyCode.S))
        {
            _cameraSpeed += 0.2f;
            transform.position += Vector3.back * Time.deltaTime * _cameraSpeed;
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            _cameraSpeedHorizontal += 0.2f;
            transform.position += Vector3.left * Time.deltaTime * _cameraSpeedHorizontal;
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            _cameraSpeedHorizontal += 0.2f;
            transform.position += Vector3.right * Time.deltaTime * _cameraSpeedHorizontal;
        }

        



        //ZOOM

        _scrollInputAmount = Input.GetAxis("Mouse ScrollWheel") *1;
        
        if( _scrollInputAmount < 0 && transform.position.y < 30)
        {
            
            transform.position -= transform.forward;
        }
        else if(_scrollInputAmount > 0 && transform.position.y > 5)
        {
            transform.position += transform.forward;
        }
            
        

    }
}
