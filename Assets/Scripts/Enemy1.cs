using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private GameObject _TownHall;
    [SerializeField] private Vector3 _distancia;
    // Start is called before the first frame update
    void Start()
    {
        
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {

        _distancia=_TownHall.transform.position - transform.position;

        RaycastHit hit;

        if(Physics.Raycast(transform.position,_distancia, out hit))
        {
            if (hit.transform.tag == "TownHall")
            {



            }
        }

    }
}
