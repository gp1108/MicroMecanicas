using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ResearchTree;
using UnityEngine.UI;

public class ResearchSkill : MonoBehaviour
{
    public int id; // para saber que upgrade es cada una
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public int[] connectedSkills;


    public void UpdateUI()
    {
        titleText.text = $"{ResearchTree.giveMeReference.skillLevels[id]}/{ResearchTree.giveMeReference.skillCaps[id]}\n{ ResearchTree.giveMeReference.skillNames[id]}";
        descriptionText.text = $"{ResearchTree.giveMeReference.skillDescriptions[id]}\nCost: {ResearchTree.giveMeReference.SkillPoint}/1 SP";

        GetComponent<Image>().color = ResearchTree.giveMeReference.skillLevels[id] >= ResearchTree.giveMeReference.skillCaps[id] ? Color.yellow
            : ResearchTree.giveMeReference.SkillPoint > 0 ? Color.green : Color.white;


        foreach ( int connectedskills in connectedSkills )
        {

            ResearchTree.giveMeReference.skillList[connectedskills].gameObject.SetActive(ResearchTree.giveMeReference.skillLevels[id] > 0);
            ResearchTree.giveMeReference.connectorList[connectedskills].SetActive(ResearchTree.giveMeReference.skillLevels[id] > 0);
        }
    }

    public void BuySkill()
    {
        if (ResearchTree.giveMeReference.SkillPoint < 1 || ResearchTree.giveMeReference.skillLevels[id] >= ResearchTree.giveMeReference.skillCaps[id]) return;
        ResearchTree.giveMeReference.SkillPoint -= 1;
        ResearchTree.giveMeReference.skillLevels[id]++;
        ResearchTree.giveMeReference.UpdateAllSkillUI();
    }
}
