using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TurretAir : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 _lookAt;
    private Quaternion _rotation;
    private float _velocitiRotation;
    private float _distance;
    private float _cadence;
    private float _accumulatedTime;
    [SerializeField] private GameObject _target;
    private GameObject _bullet;
    public GameObject bullet;
    public GameObject exitBullet;
    [SerializeField] private List<Collider> _enemies = new List<Collider>();
    [SerializeField] private Collider[] _collidersEnemies;
    private bool _attacking;

    [Header("RangeIndicator")]
    public GameObject rangeIndicator;
    private bool _mostrarRango;
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        gameManager.giveMeReference.GetTurret(this.gameObject);
        _mostrarRango = false;
        _attacking = false;
        _velocitiRotation = 8;
        GetComponent<Health>().healthPoints = UpgradeManager.giveMeReference.vidaA;
        rangeIndicator = GameObject.FindGameObjectWithTag("RangeIndicator");
        Skills.giveMeReference.listaActualizarTurrets += ActualizarVidaTorres;
        GetComponent<Health>().BarHelth();

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
            _lookAt = transform.GetChild(0).transform.position - _target.transform.position;
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
            if (Vector3.Distance(transform.GetChild(0).position, _target.transform.position) < UpgradeManager.giveMeReference.visionA)
            {
                Vector3 targetPosition = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
                transform.GetChild(0).LookAt(targetPosition);
                Attack();
            }
        }
    }
    public void Attack()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < UpgradeManager.giveMeReference.rangeA && _attacking == false)
        {
            _bullet = GameObject.Instantiate(bullet, exitBullet.transform.position, exitBullet.transform.rotation);
            _bullet.gameObject.GetComponent<Bullet>().velocidad = 20;
            _bullet.gameObject.GetComponent<Bullet>().damaged = UpgradeManager.giveMeReference.damagedA;
            _bullet.gameObject.GetComponent<Bullet>().target = _target.transform.GetChild(0).gameObject;
            _bullet.gameObject.GetComponent<Bullet>().tipoDamaged = Bullet.tipoDeDamaged.Magica;
            SoundManager.dameReferencia.PlayOneClipByName(clipName: "Shoot");
            _attacking = true;
            _cadence = UpgradeManager.giveMeReference.cadenceA;
        }
        if (_attacking == true)
        {
            _accumulatedTime += Time.deltaTime;
            if (_accumulatedTime > _cadence)
            {
                _attacking = false;
                _accumulatedTime = 0;
            }
        }
    }
    public void GetEnemy()
    {
        _collidersEnemies = Physics.OverlapSphere(transform.position, UpgradeManager.giveMeReference.visionA, layer);
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

    private void OnMouseUpAsButton()
    {
        Mostrar();
    }
    private void OnMouseExit()
    {
        Ocultar();
    }
    private void Mostrar()
    {
        bool isDestroyModeActive = canvas.GetComponent<BuildMenuButton>().destroyModeActive;
        if (isDestroyModeActive == false)
        {
            rangeIndicator.transform.position = this.transform.position;
            rangeIndicator.GetComponentInChildren<MeshRenderer>().enabled = true;
            rangeIndicator.transform.localScale = new Vector3(UpgradeManager.giveMeReference.rangeA * 2, UpgradeManager.giveMeReference.rangeA * 2, UpgradeManager.giveMeReference.rangeA * 2);
            _mostrarRango = true;
        }
        else
        {
            return;
        }

    }

    private void Ocultar()
    {
        _mostrarRango = false;
        rangeIndicator.GetComponentInChildren<MeshRenderer>().enabled = false;
        rangeIndicator.transform.position = new Vector3(0, -50, 0);
    }
    public void ActualizarVidaTorres()
    {
        GetComponent<Health>().healthPoints += 5;
    }
    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Skills.giveMeReference.listaActualizarTurrets -= ActualizarVidaTorres;
        gameManager.giveMeReference.DeletTurret(this.gameObject);
    }
}