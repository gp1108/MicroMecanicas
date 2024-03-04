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
    private bool _ataking;
    private float _damaged;
    private Animator _animator;
    [Header("RangeIndicator")]
    public GameObject rangeIndicator;
    private bool _mostrarRango;
    private GameObject canvas;
    public GameObject laserEffect;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Atacando",false);
        canvas = GameObject.Find("Canvas");
        gameManager.giveMeReference.GetTurret(this.gameObject);
        _ataking = false;
        _damaged = UpgradeManager.giveMeReference.damagedL;
        GetComponent<Health>().healthPoints = UpgradeManager.giveMeReference.vidaL;
        _velocitiRotation = 8;
        rangeIndicator = GameObject.FindGameObjectWithTag("RangeIndicator");
        Skills.giveMeReference.listaActualizarTurrets += ActualizarVidaTorres;
        GetComponent<Health>().BarHelth();
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
                Vector3 targetPosition = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
                transform.GetChild(0).LookAt(targetPosition);
            }
            RaycastHit hit;
            if (Physics.Raycast(exitRay.transform.position, _lookAt, out hit, UpgradeManager.giveMeReference.rangeL,layer))
            {
                Instantiate(laserEffect, exitRay.transform.position, exitRay.transform.rotation);
                if (hit.transform.GetComponent<Health>() != null)
                {
                    if (hit.transform.tag != "TownHall")
                    {
                        _animator.SetBool("Atacando", true);
                        if (_ataking == false)
                        {
                            GameObject enemigo = hit.transform.gameObject;
                            if (_ataking == false)
                            {
                                StartCoroutine(Daño(enemigo));
                            }
                        }
                    }
                }
            }
            else
            {
                _animator.SetBool("Atacando", false);
            }
        }
        else
        {
            _damaged = UpgradeManager.giveMeReference.damagedL;
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
            rangeIndicator.transform.localScale = new Vector3(UpgradeManager.giveMeReference.rangeL * 2, UpgradeManager.giveMeReference.rangeL * 2, UpgradeManager.giveMeReference.rangeL * 2);
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
    IEnumerator Daño( GameObject enemy)
    {
        if (enemy != null)
        {
            _ataking = true;
            SoundManager.dameReferencia.PlayOneClipByName(clipName: "Laser");
            enemy.transform.GetComponent<Health>().GetDamaged(_damaged, Bullet.tipoDeDamaged.Magica);
            _damaged += 0.1f * Time.deltaTime;
            yield return new WaitForSeconds(UpgradeManager.giveMeReference.cadenceL);
            _ataking = false;
            yield return null;
        }
    }
}
