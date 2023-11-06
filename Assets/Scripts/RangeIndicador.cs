using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicador : MonoBehaviour
{
    public GameObject rangeIndicator;
    private bool mostrarRango = false;

    // Start is called before the first frame update
    void Start()
    {
        OcultarRango();
    }

    private void OnMouseEnter()
    {
        MostrarRango();
    }

    private void OnMouseExit()
    {
        OcultarRango();
    }

    private void MostrarRango()
    {
        rangeIndicator.SetActive(true);
        mostrarRango=true;
    }

    private void OcultarRango()
    {
        rangeIndicator.SetActive(false);
        mostrarRango=false;
    }




}
