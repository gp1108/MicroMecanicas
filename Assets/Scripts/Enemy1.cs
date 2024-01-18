using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    
    private GameObject _townHall;
    private Vector3 _distancia;
    private NavMeshAgent _navAgent;
    private float _timePass;
    private float _cadencia;
    private bool _atac;




    void Start()
    {
        
        _townHall = GameObject.FindGameObjectWithTag("TownHall");
        _navAgent = GetComponent<NavMeshAgent>();
        GetComponent<Health>().healthPoints = 10;
        GetComponent<Health>().tipoVida=Health.tipoDeVida.Vida;
        StartCoroutine("CheckPath");
    }
    private void Update()
    {
        Atack();
    }


    public void Move()
    {
        if (_townHall != null)
        {
            _navAgent.SetDestination(_townHall.transform.position);
            _distancia = _townHall.transform.position - transform.position;
            NavMeshPath path = new NavMeshPath();
            // Calcula el camino hasta el TownHall
            _navAgent.CalculatePath(_townHall.transform.position, path);
            // Comprueba si el camino está disponible
            if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
            {
                // Si no hay un camino válido, establece un destino alternativo o realiza alguna otra acción.
                // Encuentra el punto más cercano accesible en el NavMesh
                Vector3 closestPoint = FindClosestPointOnNavMesh(_townHall.transform.position);
                // Establece ese punto como destino
                _navAgent.SetDestination(closestPoint);
            }
            if (Vector3.Distance(this.transform.position,_townHall.transform.position)< 1.5f)
            {
                _navAgent.isStopped = true;
            }
            else
            {
                _navAgent.isStopped = false;
            }
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
            if (Physics.Raycast(transform.position, _distancia, out RaycastHit hit, 1.5f))
            {
                if (hit.transform.GetComponent<Health>() != null && hit.transform.tag != this.tag)
                {
                    hit.transform.GetComponent<Health>().GetDamaged(2, Bullet.tipoDeDamaged.Estandar);
                    _atac = true;
                    _cadencia = 1;
                }
            }
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
        while(true)
        {
            Move();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
