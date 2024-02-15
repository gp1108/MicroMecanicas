using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    public float maxHealthPoints;
    public Canvas healthSlider;
    private GameObject mainCamera;
    private bool _slow;
    private GameObject _barraVida;
    private GameObject _nVida;
    private float _speedInical;
    private float _speedInSlow;
    public GameObject _DeadEffect;
    public GameObject _HitEffect;
    public GameObject opciones;

    // Start is called before the first frame update
    void Start()
    {
        maxHealthPoints = healthPoints;
        _speedInSlow = UpgradeManager.giveMeReference.amountSlow;
        _nVida = GameObject.Find("NumeroVidaGenerador");
        _barraVida = GameObject.Find("VidaGenerador");
        _slow = false;
        tipoVida = tipoDeVida.Estandar;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //opciones = GameObject.Find("Opciones");
        if (this.name == "MainStructure(Clone)")
        {
            UpdateVida();
        }
        opciones = FindInActiveObjectByTag("OptionsPanel");


    }

    GameObject FindInActiveObjectByTag(string tag)
    {

        MenuInicio[] objs = Resources.FindObjectsOfTypeAll<MenuInicio>() as MenuInicio[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
    public void BarHelth()
    {
        healthSlider = this.GetComponentInChildren<Canvas>();
        healthSlider.GetComponentInChildren<Slider>().maxValue = healthPoints;
        healthSlider.GetComponentInChildren<Slider>().value = healthPoints;
        healthSlider.enabled = false;
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
        _barraVida.GetComponent<Image>().fillAmount = ((1f / maxHealthPoints) * GetComponent<Health>().healthPoints);
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
            UpdateVida();
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
                gameManager.giveMeReference.EnemyDead(this.gameObject.name);
                if(PlayerPrefs.GetFloat("raptor") == 0 || PlayerPrefs.GetFloat("Pterodactilo") == 0 || PlayerPrefs.GetFloat("Triceratops") == 0 || PlayerPrefs.GetFloat("Trex") == 0 || PlayerPrefs.GetFloat("Compy") == 0)
                {
                    unlockDino(name);
                }

                Instantiate(_DeadEffect, this.gameObject.transform.position, Quaternion.identity);

               
            }
            Destroy(this.gameObject);


        }


    }

    public void unlockDino(string name)
    {
        

        switch (name)
        {
            case "raptor 1(Clone)":
                if (PlayerPrefs.GetFloat("raptor") == 0)
                {
                    PlayerPrefs.SetFloat("raptor", 1);
                    if(opciones != null)
                    {
                        opciones.GetComponent<MenuInicio>().RaptorLockedPanel.SetActive(false);
                    }
                }
            break;
            case "pterodactilo(Clone)":
                if (PlayerPrefs.GetFloat("Pterodactilo") == 0)
                {
                    PlayerPrefs.SetFloat("Pterodactilo", 1);
                    if (opciones != null)
                    {
                        opciones.GetComponent<MenuInicio>().PteroLockedPanel.SetActive(false);
                    }
                }
                break;
            case "TRex(Clone)":
                if (PlayerPrefs.GetFloat("Trex") == 0)
                {
                    PlayerPrefs.SetFloat("Trex", 1);
                    if (opciones != null)
                    {
                        opciones.GetComponent<MenuInicio>().TRexLockedPanel.SetActive(false);
                    }
                }
                break;
            case "Triceraptos(Clone)":
                if (PlayerPrefs.GetFloat("Triceratops") == 0)
                {
                    PlayerPrefs.SetFloat("Triceratops", 1);
                    if (opciones != null)
                    {
                        opciones.GetComponent<MenuInicio>().TricepLockedPanel.SetActive(false);
                    }
                }
                break;
            case "Compy(Clone)":
                if (PlayerPrefs.GetFloat("Compy") == 0)
                {
                    PlayerPrefs.SetFloat("Compy", 1);
                    if (opciones != null)
                    {
                        opciones.GetComponent<MenuInicio>().CompyLockedPanel.SetActive(false);
                    }
                }
                break;


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
