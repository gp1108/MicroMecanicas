using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public LayerMask Lul;
    private Vector3 _lookAt;
    private Quaternion _rotation;
    private float _velocitiRotation;
    private float _range;
    private float _rangeVision;
    private float _distance;
    private float _timing;
    private float _accumulatedTime;
    private GameObject _target;
    private GameObject _bullet;
    public GameObject bullet;
    public GameObject exitBullet;
    [SerializeField] private List<Collider> _enemies = new List<Collider>();
    [SerializeField] private Collider[] _prueba ;
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
        
        GetTarget();
        GetEnemi();

    }
    public void GetTarget()
    {
        if(_target != null)
        {
            _lookAt = _target.transform.position - transform.position;

            foreach (Collider _Enemy in _enemies)
            {
                if (_Enemy != null)
                {
                    if (Vector3.Distance(transform.position, _Enemy.transform.position) <= _distance)
                    {
                        _distance = Vector3.Distance(transform.position, _Enemy.transform.position);

                        _target = _Enemy.gameObject;

                    }
                }
                else
                {
                    //_enemies.Remove(_Enemy);
                }
                
            }
            if (Vector3.Distance(transform.position, _target.transform.position) < _rangeVision)
            {
                _rotation = Quaternion.LookRotation(_lookAt.normalized, Vector3.up);

                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, _rotation, _velocitiRotation * Time.deltaTime);

                _lookAt.y = 0;

                _rotation = Quaternion.LookRotation(_lookAt.normalized, Vector3.up);

                transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _velocitiRotation * Time.deltaTime);

                Attac();
            }
        }
        
        
        
    }
    public void Attac()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _range && _attacking == false)
        {

            _bullet = GameObject.Instantiate(bullet, exitBullet.transform.position, transform.GetChild(1).rotation);

            _bullet.gameObject.GetComponent<Bullet>().velocidad = 20;

            _bullet.gameObject.GetComponent<Bullet>().damaged = 1;

            _attacking = true;

            _timing = 1;
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
    public void GetEnemi()
    {
        _prueba = Physics.OverlapSphere(transform.position, 10,Lul);
        
        _enemies = _prueba.ToList();
        

        if(_enemies.Count == 0)
        {
            return;
        }
        else
        {
            _target = _enemies[0].gameObject;
        }
        
        

    }

}
