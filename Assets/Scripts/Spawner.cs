using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool isCoroutineRunning;
    public GameObject[] enemies;

    private void Start()
    {
        isCoroutineRunning = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(gameManager.giveMeReference.isSpawning == true)
        {
            Debug.Log("EmpiezoCorrutina");
            StartCoroutine("Spawning");
            isCoroutineRunning = true;
        }
        else //if(gameManager.giveMeReference.isSpawning == false)
        {
            Debug.Log("AcaboCorrutina");
            
            isCoroutineRunning = false;
        }
    }

    IEnumerator Spawning()
    {
        while(isCoroutineRunning == true)
        {
            Instantiate(enemies[0], transform.position ,transform.rotation);
            Debug.Log("Enemigo Instanciado");
            gameManager.giveMeReference.EnemySpawned();
            gameManager.giveMeReference.NumberOfSpawns();
            yield return new WaitForSeconds(2f);
        }
        
    }
}
