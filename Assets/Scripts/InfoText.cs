using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InfoText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _information;
    public TMP_Text _textInformation;
    private string _buton;
    private bool _clic;
    private void Start()
    {
        if (_information != null)
        {
            _information.SetActive(false);
        }
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
        BasicTurret,
        moreDamageBasicTurret,
        moreHealthBasicTurret,
        moreRangeBasicTurret,
        unlockSlowTurret,
        moreSlowSlowTurret,
        moreHealthSlowTurret,
        moreRangeSlowTurret,
        unlockMineTurret,
        moreDamageMineTurret,
        moreRangeMineTurret,
        oneReseachPointExtra,
        moreGoldPerMine,
        startWithExtraGold,
        startWithExtraResearchPoints,
        Investigacion,
    }

    private TipeButon _tipeButon;
    public void OnPointerEnter(PointerEventData eventData)
    {
        CheckName();
        _clic = true;
        _information.transform.position = this.transform.position - new Vector3(300,250,0);
        StartCoroutine("Wait");
        if(eventData.pointerEnter.name== "Investigacion")
        {
            _tipeButon = TipeButon.Investigacion;
            _information.transform.position = this.transform.position - new Vector3(500, 500, 0);
        }
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
            if (_buton == "BasicTurret")
            {
                _tipeButon = TipeButon.BasicTurret;
            }
            if (_buton == "moreDamageBasicTurret")
            {
                _tipeButon = TipeButon.moreDamageBasicTurret;
            }
            if (_buton == "moreHealthBasicTurret")
            {
                _tipeButon = TipeButon.moreHealthBasicTurret;
            }
            if (_buton == "moreRangeBasicTurret")
            {
                _tipeButon = TipeButon.moreRangeBasicTurret;
            }
            if (_buton == "unlockSlowTurret")
            {
                _tipeButon = TipeButon.unlockSlowTurret;
            }
            if (_buton == "moreSlowSlowTurret")
            {
                _tipeButon = TipeButon.moreSlowSlowTurret;
            }
            if (_buton == "moreHealthSlowTurret")
            {
                _tipeButon = TipeButon.moreHealthSlowTurret;
            }
            if (_buton == "moreRangeSlowTurret")
            {
                _tipeButon = TipeButon.moreRangeSlowTurret;
            }
            if (_buton == "unlockMineTurret")
            {
                _tipeButon = TipeButon.unlockMineTurret;
            }
            if (_buton == "moreDamageMineTurret")
            {
                _tipeButon = TipeButon.moreDamageMineTurret;
            }
            if (_buton == "moreRangeMineTurret")
            {
                _tipeButon = TipeButon.moreRangeMineTurret;
            }
            if (_buton == "oneReseachPointExtra")
            {
                _tipeButon = TipeButon.oneReseachPointExtra;
            }
            if (_buton == "moreGoldPerMine")
            {
                _tipeButon = TipeButon.moreGoldPerMine;
            }
            if (_buton == "startWithExtraGold")
            {
                _tipeButon = TipeButon.startWithExtraGold;
            }
            if (_buton == "startWithExtraResearchPoints")
            {
                _tipeButon = TipeButon.startWithExtraResearchPoints;
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
            if (_buton == "BasicTurret")
            {
                _tipeButon = TipeButon.BasicTurret;
            }
            if (_buton == "moreDamageBasicTurret")
            {
                _tipeButon = TipeButon.moreDamageBasicTurret;
            }
            if (_buton == "moreHealthBasicTurret")
            {
                _tipeButon = TipeButon.moreHealthBasicTurret;
            }
            if (_buton == "moreRangeBasicTurret")
            {
                _tipeButon = TipeButon.moreRangeBasicTurret;
            }
            if (_buton == "unlockSlowTurret")
            {
                _tipeButon = TipeButon.unlockSlowTurret;
            }
            if (_buton == "moreSlowSlowTurret")
            {
                _tipeButon = TipeButon.moreSlowSlowTurret;
            }
            if (_buton == "moreHealthSlowTurret")
            {
                _tipeButon = TipeButon.moreHealthSlowTurret;
            }
            if (_buton == "moreRangeSlowTurret")
            {
                _tipeButon = TipeButon.moreRangeSlowTurret;
            }
            if (_buton == "unlockMineTurret")
            {
                _tipeButon = TipeButon.unlockMineTurret;
            }
            if (_buton == "moreDamageMineTurret")
            {
                _tipeButon = TipeButon.moreDamageMineTurret;
            }
            if (_buton == "moreRangeMineTurret")
            {
                _tipeButon = TipeButon.moreRangeMineTurret;
            }
            if (_buton == "oneReseachPointExtra")
            {
                _tipeButon = TipeButon.oneReseachPointExtra;
            }
            if (_buton == "moreGoldPerMine")
            {
                _tipeButon = TipeButon.moreGoldPerMine;
            }
            if (_buton == "startWithExtraGold")
            {
                _tipeButon = TipeButon.startWithExtraGold;
            }
            if (_buton == "startWithExtraResearchPoints")
            {
                _tipeButon = TipeButon.startWithExtraResearchPoints;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _clic = false;
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
            case TipeButon.BasicTurret:

                break;
            case TipeButon.moreDamageBasicTurret: 

                break;
            case TipeButon.moreHealthBasicTurret:

                break;
            case TipeButon.moreRangeBasicTurret:

                break;
            case TipeButon.unlockSlowTurret:

                break;
            case TipeButon.moreSlowSlowTurret:

                break;
            case TipeButon.moreHealthSlowTurret:

                break;
            case TipeButon.moreRangeSlowTurret:

                break;
            case TipeButon.unlockMineTurret:

                break;
            case TipeButon.moreDamageMineTurret:

                break;
            case TipeButon.moreRangeMineTurret:

                break;
            case TipeButon.oneReseachPointExtra:

                break;
            case TipeButon.moreGoldPerMine:

                break;
            case TipeButon.startWithExtraGold:

                break;
            case TipeButon.startWithExtraResearchPoints:

                break;
            case TipeButon.Investigacion:

                break;

        }
    }
    IEnumerator Wait()
    {
        while(_clic)
        {
            yield return new WaitForSeconds(1);
            if (_clic == true)
            {
                _information.SetActive(true);
            }
        }
    }
}
