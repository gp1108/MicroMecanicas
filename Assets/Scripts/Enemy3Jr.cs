using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3Jr : MonoBehaviour
{
    private List<GameObject> _walls;
    private GameObject _TownHall;
    private GameObject _target;
    public GameObject Jr;
    private Collider[] _explosion;
    private NavMeshAgent _navAgent;
    private float _distance;
    private bool waitForLoad;
    private Animator _animator;


    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Movimiento", true);
        waitForLoad = true;
        StartCoroutine("WaitForLoad");
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _navAgent = GetComponent<NavMeshAgent>();
        _walls = BuildManager.dameReferencia.Walls;
        StartCoroutine("CheckPath");
        StartCoroutine("GetWalls");
        GetComponent<Health>().healthPoints = 10;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Magica;
        GetComponent<Health>().BarHelth();
    }

    private void Update()
    {
        Atack();
    }

    public void Move()
    {
        if (_TownHall != null && _walls.Count <= 0)
        {
            //_navAgent.SetDestination(_TownHall.transform.position);
            _target = _TownHall;


        }
        if (_walls.Count >= 1)
        {
            if (_target != null)
            {

                _distance = Vector3.Distance(transform.position, _target.transform.position);
            }
            else
            {


                if (_walls.Count >= 1)
                {
                    _target = _walls[0];
                }
            }

            foreach (GameObject _WALL in _walls)
            {
                if (_WALL != null)
                {
                    if (Vector3.Distance(transform.position, _WALL.transform.position) < _distance)
                    {
                        _distance = Vector3.Distance(transform.position, _WALL.transform.position);

                        _target = _WALL;

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
        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) <= 3)
            {
                Debug.Log("H");
                _explosion = Physics.OverlapSphere(transform.position, 4);

                foreach (Collider _EXPLOSION in _explosion)
                {
                    if (_EXPLOSION.transform.parent != null)
                    {
                        if (_EXPLOSION.transform.parent.tag == "Wall")
                        {

                            Health vida = _EXPLOSION.transform.GetComponentInParent<Health>();

                            if (vida != null)
                            {

                                _EXPLOSION.transform.parent.GetComponent<Health>().GetDamaged(10, Bullet.tipoDeDamaged.Estandar);

                            }
                        }
                    }
                    if (_EXPLOSION.tag == "TownHall")
                    {
                        _EXPLOSION.GetComponent<Health>().GetDamaged(10, Bullet.tipoDeDamaged.Estandar);
                    }
                    if (_EXPLOSION.tag == "BaseTurret")
                    {
                        _EXPLOSION.GetComponent<Health>().GetDamaged(10, Bullet.tipoDeDamaged.Estandar);
                    }
                }
                Destroy(this.gameObject);
                gameManager.giveMeReference.EnemyDead();
            }
        }

    }
    IEnumerator GetWalls()
    {
        while (true)
        {

            _walls = BuildManager.dameReferencia.Walls;
            if (_walls.Count == 0)
            {
                _target = _TownHall;
                yield return new WaitForSeconds(1.5f);
            }
            else if (_walls.Count >= 1)
            {
                for (int i = 0; i < _walls.Count; i++)
                {
                    if (_walls[i].gameObject != null)
                    {
                        _target = _walls[i];
                        break;
                    }
                    else
                    {
                        _target = _TownHall;
                    }
                }
            }
            yield return new WaitForSeconds(1.5f);
        }


    }
    IEnumerator WaitForLoad()
    {
        
        yield return new WaitForSeconds(0.1f);
        waitForLoad = false;
    }
    IEnumerator CheckPath()
    {
        while (true)
        {
            
            if(waitForLoad == false)
            {
                StopCoroutine("WaitForLoad");
                Move();
            }
           


            yield return new WaitForSeconds(0.15f);
        }
    }
}
