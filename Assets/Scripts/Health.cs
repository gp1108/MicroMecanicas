using System;
using System.Collections;
using System.Collections.Generic;
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
    public Slider healthSlider;
    private GameObject mainCamera;
    private GameObject _turret;
    private bool _slow;
    // Start is called before the first frame update
    void Start()
    {
        _slow = false;
        tipoVida = tipoDeVida.Estandar;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        StartCoroutine("SliderTracksCamera");
        healthSlider.maxValue = healthPoints;
        healthSlider.value = healthPoints;
        healthSlider.GetComponentInChildren<Image>().enabled = false;
    }

   
    public void GetDamaged(float Damaged,Bullet.tipoDeDamaged tipeDamagade)
    {
        if(tipoVida==tipoDeVida.Estandar)
        {
            healthSlider.GetComponentInChildren<Image>().enabled = true;
            healthPoints -= Damaged;
            healthSlider.value = healthPoints;
        }
        else if (tipeDamagade == Bullet.tipoDeDamaged.Estandar)
        {
            healthSlider.GetComponentInChildren<Image>().enabled = true;
            healthPoints -= Damaged;
            healthSlider.value = healthPoints;
        }
        else if (tipoVida == tipoDeVida.Vida&&tipeDamagade==Bullet.tipoDeDamaged.Vida)
        {
            
            healthSlider.GetComponentInChildren<Image>().enabled = true;
            healthPoints -= (Damaged*1.5f);
            healthSlider.value = healthPoints;

        }
        else if (tipoVida == tipoDeVida.Armadura&& tipeDamagade == Bullet.tipoDeDamaged.Armadura)
        {
            healthSlider.GetComponentInChildren<Image>().enabled = true;
            healthPoints -= (Damaged * 1.5f);
            healthSlider.value = healthPoints;
        }
        else if (tipoVida == tipoDeVida.Magica && tipeDamagade == Bullet.tipoDeDamaged.Magica)
        {
            healthSlider.GetComponentInChildren<Image>().enabled = true;
            healthPoints -= (Damaged * 1.5f);
            healthSlider.value = healthPoints;
        }
        else
        {
            healthSlider.GetComponentInChildren<Image>().enabled = true;
            healthPoints -= (Damaged * 0.5f);
            healthSlider.value = healthPoints;
        }
        
        if (healthPoints <= 0)
        {
            
            if (this.GetComponent<Enemy3>() != null)
            {
                this.GetComponent<Enemy3>().Spawn();
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
                GetComponent<NavMeshAgent>().speed = 0.5f;
                yield return new WaitForSeconds(0.2f);
            }
            if(Vector3.Distance(transform.position,turret.transform.position) > 20)
            {
                GetComponent<NavMeshAgent>().speed = 2f;
                _slow =false;
            }

        }

    }
    IEnumerator SliderTracksCamera()
    {
        while(true)
        {
            Vector3 cameraposition = mainCamera.transform.position;
            healthSlider.transform.LookAt(cameraposition);
            //healthSlider.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
