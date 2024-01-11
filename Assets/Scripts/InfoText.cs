using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InfoText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject _information;
    private TMP_Text _textInformation;
    private string _buton;
    private void Start()
    {
        _information = gameManager.giveMeReference._information;
        _textInformation=gameManager.giveMeReference._textInformation.GetComponent<TMP_Text>();
        _information.SetActive(false);
    }
    private void Update()
    {

    }
    public enum TipeButon
    {
        Walls,
        BaseTurret,
        OtherTurret,
        SniperTurret,
        LaserTurret,
        Taller,
        Mine,
    }
    private TipeButon _tipeButon;
    public void OnPointerEnter(PointerEventData eventData)
    {
        CheckName();
        _information.SetActive(true);
        _information.transform.position = this.transform.position - new Vector3(300,250,0);
     
        if (eventData.pointerEnter.GetComponent<Button>() != null)
        {
            _buton = eventData.pointerEnter.name;
            if (_buton == "Walls")
            {
                _tipeButon = TipeButon.Walls;
            }
            if (_buton == "BaseTurret")
            {
                _tipeButon= TipeButon.BaseTurret;
            }
            if (_buton== "OtherTurret")
            {
                _tipeButon=TipeButon.OtherTurret;
            }
            if (_buton == "SniperTurret")
            {
                _tipeButon = TipeButon.SniperTurret;
            }
            if (_buton == "LaserTurret")
            {
                _tipeButon = TipeButon.LaserTurret;
            }
            if (_buton == "Taller")
            {
                _tipeButon = TipeButon.Taller;
            }
            if (_buton == "Mine")
            {
                _tipeButon = TipeButon.Mine;
            }
        }
        else
        {
            _buton = eventData.pointerEnter.transform.parent.name;
            if (_buton == "Walls")
            {
                _tipeButon = TipeButon.Walls;
            }
            if (_buton == "BaseTurret")
            {
                _tipeButon = TipeButon.BaseTurret;
            }
            if (_buton == "OtherTurret")
            {
                _tipeButon = TipeButon.OtherTurret;
            }
            if (_buton == "SniperTurret")
            {
                _tipeButon = TipeButon.SniperTurret;
            }
            if (_buton == "LaserTurret")
            {
                _tipeButon = TipeButon.LaserTurret;
            }
            if (_buton == "Taller")
            {
                _tipeButon = TipeButon.Taller;
            }
            if (_buton == "Mine")
            {
                _tipeButon = TipeButon.Mine;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _information.SetActive(false);
    }
    public void CheckName()
    {
        switch (_tipeButon)
        {
            case TipeButon.Walls:

                _textInformation.text = "Esto es una prueba a <br> ver si funciona LUL";
                
                break;
            case TipeButon.BaseTurret:

                _textInformation.text = ("Funciona");
                
                break;
            case TipeButon.OtherTurret:
                
                break;
            case TipeButon.SniperTurret:
                
                break;
            case TipeButon.Taller:
                
                break;
            case TipeButon.Mine:
                
                break;
        }
    }
}
