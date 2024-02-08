using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

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
    [SerializeField] private int _raptor;
    [SerializeField] private int _trex;
    [SerializeField] private int _triceraptos;
    [SerializeField] private int _pterodactilo;
    private int _spawn;
    public bool onRound;
    public int enemiesAlive;
    private int enemiesSpawned;
    public TMP_Text roundsText;
    private GameObject enemyToSpawn;
    [Header("Menu Management")]
    public GameObject BuildMenuButton;
    public GameObject ResearchMenuButton;
    public GameObject canvas;
    public GameObject victoryImage;
    public GameObject gameOverImage;

    [Header("Muros Regeneracion")]
    public bool regenWalls;
    public delegate void regWallsR();
    public event regWallsR listaActualizarWallsReg;

    [Header("Gold System")]
    public float gold;
    public TMP_Text goldText;
    [Header("Investigation System")]
    public TMP_Text invetigationText;
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
    public List<GameObject> nodesTrue;

    public TMP_Text maxRounds;
    public TMP_Text totalXP;
    public TMP_Text highScore;
    public GameObject _information;
    public GameObject _textInformation;

    private void Awake()
    {
        enemiesSpawners = new List<GameObject>();
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("maxRoundArrive"))
        {
            PlayerPrefs.SetInt("maxRoundArrive", 0);
        }
        _raptor = 90;
        _trex = 100;
        _triceraptos = 100;
        _pterodactilo = 100;
        invetigationText.text = researchPoints.ToString();
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
        GetGold(1000 + PlayerPrefs.GetFloat("startWithMoreGold"));
        GetResearchPoints(100 + Mathf.RoundToInt(PlayerPrefs.GetFloat("startWithMoreResearchPoints")));

    }
    public void RevisionNodes()
    {
        foreach (GameObject node in nodesTrue)
        {
            node.GetComponent<Nodes>().Revision();
        }
    }
    private void Update()
    {
        invetigationText.text = researchPoints.ToString();
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && onRound == false )
        {
            onRound = true;
            SoundManager.dameReferencia.PlayClipByName(clipName: "RoundStart");
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
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("maxRoundArrive") < _roundsPlayed)
        {
            PlayerPrefs.SetInt("maxRoundArrive", _roundsPlayed);    
        }
        //Calculo de ResearchPoints
        float externalSkillpoints;
        externalSkillpoints = PlayerPrefs.GetFloat("externalResearchPoints");
        externalSkillpoints += _roundsPlayed;
        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillpoints);
        maxRounds.text=_roundsPlayed.ToString();
        totalXP.text= _roundsPlayed.ToString();
        highScore.text= PlayerPrefs.GetInt("maxRoundArrive").ToString();
        gameOverImage.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Lose");

    }
    public void PlayerWin()
    {
        if (PlayerPrefs.GetInt("maxRoundArrive") < _roundsPlayed)
        {
            PlayerPrefs.SetInt("maxRoundArrive", _roundsPlayed);
        }
        Time.timeScale = 0;
        victoryImage.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName:"Win");
        //Calculo de ResearchPoints
        float externalSkillpoints;
        externalSkillpoints = PlayerPrefs.GetFloat("externalResearchPoints");
        externalSkillpoints += _roundsPlayed * 3;
        PlayerPrefs.SetFloat("externalResearchPoints", externalSkillpoints);
    }
    public void RoundStart()
    {
        
        if(_roundsPlayed <= _totalRounds)
        {
            roundsText.text = "Ronda "  + _roundsPlayed.ToString();
            StartCoroutine("Revision");
            
            
        }
    }
    IEnumerator Revision()
    {
        while(onRound==true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(2);
        }
    }
    public void SpawnEnemies()
    {
        //StartCoroutine("SpawnCrow");
        if (_roundsPlayed <= 10)
        {
            if (enemiesAlive < 3 && enemiesSpawned < _totalNumberOfEnemies)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (enemiesSpawned < _totalNumberOfEnemies)
                    {
                        int random = Random.Range(0, 100);
                        if (random < _raptor)
                        {
                            _spawn = 0;
                        }
                        else if (random > _raptor && random <= _trex)
                        {
                            _spawn = 1;
                        }
                        else if (random > _trex && random < _triceraptos)
                        {
                            _spawn = 2;
                        }
                        else if (random > _triceraptos)
                        {
                            _spawn = 3;
                        }
                        enemyToSpawn = Instantiate(enemies[_spawn], enemiesSpawners[Random.Range(0, enemiesSpawners.Count)].transform.position + Vector3.up * 1, Quaternion.identity);
                        enemiesAlive++;
                        enemiesSpawned++;
                    }
                }
            }
        }
        if (_roundsPlayed <= 20 && _roundsPlayed > 10)
        {
            if (enemiesAlive < 10 && enemiesSpawned < _totalNumberOfEnemies)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (enemiesSpawned < _totalNumberOfEnemies)
                    {
                        int random = Random.Range(0, 100);
                        if (random < _raptor)
                        {
                            _spawn = 0;
                        }
                        if (random > _raptor && random < _trex)
                        {
                            _spawn = 1;
                        }
                        if (random > _trex && random < _triceraptos)
                        {
                            _spawn = 2;
                        }
                        if (random > _triceraptos)
                        {
                            _spawn = 3;
                        }
                        enemyToSpawn = Instantiate(enemies[_spawn], enemiesSpawners[Random.Range(0, enemiesSpawners.Count)].transform.position + Vector3.up * 1, Quaternion.identity);
                        enemiesAlive++;
                        enemiesSpawned++;
                    }
                }
            }
        }
        if (_roundsPlayed <= 30 && _roundsPlayed > 20)
        {
            if (enemiesAlive < 10 && enemiesSpawned < _totalNumberOfEnemies)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (enemiesSpawned < _totalNumberOfEnemies)
                    {
                        int random = Random.Range(0, 100);
                        if (random < _raptor)
                        {
                            _spawn = 0;
                        }
                        if (random > _raptor && random < _trex)
                        {
                            _spawn = 1;
                        }
                        if (random > _trex && random < _triceraptos) 
                        {
                            _spawn = 2;
                        }
                        if (random > _triceraptos)
                        {
                            _spawn = 3;
                        }
                        enemyToSpawn = Instantiate(enemies[_spawn], enemiesSpawners[Random.Range(0, enemiesSpawners.Count)].transform.position + Vector3.up * 1, Quaternion.identity);
                        enemiesAlive++;
                        enemiesSpawned++;
                    }
                }
            }
        }
    }
    public void SpawnEnemiesPorcentajes()
    {
        if (_roundsPlayed < 10)
        {
            _raptor -= 5;
        }
        else if (_roundsPlayed == 10)
        {
            _raptor = 45;
            _trex = 90;
        }
        else if (_roundsPlayed < 16) 
        {
            _raptor -= 3;
            _trex -= 6;
        }
        else if (_roundsPlayed == 16)
        {
            _raptor = 30;
            _trex = 60; 
            _triceraptos = 90;
        }
        else if (_roundsPlayed < 22)
        {
            _raptor -= 1;
            _trex -= 2;
            _triceraptos -= 3;
        }
    }
    public void EnemyDead()
    {
        enemiesAlive -= 1;
        SoundManager.dameReferencia.PlayClipByName(clipName: "EnemyDead");
        if (enemiesAlive <= 0 && onRound == true && enemiesSpawned == _totalNumberOfEnemies) 
        {
            if (regenWalls == true)
            {
                listaActualizarWallsReg();
            }
            if (_roundsPlayed == _totalRounds)
            {
                PlayerWin();
            }
                RevisionNodes();
            onRound = false;
            enemiesSpawned = 0;
            SpawnEnemiesPorcentajes();
            _roundsPlayed += 1;
            _totalNumberOfEnemies += 5;
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
            if(numberOfLabs > 0)
            {
                ResearchMenuButton.SetActive(true);
            }
            
            canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();
        }
    }
    public void MinesGold()
    {
        
        GetGold(numberOfMines * 100 * goldMultiplayer + PlayerPrefs.GetFloat("moreGoldPerGoldMines"));
    }
    public void ResearchPoints() //abajo hay otra funcion que añade rp de manera limpia , esta es para los talleres
    {
        researchPoints += numberOfLabs * 2 + Mathf.RoundToInt(PlayerPrefs.GetFloat("oneResearchPoint"));
        invetigationText.text = researchPoints.ToString();
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
