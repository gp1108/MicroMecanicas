using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

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
        oneMoreMine,
        fasterResearch,
        fastMine,
        slowMine,
        unlockGems,
        discountTurrets

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
        { SkillName.oneMoreMine,2},
        { SkillName.fasterResearch,2},
        { SkillName.fastMine,2},
        { SkillName.slowMine,2},
        { SkillName.unlockGems,2},
        { SkillName.discountTurrets,2}
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
        { SkillName.oneMoreMine,false},
        { SkillName.fasterResearch,false},
        { SkillName.fastMine,false},
        { SkillName.slowMine,false},
        { SkillName.unlockGems,false},
        { SkillName.discountTurrets,false}
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

        { SkillName.unlockMines,false},
        { SkillName.oneMoreMine,false},
        { SkillName.fasterResearch,false},
        { SkillName.fastMine,false},
        { SkillName.slowMine,false},
        { SkillName.unlockGems,false},
        { SkillName.discountTurrets,false}
    };

    public List<GameObject> SkillButtons = new List<GameObject>();

    public Color unlockedSkillColor;
    public Color notEnoughRPcolor;
    public Color defaultColor;
    public Color dependency;
    private GameObject canvas;
    private void Start()
    {
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

    public void unlockSkill(SkillName skill)
    {
        if (skillCost[skill] <= gameManager.giveMeReference.researchPoints)
        {

            switch (skill)
            {
                case SkillName.moreHealthTurrets:

                    skillCanBeUnlocked[SkillName.moreDamageTurrets] = true;
                    skillCanBeUnlocked[SkillName.moreHealthWalls] = true;
                    //logica
                    UnlockSkillLogic(skill);

                    break;
                case SkillName.moreDamageTurrets:
                    if (isSkillUnlocked[SkillName.moreHealthTurrets] == true)
                    {

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

                        //Logica
                    }
                    break;
                case SkillName.unlockSniperTurret:
                    if (isSkillUnlocked[SkillName.moreDamageTurrets] == true)
                    {
                        skillCanBeUnlocked[SkillName.sniperTurretMoreFireRate] = true;


                        UnlockSkillLogic(skill);

                        //Logica
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


                        UnlockSkillLogic(skill);

                        //Logica
                    }
                    break;
                case SkillName.unlockMortarTurret:
                    if (isSkillUnlocked[SkillName.unlockMachinegunTurret] == true)
                    {


                        UnlockSkillLogic(skill);

                        //Logica
                    }
                    break;

                case SkillName.unlockMines:

                    break;
                case SkillName.oneMoreMine:

                    break;
                case SkillName.fasterResearch:

                    break;
                case SkillName.fastMine:

                    break;
                case SkillName.slowMine:

                    break;
                case SkillName.unlockGems:

                    break;
                
                case SkillName.discountTurrets:

                    break;

            }


        }
   
    }

    private void UnlockSkillLogic(SkillName skill)
    {
        Debug.Log("He desbloqueado la habilidad" + skill.ToString());
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
                        //skillButtons.gameObject.GetComponent<Button>().interactable = false;
                    }
                }
            }
        }
    }


}
