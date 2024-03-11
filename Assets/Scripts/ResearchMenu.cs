using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchMenu : MonoBehaviour
{
    public GameObject researchMenuPanel;
    public GameObject skillManager;
    public bool researchMenuActive;
    [Header("Build Panel")]
    public GameObject canvas;

    void Start()
    {
        researchMenuActive = false;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (gameManager.giveMeReference.onRound == false)
            {
                if (gameManager.giveMeReference.numberOfLabs > 0)
                {
                    EnableOrDisableResearchPanel();
                }
            }
        }
    }

    public void EnableOrDisableResearchPanel()
   {
        researchMenuActive = !researchMenuActive;
        skillManager.GetComponent<Skills>().UpdateSkillUI();
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");

        if(researchMenuActive == false)
        {
            researchMenuPanel.SetActive(false);

        }
        else
        {
            researchMenuPanel.SetActive(true);
            if (canvas.GetComponent<BuildMenuButton>().buildMenuActive == false)
            {
                
                canvas.GetComponent<BuildMenuButton>().buildMenuActive = true;
                canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
                

            }
            else
            {
                canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
            }
        }


   }
}
