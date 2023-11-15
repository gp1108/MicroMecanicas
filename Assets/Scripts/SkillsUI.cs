using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static Skills;

public class SkillsUI : MonoBehaviour
{
    public Color unlockedSkillColor;
    public Color notEnoughRPcolor;
    public Color defaultColor;
    public GameObject moreHealthTurretsButton;

    private void Start()
    {
      defaultColor = moreHealthTurretsButton.GetComponent<Button>().colors.normalColor;
    }




    public void moreHealthTurret()
    {
        if (Skills.giveMeReference.isSkillUnlocked[SkillName.moreHealthTurrets] == false && gameManager.giveMeReference.researchPoints >= Skills.giveMeReference.skillCost[SkillName.moreHealthTurrets])
        {

            /*ESTO DEBERIA IR EN UPDATESKILLUI DEL SCRIPT SKILLS
            Skills.giveMeReference.unlockSkill(SkillName.moreHealthTurrets);
            moreHealthTurretsButton.GetComponent<Button>().interactable = false;
            moreHealthTurretsButton.GetComponent<Image>().color = unlockedSkillColor;
            */
        }
        else if(gameManager.giveMeReference.researchPoints < Skills.giveMeReference.skillCost[SkillName.moreHealthTurrets])
        {
            //hacer que el boton no sea interactuable y pintarlo de verde o algo
        }
    }

    
}
