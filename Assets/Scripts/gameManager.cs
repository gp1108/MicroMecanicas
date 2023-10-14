using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{

    private static gameManager _Reference;

    public static gameManager giveMeReference
    {
        get
        {


            if (_Reference == null)
            {
                _Reference = FindObjectOfType<gameManager>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("gameManager");
                    _Reference = go.AddComponent<gameManager>();
                }
            }
            return _Reference;
        }
    }




    public List<GameObject> enemiesSpawners;
    public GameObject[] enemies;
    private int _roundsPlayed;
    private int _totalRounds;
    private int _totalNumberOfEnemies;
    private int _gold;
    public TMP_Text goldText;

    private void Awake()
    {
        enemiesSpawners = new List<GameObject>();

        
    }

    private void Start()
    {
       _roundsPlayed = 0;
       _totalRounds = 20;
       _totalNumberOfEnemies = 5;
    }
    private void Update()
    {
        
    }



    public void PlayerDead()
    {
        //Time.timeScale = 0;
        Debug.Log("Has perdido");
    }

    public void PlayerWin()
    {
        //Mostrar menus , conteo de experiencia etc etc , debloqueo de cartas
    }

    public void RoundStart()
    {
        if(_roundsPlayed <= _totalRounds)
        {
            SpawnEnemies();
        }
        else
        {
            PlayerWin();
        }
    }

    
   public void SpawnEnemies()
   {
       for(int _actualNumberOfEnemies = 0; _actualNumberOfEnemies <  _totalNumberOfEnemies; _actualNumberOfEnemies++)
       {
            
            Instantiate(enemies[0], enemiesSpawners[Random.Range(0, enemiesSpawners.Count)].transform.position + Vector3.up * 4, Quaternion.identity);
           
            
       }
        _totalNumberOfEnemies += 5;
    }

    public void GetGold( int oro)
    {

        _gold += oro;
        goldText.text = _gold.ToString();

    }
    public void OnBecameVisible()
    {
        RoundStart();
    }
    

}
