using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamaged(float Damaged)
    {
        healthPoints -= Damaged;
        if (healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
