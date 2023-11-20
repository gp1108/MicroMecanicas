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
    [Header("Buttons")]
    public GameObject wallButton;
    public GameObject turretButton;
    public GameObject otherTurretButton;
    public GameObject tallerButton;
    public GameObject sniperButton;
    public GameObject laserButton;
    public GameObject mineButton;
    

    public void Start()
    {

        StartCoroutine("GoldCheck");

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

    public void SniperTurretIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(4);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void LaserTurretIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(5);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void MineIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(6);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }


    IEnumerator GoldCheck()
    {
        while (true)
        {
            if(BuildManager.dameReferencia.wallCost > gameManager.giveMeReference.gold)
            {
                wallButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                wallButton.GetComponent<Button>().interactable = true;
            }

            if(BuildManager.dameReferencia.baseTurretCost > gameManager.giveMeReference.gold)
            {
                turretButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                turretButton.GetComponent<Button>().interactable = true;
            }

            if (BuildManager.dameReferencia.otherTurretCost > gameManager.giveMeReference.gold)
            {
                otherTurretButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                otherTurretButton.GetComponent<Button>().interactable = true;
            }
            
            if (BuildManager.dameReferencia.researchStructureCost > gameManager.giveMeReference.gold)
            {
                tallerButton.GetComponent<Button>().interactable = false;
            }
            else if(BuildManager.dameReferencia.researchStructureCost < gameManager.giveMeReference.gold && gameManager.giveMeReference.numberOfLabs < gameManager.giveMeReference.maxNumberOfLabs)
            {
                tallerButton.GetComponent<Button>().interactable = true;
            }
            else if (gameManager.giveMeReference.numberOfLabs == gameManager.giveMeReference.maxNumberOfLabs)
            {
                tallerButton.GetComponent<Button>().interactable = false;
                
            }

            if (BuildManager.dameReferencia.sniperTurretCost > gameManager.giveMeReference.gold)
            {
                sniperButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                sniperButton.GetComponent<Button>().interactable = true;
            }

            if (BuildManager.dameReferencia.laserTurretCost > gameManager.giveMeReference.gold)
            {
                laserButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                laserButton.GetComponent<Button>().interactable = true;
            }

            if (BuildManager.dameReferencia.mineCost > gameManager.giveMeReference.gold)
            {
                mineButton.GetComponent<Button>().interactable = false;
            }
            else if (BuildManager.dameReferencia.mineCost < gameManager.giveMeReference.gold && gameManager.giveMeReference.numberOfMines < gameManager.giveMeReference.maxNumberOfMines)
            {
                mineButton.GetComponent<Button>().interactable = true;
            }
            else if (gameManager.giveMeReference.numberOfMines == gameManager.giveMeReference.maxNumberOfMines)
            {
                mineButton.GetComponent<Button>().interactable = false;
                
            }
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
