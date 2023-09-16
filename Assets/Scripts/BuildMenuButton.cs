using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildMenuButton : MonoBehaviour
{
    public GameObject buildMenuPanel;
    private bool _buildMenuActive;


    public void EnableOrDisableBuildPanel()
    {
        _buildMenuActive = !_buildMenuActive;

        if(_buildMenuActive == false)
        {
            buildMenuPanel.SetActive(true);
        }
        else
        {
            buildMenuPanel.SetActive(false);
        }
        
    }
}
