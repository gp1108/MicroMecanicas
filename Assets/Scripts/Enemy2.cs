using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy2 : MonoBehaviour
{

    private GameObject _TownHall;
    private GameObject _target;
    private Vector3 _direccion;
    private NavMeshAgent _navAgent;
    private float _timePass;
    private float _cadencia;
    private float _distance;
    private bool _atac;
    [SerializeField] private List<GameObject> _wall;

    void Start()
    {

        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _wall = BuildManager.dameReferencia.Walls;
        _navAgent = GetComponent<NavMeshAgent>();
        GetComponent<Health>().healthPoints = 10;
        StartCoroutine("CheckPath");
    }
    private void Update()
    {
        Atack();
    }


    public void Move()
    {
        if (_TownHall != null && _wall == null)
        {
            //_navAgent.SetDestination(_TownHall.transform.position);
            _target= _TownHall;

        }
        if (_wall != null)
        {

            _distance = Vector3.Distance(transform.position, _target.transform.position);
            foreach (GameObject _WALL in _wall)
            {
                if (_WALL != null)
                {
                    if (Vector3.Distance(transform.position, _WALL.transform.position) < _distance)
                    {
                        _distance = Vector3.Distance(transform.position, _WALL.transform.position);

                        _target = _WALL;

                    }
                }
            }
        }
        if(_target != null)
        {
            NavMeshPath path = new NavMeshPath();

            // Calcula el camino hasta el TownHall
            _navAgent.CalculatePath(_target.transform.position, path);

            // Comprueba si el camino está disponible
            if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
            {
                // Si no hay un camino válido, establece un destino alternativo o realiza alguna otra acción.

                // Encuentra el punto más cercano accesible en el NavMesh
                Vector3 closestPoint = FindClosestPointOnNavMesh(_target.transform.position);

                // Establece ese punto como destino
                _navAgent.SetDestination(closestPoint);
            }
            else
            {
                _navAgent.SetDestination(_TownHall.transform.position);
            }

            _direccion = _target.transform.position - transform.position;
        }
        

    }

    Vector3 FindClosestPointOnNavMesh(Vector3 targetPosition)
    {

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, Mathf.Infinity, NavMesh.AllAreas))
        {

            return hit.position;

        }
        else
        {
            // Si no se encuentra un punto en el NavMesh, puedes manejarlo de alguna manera.
            // Por ejemplo, podrías devolver la posición actual del agente.
            return transform.position;
        }
    }
    public void Atack()
    {

        if (_atac == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, _direccion, out hit, 1))
            {

                if (hit.transform.GetComponent<Health>() != null && hit.transform.tag != this.tag)
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

    IEnumerator CheckPath()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
