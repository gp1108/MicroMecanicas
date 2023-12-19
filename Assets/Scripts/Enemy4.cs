using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class Enemy4 : MonoBehaviour
{
    private GameObject _TownHall;
    [SerializeField] private GameObject _target;
    private Vector3 _direccion;
    private float _timePass;
    private float _cadencia;
    private float _distance;
    private float _heightE;
    private float _heightMax;
    private bool _atac;
    private bool _atacking;
    [SerializeField] private GameObject[] _torret;
    void Start()
    {
        _cadencia = 1.5f;
        _heightMax = 5;
        _atac = false;
        _TownHall = GameObject.FindGameObjectWithTag("TownHall");
        _torret = gameManager.giveMeReference.turrets.ToArray();
        GetComponent<Health>().healthPoints = 10;
        GetComponent<Health>().tipoVida = Health.tipoDeVida.Armadura;
    }
    private void Update()
    {
        height();
        Move();
        Atack();
    }

    void Atack()
    {
        if(Vector3.Distance(transform.position,_target.transform.position) < _heightMax)
        {
            _atac = true;
            if (_atacking == false)
            {
                StartCoroutine("MekeDamaged");
            }
        }
        else
        {
            _atac=false;
        }
    }
    IEnumerator MekeDamaged()
    {
        _atacking = true;
        if (Physics.Raycast(transform.position, _direccion, out RaycastHit hit, _heightMax))
        {
            hit.transform.GetComponent<Health>().GetDamaged(2, Bullet.tipoDeDamaged.Estandar);
        }
        yield return new WaitForSeconds(_cadencia);
        _atacking=false;
        yield return null;
    }
    public void Move()
    {

        if (_TownHall != null && _torret.Length <= 0)
        {
            _target = _TownHall;
        }
        if (_torret.Length >= 1)
        {
            if (_target != null)
            {
                _distance = Vector3.Distance(transform.position, _target.transform.position);
            }
            else
            {
                _torret = gameManager.giveMeReference.turrets.ToArray();

                if (_torret.Length >= 1)
                {
                    _target = _torret[0];
                }
                else
                {
                    _target = _TownHall;
                }
            }

            foreach (GameObject _TORRET in _torret)
            {
                if (_TORRET != null)
                {
                    if (Vector3.Distance(transform.position, _TORRET.transform.position) < _distance)
                    {
                        _distance = Vector3.Distance(transform.position, _TORRET.transform.position);

                        _target = _TORRET;

                    }
                }
            }
        }
        if (_target != null)
        {
            if (_atac == false)
            {
                _direccion = _target.transform.position - transform.position;
                transform.Translate(_direccion.normalized * Time.deltaTime * 2.5f, Space.World);
            }
        }
    }
    void height()
    {

        RaycastHit[] Floor = Physics.RaycastAll(transform.position, -transform.up, 30);

        if(Floor.Length > 0)
        {
            foreach (RaycastHit _floor in Floor)
            {
                if (_floor.transform.CompareTag("Floor"))
                {
                    _heightE = Vector3.Distance(_floor.transform.position,transform.position);
                }
            }
        }
        if (_heightE < _heightMax)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y+(_heightMax -_heightE),transform.position.z);
        }
        if(_heightE > _heightMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (_heightE- _heightMax), transform.position.z);
        }
    }
}
