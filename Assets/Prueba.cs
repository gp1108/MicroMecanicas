using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public LayerMask mask;
    public GameObject _target;
    public Vector3 _direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GetComponent<TurretLaser>()._target != null)
        {
            
            _target = GetComponent<TurretLaser>()._target;
            _direccion = transform.GetChild(0).transform.position - _target.transform.position;
            if (Physics.Raycast(transform.GetChild(0).transform.position, _direccion))
            {
               
            }
        }

    }
}
