using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ExternalSkills : MonoBehaviour
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
   

    // Define el costo de cada habilidad
    public Dictionary<SkillName, int> skillCost = new Dictionary<SkillName, int>
    {
        { SkillName.moreDamageBasicTurret, 1 },
       

    };

    //Define si ha sido desbloqueado o no 
    public Dictionary<SkillName, bool> isSkillUnlocked = new Dictionary<SkillName, bool>
    {
        { SkillName.moreDamageBasicTurret, false },
        

    };

    public Dictionary<SkillName, bool> skillCanBeUnlocked = new Dictionary<SkillName, bool>
    {
        { SkillName.moreDamageBasicTurret, true },
        

    };


    [Header("Skills")]
    public List<GameObject> SkillButtons = new List<GameObject>();

    public Color unlockedSkillColor;
    public Color notEnoughRPcolor;
    public Color defaultColor;
    public Color dependency;
    private GameObject canvas;

    public enum SkillName
    {
        moreDamageBasicTurret,
        moreRangeBasicTurret,
        moreHealthBasicTurret,

        moreSlowSlowTurret,
        moreRangeSlowTurret,
        moreHealthSlowTurret,
    }

    private int moreDamageBasicTurretAmount = 0;
    private int moreRangeBasicTurretAmount = 0;
    public int moreHealthBasicTurretAmount = 0;

    private int moreSlowSlowTurretAmount = 0;
    private int moreRangeSlowTurretAmount = 0;
    private int moreHealthSlowTurretAmount = 0;



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

    public void SavePlayerPrefs(string ppName, float valueToStore)
    {
        PlayerPrefs.SetFloat(ppName, valueToStore);
        PlayerPrefs.Save();  // Guardar importante si quieres que se guarde en el disco duro
    }

    private void Start()
    {
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


        canvas = GameObject.FindGameObjectWithTag("Canvas");
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
   
    public void unlockSkill(SkillName skill)
    {
        if (skillCost[skill] <= gameManager.giveMeReference.researchPoints)
        {

            switch (skill)
            {
                case SkillName.moreDamageBasicTurret:

                   if(moreDamageBasicTurretAmount < 5)
                   {
                        moreDamageBasicTurretAmount++;
                        float currentValue = PlayerPrefs.GetFloat("damageB");  // 0 es el valor predeterminado si la clave aún no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("damageB", newValue);
                   }
                   else
                   {
                        UnlockSkillLogic(skill);
                   }
                   break;
                case SkillName.moreHealthBasicTurret:

                    if (moreHealthBasicTurretAmount < 5)
                    {
                        moreHealthBasicTurretAmount++;
                        float currentValue = PlayerPrefs.GetFloat("vidaB");  // 0 es el valor predeterminado si la clave aún no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("vidaB", newValue);
                    }
                    else
                    {
                        UnlockSkillLogic(skill);
                    }
                    break;
                case SkillName.moreRangeBasicTurret:

                    if (moreRangeBasicTurretAmount < 5)
                    {
                        moreRangeBasicTurretAmount++;
                        float currentValue = PlayerPrefs.GetFloat("rangeB");  // 0 es el valor predeterminado si la clave aún no existe
                        float newValue = currentValue + 5;
                        SavePlayerPrefs("rangeB", newValue);
                    }
                    else
                    {
                        UnlockSkillLogic(skill);
                    }
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

            if (kvp.Value > gameManager.giveMeReference.researchPoints && isSkillUnlocked[kvp.Key] == false && skillCanBeUnlocked[kvp.Key] == true)
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
            if (kvp.Value <= gameManager.giveMeReference.researchPoints && isSkillUnlocked[kvp.Key] == false)
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
