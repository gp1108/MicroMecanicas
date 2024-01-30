using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
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
        {externalSkillName.moreRangeBasicTurret,2 },
        {externalSkillName.moreHealthBasicTurret,55 },

        {externalSkillName.moreSlowSlowTurret,1 },
        {externalSkillName.moreRangeSlowTurret,2 },
        {externalSkillName.moreHealthSlowTurret,3 },
        {externalSkillName.unlockSlowTurret,4 },

        {externalSkillName.unlockMineTurret,1 },
        {externalSkillName.moreDamageMineTurret,2 },
        {externalSkillName.moreRangeMineTurret,3 },
        

        {externalSkillName.oneReseachPointExtra,10 },
        {externalSkillName.moreGoldPerMine,11 },
        {externalSkillName.startWithExtraGold,12 },
        {externalSkillName.startWithExtraResearchPoints,13 },


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

        {externalSkillName.unlockMineTurret,false },
        {externalSkillName.moreDamageMineTurret,false },
        {externalSkillName.moreRangeMineTurret,false },
        

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

        {externalSkillName.unlockMineTurret,true },
        {externalSkillName.moreDamageMineTurret,false },
        {externalSkillName.moreRangeMineTurret,false },
        

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
    
    public TMP_Text skill10text;
    public TMP_Text skill11text;
    public TMP_Text skill12text;
    public TMP_Text skill13text;

    [Header("SkillsCosteText")]
    public TMP_Text skillCost1text;
    public TMP_Text skillCost2text;
    public TMP_Text skillCost3text;
    public TMP_Text skillCost4text;
    public TMP_Text skillCost5text;
    public TMP_Text skillCost6text;
    public TMP_Text skillCost7text;
    public TMP_Text skillCost8text;
    public TMP_Text skillCost9text;
    public TMP_Text skillCost10text;
    public TMP_Text skillCost11text;
    public TMP_Text skillCost12text;
    public TMP_Text skillCost13text;
    public TMP_Text skillCost14text;

    [Header("Barras")]
    public GameObject barra1;
    public GameObject barra2;
    public GameObject barra3;
    public GameObject barra4;




    //Puntos externos Quizas deban ir en el gamemanager, tambien deben ser guardables entre partida
    private float externalSkillPoints;

    public enum externalSkillName
    {
        moreDamageBasicTurret,
        moreRangeBasicTurret,
        moreHealthBasicTurret,

        unlockSlowTurret,
        moreSlowSlowTurret,
        moreRangeSlowTurret,
        moreHealthSlowTurret,

        unlockMineTurret,
        moreDamageMineTurret,
        moreRangeMineTurret,
        

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
                            barra2.SetActive(true);
                        }
                        if (ppName == "unlockMineTurret")
                        {
                            skillCanBeUnlocked[externalSkillName.moreDamageMineTurret] = true;
                            skillCanBeUnlocked[externalSkillName.moreRangeMineTurret] = true;
                            barra3.SetActive(true);
                            

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
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
            UpdateSkillUI();
            UpdateSkillTexts();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetFloat("externalResearchPoints", 100);
            UpdateSkillUI();
            UpdateSkillTexts();
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

        skill7text.text = PlayerPrefs.GetFloat("moreDamageMineTurretAmount").ToString() + "/5";
        skill8text.text = PlayerPrefs.GetFloat("moreRangeMineTurretAmount").ToString() + "/5";
        

        skill10text.text = PlayerPrefs.GetFloat("oneResearchPointExtraAmount").ToString() + "/3";
        skill11text.text = PlayerPrefs.GetFloat("moreGoldPerMineAmount").ToString() + "/3";
        skill12text.text = PlayerPrefs.GetFloat("startWithMoreGoldAmount").ToString() + "/3";
        skill13text.text = PlayerPrefs.GetFloat("startWithMoreResearchPointsAmount").ToString() + "/3";



        skillCost1text.text = skillCost[externalSkillName.moreDamageBasicTurret].ToString() + " SP";
        skillCost2text.text = skillCost[externalSkillName.moreRangeBasicTurret].ToString() + " SP";
        skillCost3text.text = skillCost[externalSkillName.moreHealthBasicTurret].ToString() + " SP";

        skillCost13text.text = skillCost[externalSkillName.unlockSlowTurret].ToString() + " SP";
        skillCost4text.text = skillCost[externalSkillName.moreSlowSlowTurret].ToString() + " SP";
        skillCost5text.text = skillCost[externalSkillName.moreRangeSlowTurret].ToString() + " SP";
        skillCost6text.text = skillCost[externalSkillName.moreHealthSlowTurret].ToString() + " SP";

        skillCost14text.text = skillCost[externalSkillName.unlockMineTurret].ToString() + " SP";
        skillCost7text.text = skillCost[externalSkillName.moreDamageMineTurret].ToString() + " SP";
        skillCost8text.text = skillCost[externalSkillName.moreRangeMineTurret].ToString() + " SP";

        skillCost9text.text = skillCost[externalSkillName.oneReseachPointExtra].ToString() + " SP";
        skillCost10text.text = skillCost[externalSkillName.moreGoldPerMine].ToString() + " SP";
        skillCost11text.text = skillCost[externalSkillName.startWithExtraGold].ToString() + " SP";
        skillCost12text.text = skillCost[externalSkillName.startWithExtraResearchPoints].ToString() + " SP";



        externalSkillPointsText.text = "Skill Points: " + PlayerPrefs.GetFloat("externalResearchPoints");
    }

    private void Start()
    {
        //TODOS LOS CHECKPLAYERPREFS SON LAS VARIABLES QUE ALTERAN LAS ESTADICSTICAS ,
        //LOS AMOUNTS SON LA CANTIDAD DE VECES QUE SE PUEDE MEJORAR ESA HABILIDAD, Y LOS ISSKILLUNLOCKED MANTIENEN EL PROGRESO GUARDADO DE ESA HABILIDAD
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
        CheckPlayerPrefsKey("vidaAm", 10);
        CheckPlayerPrefsKey("damagedAm", 5);
        CheckPlayerPrefsKey("cadenceAm", 0.3f);
        CheckPlayerPrefsKey("rangeAm", 10);
        CheckPlayerPrefsKey("visionAm", 15);

        //Torreta Aerea
        CheckPlayerPrefsKey("vidaA", 10);
        CheckPlayerPrefsKey("damagedA", 5);
        CheckPlayerPrefsKey("cadenceA", 1);
        CheckPlayerPrefsKey("rangeA", 10);
        CheckPlayerPrefsKey("visionA", 15);
        
        //Muros
        CheckPlayerPrefsKey("vidaW", 10);

        // Mina
        CheckPlayerPrefsKey("unlockMine", 0);
        CheckPlayerPrefsKey("damagedM", 5);
        CheckPlayerPrefsKey("rangeM", 10);

        //TurretMortero
        CheckPlayerPrefsKey("vidaMortero",10);
        CheckPlayerPrefsKey("damagedMortero",5);
        CheckPlayerPrefsKey("cadenceMortero",5);
        CheckPlayerPrefsKey("rangeMortero",30);
        CheckPlayerPrefsKey("visionMortero",40);

        //ResearchPoints
        CheckPlayerPrefsKey("oneResearchPoint", 0);
        //GoldMines
        CheckPlayerPrefsKey("moreGoldPerGoldMines", 0);
        //Miscelaneous
        CheckPlayerPrefsKey("startWithMoreGold", 0);
        CheckPlayerPrefsKey("startWithMoreResearchPoints", 0);

        //RESEARCHPOINTS
        CheckPlayerPrefsKey("externalResearchPoints", 0);

        //Contadores
        CheckPlayerPrefsKey("moreDamageBasicTurretAmount", 0);
        CheckPlayerPrefsKey("moreRangeBasicTurretAmount", 0);
        CheckPlayerPrefsKey("moreHealthBasicTurretAmount", 0);

        CheckPlayerPrefsKey("moreSlowSlowTurretAmount", 0);
        CheckPlayerPrefsKey("moreRangeSlowTurretAmount", 0);
        CheckPlayerPrefsKey("moreHealthSlowTurretAmount", 0);

        CheckPlayerPrefsKey("moreDamageMineTurretAmount", 0);
        CheckPlayerPrefsKey("moreRangeMineTurretAmount", 0);
        CheckPlayerPrefsKey("moreHealthMineTurretAmount", 0);

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

        isSkillUnlockedPP("unlockMineTurret", 0);
        isSkillUnlockedPP("moreDamageMineTurret", 0);
        isSkillUnlockedPP("moreRangeMineTurret", 0);
        isSkillUnlockedPP("moreHealthMineTurret", 0);

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
        if (skillCost[skill] <= PlayerPrefs.GetFloat("externalResearchPoints"))
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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);
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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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
                        barra2.SetActive(true);


                        UnlockSkillLogic(skill);
                        
                        //Falta la logica que desbloque la torreta de slows
                        //Creo q la logica esta , se desarrolla al checkear ingame si la variable unlockSlowTurret es 1 o 0


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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                case externalSkillName.unlockMineTurret:

                    if (PlayerPrefs.GetFloat("unlockMineTurret") < 1)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("unlockMineTurret");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("unlockMineTurret", counterNewValue);

                        skillCanBeUnlocked[externalSkillName.moreDamageMineTurret] = true;
                        skillCanBeUnlocked[externalSkillName.moreRangeMineTurret] = true;
                        barra3.SetActive(true);


                        UnlockSkillLogic(skill);

                        //Falta la logica que desbloque la torreta de las minas


                    }
                    break;

                case externalSkillName.moreDamageMineTurret:

                    if (PlayerPrefs.GetFloat("moreDamageMineTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreDamageMineTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreDamageMineTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("damagedM");  // 0 es el valor predeterminado si la clave a�n no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damagedM", newValue);

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

                        UpdateSkillUI();
                        UpdateSkillTexts();
                    }
                    else
                    {
                        //HAY que hacer esto para que el ultimo click lo marque como desbloqueado y al mismo tiempo de la habilidad
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreDamageMineTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreDamageMineTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("damagedM");  // 0 es el valor predeterminado si la clave a�n no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damagedM", newValue);


                        UnlockSkillLogic(skill);
                    }
                    break;
                
                case externalSkillName.moreRangeMineTurret:

                    if (PlayerPrefs.GetFloat("moreRangeMineTurretAmount") < 4)
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeMineTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeMineTurretAmount", counterNewValue);

                        float currentValue = PlayerPrefs.GetFloat("rangeM");
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeM", newValue);

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

                        UpdateSkillUI();
                        UpdateSkillTexts();
                    }
                    else
                    {
                        float counterCurrentValue = PlayerPrefs.GetFloat("moreRangeMineTurretAmount");
                        float counterNewValue = counterCurrentValue + 1;
                        SavePlayerPrefs("moreRangeMineTurretAmount", counterNewValue);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

                        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
                        externalSkillPoints -= skillCost[skill];
                        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

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

        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
        externalSkillPoints -= skillCost[skill];
        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillPoints);

        isSkillUnlocked[skill] = true;
        string skillname = skill.ToString();
        PlayerPrefs.SetFloat(skillname, 1);
        UpdateSkillUI();
        UpdateSkillTexts();
    }

    public TMP_Text externalSkillPointsText;

    public void UpdateSkillUI()
    {
        externalSkillPoints = PlayerPrefs.GetFloat("externalResearchPoints");
        externalSkillPointsText.text = "Skill Points: " + PlayerPrefs.GetFloat("externalResearchPoints");


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
