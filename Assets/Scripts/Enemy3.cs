using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    private List<GameObject> _walls;
    private GameObject _TownHall;
    [SerializeField] private GameObject _target;
    public GameObject Jr;
    private Collider[] _explosion;
    private NavMeshAgent _navAgent;
    private float _distance;
    

    // Start is called before the first frame update
    void Start()
    {
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _walls = BuildManager.dameReferencia.Walls;
        _navAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("CheckPath");
        StartCoroutine("GetWalls");
        GetComponent<Health>().healthPoints = 10;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Magica;
    }

   
    public void Move()
    {
        if (_TownHall != null && _walls.Count<= 0)
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

               
                if (_walls.Count>= 1)
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

            // Calcula el camino hasta el 
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

        if (Vector3.Distance(transform.position, _target.transform.position)>=2)
        {

            _explosion = Physics.OverlapSphere(transform.position, 4);
            foreach(Collider _EXPLOSION in _explosion)
            {
                if (_EXPLOSION.tag == "Wall")
                {
                    _EXPLOSION.GetComponent<Health>().GetDamaged(10, Bullet.tipoDeDamaged.Estandar);
                }
            }


        }
        
    }
    public void Spawn()
    {
        for(int i=0; i<5; i++)
        {
            GameObject.Instantiate(Jr, transform.position, transform.rotation);
        }        
    }
        IEnumerator GetWalls()
    {
        while (true)
        {

            _walls = BuildManager.dameReferencia.Walls;
            if (_walls.Count == 0)
            {
                yield return new WaitForSeconds(1.5f);
            }
            if (_walls.Count == 1)
            {
                _target = _walls[0].gameObject;
            }
            if (_target == null && _walls.Count != 0)
            {
                _target = _walls[0].gameObject;
            }
            yield return new WaitForSeconds(1.5f);
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
