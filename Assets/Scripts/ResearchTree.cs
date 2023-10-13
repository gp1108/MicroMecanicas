using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTree : MonoBehaviour
{
    // Referencia de donde he aprendido hacer esto https://www.youtube.com/watch?v=fE0R6WLpmrE&ab_channel=ConsideraCore
    private static ResearchTree _Reference;

    public static ResearchTree giveMeReference
    {
        get
        {


            if (_Reference == null)
            {
                _Reference = FindObjectOfType<ResearchTree>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("ResearchTree");
                    _Reference = go.AddComponent<ResearchTree>();
                }
            }
            return _Reference;
        }
    }


    public int[] skillLevels;
    public int[] skillCaps;
    public string[] skillNames;
    public string[] skillDescriptions;

    public List<ResearchSkill> skillList;
    public GameObject skillHolder;

    public List<GameObject> connectorList;
    public GameObject connectorHolder;


    public int SkillPoint; //deberia ser rondas pasadas 

    private void Start()
    {
        SkillPoint = 20;

        skillLevels = new int[6]; // este es el numero total de mejoras 
        skillCaps = new int[] {1, 2, 2, 3, 3, 3, }; //esto es lo que cuesta investigar cada habilidad
        skillNames = new string[] {"Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Upgrade 5", "Upgrade 6", }; //Estos son los nombres de cada mejora
        skillDescriptions = new string[] {
        
        "Esta mejora hace esto 1",
        "Esta mejora hace esto 2",
        "Esta mejora hace esto 3",
        "Esta mejora hace esto 4",
        "Esta mejora hace esto 5",
        "Esta mejora hace esto 6",


        };

        foreach (var skill in skillHolder.GetComponentsInChildren<ResearchSkill>())
        {
            skillList.Add(skill);
        }
        foreach (RectTransform connector in connectorHolder.GetComponentsInChildren<RectTransform>())
        {
            connectorList.Add(connector.gameObject);
        }

        for (int i = 0; i< skillList.Count; i++) // Aqui le estamos asignando a cada mejora un id
        {
            skillList[i].id = i;
        }

        skillList[0].connectedSkills = new [] {1 ,2 ,4}; // Aqui creas manualmente las conexciones entre ellos
        skillList[1].connectedSkills = new [] { 3 };
        skillList[4].connectedSkills = new [] { 5 };

        UpdateAllSkillUI();
    }
    public void UpdateAllSkillUI()
    {
        foreach (var skill in skillList)
        {
            skill.UpdateUI();
        }
    }

}
