using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Health>().healthPoints = 50;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
