using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject menu;
    public GameObject opciones;
    public GameObject controles;
    public GameObject pausa;

    [Header("Sound")]
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    public void NuevaPartida()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        soundManager.ControlAudios(0, 1f);
    }
    
    public void CargarPartida()
    {
        //SceneManager.LoadScene(1);
    }
    public void Opciones()
    {
        menu.gameObject.SetActive(false);
        opciones.gameObject.SetActive(true);
        soundManager.ControlAudios(0, 1f);
    }

    public void Volver()
    {
        menu.gameObject.SetActive(true);
        opciones.gameObject.SetActive(false);
    }

    public void ControlesVolver()
    {
        controles.gameObject.SetActive(false);
        opciones.gameObject.SetActive(true);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Controles()
    {
        opciones.gameObject.SetActive(false);
        controles.gameObject.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausa.gameObject.SetActive(false);
        soundManager.ControlAudios(0, 1f);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
