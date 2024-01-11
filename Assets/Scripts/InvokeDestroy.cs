using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Desactivar", 0.5f);
    }
    
    void Desactivar()
    {
        this.gameObject.SetActive(false);
    }

}
