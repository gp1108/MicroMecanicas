using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BalaMortero : MonoBehaviour
{
    
    private Collider[] _collidersEnemies;
    private Rigidbody rb;
    private float time;
    public LayerMask layer;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        time = 5;
        StartCoroutine("Potencia");
    }

    IEnumerator Potencia()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            Vector3 vel = (-this.transform.position + target.transform.position - 0.5f * Physics.gravity * time * time) / time;
            rb.velocity = vel;
            Debug.Log(vel);
            time -= Time.deltaTime;
            Debug.Log(time);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        _collidersEnemies = Physics.OverlapSphere(transform.position, 5, layer);
        foreach(Collider collider in _collidersEnemies)
        {
            collider.GetComponent<Health>().GetDamaged(UpgradeManager.giveMeReference.damagedMortero, Bullet.tipoDeDamaged.Armadura);
        }
        Destroy(this.gameObject);
    }
}
