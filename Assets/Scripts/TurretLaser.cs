using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretLaser : MonoBehaviour
{
    private Collider[] _collidersEnemies;
    private Vector3 _lookAt;
    private float _distance;
    private Quaternion _rotation;
    private List<Collider> _enemies;
    public LayerMask layer;
    private GameObject _target;
    private float _rangeVision;
    private float _velocitiRotation;
    private bool _enemyActive;
    private float _damaged;
    // Start is called before the first frame update
    void Start()
    {

        _damaged = 0.1f;
        GetComponent<Health>().healthPoints = 10;
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
                
                _lookAt = _target.transform.position - transform.GetChild(0).transform.position;
                _distance = Vector3.Distance(transform.GetChild(0).position, _target.transform.position);
                foreach (Collider _Enemy in _enemies)
                {
                    if (_Enemy != null)
                    {
                        if (Vector3.Distance(transform.GetChild(0).position, _Enemy.transform.position) < _distance)
                        {
                            _distance = Vector3.Distance(transform.GetChild(0).position, _Enemy.transform.position);

                            _target = _Enemy.gameObject;

                        }
                    }
                }
                if (Vector3.Distance(transform.GetChild(0).position, _target.transform.position) < _rangeVision)
                {
                    _rotation = Quaternion.LookRotation(_lookAt.normalized, Vector3.up);

                    transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, _rotation, _velocitiRotation * Time.deltaTime);


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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _target.transform.position, out hit, 15))
            {
                hit.transform.GetComponent<Health>().GetDamaged(_damaged, Bullet.tipoDeDamaged.Magica);
                _damaged += 0.1f*Time.deltaTime;
            }
        }
        else
        {
            _damaged = 0.1f;
        }
    }
    public void GetEnemy()
    {
        _collidersEnemies = Physics.OverlapSphere(transform.position, 20, layer);

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
}
