using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretSnip : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 _lookAt;
    private Quaternion _rotation;
    private float _velocitiRotation;
    private float _range;
    private float _rangeVision;
    private float _distance;
    private float _timing;
    private float _accumulatedTime;
    [SerializeField] private GameObject _target;
    private GameObject _bullet;
    public GameObject bullet;
    public GameObject exitBullet;
    [SerializeField] private List<Collider> _enemies = new List<Collider>();
    [SerializeField] private Collider[] _collidersEnemies;
    private bool _attacking;
    // Start is called before the first frame update
    void Start()
    {

        _attacking = false;
        _velocitiRotation = 8;
        _range = 10;
        _rangeVision = 15;
        GetComponent<Health>().healthPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemy();
        GetTarget();


    }
    public void GetTarget()
    {
        if (_target != null)
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

                Attack();
            }
        }



    }
    public void Attack()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _range && _attacking == false)
        {

            _bullet = GameObject.Instantiate(bullet, exitBullet.transform.position, exitBullet.transform.rotation);

            _bullet.gameObject.GetComponent<Bullet>().velocidad = 20;

            _bullet.gameObject.GetComponent<Bullet>().damaged = 20;
            _bullet.gameObject.GetComponent<Bullet>().target = _target;
            _bullet.gameObject.GetComponent<Bullet>().tipoDamaged = Bullet.tipoDeDamaged.Estandar;

            _attacking = true;

            _timing = 5;
        }
        if (_attacking == true)
        {

            _accumulatedTime += Time.deltaTime;

            if (_accumulatedTime > _timing)
            {
                _attacking = false;

                _accumulatedTime = 0;
            }
        }
    }
    public void GetEnemy()
    {
        _collidersEnemies = Physics.OverlapSphere(transform.position, 30, layer);

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