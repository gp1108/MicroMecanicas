using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class GenPerlinNoise : MonoBehaviour
{
    [Header ("Terrain Cubes")]
    //Bloques a instanciar como terreno
    public GameObject cubeGameObjectGrass;
    public GameObject cubeGameObjectWater;
    public GameObject cubeGameObjectHill;

    [Header("Parents and Node")]
    //Prefab del nodo y del padre donde almacenarlos
    public GameObject node;
    public GameObject nodeGroup;
    public GameObject propsGroup;
    public GameObject enemySpawnersGroup;

    [Header("Perlin Noise")]
    //Dimension de la generacion
    [SerializeField] private int _worldSizeX;
    [SerializeField] private int _worldSizeZ;
    private float _gridOffset;
    //Caracteristicas de la perlin noise
    [Range(1f, 10f)][SerializeField] private int _noiseHeight; // basicamente como de alto se genera nuestro cubo 
    [SerializeField] private float _detailScale; //A menos cantidad mas abrupto se ven las coas , valores muy altos pueden dar lugar a superficies muy planas

    private float _perlinNoiseToInt; // creo esta variable para aproximar los valores a enteros y que de la semsacion de minecraft
    private int _randomSeed;

    [Header("Props")]
    //Generacion procedural de arboles, rocas etc.
    private List<Vector3> blockPositions = new List<Vector3>();
    public GameObject[] worldProps;

    [Header("Enemies")]
    private List<Vector3> enemyPositions = new List<Vector3>();
    public GameObject enemieSpawner;
    void Start()
    {
        // Genera una semilla aleatoria
        _randomSeed = Random.Range(0, 10000);
        //Debug.Log("Seed: " + _randomSeed);

        _gridOffset = 1;
       

        _detailScale = 30;
        
        for(int x = 0; x< _worldSizeX; x++)
        {
            for(int z = 0; z < _worldSizeZ; z++)
            {
                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(x, z, _detailScale) * _noiseHeight);
                //Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(x * _gridOffset, _perlinNoiseToInt, z * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Spawn which block depending on Y coordinate
                if(_perlinNoiseToInt == 0)
                {
                    GameObject cube = Instantiate(cubeGameObjectWater, position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject; 
                    cube.transform.SetParent(this.transform);
                }
                else if(_perlinNoiseToInt >= 1 && _perlinNoiseToInt <=1)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                    //Nodos
                    GameObject nodes = Instantiate(node, position + new Vector3(0, 1.01f, 0), Quaternion.identity) as GameObject;
                    nodes.transform.SetParent(nodeGroup.transform);
                    //Añadir a la lista de blockpositions
                    blockPositions.Add(cube.transform.position);
                }
                else
                {
                    GameObject cube = Instantiate(cubeGameObjectHill, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                    //Nodos
                    GameObject nodes = Instantiate(node, position + new Vector3(0, 1.01f, 0), Quaternion.identity) as GameObject;
                    nodes.transform.SetParent(nodeGroup.transform);

                    blockPositions.Add(cube.transform.position);
                }
  
            }
            
        }



        //Lado de spawn enemigo Lado IZQ

        for (int xmargin = -5; xmargin < 0; xmargin++)
        {

            for (int zmargin = -5; zmargin < _worldSizeZ+5; zmargin++)
            {

                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(xmargin, zmargin, _detailScale) * _noiseHeight);

                //Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(xmargin * _gridOffset, _perlinNoiseToInt, zmargin * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Spawn which block depending on Y coordinate
                if (_perlinNoiseToInt == 0)
                {
                    GameObject cube = Instantiate(cubeGameObjectWater, position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                }
                else if (_perlinNoiseToInt >= 1 && _perlinNoiseToInt <= 1)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    //Añadir a la lista de enemyPositions
                    enemyPositions.Add(cube.transform.position);
                }
                else
                {
                    GameObject cube = Instantiate(cubeGameObjectHill, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);


                    enemyPositions.Add(cube.transform.position);
                }
            }
        }

        //Lado de spawn enemigo LADO DER

        for (int zmargin = -5; zmargin < 0; zmargin++)
        {
            for (int xmargin = 0; xmargin < _worldSizeX + 5; xmargin++)
            {

                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(xmargin, zmargin, _detailScale) * _noiseHeight);

                //Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(xmargin * _gridOffset, _perlinNoiseToInt, zmargin * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Spawn which block depending on Y coordinate
                if (_perlinNoiseToInt == 0)
                {
                    GameObject cube = Instantiate(cubeGameObjectWater, position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                }
                else if (_perlinNoiseToInt >= 1 && _perlinNoiseToInt <= 1)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    //Añadir a la lista de enemyPositions
                    enemyPositions.Add(cube.transform.position);
                }
                else
                {
                    GameObject cube = Instantiate(cubeGameObjectHill, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);


                    enemyPositions.Add(cube.transform.position);
                }
            }
        }


        //Lado de spawn enemigo LADO INFERIOR

        for (int xmargin = _worldSizeX; xmargin < _worldSizeX +5; xmargin++)
        {
            for (int zmargin = 0; zmargin < _worldSizeZ + 5; zmargin++)
            {

                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(xmargin, zmargin, _detailScale) * _noiseHeight);

                //Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(xmargin * _gridOffset, _perlinNoiseToInt, zmargin * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Spawn which block depending on Y coordinate
                if (_perlinNoiseToInt == 0)
                {
                    GameObject cube = Instantiate(cubeGameObjectWater, position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                }
                else if (_perlinNoiseToInt >= 1 && _perlinNoiseToInt <= 1)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    //Añadir a la lista de enemyPositions
                    enemyPositions.Add(cube.transform.position);
                }
                else
                {
                    GameObject cube = Instantiate(cubeGameObjectHill, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);


                    enemyPositions.Add(cube.transform.position);
                }
            }
        }

        //Lado de spawn enemigo LADO SUPERIOR

        for (int zmargin = _worldSizeZ; zmargin < _worldSizeZ + 5; zmargin++)
        {
            for (int xmargin = 0; xmargin < _worldSizeX + 5; xmargin++)
            {

                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(xmargin, zmargin, _detailScale) * _noiseHeight);

                //Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(xmargin * _gridOffset, _perlinNoiseToInt, zmargin * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Spawn which block depending on Y coordinate
                if (_perlinNoiseToInt == 0)
                {
                    GameObject cube = Instantiate(cubeGameObjectWater, position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                }
                else if (_perlinNoiseToInt >= 1 && _perlinNoiseToInt <= 1)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    //Añadir a la lista de enemyPositions
                    enemyPositions.Add(cube.transform.position);
                }
                else
                {
                    GameObject cube = Instantiate(cubeGameObjectHill, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);


                    enemyPositions.Add(cube.transform.position);
                }
            }
        }


        SpawnObject();

        SpawnEnemiesSpawners();

    }
    //Spawning EnemySpawner
    private void SpawnEnemiesSpawners()
    {
        
        for (int i = 0; i < 15; i++) // Con este numero se cambia la cantidad de spawners
        {
            GameObject toPlaceObject = Instantiate(enemieSpawner, EnemySpawnerSpawnLocation(), Quaternion.Euler(0, Random.Range(0, 360), 0));
            //Este codigo hace que todos los spawners miren al centro del mapa , podria cambiarse para que mirasen al ayuntamiento.
            Vector3 originPosition = new Vector3(_worldSizeX/2,0,_worldSizeZ/2) - toPlaceObject.transform.position;
            toPlaceObject.transform.rotation = Quaternion.LookRotation(originPosition);
            toPlaceObject.transform.SetParent(enemySpawnersGroup.transform);
            //Añadir el spawner al gameManager para poder utilizarlo en las rondas.
            gameManager.giveMeReference.enemiesSpawners.Add(toPlaceObject);
            
        }
    }
    private Vector3 EnemySpawnerSpawnLocation()
    {
        int randomIndex = Random.Range(0, enemyPositions.Count);
        Vector3 newPosition = new Vector3(enemyPositions[randomIndex].x, enemyPositions[randomIndex].y + 1.01f, enemyPositions[randomIndex].z);
        enemyPositions.RemoveAt(randomIndex);
        return newPosition;
    }

    //Spawning objects

    private void SpawnObject()
    {
        //Aqui se puede usar la misma logica de altura para determinar que gameobject se spawnea , yo lo hago aleatorio pero es bastante feo
        for(int i = 0; i<40;i++)
        {
            GameObject toPlaceObject = Instantiate(worldProps[Random.Range(0, worldProps.Length)], ObjectsSpawnLocation(), Quaternion.Euler(0,Random.Range(0,360),0));
            toPlaceObject.transform.SetParent(propsGroup.transform);
        }
    }

    private Vector3 ObjectsSpawnLocation()
    {
        int randomIndex = Random.Range(0, blockPositions.Count);
        Vector3 newPosition = new Vector3(blockPositions[randomIndex].x, blockPositions[randomIndex].y + 1.01f, blockPositions[randomIndex].z);
        blockPositions.RemoveAt(randomIndex);
        return newPosition;
    }


    

    private float GenerateNoise(int x, int z, float detailScale)
    {
        float xNoise = _randomSeed +(x + this.transform.position.x) / detailScale;
        float zNoise = _randomSeed +(z + this.transform.position.y) / detailScale;

        return Mathf.PerlinNoise(xNoise, zNoise);
    }
    
}
