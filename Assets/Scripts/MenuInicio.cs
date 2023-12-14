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
    public GameObject volume;
    public GameObject volumenInGame;
    public GameObject volumePanel;

    public void NuevaPartida()
    {
        volumePanel.SetActive(true);
        Time.timeScale = 1;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        Invoke("FuncionParaCargarLaPartida",1);
    }

    public void FuncionParaCargarLaPartida()
    {
        SceneManager.LoadScene(1);
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
        volumePanel.SetActive(true);
        volume.gameObject.SetActive(true);
        opciones.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Volver()
    {
        menu.gameObject.SetActive(true);
        opciones.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void ControlesVolver()
    {
        controles.gameObject.SetActive(false);
        opciones.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void VolumeReturn()
    {
        volumePanel.SetActive(false);
        volume.gameObject.SetActive(false);
        opciones.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Controles()
    {
        opciones.gameObject.SetActive(false);
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

    public void VolumenInGame()
    {
        volumenInGame.SetActive(true);
        pausa.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void VolumenReturnInGame()
    {
        volumenInGame.gameObject.SetActive(false);
        pausa.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

}
