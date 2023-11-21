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
    public float damagedS;
    public float cadenceS;
    public float rangeS;
    public float visionS;

    [Header("TurretLaser")]
    public float cadenceL;
    public float rangeL;
    public float visionL;

    [Header("TurretBasic")]
    public float damagedB;
    public float cadenceB;
    public float rangeB;
    public float visionB;

    // Start is called before the first frame update
    void Start()
    {
        damagedS = 20;
        cadenceS = 5;
        rangeS = 25;
        visionS = 30;

        cadenceL = 0.1f;
        rangeL = 15;
        visionL = 20;

        damagedB = 1;
        cadenceB = 1;
        rangeB = 10;
        visionB = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
