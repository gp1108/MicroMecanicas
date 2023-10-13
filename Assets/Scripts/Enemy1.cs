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
        GetComponent<Health>().healthPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {

        _navAgent.SetDestination(_TownHall.transform.position);

        NavMeshPath path = new NavMeshPath();

        // Calcula el camino hasta el TownHall
        _navAgent.CalculatePath(_TownHall.transform.position, path);

        // Comprueba si el camino está disponible
        if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
        {
            // Si no hay un camino válido, establece un destino alternativo o realiza alguna otra acción.


            // Encuentra el punto más cercano accesible en el NavMesh
            Vector3 closestPoint = FindClosestPointOnNavMesh(_TownHall.transform.position);

            // Establece ese punto como destino
            _navAgent.SetDestination(closestPoint);
        }

        _distancia = _TownHall.transform.position - transform.position;

        

    }

    Vector3 FindClosestPointOnNavMesh(Vector3 targetPosition)
    {
        Debug.Log("Esto esta ocurriendo, la condicion de path not found funciona");
        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, 10f, NavMesh.AllAreas))
        {
            Debug.Log("Esto esta ocurriendo , estoy devolviendo un supuesto hit point");
            Debug.Log(hit.position);
            return hit.position;
            
        }
        else
        {
            // Si no se encuentra un punto en el NavMesh, puedes manejarlo de alguna manera.
            // Por ejemplo, podrías devolver la posición actual del agente.
            return transform.position;
        }
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
