using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float daño;
    public int velocidad;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            other.gameObject.GetComponent<Health>().GetDamaged(daño);
        }
        if (other.gameObject.tag == "Destruible")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Jugador")
        {
            other.gameObject.GetComponent<Health>().GetDamaged(daño);
        }
        Destroy(this.gameObject);
    }
}
