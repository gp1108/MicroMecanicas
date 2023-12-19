using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public bool onRound;
    public int enemiesAlive;
    public TMP_Text roundsText;
    private GameObject enemyToSpawn;
    [Header("Menu Management")]
    public GameObject BuildMenuButton;
    public GameObject ResearchMenuButton;
    public GameObject canvas;

    [Header("Muros Regeneracion")]
    public bool regenWalls;
    public delegate void regWallsR();
    public event regWallsR listaActualizarWallsReg;

    [Header("Gold System")]
    public float gold;
    public TMP_Text goldText;
    [Header("Research System")]
    public int researchPoints;
    [Header("NavMesh")]
    public GameObject navmeshUpdater;
    [Header("Number of ResearchLabs")]
    public int numberOfLabs;
    public int maxNumberOfLabs;
    public GameObject researchStructureButton;
    public GameObject ResearchPanel;
    public int researchRoundsElapsed;
    [Header("Number of Mines ")]
    public int numberOfMines;
    public int maxNumberOfMines;
    public GameObject mineButton;
    public float goldMultiplayer;
    public int goldRoundsElapsed; //CADA CUANTAS RONDAS RECIBE ORO EL JUGADOR
    public List<GameObject> turrets;
    private void Awake()
    {
        enemiesSpawners = new List<GameObject>();

        GetResearchPoints(100); //Esta en el awake por temas de debugging , luego mover al start
    }

    private void Start()
    {
        researchRoundsElapsed = 3;
        goldRoundsElapsed = 2;
        goldMultiplayer = 1;
        numberOfMines = 0;
        maxNumberOfMines = 1;
        maxNumberOfLabs = 1;
        numberOfLabs = 0;
        onRound = false;
       _roundsPlayed = 0;
       _totalRounds = 20;
       _totalNumberOfEnemies = 5;
        roundsText.text = "Ronda "  + _roundsPlayed.ToString();
        GetGold(1000);
        
    }
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && onRound == false )
        {
            onRound = true;
            RoundStart();


            //Disable Menus
            if (canvas.GetComponent<ResearchMenu>().researchMenuActive == true)
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
    public void MaxNumberOfMines()
    {
        //Este calculo lo lleva realmente el buildMenuButtons
        if (numberOfMines >= maxNumberOfMines)
        {
            canvas.GetComponent<BuildMenuButton>().SetWallsIndex();

        }
       

    }
    public void MaxNumberOfResearchStructures()
    {

        if(numberOfLabs >= maxNumberOfLabs)
        {
            canvas.GetComponent<BuildMenuButton>().SetWallsIndex();
        }
        if(numberOfLabs == 0)
        {
            ResearchPanel.SetActive(false);
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
        
        if(_roundsPlayed <= _totalRounds)
        {
            roundsText.text = "Ronda "  + _roundsPlayed.ToString();
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
            
            enemyToSpawn = Instantiate(enemies[Random.Range(0, enemies.Length)], enemiesSpawners[Random.Range(0, enemiesSpawners.Count)].transform.position + Vector3.up * 1, Quaternion.identity);
            enemiesAlive ++;
            
            
       }
        _totalNumberOfEnemies += 5;
        
   }

   
    public void EnemyDead()
    {
        enemiesAlive -= 1;

        SoundManager.dameReferencia.PlayClipByName(clipName: "EnemyDead");
        
        if(enemiesAlive <= 0 && onRound == true)
        {
            if (regenWalls == true)
            {
                listaActualizarWallsReg();
            }
            onRound = false;
            _roundsPlayed += 1;
            roundsText.text = "Ronda " +_roundsPlayed.ToString();

            if(_roundsPlayed % goldRoundsElapsed == 0)
            {
                
                MinesGold(); //Cambiar esto a una manera consistente de obtenerlo
            }
            if (_roundsPlayed % researchRoundsElapsed == 0)
            {
                
                ResearchPoints();
            }

            //Enable Menus
            BuildMenuButton.SetActive(true);
            ResearchMenuButton.SetActive(true);
            canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
        }
    }

    public void MinesGold()
    {
        
        GetGold(numberOfMines * 100 * goldMultiplayer);
    }
    public void ResearchPoints() //abajo hay otra funcion que hace lo mismo , ver cual es mejor()
    {
        
        researchPoints += numberOfLabs * 2;
    }


    public void GetGold( float oro)
    {
        float lastGold;
        lastGold = gold;
        gold += oro;
        goldText.text = gold.ToString();
        if(lastGold > gold )
        {
            Invoke("SonidoOro", 0.15f);
        }
        

    }

    public void SonidoOro()
    {
        SoundManager.dameReferencia.PlayOneClipByName(clipName: "Gold");
    }

    public void GetTurret(GameObject Turret)
    {
        turrets.Add(Turret);
    }
    public void DeletTurret(GameObject Turret)
    {
        turrets.Remove(Turret);
    }
    public void GetResearchPoints(int ResearchPoints) //arriba hay otra funcion que hace lo mismo , ver cual es mejor()
    {

        researchPoints += ResearchPoints;
        //FALTA A�ADIR EL TEXTO DE LOS PUNTOS DE INVESTIGACION

    }



}
