using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    bool muerto = false;
    
    public enum tipoDeVida
    {
        Estandar,
        Vida,
        Armadura,
        Magica
    }
    public tipoDeVida tipoVida;
    public float healthPoints;
    public Canvas healthSlider;
    private GameObject mainCamera;
    private bool _slow;
    private GameObject _barraVida;
    private GameObject _nVida;
    private float _speedInical;
    private float _speedInSlow;

    public GameObject _DeadEffect;
    public GameObject _HitEffect;

    // Start is called before the first frame update
    void Start()
    {
        _speedInSlow = 0.5f;
        _nVida = GameObject.Find("NumeroVidaGenerador");
        _barraVida = GameObject.Find("VidaGenerador");
        _slow = false;
        tipoVida = tipoDeVida.Estandar;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
       
        
        if (this.gameObject.tag != ("TownHall"))
        {
            healthSlider = this.GetComponentInChildren<Canvas>();
            //healthSlider = this.GetComponent<Slider>();
            Debug.Log(this.gameObject.name);
            healthSlider.GetComponentInChildren<Slider>().maxValue = healthPoints;
            healthSlider.GetComponentInChildren<Slider>().value = healthPoints;
            healthSlider.enabled = true;
     
            
        }
        if (this.name == "MainStructure(Clone)")
        {
            UpdateVida();
        }

        


    }
    private void Update()
    {
        if(this.name== "MainStructure(Clone)")
        {
            //UpdateVida();
        }
    }
    public void UpdateVida()
    { 
        _barraVida.GetComponent<Image>().fillAmount = ((1f / 30) * GetComponent<Health>().healthPoints);
        _nVida.GetComponent<TMP_Text>().text = ("Vida Generador: " + GetComponent<Health>().healthPoints);

    }
    public void GetDamaged(float Damaged,Bullet.tipoDeDamaged tipeDamagade)
    {
        if(tipoVida==tipoDeVida.Estandar)
        {
            Instantiate(_HitEffect, this.gameObject.transform.position, Quaternion.identity);
            healthPoints -= Damaged;
            
        }
        else if (tipeDamagade == Bullet.tipoDeDamaged.Estandar)
        {
            Instantiate(_HitEffect, this.gameObject.transform.position, Quaternion.identity);
            healthPoints -= Damaged;
           
        }
        else if (tipoVida == tipoDeVida.Vida&&tipeDamagade==Bullet.tipoDeDamaged.Vida)
        {
            Instantiate(_HitEffect, this.gameObject.transform.position, Quaternion.identity);
            healthPoints -= (Damaged * 1.5f);
            
        }
        else if (tipoVida == tipoDeVida.Armadura&& tipeDamagade == Bullet.tipoDeDamaged.Armadura)
        {
            Instantiate(_HitEffect, this.gameObject.transform.position, Quaternion.identity);
            healthPoints -= (Damaged * 1.5f);
            
        }
        else if (tipoVida == tipoDeVida.Magica && tipeDamagade == Bullet.tipoDeDamaged.Magica)
        {
            Instantiate(_HitEffect, this.gameObject.transform.position, Quaternion.identity);
            healthPoints -= (Damaged * 1.5f);
            
        }
        else
        {
            Instantiate(_HitEffect, this.gameObject.transform.position, Quaternion.identity);
            healthPoints -= (Damaged * 0.5f);
            
        }
        if (this.gameObject.tag != ("TownHall"))
        {
            healthSlider.enabled = true;
            healthSlider.GetComponentInChildren<Slider>().value = healthPoints;
            StartCoroutine("SliderTracksCamera");
        }
        if (this.gameObject.tag == ("TownHall"))
        {
            _barraVida.GetComponent<Image>().fillAmount = ((1f / 30) * GetComponent<Health>().healthPoints);
            _nVida.GetComponent<TMP_Text>().text = ("Vida Generador: " + GetComponent<Health>().healthPoints);
        }
        if (healthPoints <= 0)
        {
            if (this.GetComponent<Enemy3>() != null)
            {
                this.GetComponent<Enemy3>().Spawn();
            }
            if(this.tag == "TownHall")
            {
                gameManager.giveMeReference.PlayerDead();
            }
            if (this.tag == "Wall")
            {
                BuildManager.dameReferencia.RemoveAndWallUpdate(this.gameObject);
            }
            if (this.tag == "Enemies" && !muerto)
            {
                muerto = true;
                gameManager.giveMeReference.GetGold(10);
                gameManager.giveMeReference.EnemyDead();

                Instantiate(_DeadEffect, this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
    public void GetSlow(GameObject turret)
    {
        _slow = true;
        StartCoroutine(Slow(turret));
    }
    
    IEnumerator Slow(GameObject turret)
    {
        while (_slow==true)
        {
            if (Vector3.Distance(transform.position, turret.transform.position) <= 20)
            {
                _speedInical = GetComponent<NavMeshAgent>().speed;
                GetComponent<NavMeshAgent>().speed = _speedInSlow;
                yield return new WaitForSeconds(0.2f);
            }
            if(Vector3.Distance(transform.position,turret.transform.position) > 20)
            {
                GetComponent<NavMeshAgent>().speed = _speedInical;
                _slow =false;
            }
        }
    }
    public IEnumerator Poisoned()
    {
        float _nTics = 0;
        while (_nTics < 3)
        {
            GetDamaged(UpgradeManager.giveMeReference.damagedMinaUpgrade, Bullet.tipoDeDamaged.Magica);
            _nTics++;
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator SliderTracksCamera()
    {
        while(true)
        {
            if (this.gameObject.tag != ("TownHall"))
            {
                Vector3 cameraposition = mainCamera.transform.position;
                healthSlider.gameObject.transform.LookAt(cameraposition); //parent.transform.
                //healthSlider.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
