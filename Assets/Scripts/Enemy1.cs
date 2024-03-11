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
    private Animator _animator;
    public GameObject debuff;
    public GameObject debuff2;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Caminando", true);
        _townHall = GameObject.FindGameObjectWithTag("TownHall");
        _navAgent = GetComponent<NavMeshAgent>();
        GetComponent<Health>().healthPoints = 13;
        GetComponent<Health>().tipoVida=Health.tipoDeVida.Estandar;
        StartCoroutine("CheckPath");
        GetComponent<Health>().BarHelth();
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
            if (Vector3.Distance(this.transform.GetChild(0).position, _townHall.transform.position)< 3f)
            {
                _navAgent.isStopped = true;
                _animator.SetBool("Caminando", false);
            }
            else
            {
                _navAgent.isStopped = false;
                _animator.SetBool("Caminando", true);
            }
            if (GetComponent<Health>()._slow == true)
            {
                Instantiate(debuff, this.transform.position, Quaternion.identity);
                SoundManager.dameReferencia.PlayOneClipByName(clipName: "Slow");
            }
            if (GetComponent<Health>().itsPoisoned == true)
            {
                Instantiate(debuff2, this.transform.position, Quaternion.identity);
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
            LayerMask golpe = LayerMask.GetMask("ObjetivoEnemigos");
            _distancia=new Vector3 (_distancia.x,0,_distancia.z);
            if (Physics.Raycast(this.transform.GetChild(0).position, _distancia, out RaycastHit hit, 0.5f,golpe))
            {
                if (hit.transform.GetComponent<Health>() != null && hit.transform.tag != this.tag)
                {
                    hit.transform.GetComponent<Health>().GetDamaged(2, Bullet.tipoDeDamaged.Estandar);
                    SoundManager.dameReferencia.PlayOneClipByName(clipName: "Hit");
                    _atac = true;
                    _cadencia = 0.5f;
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
