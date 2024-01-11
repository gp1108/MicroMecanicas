using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonOpcionesFix : MonoBehaviour
{
    public GameObject pause;

    public void Boton()
    {
        MenuInicio.giveMeReference.OpcionesInGame();
        MenuInicio.giveMeReference.opcionesIngame = true;
        pause.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();
        Time.timeScale = 0f;
    }

    public void BotonC()
    {
        MenuInicio.giveMeReference.Continue();
    }

    public void BotonQ()
    {
        MenuInicio.giveMeReference.Quit();
    }

    public void ContinueButtonIngame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
