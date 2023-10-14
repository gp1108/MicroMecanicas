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



    [Header("Rounds and Enemies")]
    public List<GameObject> enemiesSpawners;
    public GameObject[] enemies;
    private int _roundsPlayed;
    private int _totalRounds;
    private int _totalNumberOfEnemies;
    private bool _onRound;
    public int enemiesAlive;
    private List<GameObject> _enemies;
    private GameObject enemyToSpawn;
    [Header("Menu Management")]
    public GameObject BuildMenuButton;
    public GameObject ResearchMenuButton;
    public GameObject canvas;

    [Header("Gold System")]
    public int gold;
    public TMP_Text goldText;
    [Header("NavMesh")]
    public GameObject navmeshUpdater;
    private void Awake()
    {
        enemiesSpawners = new List<GameObject>();

        
    }

    private void Start()
    {
        _onRound = false;
       _roundsPlayed = 0;
       _totalRounds = 20;
       _totalNumberOfEnemies = 5;
        GetGold(100);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && _onRound == false )
        {
            _onRound = true;
            NavmeshUpdate();
            
            
            //Disable Menus
            if(canvas.GetComponent<ResearchMenu>().researchMenuActive == true)
            {
                canvas.GetComponent<ResearchMenu>().EnableOrDisableResearchPanel();
            }
            if(canvas.GetComponent<BuildMenuButton>().buildMenuActive == true)
            {
                canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
            }
            BuildMenuButton.SetActive(false);
            
            ResearchMenuButton.SetActive(false);
        }
        else
        {
            return;
        }
    }



    public void PlayerDead()
    {
        //Time.timeScale = 0;
        Debug.Log("Has perdido");
    }

    public void PlayerWin()
    {
        //Mostrar menus , conteo de experiencia etc etc 
    }

    public void RoundStart()
    {
        Debug.Log(_roundsPlayed + "Rondas");
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
            
            enemyToSpawn = Instantiate(enemies[0], enemiesSpawners[Random.Range(0, enemiesSpawners.Count)].transform.position + Vector3.up * 1, Quaternion.identity);
            enemiesAlive ++;
            Debug.Log(enemiesAlive + "Enemigo vivo");
            //_enemies.Add(enemyToSpawn);
       }
        _totalNumberOfEnemies += 5;
        
   }

   
    public void EnemyDead()
    {
        enemiesAlive -= 1;
        Debug.Log(enemiesAlive + "Menis 1 enemigo , quedan");
        //_enemies.Remove(enemyToSpawn);
        /*
        foreach(var enemies in _enemies)
        {
            if(enemies == null)
            {
                _enemies.Remove(enemies);
            }
        }
        */
        if(enemiesAlive <= 0)
        {
            _onRound = false;
            _roundsPlayed += 1;
            //Enable Menus
            
            BuildMenuButton.SetActive(true);
            ResearchMenuButton.SetActive(true);
            canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
        }
    }

    //NavmeshSystem
    public void NavmeshUpdate()
    {
        navmeshUpdater.GetComponent<NavMeshBake>().doNavMeshBake();
        RoundStart();
    }



    public void GetGold( int oro)
    {

        gold += oro;
        goldText.text = gold.ToString();

    }
    
    

}
