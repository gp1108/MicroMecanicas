using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy2 : MonoBehaviour
{

    private GameObject _TownHall;
    [SerializeField] private GameObject _target;
    private Vector3 _direccion;
    private NavMeshAgent _navAgent;
    private float _timePass;
    private float _cadencia;
    private float _distance;
    private bool _atac;
    [SerializeField] private GameObject [] _torret;

    void Start()
    {

        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _torret = gameManager.giveMeReference.turrets.ToArray();
        _navAgent = GetComponent<NavMeshAgent>();
        GetComponent<Health>().healthPoints = 10;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Armadura;
        StartCoroutine("CheckPath");
    }
    private void Update()
    {
        Atack();
    }


    public void Move()
    {
        if (_TownHall != null && _torret.Length <= 0)
        {
            //_navAgent.SetDestination(_TownHall.transform.position);
            _target= _TownHall;
            

        }
        if (_torret.Length >= 1)
        {
            
            
            if (_target != null)
            {
                
                _distance = Vector3.Distance(transform.position, _target.transform.position);
            }
            else
            {
                
                _torret = gameManager.giveMeReference.turrets.ToArray();

                if (_torret.Length >= 1)
                {
                    _target = _torret[0];
                }
            }
            
            foreach (GameObject _TORRET in _torret)
            {
                if (_TORRET != null)
                {
                    if (Vector3.Distance(transform.position, _TORRET.transform.position) < _distance)
                    {
                        _distance = Vector3.Distance(transform.position, _TORRET.transform.position);

                        _target = _TORRET;

                    }
                }
                else
                {
                    
                }
            }
        }
        else
        {

        }
        if(_target != null)
        {
            

            NavMeshPath path = new NavMeshPath();

            // Calcula el camino hasta el TownHall
            _navAgent.CalculatePath(_target.transform.position, path);

            // Comprueba si el camino est� disponible
            if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathInvalid)
            {
                // Si no hay un camino v�lido, establece un destino alternativo o realiza alguna otra acci�n.

                // Encuentra el punto m�s cercano accesible en el NavMesh
                Vector3 closestPoint = FindClosestPointOnNavMesh(_target.transform.position);

                // Establece ese punto como destino
                _navAgent.SetDestination(closestPoint);
            }
            else
            {
                _navAgent.SetDestination(_target.transform.position);
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
            // Por ejemplo, podr�as devolver la posici�n actual del agente.
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

                    hit.transform.GetComponent<Health>().GetDamaged(2, Bullet.tipoDeDamaged.Estandar);

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
