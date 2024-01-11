using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchMenu : MonoBehaviour
{
    public GameObject researchMenuPanel;
    public bool researchMenuActive;
    [Header("Build Panel")]
    public GameObject canvas;

    void Start()
    {
        researchMenuActive = false;
    }

   public void EnableOrDisableResearchPanel()
   {
        researchMenuActive = !researchMenuActive;

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
