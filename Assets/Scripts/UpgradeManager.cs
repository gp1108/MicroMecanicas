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

    [Header("TurretMortar")]
    public float vidaM;
    public float damagedM;
    public float rangeM;

    [Header("Mina")]
    public float itsUpgraded;
    public float damagedMina;
    public float damagedMinaUpgrade;

    [Header("Walls")]
    public float vidaW;

    // Start is called before the first frame update
    void Start()
    {
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
        vidaA = PlayerPrefs.GetFloat("vidaA");
        damagedA = PlayerPrefs.GetFloat("damagedA");
        cadenceA = PlayerPrefs.GetFloat("cadenceA");
        rangeA = PlayerPrefs.GetFloat("rangeA");
        visionA = PlayerPrefs.GetFloat("visionA");

        //Walls
        vidaW = PlayerPrefs.GetFloat("vidaW");

        //Mina
        itsUpgraded = PlayerPrefs.GetFloat("itsUpgraded");
        damagedMina = PlayerPrefs.GetFloat("damagedMina");
        damagedMinaUpgrade = PlayerPrefs.GetFloat("damagedMinaUpgrade");

        //Torreta Slow
        vidaSlow = PlayerPrefs.GetFloat("vidaSlow");
        amountSlow = PlayerPrefs.GetFloat("amountSlow");
        rangeSlow = PlayerPrefs.GetFloat("rangeSlow");
        //An�adir el unlock slow para desbloquear la torreta slow ingame

        //Torreta Mina
        vidaM = PlayerPrefs.GetFloat("vidaM");
        damagedM = PlayerPrefs.GetFloat("damagedM");
        rangeM = PlayerPrefs.GetFloat("rangeM");
        //An�adir el unlock slow para desbloquear la torreta mina ingame

    }




}
