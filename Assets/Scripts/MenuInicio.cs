using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public GameObject menu;
    public GameObject opciones;
    public GameObject controles;
    
    public void NuevaPartida()
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
}
