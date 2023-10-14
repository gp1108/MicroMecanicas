using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;


public class BuildMenuButton : MonoBehaviour
{
    public GameObject buildMenuPanel;
    public bool buildMenuActive;
    public GameObject nodes;
    [Header("Destroy Function")]
    public bool destroyModeActive;
    public GameObject destroyButton;
    [Header("Research Panel")]
    public GameObject canvas;
    

    public void Start()
    {
       


        destroyModeActive = false;
        buildMenuActive = true;
    }


    public void EnableOrDisableBuildPanel()
    {
        buildMenuActive = !buildMenuActive;

        if(buildMenuActive == true)
        {
            buildMenuPanel.SetActive(true);
            nodes.SetActive(true);
            BuildManager.dameReferencia.DestroyPreviewPrefab(); // se encarga de limpiar el preview obsoleto
            destroyModeActive = false;
            if(canvas.GetComponent<ResearchMenu>().researchMenuActive == false)//desactiva cualquier otro panel en pantalla
            {
                canvas.GetComponent<ResearchMenu>().researchMenuActive = true;
                canvas.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
            }
            else
            {
                canvas.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
            }
        }
        else
        {
            buildMenuPanel.SetActive(false);
            nodes.SetActive(false);
            destroyModeActive = false;
        }
        
    }

    public void DestroyStructure()
    {
        destroyModeActive = !destroyModeActive;

        if(destroyModeActive == true)
        {
            destroyButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }






    public void SetWallsIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(0);
        if(destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void SetBaseTurretIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(1);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void OtherTurretIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(2);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void SetResearchStructureIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(3);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
}
