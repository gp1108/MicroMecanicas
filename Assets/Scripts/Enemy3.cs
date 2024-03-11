using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class Enemy3 : MonoBehaviour
{
    [SerializeField]  private List<GameObject> _walls;
    private GameObject _TownHall;
    [SerializeField] private GameObject _target;
    public GameObject Jr;
    private Collider[] _explosion;
    private NavMeshAgent _navAgent;
    private float _distance;
    private Animator _animator;
    public GameObject explosionEffect;
    public GameObject debuff;
    public GameObject debuff2;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Movimiento", true);
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _walls = BuildManager.dameReferencia.Walls;
        _navAgent = GetComponent<NavMeshAgent>();
        StartCoroutine("CheckPath");
        StartCoroutine("GetWalls");
        GetComponent<Health>().healthPoints = 60;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Armadura;
        GetComponent<Health>().BarHelth();
    }
    private void Update()
    {
        Atack();

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
                                SoundManager.dameReferencia.PlayOneClipByName(clipName: "Explosion");
                                vida.GetDamaged(10, Bullet.tipoDeDamaged.Estandar);
                                Instantiate(explosionEffect, this.transform.position, Quaternion.identity);

                            }
                        }
                    }
                    if (_EXPLOSION.tag == "TownHall")
                    {
                        SoundManager.dameReferencia.PlayOneClipByName(clipName: "Explosion");
                        _EXPLOSION.GetComponent<Health>().GetDamaged(10, Bullet.tipoDeDamaged.Estandar);
                        Instantiate(explosionEffect, this.transform.position, Quaternion.identity);
                    }
                    if (_EXPLOSION.tag == "BaseTurret")
                    {
                        SoundManager.dameReferencia.PlayOneClipByName(clipName: "Explosion");
                        _EXPLOSION.GetComponent<Health>().GetDamaged(10, Bullet.tipoDeDamaged.Estandar);
                        Instantiate(explosionEffect, this.transform.position, Quaternion.identity);
                    }
                }
                Destroy(this.gameObject);
                gameManager.giveMeReference.EnemyDead(this.gameObject.name);
            }
        }

    }
    public void Spawn()
    {

        for(int i=0; i<5; i++)
        {
            GameObject.Instantiate(Jr, new Vector3(transform.position.x, transform.position.y +0.9f, transform.position.z), transform.rotation);
            gameManager.giveMeReference.enemiesAlive += 1;
        }        
    }



IEnumerator GetWalls()
    {
        while (true)
        {

            _walls = BuildManager.dameReferencia.Walls;
            if (_walls.Count == 0)
            {
                _target= _TownHall;
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
    IEnumerator CheckPath()
    {
        while (true)
        {
            
            Move();
            
            
            yield return new WaitForSeconds(1.5f);
        }
    }
}
