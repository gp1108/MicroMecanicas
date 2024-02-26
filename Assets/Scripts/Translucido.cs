using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Translucido : MonoBehaviour
{
    public Color myColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject != null)
        {
            this.gameObject.GetComponent<Image>().color = myColor;
        }
    }
}
