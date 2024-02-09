using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum tipoDeDamaged
    {
        Estandar,
        Vida,
        Armadura,
        Magica
    }
    public tipoDeDamaged tipoDamaged;
    public float damaged;
    public int velocidad;
    public GameObject target;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            distance = target.transform.position - transform.position;
            
            transform.Translate(distance * velocidad * Time.deltaTime, Space.World);
        }
        else //Esto es para que si el target se muere la bala continue recta.
        {
            transform.Translate(transform.forward * velocidad * Time.deltaTime, Space.World);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            other.gameObject.GetComponent<Health>().GetDamaged(damaged,tipoDamaged);
            Destroy(this.gameObject);
        }
      
    }
}
