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
    public GameObject externalSkillTree;
    public GameObject newGameSettings;
    public GameObject LoadingPanel;

    public GameObject warningPopUp;
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

    

    private void Awake()
    {
        _Reference = this;
        

    }

    

    public void Start()
    {
        Time.timeScale = 1.0f;
        if (SceneManager.GetSceneByBuildIndex(0).isLoaded)
        {
            enmenu = true;
            opcionesIngame = false;
        }
        

    }

    public void NewGameSettings()
    {
        newGameSettings.SetActive(true);
        
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void ReturnFromNewGameSettings()
    {
        newGameSettings.SetActive(false);
        
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void NuevaPartida()
    {
        //volume.SetActive(true);
        Time.timeScale = 1;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        SceneManager.LoadScene(1);
        pausa = GameObject.Find("PauseScreen");
        opciones.SetActive(true);
        LoadingPanel.SetActive(true);
    }
    
    private void OnLevelWasLoaded(int level)
    {
        
        if (level == 1)
        {
            
            enmenu = false;
            //opcionesCanvas = GameObject.FindGameObjectWithTag("OptionsPanel");
            opciones = GameObject.Find("Opciones");
            pausa = GameObject.Find("PauseScreen");
            
            opciones.SetActive(false);


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
        
        
    }

    public void WarningBorrarDatos()
    {
        warningPopUp.gameObject.SetActive(true);
    }

    public void BorrarDatos()
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void CancelarBorrarDatos()
    {
        warningPopUp.gameObject.SetActive(false);
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

    public void ExternalSkillTree()
    {
        externalSkillTree.gameObject.SetActive(true);
        opcionesPanel.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }
    public void ExternalSkillTreeReturn()
    {
        externalSkillTree.gameObject.SetActive(false);
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

    public void QuitInGame()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        gameManager.giveMeReference.PlayerDead(); 
    }

    public void OpcionesInGame()
    {
        GameObject botonfix = GameObject.Find("Boton Fix");
        pausa = botonfix.GetComponent<BotonOpcionesFix>().pause;
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
            this.gameObject.SetActive(true);
            opcionesIngame = true;
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }

        this.gameObject.SetActive(true);
    }

    public void OpcionesReturnInGame()
    {
        opciones.SetActive(false);
        GameObject botonfix = GameObject.Find("Boton Fix");
        pausa = botonfix.GetComponent<BotonOpcionesFix>().pause;
        pausa.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

}
