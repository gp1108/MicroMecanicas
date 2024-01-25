using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _Reference;

    public static UpgradeManager giveMeReference
    {
        get
        {


            if (_Reference == null)
            {
                _Reference = FindObjectOfType<UpgradeManager>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("UpgradeManager");
                    _Reference = go.AddComponent<UpgradeManager>();
                }
            }
            return _Reference;
        }
    }



    [Header("TurretSnipe")]
    public float vidaS;
    public float damagedS;
    public float cadenceS;
    public float rangeS;
    public float visionS;

    [Header("TurretLaser")]
    public float vidaL;
    public float cadenceL;
    public float rangeL;
    public float visionL;

    [Header("TurretBasic")]
    public float vidaB;
    public float damagedB;
    public float cadenceB;
    public float rangeB;
    public float visionB;

    [Header("TurrerAmetralladora")]
    public float vidaAm;
    public float damagedAm;
    public float cadenceAm;
    public float rangeAm;
    public float visionAm;

    [Header("TurretAir")]
    public float vidaA;
    public float damagedA;
    public float cadenceA;
    public float rangeA;
    public float visionA;

    [Header("TurretSlow")]
    public float vidaSlow;
    public float amountSlow;
    public float rangeSlow;
    public float isSlowTurretUnlocked;

    [Header("Mina")]
    public float damagedM;
    public float rangeM;
    public float itsUpgraded;
    public float damagedMinaUpgrade;//sangrado
    public float isMineUnlocked;

    [Header("TurretMortero")]
    public float vidaMortero;
    public float damagedMortero;
    public float cadenceMortero;
    public float rangeMortero;
    public float visionMortero;

    [Header("Walls")]
    public float vidaW;

    // Start is called before the first frame update
    void Start()
    {
        damagedMinaUpgrade = 5;
        LoadPlayerPrefsUpgradeManager();
        Skills.giveMeReference.listaActualizarTurrets += ActualizarVidaTorres;
        Skills.giveMeReference.listaActualizarWalls += ActualizarVidaWalls;
    }


    public void ActualizarVidaTorres()
    {
        vidaS += 5;
        vidaL += 5;
        vidaB += 5;
        vidaA += 5;
    }
    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Skills.giveMeReference.listaActualizarTurrets -= ActualizarVidaTorres;
        Skills.giveMeReference.listaActualizarWalls -= ActualizarVidaWalls;
    }
    public void ActualizarVidaWalls()
    {
        vidaW += 5;
    }
    public void MoreDamagedTurrets()
    {
        damagedB += 5;
        damagedS += 5;
        damagedA += 5;
    }

    public void Update()
    {
        
    }

    public void LoadPlayerPrefsUpgradeManager()
    {
        //Torreta Sniper
        vidaS = PlayerPrefs.GetFloat("vidaS");
        damagedS = PlayerPrefs.GetFloat("damagedS");
        cadenceS = PlayerPrefs.GetFloat("cadenceS");
        rangeS = PlayerPrefs.GetFloat("rangeS");
        visionS = PlayerPrefs.GetFloat("visionS");
        //Torreta Laser
        vidaL = PlayerPrefs.GetFloat("vidaL");
        cadenceL = PlayerPrefs.GetFloat("cadenceL");
        rangeL = PlayerPrefs.GetFloat("rangeL");
        visionL = PlayerPrefs.GetFloat("visionL");
        //Torreta Basica
        vidaB = PlayerPrefs.GetFloat("vidaB");
        damagedB = PlayerPrefs.GetFloat("damagedB");
        cadenceB = PlayerPrefs.GetFloat("cadenceB");
        rangeB = PlayerPrefs.GetFloat("rangeB");
        visionB = PlayerPrefs.GetFloat("visionB");
        //Torreta Ametralladora
        vidaAm = PlayerPrefs.GetFloat("vidaAm");
        damagedAm = PlayerPrefs.GetFloat("damagedAm");
        cadenceAm = PlayerPrefs.GetFloat("cadenceAm");
        rangeAm = PlayerPrefs.GetFloat("rangeAm");
        visionAm = PlayerPrefs.GetFloat("visionAm");
        //Torreta Aerea 
        vidaA = PlayerPrefs.GetFloat("vidaA");
        damagedA = PlayerPrefs.GetFloat("damagedA");
        cadenceA = PlayerPrefs.GetFloat("cadenceA");
        rangeA = PlayerPrefs.GetFloat("rangeA");
        visionA = PlayerPrefs.GetFloat("visionA");

        //Walls
        vidaW = PlayerPrefs.GetFloat("vidaW");

        //TurretMortero
        vidaMortero= PlayerPrefs.GetFloat("vidaMortero");
        damagedMortero= PlayerPrefs.GetFloat("damagedMortero");
        cadenceMortero= PlayerPrefs.GetFloat("cadenceMortero");
        rangeMortero = PlayerPrefs.GetFloat("rangeMortero");
        visionMortero= PlayerPrefs.GetFloat("visionMortero");
        
        //Torreta Slow
        vidaSlow = PlayerPrefs.GetFloat("vidaSlow");
        amountSlow = PlayerPrefs.GetFloat("amountSlow");
        rangeSlow = PlayerPrefs.GetFloat("rangeSlow");
        isSlowTurretUnlocked = PlayerPrefs.GetFloat("unlockSlowTurret");
        //Anñadir el unlock slow para desbloquear la torreta slow ingame

        //Torreta Mina
        damagedM = PlayerPrefs.GetFloat("damagedM");
        rangeM = PlayerPrefs.GetFloat("rangeM");
        isMineUnlocked = PlayerPrefs.GetFloat("unlockMineTurret");

        //Mina // revisar para las mejoras de la mina
        itsUpgraded = PlayerPrefs.GetFloat("itsUpgraded");
        //damagedMinaUpgrade = PlayerPrefs.GetFloat("damagedMinaUpgrade");
        //Anñadir el unlock slow para desbloquear la torreta mina ingame

    }




}
