using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResearchStructure : MonoBehaviour
{
    public GameObject canvas;
    public GameObject researchPanel;
    
    public void OnMouseDown()
    {
        if(gameManager.giveMeReference.onRound == false)
        {
            if (canvas.GetComponent<ResearchMenu>().researchMenuActive == false && canvas.GetComponent<BuildMenuButton>().buildMenuActive == false)//desactiva cualquier otro panel en pantalla
            {
                canvas.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
            }
        }
        else
        {
            return;
        }
        
    }

    private void Start()
    {
        gameManager.giveMeReference.numberOfLabs++;
        gameManager.giveMeReference.MaxNumberOfResearchStructures();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        GetComponent<Health>().healthPoints = 10;

        //Revisar si se puede hacer mas simple por que el problema era que el mombre del gameobject tenia un espacio al final.
        RectTransform[] objectsInCanvas = canvas.GetComponentsInChildren<RectTransform>(true);
        foreach (RectTransform objectInCanva in objectsInCanvas )
        {
            
            if(objectInCanva.name == "ResearchMenu")
            {
                
                researchPanel = objectInCanva.gameObject ;
            }
            
        }
        researchPanel.SetActive(true);
        
    }

    
}
