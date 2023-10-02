using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    private static gameManager _Reference;

    //Enemies
    private int _numberOfEnemies;
    int _enemyMultiplier = 5;
    private int _totalOfRounds;
    private int _RoundsPlayed;
    public bool isSpawning;


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

    private void Awake()
    {
        _numberOfEnemies = 0;
        _enemyMultiplier = 5;
        _RoundsPlayed = 0;
        _totalOfRounds = 30;
    }

    public void PlayerDead()
    {
        //Time.timeScale = 0;
        Debug.Log("Has perdido");
    }

    public void StartRound()
    {
        if(_RoundsPlayed <= _totalOfRounds)
        {
            NumberOfSpawns();
            _RoundsPlayed += 1;
        }
        else
        {
            //LLAMAR A FUNCION DE VICTORIA
        }
        
    }

    public void NumberOfSpawns()
    {

        if (_numberOfEnemies < 1 * _enemyMultiplier)
        {
            Debug.Log("NumberOfEnemies" + _numberOfEnemies);
            isSpawning = true;
        }
        else
        {
            isSpawning = false;
            _enemyMultiplier += 5;
        }
    }
    public void EnemySpawned()
    {
        _numberOfEnemies++;
    }

    public void EndRound()
    {
        _numberOfEnemies--;
        if(_numberOfEnemies <= 0)
        {
            //TimerOrPressedButtonToContinueRound();
        }
    }
    

    public void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            
            StartRound();
        }
    }
    public void OnEnable()
    {
        StartRound();
    }

}
