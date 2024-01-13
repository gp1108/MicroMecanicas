using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMortero : MonoBehaviour
{
    public float fuerzaInicial;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * fuerzaInicial, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
