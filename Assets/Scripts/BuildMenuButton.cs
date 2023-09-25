using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildMenuButton : MonoBehaviour
{
    public GameObject buildMenuPanel;
    private bool _buildMenuActive;
    public GameObject nodes;


    public void EnableOrDisableBuildPanel()
    {
        _buildMenuActive = !_buildMenuActive;

        if(_buildMenuActive == false)
        {
            buildMenuPanel.SetActive(true);
            nodes.SetActive(true);
        }
        else
        {
            buildMenuPanel.SetActive(false);
            nodes.SetActive(false);
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
}
