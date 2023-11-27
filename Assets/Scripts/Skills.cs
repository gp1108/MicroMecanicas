using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skills : MonoBehaviour
{
    private static Skills _Reference;
    public static Skills giveMeReference
    {
        get
        {
            if (_Reference == null)
            {
                _Reference = FindObjectOfType<Skills>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("skillManager");
                    _Reference = go.AddComponent<Skills>();
                }
            }
            return _Reference;
        }
    }
    public enum SkillName
    {
        moreHealthTurrets,
        moreDamageTurrets,
        moreHealthWalls,
        unlockSniperTurret,
        unlockMachinegunTurret,
        sniperTurretMoreFireRate,
        structureRecoverHealth,
        unlockLaserTurret,
        unlockMortarTurret,

        unlockMines,
        minesFaster,
        oneMoreMine,
        fasterResearch,
        fastMine,
        slowMine,
        unlockGems,
        

    }

    

    // Define el costo de cada habilidad
    public Dictionary<SkillName, int> skillCost = new Dictionary<SkillName, int>
    {
        { SkillName.moreHealthTurrets, 1 },
        { SkillName.moreDamageTurrets, 1 },
        { SkillName.moreHealthWalls, 1 },
        { SkillName.unlockSniperTurret,2 },
        { SkillName.unlockMachinegunTurret,2},
        { SkillName.sniperTurretMoreFireRate, 1 },
        { SkillName.structureRecoverHealth,2},
        { SkillName.unlockLaserTurret,2 },
        { SkillName.unlockMortarTurret,200},

        { SkillName.unlockMines,2},
        { SkillName.minesFaster,2},
        { SkillName.oneMoreMine,2},
        { SkillName.fasterResearch,2},
        { SkillName.fastMine,2},
        { SkillName.slowMine,2},
        { SkillName.unlockGems,2},
        
    };

    

    //Define si ha sido desbloqueado o no 
    public Dictionary<SkillName, bool> isSkillUnlocked = new Dictionary<SkillName, bool>
    {
        { SkillName.moreHealthTurrets, false },
        { SkillName.moreDamageTurrets, false },
        { SkillName.moreHealthWalls, false },
        { SkillName.unlockSniperTurret,false },
        { SkillName.unlockMachinegunTurret,false},
        { SkillName.sniperTurretMoreFireRate, false },
        { SkillName.structureRecoverHealth,false},
        { SkillName.unlockLaserTurret,false },
        { SkillName.unlockMortarTurret,false},

        { SkillName.unlockMines,false},
        { SkillName.minesFaster,false},
        { SkillName.oneMoreMine,false},
        { SkillName.fasterResearch,false},
        { SkillName.fastMine,false},
        { SkillName.slowMine,false},
        { SkillName.unlockGems,false},
        
    };

    public Dictionary<SkillName, bool> skillCanBeUnlocked = new Dictionary<SkillName, bool>
    {
        { SkillName.moreHealthTurrets, true },
        { SkillName.moreDamageTurrets, false },
        { SkillName.moreHealthWalls, false },
        { SkillName.unlockSniperTurret,false },
        { SkillName.unlockMachinegunTurret,false},
        { SkillName.sniperTurretMoreFireRate, false },
        { SkillName.structureRecoverHealth,false},
        { SkillName.unlockLaserTurret,false },
        { SkillName.unlockMortarTurret,false},

        { SkillName.unlockMines,true},
        { SkillName.minesFaster,false},
        { SkillName.oneMoreMine,false},
        { SkillName.fasterResearch,false},
        { SkillName.fastMine,false},
        { SkillName.slowMine,false},
        { SkillName.unlockGems,false},
        
    };
    
    public delegate void maxVidaTurrets();
    public event maxVidaTurrets listaActualizarTurrets;
    public delegate void maxVidaWalls();
    public event maxVidaWalls listaActualizarWalls;
    
    [Header("Skills")]
    public List<GameObject> SkillButtons = new List<GameObject>();

    public Color unlockedSkillColor;
    public Color notEnoughRPcolor;
    public Color defaultColor;
    public Color dependency;
    private GameObject canvas;
    [Header("GoldPanels")]
    public GameObject[] goldPanels;
    private int panelCost;
    private int index;
    public TMP_Text goldPanelText;
    [Header("Buttons")]
    public GameObject minesButton;
    public GameObject sniperTurretButton;
    public GameObject laserTurretButton;
    private void Start()
    {
        
        index = 0;
        panelCost = 300;
        goldPanelText.text = panelCost.ToString() + " g";
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        SkillsUI[] skillButtons = canvas.GetComponentsInChildren<SkillsUI>(true);
        foreach(SkillsUI skillUIscript in skillButtons)
        {
            SkillButtons.Add(skillUIscript.gameObject);
        }
        foreach (GameObject buttons in SkillButtons)
        {

            buttons.GetComponent<Image>().color = defaultColor;

        }
        UpdateSkillUI();
    }
    public void unlockGoldPanels(GameObject goldpanel)
    {
       
        if(panelCost <= gameManager.giveMeReference.gold)
        {
            SkillButtons.Remove(goldpanel);
            
            
            goldPanels[index].SetActive(false);
            index++;
            panelCost += 300;
            goldPanelText.text = panelCost.ToString() + " g";
        }
    }
    public void unlockSkill(SkillName skill)
    {
        if (skillCost[skill] <= gameManager.giveMeReference.researchPoints)
        {

            switch (skill)
            {
                case SkillName.moreHealthTurrets:

                    skillCanBeUnlocked[SkillName.moreDamageTurrets] = true;
                    skillCanBeUnlocked[SkillName.moreHealthWalls] = true;
                    UnlockSkillLogic(skill);

                    listaActualizarTurrets();

                    break;
                case SkillName.moreDamageTurrets:
                    if (isSkillUnlocked[SkillName.moreHealthTurrets] == true)
                    {
                        UpgradeManager.giveMeReference.damagedB += 3;
                        UpgradeManager.giveMeReference.damagedS += 10;
                        skillCanBeUnlocked[SkillName.unlockSniperTurret] = true;
                        skillCanBeUnlocked[SkillName.unlockMachinegunTurret] = true;

                        UnlockSkillLogic(skill);
                        
                        //Logica
                    }
                    break;
                case SkillName.moreHealthWalls:
                    if (isSkillUnlocked[SkillName.moreHealthTurrets] == true)
                    {
                        skillCanBeUnlocked[SkillName.structureRecoverHealth] = true;


                        UnlockSkillLogic(skill);

                        listaActualizarWalls();
                    }
                    break;
                case SkillName.unlockSniperTurret:
                    if (isSkillUnlocked[SkillName.moreDamageTurrets] == true)
                    {
                        skillCanBeUnlocked[SkillName.sniperTurretMoreFireRate] = true;


                        UnlockSkillLogic(skill);

                        sniperTurretButton.SetActive(true);
                    }
                    break;
                case SkillName.unlockMachinegunTurret:
                    if (isSkillUnlocked[SkillName.moreDamageTurrets] == true)
                    {
                        skillCanBeUnlocked[SkillName.unlockLaserTurret] = true;
                        skillCanBeUnlocked[SkillName.unlockMortarTurret] = true;

                        UnlockSkillLogic(skill);

                        //Logica
                    }

                    break;
                case SkillName.structureRecoverHealth:
                    if (isSkillUnlocked[SkillName.moreHealthWalls] == true)
                    {
                        //FALTA AÑADIR RECOVER HEALT 2 

                        UnlockSkillLogic(skill);

                        //Logica
                    }
                    break;

                case SkillName.sniperTurretMoreFireRate:
                    if (isSkillUnlocked[SkillName.unlockSniperTurret] == true)
                    {
                        
                        UnlockSkillLogic(skill);

                        //Logica
                    }
                    break;
                case SkillName.unlockLaserTurret:
                    if (isSkillUnlocked[SkillName.unlockMachinegunTurret] == true)
                    {
                        
                        skillCanBeUnlocked[SkillName.unlockMortarTurret] = false;
                        UnlockSkillLogic(skill);

                        laserTurretButton.SetActive(true);
                    }
                    break;
                case SkillName.unlockMortarTurret:
                    if (isSkillUnlocked[SkillName.unlockMachinegunTurret] == true)
                    {
                        skillCanBeUnlocked[SkillName.unlockLaserTurret] = false;

                        UnlockSkillLogic(skill);

                        //Logica
                    }
                    break;

                case SkillName.unlockMines:

                    skillCanBeUnlocked[SkillName.minesFaster] = true;
                    skillCanBeUnlocked[SkillName.fasterResearch] = true;
                    UnlockSkillLogic(skill);
                    minesButton.SetActive(true);

                    break;
                case SkillName.minesFaster:
                    if (isSkillUnlocked[SkillName.unlockMines] == true)
                    {
                        skillCanBeUnlocked[SkillName.oneMoreMine] = true;
                        
                        UnlockSkillLogic(skill);

                        gameManager.giveMeReference.goldMultiplayer = 2;
                    }
                    break;
                case SkillName.oneMoreMine:
                    if (isSkillUnlocked[SkillName.minesFaster] == true)
                    {
                        skillCanBeUnlocked[SkillName.fastMine] = true;
                        skillCanBeUnlocked[SkillName.slowMine] = true;

                        UnlockSkillLogic(skill);
                        gameManager.giveMeReference.maxNumberOfMines++;
                        gameManager.giveMeReference.MaxNumberOfMines();
                        
                    }
                    break;
                case SkillName.fasterResearch:
                    if (isSkillUnlocked[SkillName.unlockMines] == true)
                    {
                        skillCanBeUnlocked[SkillName.unlockGems] = true;

                        UnlockSkillLogic(skill);

                        gameManager.giveMeReference.researchRoundsElapsed = 1;
                    }
                    break;
                case SkillName.fastMine:
                    if (isSkillUnlocked[SkillName.slowMine] == false)
                    {
                        skillCanBeUnlocked[SkillName.slowMine] = false;
                        
                        UnlockSkillLogic(skill);

                        gameManager.giveMeReference.goldRoundsElapsed = 1;
                        gameManager.giveMeReference.goldMultiplayer = 1.5f;
                    }
                    
                    break;
                case SkillName.slowMine:
                    if (isSkillUnlocked[SkillName.fastMine] == false)
                    {
                        
                        skillCanBeUnlocked[SkillName.fastMine] = false;
                        UnlockSkillLogic(skill);
                        gameManager.giveMeReference.goldRoundsElapsed = 4;
                        gameManager.giveMeReference.goldMultiplayer = 8f;
                    }
                    
                    break;
                case SkillName.unlockGems:
                    UnlockSkillLogic(skill);
                    break;
                

            }


        }
   
    }

    private void UnlockSkillLogic(SkillName skill)
    {
        
        gameManager.giveMeReference.researchPoints -= skillCost[skill];
        isSkillUnlocked[skill] = true;
        UpdateSkillUI();
    }
    
    public void UpdateSkillUI()
    {
        foreach (KeyValuePair<SkillName, int> kvp in skillCost)
        {
            SkillName clave = kvp.Key;
            int valor = kvp.Value;
            
            if(kvp.Value > gameManager.giveMeReference.researchPoints && isSkillUnlocked[kvp.Key] == false && skillCanBeUnlocked[kvp.Key] == true)
            {
                foreach(GameObject skillButtons in SkillButtons)
                {
                    if(skillButtons.gameObject.name == kvp.Key.ToString())
                    {
                        skillButtons.gameObject.GetComponent<Image>().color = notEnoughRPcolor;
                        skillButtons.gameObject.GetComponent<Button>().interactable = true;
                    }
                }
            }
            if(kvp.Value <= gameManager.giveMeReference.researchPoints && isSkillUnlocked[kvp.Key] == false)
            {
                foreach (GameObject skillButtons in SkillButtons)
                {
                    if (skillButtons.gameObject.name == kvp.Key.ToString())
                    {
                        skillButtons.gameObject.GetComponent<Image>().color = defaultColor;
                        skillButtons.gameObject.GetComponent<Button>().interactable = true;
                    }
                }
            }
            if(isSkillUnlocked[kvp.Key] == true)
            {
                
                foreach (GameObject skillButtons in SkillButtons)
                {
                    
                    if (skillButtons.gameObject.name == kvp.Key.ToString())
                    {
                        
                        skillButtons.gameObject.GetComponent<Image>().color = unlockedSkillColor;
                        skillButtons.gameObject.GetComponent<Button>().interactable = false;
                    }
                }
            }
            if (skillCanBeUnlocked[kvp.Key] == false )
            {

                foreach (GameObject skillButtons in SkillButtons)
                {

                    if (skillButtons.gameObject.name == kvp.Key.ToString())
                    {

                        skillButtons.gameObject.GetComponent<Image>().color = dependency;
                        skillButtons.gameObject.GetComponent<Button>().interactable = false;
                    }
                }
            }
        }
    }


}
