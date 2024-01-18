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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            opciones = GameObject.Find("Opciones");
            Debug.Log("Pausa");

            if (buildMenu.GetComponent<BuildMenuButton>().buildMenuActive == false && researchMenu.GetComponent<ResearchMenu>().researchMenuActive == false)
            {
                Debug.Log("Activar panel de pausa");
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            }
            else if (pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == true)
            {
                Debug.Log("Desactivar panel de pausa");
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            }
            if (MenuInicio.giveMeReference.opcionesIngame == true && pause.GetComponent<PauseMenuEnabled>().pauseMenuActive == false)
            {
                pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
                MenuInicio.giveMeReference.opcionesIngame = false;
                opciones.SetActive(false);
                SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
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
