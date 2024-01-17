using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMortero : MonoBehaviour
{
    public GameObject target;
    public float fuerzaInicial;
    public Rigidbody rb;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
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
        Destroy(this.gameObject);
    }
}
