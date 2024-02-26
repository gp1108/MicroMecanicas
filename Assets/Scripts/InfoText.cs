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
    private RectTransform _canvas;
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

        moreHealthTurrets,

        moreDamageTurrets,
        moreHealthWalls,
        unlockMines,

        unlockSniperTurret,
        unlockMachinegunTurret,
        structureRecoverHealth,
        minesFaster,
        fasterResearch,


        sniperTurretMoreFireRate,
        oneMoreMine,
        unlockGems,

        unlockLaserTurret,
        unlockMortarTurret,
        fastMine,
        slowMine,
    }

    private TipeButon _tipeButon;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        _clic = true;
        _information.transform.position = this.transform.position;
        Debug.Log(_information.transform.position);
        
        if (_information.transform.position.x + 432 > 1920) 
        {
            Vector3 otro = this.transform.position+new Vector3(450, 0, 0);
            Debug.Log("Se sale por la X"+ otro);
            //_information.transform.position = this.transform.position - new Vector3(0, 0, 450);
            _information.transform.position = _information.transform.position - new Vector3(450, 0, 0);
        }
        if (_information.transform.position.y - 391 < 0) 
        {
            Vector3 otro = this.transform.position + new Vector3(0, 391, 0);
            Debug.Log("Se sale por la y" + otro);
            _information.transform.position = _information.transform.position + new Vector3(0, 391, 0);
        }
        StartCoroutine("Wait");
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
            if (_buton == "moreHealthTurrets")
            {
                _tipeButon = TipeButon.moreHealthTurrets;
            }
            if (_buton == "moreDamageTurrets")
            {
                _tipeButon = TipeButon.moreDamageTurrets;
            }
            if (_buton == "moreHealthWalls")
            {
                _tipeButon = TipeButon.moreHealthWalls;
            }
            if (_buton == "unlockMines")
            {
                _tipeButon = TipeButon.unlockMines;
            }
            if (_buton == "unlockSniperTurret")
            {
                _tipeButon = TipeButon.unlockSniperTurret;
            }
            if (_buton == "unlockMachinegunTurret")
            {
                _tipeButon = TipeButon.unlockMachinegunTurret;
            }
            if (_buton == "structureRecoverHealth")
            {
                _tipeButon = TipeButon.structureRecoverHealth;
            }
            if (_buton == "minesFaster")
            {
                _tipeButon = TipeButon.minesFaster;
            }
            if (_buton == "fasterResearch")
            {
                _tipeButon = TipeButon.fasterResearch;
            }
            if (_buton == "sniperTurretMoreFireRate")
            {
                _tipeButon = TipeButon.sniperTurretMoreFireRate;
            }
            if (_buton == "oneMoreMine")
            {
                _tipeButon = TipeButon.oneMoreMine;
            }
            if (_buton == "unlockGems")
            {
                _tipeButon = TipeButon.unlockGems;
            }
            if (_buton == "unlockLaserTurret")
            {
                _tipeButon = TipeButon.unlockLaserTurret;
            }
            if (_buton == "unlockMortarTurret")
            {
                _tipeButon = TipeButon.unlockMortarTurret;
            }
            if (_buton == "fastMine")
            {
                _tipeButon = TipeButon.fastMine;
            }
            if (_buton == "slowMine")
            {
                _tipeButon = TipeButon.slowMine;
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
            if (_buton == "moreHealthTurrets")
            {
                _tipeButon = TipeButon.moreHealthTurrets;
            }
            if (_buton == "moreDamageTurrets")
            {
                _tipeButon = TipeButon.moreDamageTurrets;
            }
            if (_buton == "moreHealthWalls")
            {
                _tipeButon = TipeButon.moreHealthWalls;
            }
            if (_buton == "unlockMines")
            {
                _tipeButon = TipeButon.unlockMines;
            }
            if (_buton == "unlockSniperTurret")
            {
                _tipeButon = TipeButon.unlockSniperTurret;
            }
            if (_buton == "unlockMachinegunTurret")
            {
                _tipeButon = TipeButon.unlockMachinegunTurret;
            }
            if (_buton == "structureRecoverHealth")
            {
                _tipeButon = TipeButon.structureRecoverHealth;
            }
            if (_buton == "minesFaster")
            {
                _tipeButon = TipeButon.minesFaster;
            }
            if (_buton == "fasterResearch")
            {
                _tipeButon = TipeButon.fasterResearch;
            }
            if (_buton == "sniperTurretMoreFireRate")
            {
                _tipeButon = TipeButon.sniperTurretMoreFireRate;
            }
            if (_buton == "oneMoreMine")
            {
                _tipeButon = TipeButon.oneMoreMine;
            }
            if (_buton == "unlockGems")
            {
                _tipeButon = TipeButon.unlockGems;
            }
            if (_buton == "unlockLaserTurret")
            {
                _tipeButon = TipeButon.unlockLaserTurret;
            }
            if (_buton == "unlockMortarTurret")
            {
                _tipeButon = TipeButon.unlockMortarTurret;
            }
            if (_buton == "fastMine")
            {
                _tipeButon = TipeButon.fastMine;
            }
            if (_buton == "slowMine")
            {
                _tipeButon = TipeButon.slowMine;
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

                _textInformation.text = "Con esta estructura podras impedir el paso de los enemigos \r\nVida:"+UpgradeManager.giveMeReference.vidaW;
                
                break;
            case TipeButon.BaseTurret:

                _textInformation.text = "Tipo de daño : estándar\r\nTorreta sencilla de coste reducido y características comunes.\r\nDps =" + UpgradeManager.giveMeReference.damagedB * 
                UpgradeManager.giveMeReference.cadenceB + "\r\nRango =" + UpgradeManager.giveMeReference.rangeB + "\r\nVida =" + UpgradeManager.giveMeReference.vidaB;
                Debug.Log("Cadencia" + UpgradeManager.giveMeReference.cadenceB + "Daño " + UpgradeManager.giveMeReference.damagedB);

                break;
            case TipeButon.OtherTurret:
                
                break;
            case TipeButon.ExplosiveMine:

                _textInformation.text = "Tipo de daño : ???\r\nMina explosiva que se activa al pasar por encima de ella. Hace un gran daño en area. Se destruye al activarse.\r\n" +
                    "Damage = " + PlayerPrefs.GetFloat("damagedM") + " \r\nRango = \r\n" + PlayerPrefs.GetFloat("rangeM");

                break;
            case TipeButon.AmetralladoraTurret:

                _textInformation.text = "Tipo de daño: estandar\r\nEs la torreta básica mejorada, tiene mismo daño y rango que la torreta básica pero más cadencia\r\nDps = " + PlayerPrefs.GetFloat("damagedAm") *
                PlayerPrefs.GetFloat("cadenceAm");

                break;
            case TipeButon.SniperTurret:
                _textInformation.text = "Tipo de daño : Estándar\r\nTorreta sencilla de coste reducido y características comunes.\r\nDps =" + UpgradeManager.giveMeReference.damagedS *
                UpgradeManager.giveMeReference.cadenceS + "\r\nRango =" + UpgradeManager.giveMeReference.rangeS + "\r\nVida =" + UpgradeManager.giveMeReference.vidaS;
                break;
            case TipeButon.LaserTurret:

                _textInformation.text = "Tipo de daño : Armadura\r\nTorreta que dispara constantemente a un objetivo y hace daño progresivo en funcion de el tiempo que pase disparando a un mismo objetivo\r\nDps = " + UpgradeManager.giveMeReference.damagedL *
                UpgradeManager.giveMeReference.cadenceL + "\r\nRango =" + UpgradeManager.giveMeReference.rangeL + "\r\nVida =" + UpgradeManager.giveMeReference.vidaL;

                break;
            case TipeButon.SlowTurret:

                _textInformation.text = "Torreta que no puede dañar a los enemigos pero les ralentiza el movimiento.\r\nSlow =" + PlayerPrefs.GetFloat("amountSlow") +
                "\r\nRango =" + PlayerPrefs.GetFloat("rangeSlow") + "\r\nVida =" + PlayerPrefs.GetFloat("vidaSlow");

                break;
            case TipeButon.MortarTurret:

                _textInformation.text = "Tipo de daño : magico \r\nTorreta que lanza bombas a grandes grupos de enemigos por su gran daño en area por explosion\r\nDps = " + UpgradeManager.giveMeReference.damagedMortero *
                UpgradeManager.giveMeReference.cadenceMortero + "\r\nRango =" + UpgradeManager.giveMeReference.rangeMortero + "\r\nVida =" + UpgradeManager.giveMeReference.vidaMortero;

                break;
            case TipeButon.Taller:
                _textInformation.text = "El taller permite investigar mejoras temporales solo para la partida actual, cada taller genera: " + (1 * 2 + Mathf.RoundToInt(PlayerPrefs.GetFloat("oneResearchPoint"))) +
                 " puntos de investigacion cada " + gameManager.giveMeReference.researchRoundsElapsed + " rondas ";

                break;
            case TipeButon.Mine:
                 
                _textInformation.text = "Construccion que genera " + gameManager.giveMeReference.numberOfMines * 100 * gameManager.giveMeReference.goldMultiplayer + PlayerPrefs.GetFloat("moreGoldPerGoldMines")
                + " puntos oro cada " + gameManager.giveMeReference.goldRoundsElapsed + " rondas ";

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

                _textInformation.text = "Empiezas con X puntos mas de investigación.";

                break;
            case TipeButon.Investigacion:

                _textInformation.text = "Puntos de investigacion para el taller.\r\n Se consiguen " + gameManager.giveMeReference.numberOfLabs * 2 + Mathf.RoundToInt(PlayerPrefs.GetFloat("oneResearchPoint"))
                + " cada " + gameManager.giveMeReference.researchRoundsElapsed + " rondas\r\nTienes = " + gameManager.giveMeReference.researchPoints.ToString();

                break;
            case TipeButon.moreHealthTurrets:

                _textInformation.text = "Incrementa la vida base de todas las torretas";        

                break;
            case TipeButon.moreDamageTurrets:

                _textInformation.text = "Incrementa el daño base de las torretas X";
        
                break;
            case TipeButon.moreHealthWalls:

                _textInformation.text = "Aumenta La vida base de los muros";
        
                break;
            case TipeButon.unlockMines:

                _textInformation.text = "Desbloquea la Estructura Mina que se ocupa de generar oro";

                break;
            case TipeButon.unlockSniperTurret:

                _textInformation.text = "Desbloquea la torreta con bastante rango y daño pero una cadencia baja";

                break;
            case TipeButon.unlockMachinegunTurret:

                _textInformation.text = "Desbloquea la mejora de la torreta basica con mismas estadisticas pero con mayor cadencia";

                break;
            case TipeButon.structureRecoverHealth:

                _textInformation.text = "Los muros recuperan vida cada ronda";
                
                break;
            case TipeButon.minesFaster:

                _textInformation.text = "Las minas consiguen Oro cada menos rondas";

                break;
            case TipeButon.fasterResearch:


                _textInformation.text = "Se consiguen los puntos de investigacion cada menos rondas";

                break;
            case TipeButon.sniperTurretMoreFireRate:

                _textInformation.text = "La torreta Sniper mejora su cadenia";

                break;
            case TipeButon.oneMoreMine:

                _textInformation.text = "Se puede construir una mina mas";

                break;
            case TipeButon.unlockGems:

                _textInformation.text = "Te cura el generador a su vida maxima y le añade 5 de vida mas";

                break;
            case TipeButon.unlockLaserTurret:

                _textInformation.text = "Desbloquea la torreta laser";
                
                break;
            case TipeButon.unlockMortarTurret:

                _textInformation.text = "Desbloquea el mortero";                

                break;
            case TipeButon.fastMine:

                _textInformation.text = "Consigues menos oro pero tardas menos rondas en conseguirlo";

                break;
            case TipeButon.slowMine:

                _textInformation.text = "Consigues mas oro pero tardas mas rondas en conseguirlo";

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
