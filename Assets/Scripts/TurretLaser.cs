using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretLaser : MonoBehaviour
{
    public LayerMask layer;
    private Collider[] _collidersEnemies;
    private Vector3 _lookAt;
    private float _distance;
    private Quaternion _rotation;
    [SerializeField] private List<Collider> _enemies;
    [SerializeField] private GameObject _target;
    public GameObject exitRay;
    private float _velocitiRotation;
    private bool _enemyActive;
    private float _damaged;
    // Start is called before the first frame update
    void Start()
    {

        _damaged = 0.1f;
        GetComponent<Health>().healthPoints = 10;
        _velocitiRotation = 8;

    }

    // Update is called once per frame
    void Update()
    {

        GetEnemy();
        GetTarget();
        Atack();

    }
    public void GetTarget()
    {
        if (_target != null) 
        { 

            if (_enemyActive == false)
            {
                
                
                _distance = Vector3.Distance(transform.position, _target.transform.position);
                foreach (Collider _Enemy in _enemies)
                {
                    if (_Enemy != null)
                    {
                        if (Vector3.Distance(transform.position, _Enemy.transform.position) < _distance)
                        {
                            _distance = Vector3.Distance(transform.GetChild(0).position, _Enemy.transform.position);

                            _target = _Enemy.gameObject;

                        }
                    }
                }
                
                _enemyActive = true;
            }
            

        }
        else
        {
            _enemyActive = false;
        }
    }
    public void Atack()
    {
        if (_enemyActive == true) 
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < UpgradeManager.giveMeReference.visionL)
            {
                _lookAt = _target.transform.position - transform.GetChild(0).transform.position;

                _rotation = Quaternion.LookRotation(_lookAt.normalized, Vector3.up);

                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, _rotation, _velocitiRotation * Time.deltaTime);


            }
            RaycastHit hit;
            if (Physics.Raycast(exitRay.transform.position, _lookAt, out hit, UpgradeManager.giveMeReference.rangeL,layer))
            {
                if (hit.transform.GetComponent<Health>() != null)
                {
                    if (hit.transform.tag != "TownHall")
                    {
                        GameObject enemigo = hit.transform.GetComponent<GameObject>();
                        Daño(enemigo);
                        //hit.transform.GetComponent<Health>().GetDamaged(_damaged, Bullet.tipoDeDamaged.Magica);
                        //_damaged += 0.1f * Time.deltaTime;
                    }
                }
            }
        }
        else
        {
            //_damaged = 0.1f;
        }
    }
    public void GetEnemy()
    {
        _collidersEnemies = Physics.OverlapSphere(transform.position, UpgradeManager.giveMeReference.visionL, layer);

        _enemies = _collidersEnemies.ToList();


        if (_enemies.Count == 0)
        {
            return;
        }
        if (_enemies.Count == 1)
        {
            _target = _enemies[0].gameObject;
        }
        if (_target == null && _enemies.Count != 0)
        {
            _target = _enemies[0].gameObject;
        }


    }
    IEnumerator Daño( GameObject enemy)
    {

        enemy.transform.GetComponent<Health>().GetDamaged(_damaged, Bullet.tipoDeDamaged.Magica);
        _damaged += 0.1f * Time.deltaTime;
        yield return new WaitForSeconds(UpgradeManager.giveMeReference.cadenceL);

    }
}
