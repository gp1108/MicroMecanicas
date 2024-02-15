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
        ExplosiveMine,
        AmetralladoraTurret,

        SniperTurret,
        LaserTurret,
        SlowTurret,
        MortarTurret,

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
        
        _clic = true;
        //_information.transform.position = this.transform.position - new Vector3(300,250,0);
        _information.transform.position = this.transform.position;
        StartCoroutine("Wait");
        if(eventData.pointerEnter.name == "Investigacion")
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
            if (_buton == "ExplosiveMine")
            {
                _tipeButon = TipeButon.ExplosiveMine;
            }
            if (_buton == "AmetralladoraTurret")
            {
                _tipeButon = TipeButon.AmetralladoraTurret;
            }
            if (_buton == "SniperTurret")
            {
                _tipeButon = TipeButon.SniperTurret;
            }
            if (_buton == "LaserTurret")
            {
                _tipeButon = TipeButon.LaserTurret;
            }
            if (_buton == "SlowTurret")
            {
                _tipeButon = TipeButon.SlowTurret;
            }
            if (_buton == "MortarTurret")
            {
                _tipeButon = TipeButon.MortarTurret;
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
            if (_buton == "ExplosiveMine")
            {
                _tipeButon = TipeButon.ExplosiveMine;
            }
            if (_buton == "AmetralladoraTurret")
            {
                _tipeButon = TipeButon.AmetralladoraTurret;
            }
            if (_buton == "SniperTurret")
            {
                _tipeButon = TipeButon.SniperTurret;
            }
            if (_buton == "LaserTurret")
            {
                _tipeButon = TipeButon.LaserTurret;
            }
            if (_buton == "SlowTurret")
            {
                _tipeButon = TipeButon.SlowTurret;
            }
            if (_buton == "MortarTurret")
            {
                _tipeButon = TipeButon.MortarTurret;
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
        CheckName();
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

                _textInformation.text = "Tipo de daño : estándar\r\nTorreta sencilla de coste reducido y características comunes.\r\nDps =" + UpgradeManager.giveMeReference.damagedB * 
                UpgradeManager.giveMeReference.cadenceB + "\r\nRango =" + UpgradeManager.giveMeReference.rangeB + "\r\nVida =" + UpgradeManager.giveMeReference.vidaB;

                break;
            case TipeButon.OtherTurret:
                
                break;
            case TipeButon.ExplosiveMine:

                _textInformation.text = "Tipo de daño : ???\r\nMina explosiva que se activa al pasar por encima de ella. Hace un gran daño en area. Se destruye al activarse.\r\n" +
                    "Damage = " + PlayerPrefs.GetFloat("damagedM") + " \r\nRango = \r\n" + PlayerPrefs.GetFloat("rangeM");

                break;
            case TipeButon.AmetralladoraTurret:

                _textInformation.text = "Tipo de daño: estandar\r\nEs la torreta básica mejorada, tiene mismo daño y rango que la torreta básica pero más cadencia\r\nDps = "+PlayerPrefs.GetFloat("damagedAm")*
                PlayerPrefs.GetFloat("cadenceAm")

                break;
            case TipeButon.SniperTurret:
                _textInformation.text = "Tipo de daño : estándar\r\nTorreta sencilla de coste reducido y características comunes.\r\nDps =" + UpgradeManager.giveMeReference.damagedS *
                UpgradeManager.giveMeReference.cadenceS + "\r\nRango =" + UpgradeManager.giveMeReference.rangeS + "\r\nVida =" + UpgradeManager.giveMeReference.vidaS;
                break;
            case TipeButon.LaserTurret:

                break;
            case TipeButon.SlowTurret:

                _textInformation.text = "Torreta que no puede dañar a los enemigos pero les ralentiza el movimiento.\r\nSlow =" + PlayerPrefs.GetFloat("amountSlow") +
                "\r\nRango =" + PlayerPrefs.GetFloat("rangeSlow") + "\r\nVida =" + PlayerPrefs.GetFloat("vidaSlow");

                break;
            case TipeButon.MortarTurret:

                break;
            case TipeButon.Taller:
                
                break;
            case TipeButon.Mine:
                
                break;
            case TipeButon.BasicTurret:

                _textInformation.text = "Tipo de daño : estándar\r\nTorreta sencilla de coste reducido y características comunes.\r\nDps =" + PlayerPrefs.GetFloat("damagedB") * 
                PlayerPrefs.GetFloat("cadenceB") + "\r\nRango =" + PlayerPrefs.GetFloat("rangeB") + "\r\nVida =" + PlayerPrefs.GetFloat("vidaB");

                break;
            case TipeButon.moreDamageBasicTurret:

                _textInformation.text = "Aumenta el daño de la torreta básica\r\nDps = " + PlayerPrefs.GetFloat("damagedB") * PlayerPrefs.GetFloat("cadenceB");

                break;
            case TipeButon.moreHealthBasicTurret:

                _textInformation.text = "Aumenta la vida base de la torreta básica\r\nVida Base = "+ PlayerPrefs.GetFloat("vidaB");

                break;
            case TipeButon.moreRangeBasicTurret:

                _textInformation.text = "Aumenta el rango de la torreta básica\r\n Range " + PlayerPrefs.GetFloat("rangeB");

                break;
            case TipeButon.unlockSlowTurret:

                _textInformation.text = "Torreta que no puede dañar a los enemigos pero les ralentiza el movimiento.\r\nSlow =" + PlayerPrefs.GetFloat("amountSlow") + 
                "\r\nRango ="+ PlayerPrefs.GetFloat("rangeSlow") + "\r\nVida ="+ PlayerPrefs.GetFloat("vidaSlow");

                break;
            case TipeButon.moreSlowSlowTurret:

                _textInformation.text = "Aumenta el Slow que aplica\r\n Slow=" + PlayerPrefs.GetFloat("amountSlow");

                break;
            case TipeButon.moreHealthSlowTurret:

                _textInformation.text = "Aumenta la vida de la toreta\r\n Vida=" + PlayerPrefs.GetFloat("vidaSlow");

                break;
            case TipeButon.moreRangeSlowTurret:

                _textInformation.text = "Aumenta el rango de la toreta\r\n Range=" + PlayerPrefs.GetFloat("rangeSlow");

                break;
            case TipeButon.unlockMineTurret:

                _textInformation.text = "Tipo de daño : ???\r\nMina explosiva que se activa al pasar por encima de ella. Hace un gran daño en area. Se destruye al activarse.\r\n" +
                    "Damage = " + PlayerPrefs.GetFloat("damagedM") + " \r\nRango = \r\n" + PlayerPrefs.GetFloat("rangeM");    

                break;
            case TipeButon.moreDamageMineTurret:

                _textInformation.text = "Aumenta el daño al explotar \r\n Damaged = " + PlayerPrefs.GetFloat("damagedM");

                break;
            case TipeButon.moreRangeMineTurret:

                _textInformation.text = "Aumenta el Rango de explosion \r\n Rango = " + PlayerPrefs.GetFloat("rangeM");

                break;
            case TipeButon.oneReseachPointExtra:

                _textInformation.text = "Los talleres dan 1 punto más de investigación.";

                break;
            case TipeButon.moreGoldPerMine:

                _textInformation.text = "Las minas dan X más de oro.";

                break;
            case TipeButon.startWithExtraGold:

                _textInformation.text = " Empiezas con X más oro.";

                break;
            case TipeButon.startWithExtraResearchPoints:

                _textInformation.text = "Empiezas con X más puntos de investigación.";

                break;
            case TipeButon.Investigacion:

                _textInformation.text = "Puntos de investigacion para el taller.\r\nTienes = " + gameManager.giveMeReference.researchPoints.ToString();

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
