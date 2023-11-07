using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicador : MonoBehaviour
{
    public GameObject rangeIndicator;
    public GameObject rangeIndicator2;
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
        rangeIndicator2.SetActive(true);
        mostrarRango=true;
    }

    private void OcultarRango()
    {
        rangeIndicator.SetActive(false);
        rangeIndicator2.SetActive(false);
        mostrarRango=false;
    }




}
