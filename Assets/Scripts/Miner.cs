using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    
    void Start()
    {
        gameManager.giveMeReference.numberOfMines++;
        gameManager.giveMeReference.MaxNumberOfMines();
        GetComponent<Health>().BarHelth();
    }

    
   
}
