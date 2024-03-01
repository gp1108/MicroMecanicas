using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {

        DontDestroyOnLoad(this);
    }
}
