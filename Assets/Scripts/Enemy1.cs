using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    private GameObject _TownHall;
    private Vector3 _distancia;
    private NavMeshAgent _navAgent;
    private float _timePass;
    private float _cadencia;
    private bool _atac;

    // Start is called before the first frame update
    void Start()
    {
        
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _navAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {

        _navAgent.SetDestination(_TownHall.transform.position);

        _distancia =_TownHall.transform.position - transform.position;

        

        

    }
    public void Atac()
    {

        if (_atac == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, _distancia, out hit, 1))
            {
                if (hit.transform.tag == "TownHall")
                {

                    hit.transform.GetComponent<Health>().GetDamaged(2);

                }
                if (hit.transform.tag == "Wall")
                {
                    hit.transform.GetComponent<Health>().GetDamaged(2);

                }
            }
            
            _atac = true;

            _cadencia = 1;

        }
        if (_atac == true)
        {

            _timePass += Time.deltaTime;

            if (_timePass > _cadencia)
            {
                _atac = false;

                _timePass = 0;
            }
        }

    }
}
