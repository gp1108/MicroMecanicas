using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonOpcionesFix : MonoBehaviour
{

    public void Boton()
    {
        MenuInicio.giveMeReference.OpcionesInGame();
    }

    public void BotonC()
    {
        MenuInicio.giveMeReference.Continue();
    }

    public void BotonQ()
    {
        MenuInicio.giveMeReference.Quit();
    }

}
