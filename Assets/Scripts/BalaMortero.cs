using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BalaMortero : MonoBehaviour
{
    
    private Collider[] _collidersEnemies;
    private Rigidbody rb;
    private float time;
    public LayerMask layer;
    public GameObject target;
    private bool muerto;
    // Start is called before the first frame update
    void Start()
    {
        muerto = false;
        time = 2f;
        StartCoroutine("Potencia");
        rb= GetComponent<Rigidbody>();
    }

    IEnumerator Potencia()
    {
        while (time > 0)
        {
            if (target != null && this.gameObject!=null && muerto == false)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                Vector3 vel = (-this.transform.position + target.transform.position - 0.5f * Physics.gravity * time * time) / time;
                rb.velocity = vel;
                time -= Time.deltaTime;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        muerto= true;
        _collidersEnemies = Physics.OverlapSphere(transform.position, 5, layer);
        foreach(Collider collider in _collidersEnemies)
        {
            if (collider != null)
            {
                collider.GetComponent<Health>().GetDamaged(UpgradeManager.giveMeReference.damagedMortero, Bullet.tipoDeDamaged.Armadura);
            }
        }
        Destroy(this.gameObject);
    }
}
