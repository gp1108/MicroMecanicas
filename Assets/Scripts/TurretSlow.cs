using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretSlow : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().healthPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Slow();
    }
    public void Slow()
    {
        /*
        _zoneNormal = Physics.OverlapSphere(transform.position, 20, layer);
        _zoneSlow= Physics.OverlapSphere(transform.position,15, layer);
        if (_zoneSlow.Length > 0)
        {
            foreach (Collider c in _zoneSlow)
            {
                c.gameObject.GetComponent<NavMeshAgent>().speed = 1;
            }
        }
        if (_zoneNormal.Length > 0)
        {
            foreach(Collider c in _zoneNormal)
            {
                
            }
        }
        */

    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<NavMeshAgent>().speed = 1;
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent <NavMeshAgent>().speed = 2;
    }
}
