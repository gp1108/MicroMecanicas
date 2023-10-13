using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position , Vector3.up, out hit, 0.3f ))
        {
            Destroy(this.gameObject);
        }
    }
}
