using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ExternalSkills : MonoBehaviour
{
    private static ExternalSkills _Reference;
    public static ExternalSkills giveMeReference
    {
        get
        {
            if (_Reference == null)
            {
                _Reference = FindObjectOfType<ExternalSkills>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("SkillTreeManager");
                    _Reference = go.AddComponent<ExternalSkills>();
                }
            }
            return _Reference;
        }
    }
   

    // Define el costo de cada habilidad
    public Dictionary<externalSkillName, int> skillCost = new Dictionary<externalSkillName, int>
    {
        {externalSkillName.moreDamageBasicTurret, 1 },
        {externalSkillName.moreRangeBasicTurret,1 },
        {externalSkillName.moreHealthBasicTurret,55 },

        {externalSkillName.moreSlowSlowTurret,1 },
        {externalSkillName.moreRangeSlowTurret,1 },
        {externalSkillName.moreHealthSlowTurret,1 },
        {externalSkillName.unlockSlowTurret,1 },

        {externalSkillName.unlockMortarTurret,1 },
        {externalSkillName.moreDamageMortarTurret,1 },
        {externalSkillName.moreRangeMortarTurret,1 },
        {externalSkillName.moreHealthMortarTurret,1 },

    };

    //Define si ha sido desbloqueado o no 
    public Dictionary<externalSkillName, bool> isSkillUnlocked = new Dictionary<externalSkillName, bool>
    {
        {externalSkillName.moreDamageBasicTurret,false },
        {externalSkillName.moreRangeBasicTurret,false },
        {externalSkillName.moreHealthBasicTurret,false },

        {externalSkillName.unlockSlowTurret,false },
        {externalSkillName.moreSlowSlowTurret,false },
        {externalSkillName.moreRangeSlowTurret,false },
        {externalSkillName.moreHealthSlowTurret,false },

        {externalSkillName.unlockMortarTurret,false },
        {externalSkillName.moreDamageMortarTurret,false },
        {externalSkillName.moreRangeMortarTurret,false },
        {externalSkillName.moreHealthMortarTurret,false },

    };

    public Dictionary<externalSkillName, bool> skillCanBeUnlocked = new Dictionary<externalSkillName, bool>
    {
        {externalSkillName.moreDamageBasicTurret,true },
        {externalSkillName.moreRangeBasicTurret,true },
        {externalSkillName.moreHealthBasicTurret,true },

        {externalSkillName.unlockSlowTurret,true },
        {externalSkillName.moreSlowSlowTurret,false },
        {externalSkillName.moreRangeSlowTurret,false },
        {externalSkillName.moreHealthSlowTurret,false },

        {externalSkillName.unlockMortarTurret,true },
        {externalSkillName.moreDamageMortarTurret,false },
        {externalSkillName.moreRangeMortarTurret,false },
        {externalSkillName.moreHealthMortarTurret,false },
    };


    [Header("Skills")]
    public List<GameObject> SkillButtons = new List<GameObject>();

    public Color unlockedSkillColor;
    public Color notEnoughRPcolor;
    public Color defaultColor;
    public Color dependency;
    private GameObject canvas;

    //Puntos externos Quizas deban ir en el gamemanager, tambien deben ser guardables entre partida
    private int externalSkillPoints;

    public enum externalSkillName
    {
        moreDamageBasicTurret,
        moreRangeBasicTurret,
        moreHealthBasicTurret,

        unlockSlowTurret,
        moreSlowSlowTurret,
        moreRangeSlowTurret,
        moreHealthSlowTurret,

        unlockMortarTurret,
        moreDamageMortarTurret,
        moreRangeMortarTurret,
        moreHealthMortarTurret,
    }



    public void CheckPlayerPrefsKey(string ppName, float valueToStore)
    {
        if (PlayerPrefs.HasKey(ppName))
        {
            return;
            //Cargar la variable
            
        }
        else
        {
            //Crear la variable
            SavePlayerPrefs(ppName, valueToStore);
        }
    }

    public void isSkillUnlockedPP(string ppName, float valueToStore)
    {
        if (PlayerPrefs.HasKey(ppName))
        {
            if(PlayerPrefs.GetFloat(ppName) == 0)
            {
                return;
            }
            else
            {
                foreach (externalSkillName skillName in externalSkillName.GetValues(typeof(externalSkillName)))
                {
                    if (ppName == skillName.ToString())
                    {
                        isSkillUnlocked[skillName] = true;
                        if (ppName == "unlockSlowTurret")
                        {

                            skillCanBeUnlocked[externalSkillName.moreSlowSlowTurret] = true;
                            skillCanBeUnlocked[externalSkillName.moreRangeSlowTurret] = true;
                            skillCanBeUnlocked[externalSkillName.moreHealthSlowTurret] = true;
                        }
                        if (ppName == "unlockMortarTurret")
                        {
                            skillCanBeUnlocked[externalSkillName.moreDamageMortarTurret] = true;
                            skillCanBeUnlocked[externalSkillName.moreRangeMortarTurret] = true;
                            skillCanBeUnlocked[externalSkillName.moreHealthMortarTurret] = true;

                        }

                        UpdateSkillUI();

                        
                    }
                }
                
            }
            

        }
        else
        {
            //Crear la variable
            SavePlayerPrefs(ppName, valueToStore);
        }
    }

    public void SavePlayerPrefs(string ppName, float valueToStore)
    {
        PlayerPrefs.SetFloat(ppName, valueToStore);
        PlayerPrefs.Save();  // Guardar importante si quieres que se guarde en el disco duro
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("moreDamageBasicTurretAmount"));

        if(Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteKey("moreDamageBasicTurretAmount");
            PlayerPrefs.DeleteKey("damagedB");
            PlayerPrefs.DeleteAll();
        }
    }

    private void Start()
    {
        externalSkillPoints = 100;
        //Torreta Sniper
        CheckPlayerPrefsKey("vidaS", 10);
        CheckPlayerPrefsKey("damagedS", 20);
        CheckPlayerPrefsKey("cadenceS", 5);
        CheckPlayerPrefsKey("rangeS", 25);
        CheckPlayerPrefsKey("visionS", 35);

        //Torreta Laser
        CheckPlayerPrefsKey("vidaL", 10);
        CheckPlayerPrefsKey("cadenceL", 0.1f);
        CheckPlayerPrefsKey("rangeL", 15);
        CheckPlayerPrefsKey("visionL", 25);

        //Torreta Slow
        //CheckPlayerPrefsKey("unlockSlow", 0);
        CheckPlayerPrefsKey("vidaSlow", 10);
        CheckPlayerPrefsKey("amountSlow", 0.1f);
        CheckPlayerPrefsKey("rangeSlow", 15);
        

        //Torreta Basica
        CheckPlayerPrefsKey("vidaB", 10);
        CheckPlayerPrefsKey("damagedB", 3);
        CheckPlayerPrefsKey("cadenceB", 1);
        CheckPlayerPrefsKey("rangeB", 10);
        CheckPlayerPrefsKey("visionB", 15);

        //Torreta Ametralladora
        CheckPlayerPrefsKey("vidaA", 10);
        CheckPlayerPrefsKey("damagedA", 5);
        CheckPlayerPrefsKey("cadenceA", 1);
        CheckPlayerPrefsKey("rangeA", 10);
        CheckPlayerPrefsKey("visionA", 15);
        
        //Muros
        CheckPlayerPrefsKey("vidaW", 10);

        //Torreta Mortero
        CheckPlayerPrefsKey("unlockMortar", 0);
        CheckPlayerPrefsKey("vidaM", 10);
        CheckPlayerPrefsKey("damagedM", 5);
        CheckPlayerPrefsKey("rangeM", 10);

        //Contadores
        CheckPlayerPrefsKey("moreDamageBasicTurretAmount", 0);
        CheckPlayerPrefsKey("moreRangeBasicTurretAmount", 0);
        CheckPlayerPrefsKey("moreHealthBasicTurretAmount", 0);

        CheckPlayerPrefsKey("moreSlowSlowTurretAmount", 0);
        CheckPlayerPrefsKey("moreRangeSlowTurretAmount", 0);
        CheckPlayerPrefsKey("moreHealthSlowTurretAmount", 0);

        CheckPlayerPrefsKey("moreDamageMortarTurretAmount", 0);
        CheckPlayerPrefsKey("moreRangeMortarTurretAmount", 0);
        CheckPlayerPrefsKey("moreHealthMortarTurretAmount", 0);

        //Is skill unlocked (0 es no 1 es si)
        isSkillUnlockedPP("moreDamageBasicTurret", 0);
        isSkillUnlockedPP("moreRangeBasicTurret", 0);
        isSkillUnlockedPP("moreHealthBasicTurret", 0);

        isSkillUnlockedPP("unlockSlowTurret", 0);
        isSkillUnlockedPP("moreSlowSlowTurret", 0);
        isSkillUnlockedPP("moreRangeSlowTurret", 0);
        isSkillUnlockedPP("moreHealthSlowTurret", 0);

        isSkillUnlockedPP("unlockMortarTurret", 0);
        isSkillUnlockedPP("moreDamageMortarTurret", 0);
        isSkillUnlockedPP("moreRangeMortarTurret", 0);
        isSkillUnlockedPP("moreHealthMortarTurret", 0);





        canvas = GameObject.FindGameObjectWithTag("MainMenuCanvas");
        SkillsUI[] skillButtons = canvas.GetComponentsInChildren<SkillsUI>(true);
        foreach (SkillsUI skillUIscript in skillButtons)
        {
            SkillButtons.Add(skillUIscript.gameObject);
        }
        foreach (GameObject buttons in SkillButtons)
        {

            buttons.GetComponent<Image>().color = defaultColor;

        }
        UpdateSkillUI();


    }
   
    public void unlockSkill(externalSkillName skill)
    {
        if (skillCost[skill] <= externalSkillPoints)
        {

            switch (skill)
            {
                case externalSkillName.moreDamageBasicTurret:
                    
                   if(PlayerPrefs.GetFloat("moreDamageBasicTurretAmount") < 4)
                   {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreDamageBasicTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreDamageBasicTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("damagedB");  // 0 es el valor predeterminado si la clave a�n no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damagedB", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                   else
                   {
                        //HAY que hacer esto para que el ultimo click lo marque como desbloqueado y al mismo tiempo de la habilidad
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreDamageBasicTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreDamageBasicTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("damagedB");  // 0 es el valor predeterminado si la clave a�n no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damagedB", newValue);


                        UnlockSkillLogic(skill);
                   }
                   break;
                case externalSkillName.moreHealthBasicTurret:

                    if (PlayerPrefs.GetFloat("moreHealthBasicTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreHealthBasicTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreHealthBasicTurretAmount", counterNewValue);
                        
                        float currentValue = PlayerPrefs.GetFloat("vidaB");  
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaB", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreHealthBasicTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreHealthBasicTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("vidaB");  
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaB", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.moreRangeBasicTurret:

                    if (PlayerPrefs.GetFloat("moreRangeBasicTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeBasicTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeBasicTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeB");  
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeB", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeBasicTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeBasicTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeB");  
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeB", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                
                case externalSkillName.unlockSlowTurret:

                    if (PlayerPrefs.GetFloat("unlockSlowTurret") < 1)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("unlockSlowTurret");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("unlockSlowTurret", counterNewValue);

                        skillCanBeUnlocked[externalSkillName.moreSlowSlowTurret] = true;
                        skillCanBeUnlocked[externalSkillName.moreRangeSlowTurret] = true;
                        skillCanBeUnlocked[externalSkillName.moreHealthSlowTurret] = true;

                        
                        UnlockSkillLogic(skill);
                        
                        //Falta la logica que desbloque la torreta de slows


                    }                  
                    break;
                case externalSkillName.moreSlowSlowTurret:

                    if (PlayerPrefs.GetFloat("moreSlowSlowTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreSlowSlowTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreSlowSlowTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("amountSlow");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("amountSlow", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreSlowSlowTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreSlowSlowTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("amountSlow");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("amountSlow", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.moreRangeSlowTurret:

                    if (PlayerPrefs.GetFloat("moreRangeSlowTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeSlowTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeSlowTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeSlow");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeSlow", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeSlowTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeSlowTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeSlow");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeSlow", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.moreHealthSlowTurret:

                    if (PlayerPrefs.GetFloat("moreHealthSlowTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreHealthSlowTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreHealthSlowTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("vidaSlow");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaSlow", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreHealthSlowTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreHealthSlowTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("vidaSlow");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaSlow", newValue);

                        UnlockSkillLogic(skill);


                    }
                    break;

                case externalSkillName.unlockMortarTurret:

                    if (PlayerPrefs.GetFloat("unlockMortarTurret") < 1)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("unlockMortarTurret");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("unlockMortarTurret", counterNewValue);

                        skillCanBeUnlocked[externalSkillName.moreDamageMortarTurret] = true;
                        skillCanBeUnlocked[externalSkillName.moreRangeMortarTurret] = true;
                        skillCanBeUnlocked[externalSkillName.moreHealthMortarTurret] = true;


                        UnlockSkillLogic(skill);

                        //Falta la logica que desbloque la torreta de morteros


                    }
                    break;

                case externalSkillName.moreDamageMortarTurret:

                    if (PlayerPrefs.GetFloat("moreDamageMortarTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreDamageMortarTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreDamageMortarTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("damagedM");  // 0 es el valor predeterminado si la clave a�n no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damagedM", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        //HAY que hacer esto para que el ultimo click lo marque como desbloqueado y al mismo tiempo de la habilidad
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreDamageMortarTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreDamageMortarTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("damagedM");  // 0 es el valor predeterminado si la clave a�n no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damagedM", newValue);


                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.moreHealthMortarTurret:

                    if (PlayerPrefs.GetFloat("moreHealthMortarTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreHealthMortarTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreHealthMortarTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("vidaM");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaM", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreHealthMortarTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreHealthMortarTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("vidaM");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaM", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.moreRangeMortarTurret:

                    if (PlayerPrefs.GetFloat("moreRangeMortarTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeMortarTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeMortarTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeM");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeM", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeMortarTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeMortarTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeM");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeM", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
            }


        }

    }

    private void UnlockSkillLogic(externalSkillName skill)
    {

        externalSkillPoints -= skillCost[skill];
        isSkillUnlocked[skill] = true;
        string skillname = skill.ToString();
        PlayerPrefs.SetFloat(skillname, 1);
        UpdateSkillUI();
    }

    public void UpdateSkillUI()
    {
        foreach (KeyValuePair<externalSkillName, int> kvp in skillCost)
        {
            externalSkillName clave = kvp.Key;
            int valor = kvp.Value;

            if (kvp.Value > externalSkillPoints && isSkillUnlocked[kvp.Key] == false && skillCanBeUnlocked[kvp.Key] == true)
            {
                foreach (GameObject skillButtons in SkillButtons)
                {
                    if (skillButtons.gameObject.name == kvp.Key.ToString())
                    {
                        skillButtons.gameObject.GetComponent<Image>().color = notEnoughRPcolor;
                        skillButtons.gameObject.GetComponent<Button>().interactable = true;
                    }
                }
            }
            if (kvp.Value <= externalSkillPoints && isSkillUnlocked[kvp.Key] == false)
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
            if (isSkillUnlocked[kvp.Key] == true)
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
            if (skillCanBeUnlocked[kvp.Key] == false)
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
