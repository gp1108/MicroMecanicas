using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicador : MonoBehaviour
{
    public GameObject rangeIndicator;
    public GameObject rangeIndicator2;
    //public GameObject InfoPanel;
    private bool mostrarRango = false;

    // Start is called before the first frame update
    void Start()
    {
        Ocultar();
    }

    private void OnMouseEnter()
    {
        Mostrar();
    }

    private void OnMouseExit()
    {
        Ocultar();
    }

    private void Mostrar()
    {
        rangeIndicator.SetActive(true);
        rangeIndicator2.SetActive(true);
        //InfoPanel.SetActive(true);
        mostrarRango=true;
    }

    private void Ocultar()
    {
        rangeIndicator.SetActive(false);
        rangeIndicator2.SetActive(false);
        //InfoPanel.SetActive(false);
        mostrarRango=false;
    }




}
