using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonOpcionesFix : MonoBehaviour
{
    public GameObject buildMenu;
    public GameObject researchMenu;
    public GameObject pause;
    public GameObject opciones;

    private void Awake()
    {
        opciones = GameObject.Find("Opciones");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            //Debug.Log("Pausa");

            if (buildMenu.GetComponent<BuildMenuButton>().buildMenuActive == false && researchMenu.GetComponent<ResearchMenu>().researchMenuActive == false)
            {
                //Debug.Log("Activar panel de pausa");
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            }
            else if (pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == true)
            {
                //Debug.Log("Desactivar panel de pausa");
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            }
            
            if (MenuInicio.giveMeReference.opcionesIngame == true && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false)
            {
                //Debug.Log("Desactivar panel de opciones");
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                MenuInicio.giveMeReference.opcionesIngame = false;
                opciones.SetActive(false);
                SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            }
            if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.volumePanelActive == true)
            {
                MenuInicio.giveMeReference.volume.gameObject.SetActive(false);
                MenuInicio.giveMeReference.volumePanelActive = false;
                MenuInicio.giveMeReference.opcionesIngame = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.controlPanelActive == true)
            {
                MenuInicio.giveMeReference.controles.gameObject.SetActive(false);
                MenuInicio.giveMeReference.controlPanelActive = false;
                MenuInicio.giveMeReference.opcionesIngame = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.BestiarioPanelActive == true)
            {
                MenuInicio.giveMeReference.BestiarioPanel.gameObject.SetActive(false);
                MenuInicio.giveMeReference.BestiarioPanelActive = false;
                MenuInicio.giveMeReference.opcionesIngame = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            else if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.RaptorPanelActive == true && MenuInicio.giveMeReference.BestiarioPanelActive == false)
            {
                MenuInicio.giveMeReference.RaptorPanel.gameObject.SetActive(false);
                MenuInicio.giveMeReference.RaptorPanelActive = false;
                MenuInicio.giveMeReference.BestiarioPanelActive = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            else if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.TricePanelActive == true && MenuInicio.giveMeReference.BestiarioPanelActive == false)
            {
                MenuInicio.giveMeReference.TriceratopsPanel.gameObject.SetActive(false);
                MenuInicio.giveMeReference.TricePanelActive = false;
                MenuInicio.giveMeReference.BestiarioPanelActive = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            else if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.PteroPanelActive == true && MenuInicio.giveMeReference.BestiarioPanelActive == false)
            {
                MenuInicio.giveMeReference.PterodactiloPanel.gameObject.SetActive(false);
                MenuInicio.giveMeReference.PteroPanelActive = false;
                MenuInicio.giveMeReference.BestiarioPanelActive = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            else if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.TRexPanelActive == true && MenuInicio.giveMeReference.BestiarioPanelActive == false)
            {
                MenuInicio.giveMeReference.TRexPanel.gameObject.SetActive(false);
                MenuInicio.giveMeReference.TRexPanelActive = false;
                MenuInicio.giveMeReference.BestiarioPanelActive = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            else if (MenuInicio.giveMeReference.opcionesIngame == false && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false && MenuInicio.giveMeReference.CompyPanelActive == true && MenuInicio.giveMeReference.BestiarioPanelActive == false)
            {
                MenuInicio.giveMeReference.CompsognathusPanel.gameObject.SetActive(false);
                MenuInicio.giveMeReference.CompyPanelActive = false;
                MenuInicio.giveMeReference.BestiarioPanelActive = true;
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
            }
            else if (buildMenu.GetComponent<BuildMenuButton>().buildMenuActive == true)
            {
                buildMenu.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
            }
            else if (researchMenu.GetComponent<ResearchMenu>().researchMenuActive == true)
            {
                researchMenu.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
            }

        }
    }

    public void BotonOpciones()
    {
        Debug.Log("Activar panel de opciones");
        MenuInicio.giveMeReference.OpcionesInGame();
        MenuInicio.giveMeReference.opcionesIngame = true;
        pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
        Time.timeScale = 0f;
    }

    public void BotonContinuePause()
    {
        pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
        Time.timeScale = 1f;
    }

    public void BotonQuit()
    {
        MenuInicio.giveMeReference.QuitInGame();
        pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
        Time.timeScale = 0f;
    }

    public void ContinueButtonIngame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }


}
