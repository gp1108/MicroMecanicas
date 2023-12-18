using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        Debug.Log("dontdestroyPanel");

    }

    /*
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Debug.Log(" he entrado en el");
          
            this.gameObject.SetActive(false);

        }

    }
    */
}
