using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    private Animator _animator;
    public GameObject debuff;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Caminando", true);
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _torret = gameManager.giveMeReference.turrets.ToArray();
        _navAgent = GetComponent<NavMeshAgent>();
        GetComponent<Health>().healthPoints = 14;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Vida;
        StartCoroutine("CheckPath");
        GetComponent<Health>().BarHelth();
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
            if (Vector3.Distance(this.transform.position, _target.transform.position) < 3f)
            {
                _navAgent.isStopped = true;
                _animator.SetBool("Caminando", false);
            }
            else
            {
                _navAgent.isStopped = false;
                _animator.SetBool("Caminando", true);
            }
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
            }
            if (Vector3.Distance(this.transform.position, _target.transform.position) < 3f)
            {
                _navAgent.isStopped = true;
                _animator.SetBool("Caminando", false);
            }
            else
            {
                _navAgent.isStopped = false;
                _animator.SetBool("Caminando", true);
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
                _navAgent.SetDestination(_target.transform.position);
            }
            
            _direccion = _target.transform.position - transform.position;
        }
        if (GetComponent<Health>()._slow == true)
        {
            Instantiate(debuff, this.transform.position, Quaternion.identity);
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
            LayerMask golpe = LayerMask.GetMask("ObjetivoEnemigos");
            if (Physics.Raycast(transform.position, _direccion, out hit, 3,golpe))
            {
                if (hit.transform.GetComponent<Health>() != null && hit.transform.tag != this.tag)
                {
                    hit.transform.GetComponent<Health>().GetDamaged(2, Bullet.tipoDeDamaged.Estandar);
                }
            }
            _atac = true;
            _cadencia = 1.5f;
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
