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

    private void Start()
    {
        _SkillNameString = this.gameObject.name;
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
        SoundManager.dameReferencia.PlayClipByName(clipName: "Gold");
    }

}
