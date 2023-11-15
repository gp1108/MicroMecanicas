using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchStructure : MonoBehaviour
{
    public GameObject canvas;
    
    public void OnMouseDown()
    {
        
        if (canvas.GetComponent<ResearchMenu>().researchMenuActive == false && canvas.GetComponent<BuildMenuButton>().buildMenuActive == false)//desactiva cualquier otro panel en pantalla
        {
            canvas.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
        }
    }

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        GetComponent<Health>().healthPoints = 10;
        
    }

    
}
