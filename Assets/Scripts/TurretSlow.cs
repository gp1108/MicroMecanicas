using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretSlow : MonoBehaviour
{
    public LayerMask layer;
    private Collider[] _zoneSlow;
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
        _zoneSlow= Physics.OverlapSphere(transform.position,20, layer);
        if (_zoneSlow.Length > 0)
        {
            foreach (Collider c in _zoneSlow)
            {
                if (c.gameObject.GetComponent<NavMeshAgent>()!=null)
                {
                    c.gameObject.GetComponent<Health>().GetSlow(this.gameObject);
                }
            }
        }
    }
}
