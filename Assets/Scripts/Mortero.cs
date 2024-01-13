using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Mortero : MonoBehaviour
{
    public float _fuerzaInicial;
    public float _posicionInicialX;
    public float _posicionInicialY;
    public float _posicionFinalX;
    public float _posicionFinalY;
    public float Grados;
    [SerializeField] private GameObject _bala;
    [SerializeField] private GameObject _balaLanzada;
    [SerializeField] private GameObject _salidaBala;
    public LayerMask layer;
    private bool _mostrarRango;
    public GameObject rangeIndicator;
    [SerializeField] private GameObject _target;
    [SerializeField] private Collider[] _collidersEnemies;
    [SerializeField] private List<Collider> _enemies = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager.giveMeReference.GetTurret(this.gameObject);
        GetComponent<Health>().healthPoints = UpgradeManager.giveMeReference.vidaS;
        rangeIndicator = GameObject.FindGameObjectWithTag("RangeIndicator");
        Skills.giveMeReference.listaActualizarTurrets += ActualizarVidaTorres;
    }

    // Update is called once per frame
    void Update()
    {
        _salidaBala.transform.rotation = Quaternion.Euler(-Grados,0f,0f);
        ataque();
    }
    public void ataque()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _posicionInicialX=_target.transform.position.x;
            _posicionInicialY=_target.transform.position.y;



            _balaLanzada = GameObject.Instantiate(_bala, _salidaBala.transform.position, _salidaBala.transform.rotation);
            _balaLanzada.GetComponent<BalaMortero>().fuerzaInicial = _fuerzaInicial;
        }
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
