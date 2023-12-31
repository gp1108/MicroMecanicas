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

        {externalSkillName.oneReseachPointExtra,10 },
        {externalSkillName.moreGoldPerMine,10 },
        {externalSkillName.startWithExtraGold,10 },
        {externalSkillName.startWithExtraResearchPoints,10 },


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

        {externalSkillName.oneReseachPointExtra,false },
        {externalSkillName.moreGoldPerMine,false },
        {externalSkillName.startWithExtraGold,false },
        {externalSkillName.startWithExtraResearchPoints,false },

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

        {externalSkillName.oneReseachPointExtra,true },
        {externalSkillName.moreGoldPerMine,true },
        {externalSkillName.startWithExtraGold,true },
        {externalSkillName.startWithExtraResearchPoints,true },
    };


    [Header("Skills")]
    public List<GameObject> SkillButtons = new List<GameObject>();

    public Color unlockedSkillColor;
    public Color notEnoughRPcolor;
    public Color defaultColor;
    public Color dependency;
    private GameObject canvas;

    [Header("SkillsText")]
    public TMP_Text skill1text;
    public TMP_Text skill2text;
    public TMP_Text skill3text;
    public TMP_Text skill4text;
    public TMP_Text skill5text;
    public TMP_Text skill6text;
    public TMP_Text skill7text;
    public TMP_Text skill8text;
    public TMP_Text skill9text;
    public TMP_Text skill10text;
    public TMP_Text skill11text;
    public TMP_Text skill12text;
    public TMP_Text skill13text;


   

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

        oneReseachPointExtra,
        moreGoldPerMine,
        startWithExtraGold,
        startWithExtraResearchPoints,
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

        if(Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void UpdateSkillTexts()
    {
        skill1text.text = PlayerPrefs.GetFloat("moreDamageBasicTurretAmount").ToString() + "/5";
        skill2text.text = PlayerPrefs.GetFloat("moreRangeBasicTurretAmount").ToString() + "/5";
        skill3text.text = PlayerPrefs.GetFloat("moreHealthBasicTurretAmount").ToString() + "/5";

        skill4text.text = PlayerPrefs.GetFloat("moreSlowSlowTurretAmount").ToString() + "/5";
        skill5text.text = PlayerPrefs.GetFloat("moreRangeSlowTurretAmount").ToString() + "/5";
        skill6text.text = PlayerPrefs.GetFloat("moreHealthSlowTurretAmount").ToString() + "/5";

        skill7text.text = PlayerPrefs.GetFloat("moreDamageMortarTurretAmount").ToString() + "/5";
        skill8text.text = PlayerPrefs.GetFloat("moreRangeMortarTurretAmount").ToString() + "/5";
        skill9text.text = PlayerPrefs.GetFloat("moreHealthMortarTurretAmount").ToString() + "/5";

        skill10text.text = PlayerPrefs.GetFloat("oneResearchPointExtraAmount").ToString() + "/3";
        skill11text.text = PlayerPrefs.GetFloat("moreGoldPerMineAmount").ToString() + "/3";
        skill12text.text = PlayerPrefs.GetFloat("startWithMoreGoldAmount").ToString() + "/3";
        skill13text.text = PlayerPrefs.GetFloat("startWithMoreResearchPointsAmount").ToString() + "/3";
    }

    private void Start()
    {
        //TODOS LOS CHECKPLAYERPREFS SON LAS VARIABLES QUE ALTERAN LAS ESTADICSTICAS ,
        //LOS AMOUNTS SON LA CANTIDAD DE VERCES QUE SE PUEDE MEJORAR ESA HABILIDAD, Y LOS ISSKILLUNLOCKED MANTIENEN EL PROGRESO GUARDADO DE ESA HABILIDAD
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


        //ResearchPoints
        CheckPlayerPrefsKey("oneResearchPoint", 0);
        //GoldMines
        CheckPlayerPrefsKey("moreGoldPerGoldMines", 0);
        //Miscelaneous
        CheckPlayerPrefsKey("startWithMoreGold", 0);
        CheckPlayerPrefsKey("startWithMoreResearchPoints", 0);

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

        CheckPlayerPrefsKey("oneResearchPointExtraAmount", 0);

        CheckPlayerPrefsKey("moreGoldPerMineAmount", 0);

        CheckPlayerPrefsKey("startWithMoreGoldAmount", 0);
        CheckPlayerPrefsKey("startWithMoreResearchPointsAmount", 0);

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

        isSkillUnlockedPP("oneReseachPointExtra", 0);
        isSkillUnlockedPP("moreGoldPerMine", 0);

        isSkillUnlockedPP("startWithExtraGold", 0);
        isSkillUnlockedPP("startWithExtraResearchPoints", 0);








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
        UpdateSkillTexts();


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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                        UpdateSkillTexts();
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
                case externalSkillName.oneReseachPointExtra:

                    if (PlayerPrefs.GetFloat("oneResearchPointExtraAmount") < 2)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("oneResearchPointExtraAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("oneResearchPointExtraAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("oneResearchPoint");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("oneResearchPoint", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                        UpdateSkillTexts();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("oneResearchPointExtraAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("oneResearchPointExtraAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("oneResearchPoint");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("oneResearchPoint", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.moreGoldPerMine:

                    if (PlayerPrefs.GetFloat("moreGoldPerMineAmount") < 2)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreGoldPerMineAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreGoldPerMineAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("moreGoldPerGoldMines");
                        float newValue = currentValue + 50;
                        SavePlayerPrefs("moreGoldPerGoldMines", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                        UpdateSkillTexts();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreGoldPerMineAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreGoldPerMineAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("moreGoldPerGoldMines");
                        float newValue = currentValue + 50;
                        SavePlayerPrefs("moreGoldPerGoldMines", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.startWithExtraGold:

                    if (PlayerPrefs.GetFloat("startWithMoreGoldAmount") < 2)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("startWithMoreGoldAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("startWithMoreGoldAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("startWithMoreGold");
                        float newValue = currentValue + 50;
                        SavePlayerPrefs("startWithMoreGold", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                        UpdateSkillTexts();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("startWithMoreGoldAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("startWithMoreGoldAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("startWithMoreGold");
                        float newValue = currentValue + 50;
                        SavePlayerPrefs("startWithMoreGold", newValue);

                        UnlockSkillLogic(skill);
                    }
                    break;
                case externalSkillName.startWithExtraResearchPoints:

                    if (PlayerPrefs.GetFloat("startWithMoreResearchPointsAmount") < 2)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("startWithMoreResearchPointsAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("startWithMoreResearchPointsAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("startWithMoreResearchPoints");
                        float newValue = currentValue + 50;
                        SavePlayerPrefs("startWithMoreResearchPoints", newValue);

                        externalSkillPoints -= skillCost[skill];
                        UpdateSkillUI();
                        UpdateSkillTexts();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("startWithMoreResearchPointsAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("startWithMoreResearchPointsAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("startWithMoreResearchPoints");
                        float newValue = currentValue + 50;
                        SavePlayerPrefs("startWithMoreResearchPoints", newValue);

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
        UpdateSkillTexts();
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
