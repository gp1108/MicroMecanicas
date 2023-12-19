using System.Collections;
using System.Collections.Generic;
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

    [Header("Walls")]
    public float vidaW;

    // Start is called before the first frame update
    void Start()
    {
        vidaS = 10;
        damagedS = 20;
        cadenceS = 5;
        rangeS = 25;
        visionS = damagedS +10;

        vidaL += 10;
        cadenceL = 0.1f;
        rangeL = 15;
        visionL = rangeL +10;

        vidaB = 10;
        damagedB = 3;
        cadenceB = 1;
        rangeB = 10;
        visionB = rangeB +5;

        vidaA = 10;
        damagedA = 5;
        cadenceA = 1;
        rangeA = 10;
        visionA = rangeA +5;

        vidaW = 10;

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
}
