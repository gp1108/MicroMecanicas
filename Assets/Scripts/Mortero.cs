using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Mortero : MonoBehaviour
{
    private Vector3 _lookAt;
    private quaternion _rotation;
    private float _velocitiRotation;
    private float _distance;
    [SerializeField] private GameObject _bala;
    [SerializeField] private GameObject _balaLanzada;
    [SerializeField] private GameObject _salidaBala;
    public LayerMask layer;
    private bool _mostrarRango;
    private bool _attacking;
    public GameObject rangeIndicator;
    [SerializeField] private GameObject _target;
    [SerializeField] private Collider[] _collidersEnemies;
    [SerializeField] private List<Collider> _enemies = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        _velocitiRotation = 8;
        gameManager.giveMeReference.GetTurret(this.gameObject);
        GetComponent<Health>().healthPoints = UpgradeManager.giveMeReference.vidaS;
        rangeIndicator = GameObject.FindGameObjectWithTag("RangeIndicator");
        Skills.giveMeReference.listaActualizarTurrets += ActualizarVidaTorres;
    }

    // Update is called once per frame
    void Update()
    {
        _salidaBala.transform.rotation = Quaternion.Euler(0f,0f,0f);
        ataque();
        GetEnemy();
    }
    public void ataque()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _balaLanzada = GameObject.Instantiate(_bala, _salidaBala.transform.position, _salidaBala.transform.rotation);
            _balaLanzada.GetComponent<BalaMortero>().target = _target;
        }
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
            if (Vector3.Distance(transform.GetChild(0).position, _target.transform.position) < UpgradeManager.giveMeReference.visionB)
            {
                _rotation = Quaternion.LookRotation(_lookAt.normalized, Vector3.up);
                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, _rotation, _velocitiRotation * Time.deltaTime);
                Attack();

            }
        }
    }
    public void Attack()
    {
        if(Vector3.Distance(transform.position, _target.transform.position) < UpgradeManager.giveMeReference.rangeB && _attacking == false)
        {
            StartCoroutine("Shoot");
        }
    }
    IEnumerator Shoot()
    {
        _attacking = true;
        _balaLanzada = GameObject.Instantiate(_bala, _salidaBala.transform.position, _salidaBala.transform.rotation);
        _balaLanzada.GetComponent<BalaMortero>().target = _target;
        SoundManager.dameReferencia.PlayOneClipByName(clipName: "Shoot");
        yield return new WaitForSeconds(UpgradeManager.giveMeReference.cadenceA);
        _attacking = false;
    }
    public void GetEnemy()
    {
        _collidersEnemies = Physics.OverlapSphere(transform.position, UpgradeManager.giveMeReference.visionS, layer);
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
        rangeIndicator.transform.position = this.transform.position;
        rangeIndicator.GetComponent<MeshRenderer>().enabled = true;
        rangeIndicator.transform.localScale = new Vector3(UpgradeManager.giveMeReference.rangeS * 2, UpgradeManager.giveMeReference.rangeS * 2, UpgradeManager.giveMeReference.rangeS * 2);

        _mostrarRango = true;
    }
    private void Ocultar()
    {
        _mostrarRango = false;
        rangeIndicator.GetComponent<MeshRenderer>().enabled = false;
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
