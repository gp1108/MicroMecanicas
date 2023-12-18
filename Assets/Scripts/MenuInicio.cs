using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject menu;
    public GameObject opciones;
    public GameObject opcionesPanel;
    public GameObject controles;
    public GameObject pausa;
    public GameObject volume;
    //public GameObject opcionesCanvas;
    private bool enmenu;
    public bool opcionesIngame;

    private static MenuInicio _Reference;

    public static MenuInicio giveMeReference
    {
        get
        {

                return _Reference;

            
        }
    }

    /*public static MenuInicio giveMeReference
    {
        get
        {


            if (_Reference == null)
            {
                _Reference = FindObjectOfType<MenuInicio>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("Opciones");
                    _Reference = go.AddComponent<MenuInicio>();
                }
            }
            return _Reference;
        }
    }*/

    private void Awake()
    {
        _Reference = this;
        

        /*if (_Reference == null)
        {
            
        }*/

    }

    /*public static MenuInicio giveMeReference
    {
        get
        {
            return _Reference;
        }
    }*/

    public void Start()
    {
        Debug.Log("HOLA SOY EL START");
        if (SceneManager.GetSceneByBuildIndex(0).isLoaded)
        {
            enmenu = true;
            opcionesIngame = false;
        }
        //enmenu = true;
            /*
            //opcionesCanvas = GameObject.FindGameObjectWithTag("OptionsPanel");
            if(SceneManager.GetSceneByBuildIndex(0).isLoaded)
            {
                Debug.Log("sOY 0");
                enmenu = true;
            }
            if (SceneManager.GetSceneByBuildIndex(1).isLoaded)
            {
                enmenu = false;
                pausa = GameObject.Find("PauseScreen");
                //opcionesCanvas = GameObject.FindGameObjectWithTag("OptionsPanel");
                opcionesCanvas = GameObject.Find("Opciones");
                if (opcionesCanvas == null)
                {
                    Debug.Log(" Soy Nulo despues");
                }
                else
                {
                    Debug.Log(" no soy nulo despues" + opcionesCanvas + "Y de nombre: " + opcionesCanvas.name);
                }
                opcionesCanvas.SetActive(false);
            }

            */

    }

    public void NuevaPartida()
    {
        //volume.SetActive(true);
        Time.timeScale = 1;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        SceneManager.LoadScene(1);
        pausa = GameObject.Find("PauseScreen");
        opciones.SetActive(true);
    }
    
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log(level + "Soy LEVEL");
        if (level == 1)
        {
            
            enmenu = false;
            //opcionesCanvas = GameObject.FindGameObjectWithTag("OptionsPanel");
            opciones = GameObject.Find("Opciones");
            pausa = GameObject.Find("PauseScreen");
            if(opciones == null)
            {
                Debug.Log(" Soy Nulo despues");
            }
            else
            {
                Debug.Log(" no soy nulo despues" + opciones + "Y de nombre: " + opciones.name);
            }
            opciones.SetActive(false);
            Debug.Log("lul");

        }
        if (level == 0)
        {
            Debug.Log("sOY 0");
            //enmenu = true;

        }

    }
    

    private void Update()
    {
        Debug.Log(enmenu);
    }
    public void CargarPartida()
    {
        //SceneManager.LoadScene(1);
    }
    public void Opciones()
    {
        menu.gameObject.SetActive(false);
        opciones.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Volume()
    {
        volume.gameObject.SetActive(true);
        opcionesPanel.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Volver()
    {
        if (opcionesIngame == true && enmenu == false)
        {
            this.gameObject.SetActive(false);
            pausa.gameObject.SetActive(true);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            opcionesIngame = false;
        }
        if(enmenu == true)
        {
            menu.gameObject.SetActive(true);
            opciones.gameObject.SetActive(false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        /*else if(enmenu == false)
        {
            opciones.SetActive(false);
            pausa.gameObject.SetActive(true);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }*/
        
    }

    public void ControlesVolver()
    {
        controles.gameObject.SetActive(false);
        opcionesPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void VolumeReturn()
    {
        volume.gameObject.SetActive(false);
        opcionesPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Controles()
    {
        opcionesPanel.gameObject.SetActive(false);
        controles.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausa.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        SceneManager.LoadScene(0);  
    }

    public void OpcionesInGame()
    {
        GameObject Camaraa = GameObject.Find("Main Camera");
        pausa = Camaraa.GetComponent<CameraMovement>().pause;
        //pausa.gameObject.SetActive(false);
        pausa.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();

        if (opciones == null)
        {
            opciones = GameObject.Find("Opciones");
            this.gameObject.SetActive(true);
            opcionesIngame = true;
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        else
        {
            opciones = GameObject.Find("Opciones");
            //Debug.Log(" no soy nulo despues" + opciones + "Y de nombre: " + opciones.name);
            //opciones.SetActive(true);
            this.gameObject.SetActive(true);
            opcionesIngame = true;
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }

        this.gameObject.SetActive(true);
    }

    public void OpcionesReturnInGame()
    {
        opciones.SetActive(false);
        GameObject Camaraa = GameObject.Find("Main Camera");
        pausa = Camaraa.GetComponent<CameraMovement>().pause;
        pausa.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

}
