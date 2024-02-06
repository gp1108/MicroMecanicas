using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static Skills;
using static ExternalSkills;

public class SkillsUI : MonoBehaviour
{

    private string _SkillNameString;
    public GameObject goldPanelButton;
    private Color _goldButtonColor;

    private void Start()
    {
        _SkillNameString = this.gameObject.name;
        if(goldPanelButton != null)
        {
            _goldButtonColor = goldPanelButton.GetComponent<Image>().color;
        }
        

    }


    public void CallSkillUnlockFunction()
    {
        SoundManager.dameReferencia.PlayOneClipByName(clipName: "PowerUp2");

        foreach (SkillName skillName in Enum.GetValues(typeof(SkillName)))
        {
            if (_SkillNameString == skillName.ToString())
            {
                Skills.giveMeReference.unlockSkill(skillName);
            }
        }
    }

    public void externalCallSkillUnlockFunction()
    {
        SoundManager.dameReferencia.PlayOneClipByName(clipName: "PowerUp");

        foreach (externalSkillName skillName in Enum.GetValues(typeof(externalSkillName)))
        {
            if (_SkillNameString == skillName.ToString())
            {
                ExternalSkills.giveMeReference.unlockSkill(skillName);
            }
        }
    }

    public void BuyGoldPanel()
    {
        Skills.giveMeReference.unlockGoldPanels(this.gameObject);
        
    }

    private void Update()
    {
        if (goldPanelButton != null)
        {
           
            if (Skills.giveMeReference.panelCost > gameManager.giveMeReference.gold)
            {
                goldPanelButton.GetComponent<Button>().interactable = false;
                goldPanelButton.GetComponent<Image>().color = Color.red;
            }
            else
            {
                goldPanelButton.GetComponent<Button>().interactable = true;
                goldPanelButton.GetComponent<Image>().color = _goldButtonColor;

            }

        }
    }

   

}
