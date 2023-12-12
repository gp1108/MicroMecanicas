using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField][Range(1,10)]private float _cameraSpeed;
    [SerializeField][Range(1,10)]private float _cameraSpeedHorizontal;
    private float _scrollInputAmount;
    public float velocidadRotacion = 60.0f;
    [SerializeField]private Camera _mainCamera;
    private Vector3 puntoImpacto;

    [Header("Referencias a menus")]
    public GameObject buildMenu;
    public GameObject researchMenu;
    public GameObject pause;


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


        //Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            

            if (buildMenu.GetComponent<BuildMenuButton>().buildMenuActive == true)
            {
                buildMenu.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
            }
            else if (researchMenu.GetComponent<ResearchMenu>().researchMenuActive == true)
            {
                researchMenu.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
            }
            else if (buildMenu.GetComponent<BuildMenuButton>().buildMenuActive == false && researchMenu.GetComponent<ResearchMenu>().researchMenuActive == false)
            {
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                SoundManager.dameReferencia.PlayClipByName(clipName:"Sfx");
            }
            else if (pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == true)
            {
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                SoundManager.dameReferencia.PlayClipByName(clipName: "Sfx");
            }

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

        GetRaycastPosition();
        CameraRotation();

    }

    private void GetRaycastPosition() 
    {
        Ray rayFromMouse = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            /*
            if (Physics.Raycast(_mainCamera.transform.position , _mainCamera.transform.forward, out hit , Mathf.Infinity)) // Cambiar el raycast a rayFromMouse y ponerle el hit y el math ininity
            {

                puntoImpacto = hit.point;

                
            }
            */

            
        }

        if (Physics.Raycast(rayFromMouse, out hit, Mathf.Infinity))
        {
            puntoImpacto = hit.point;
        }

    }

    private void CameraRotation()
    {

      

        if (Input.GetKey(KeyCode.Q))
        {

            transform.RotateAround(puntoImpacto, Vector3.up, 55 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(puntoImpacto, Vector3.up, -55 * Time.deltaTime);
        }
    }

}
