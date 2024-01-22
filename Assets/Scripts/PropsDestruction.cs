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
        if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Vector3.up, out hit, 0.5f ))
        {
            Destroy(this.gameObject);
        }

        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z) , Color.blue);
    }
}
