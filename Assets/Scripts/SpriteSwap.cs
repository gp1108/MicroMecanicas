using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;



public class SpriteSwap : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponentInParent<Button>().interactable == false)
        {
            this.gameObject.GetComponent<Image>().color = Color.black;
            
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
