using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class Enemy4 : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private GameObject _TownHall;
    [SerializeField] private GameObject _target;
    private Vector3 _direccion;
    private float _cadencia;
    private float _distance;
    private float _range;
    private bool _atac;
    private bool _atacking;
    [SerializeField] private GameObject[] _torret;

    
    void Start()
    {
        
        transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        _cadencia = 1f;
        _range = 5;
        _atac = false;
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _torret = gameManager.giveMeReference.turrets.ToArray();
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.enabled = true;
        GetComponent<Health>().healthPoints = 12;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Magica;
        StartCoroutine("CheckPath");
        GetComponent<Health>().BarHelth();
    }
    private void Update()
    {
        Atack();
    }

    void Atack()
    {
        if(_target == null) return;
        if (Vector3.Distance(transform.position, _target.transform.position) < _range)
        {
            _atac = true;
            if (_atacking == false)
            {
                StartCoroutine("MekeDamaged");
            }
        }
        else
        {
            _atac = false;
        }
    }
    IEnumerator MekeDamaged()
    {
        _atacking = true;
        LayerMask golpe = LayerMask.GetMask("ObjetivoEnemigos");
        if (Physics.Raycast(transform.position, _direccion, out RaycastHit hit, _range,golpe))
        {
            if (hit.transform.GetComponent<Health>() != null)
            {

                hit.transform.GetComponent<Health>().GetDamaged(2, Bullet.tipoDeDamaged.Estandar);
            }
        }
        yield return new WaitForSeconds(_cadencia);
        _atacking = false;
        yield return null;
    }
    public void Move2()
    {
        if (_TownHall != null && _torret.Length <= 0)
        {
            
            _target = _TownHall;


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
                else
                {
                    _target = _TownHall;
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
            }
        }
        if (_target != null)
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
                _navAgent.SetDestination(_target.transform.position);
            }

            _direccion = _target.transform.position - transform.position;
        }
        if (_atac == true)
        {
            
            _navAgent.isStopped = true;

        }
        else
        {
            
            _navAgent.isStopped = false;
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
    IEnumerator CheckPath()
    {
        while (true)
        {

            Move2();
            yield return new WaitForSeconds(1.5f);
        }
    }
}

