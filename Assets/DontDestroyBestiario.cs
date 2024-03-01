using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroyBestiario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Referencia != null && Referencia != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
             Referencia = this;
        }
    }
    
    private static DontDestroyBestiario Referencia;

    public static DontDestroyBestiario dameReferencia
    {
        get
        {


            if (Referencia == null)
            {
                Referencia = FindObjectOfType<DontDestroyBestiario>();

            }


            return Referencia;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
