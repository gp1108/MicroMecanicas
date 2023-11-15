using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Skills;

public class SkillsUI : MonoBehaviour
{

    



    public void moreHealthTurret()
    {
        if (Skills.giveMeReference.isSkillUnlocked[SkillName.moreHealthTurrets] == false)
        {
            Skills.giveMeReference.unlockSkill(SkillName.moreHealthTurrets);
        }
        else
        {
            //hacer que el boton no sea interactuable y pintarlo de verde o algo
        }
    }
}
