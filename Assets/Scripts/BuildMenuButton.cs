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
    public GameObject slowTurretButton;
    public GameObject explosiveMineButton;


    public void Start()
    {

        StartCoroutine("GoldCheck");

        destroyModeActive = false;
        buildMenuActive = true;
    }

    
    public void EnableOrDisableBuildPanel()
    {
        buildMenuActive = !buildMenuActive;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");

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

                SoundManager.dameReferencia.PlayClipByName(clipName: "Build");
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
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        else
        {
            destroyButton.GetComponent<Image>().color = Color.white;
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
    }



    private void Update()
    {
        if (UpgradeManager.giveMeReference.isMineUnlocked != 0)
        {
            explosiveMineButton.SetActive(true);
        }
        else
        {
            explosiveMineButton.SetActive(false);
        }

        if (UpgradeManager.giveMeReference.isSlowTurretUnlocked != 0)
        {
            slowTurretButton.SetActive(true);
        }
        else
        {
            slowTurretButton.SetActive(false);
        }
    }



    public void SetWallsIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(0);
        if(destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void SetBaseTurretIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(1);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void OtherTurretIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(2);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void SetResearchStructureIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(3);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void SniperTurretIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(4);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void LaserTurretIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(5);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void MineIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(6);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void SlowTurretIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(7);
        if (destroyModeActive == true)
        {
            destroyModeActive = false;
            destroyButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void ExplosiveMineIndex()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        BuildManager.dameReferencia.GetStructurePrefabIndex(8);
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

            if (BuildManager.dameReferencia.slowTurretCost > gameManager.giveMeReference.gold)
            {
                slowTurretButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                slowTurretButton.GetComponent<Button>().interactable = true;
            }

            if (BuildManager.dameReferencia.explosiveMineCost > gameManager.giveMeReference.gold)
            {
                explosiveMineButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                explosiveMineButton.GetComponent<Button>().interactable = true;
            }
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
