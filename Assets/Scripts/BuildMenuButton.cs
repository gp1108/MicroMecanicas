using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;


public class BuildMenuButton : MonoBehaviour
{
    public GameObject buildMenuPanel;
    private bool _buildMenuActive;
    public GameObject nodes;
    [Header("Destroy Function")]
    public bool destroyModeActive;
    public GameObject destroyButton;


    public void Start()
    {
        destroyModeActive = false;
    }


    public void EnableOrDisableBuildPanel()
    {
        _buildMenuActive = !_buildMenuActive;

        if(_buildMenuActive == false)
        {
            buildMenuPanel.SetActive(true);
            nodes.SetActive(true);
            BuildManager.dameReferencia.DestroyPreviewPrefab();
            destroyModeActive = false;
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
    }
    public void SetBaseTurretIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(1);
    }

    public void OtherTurretIndex()
    {
        BuildManager.dameReferencia.GetStructurePrefabIndex(2);
    }
}
