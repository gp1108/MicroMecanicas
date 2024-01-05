using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMenu : MonoBehaviour
{
    [Header("Terrain Cubes")]
    //Bloques a instanciar como terreno
    public GameObject cubeGameObjectSand;
    public GameObject cubeGameObjectWater;
    public GameObject cubeGameObjectGrass;
    public GameObject cubeGameObjectGrassNotWalkable;
    private int[] rotaciones = { 0, 90, 180, 270 };

 

    [Header("Perlin Noise")]
    //Dimension de la generacion
    public int _worldSizeX;
    public int _worldSizeZ;
    private float _gridOffset;
    //Caracteristicas de la perlin noise
    [Range(1f, 10f)][SerializeField] private int _noiseHeight; // basicamente como de alto se genera nuestro cubo 
    [SerializeField] private float _detailScale; //A menos cantidad mas abrupto se ven las coas , valores muy altos pueden dar lugar a superficies muy planas

    private float _perlinNoiseToInt; // creo esta variable para aproximar los valores a enteros y que de la semsacion de minecraft
    private int _randomSeed;

    public GameObject cameraPerlin;

    private void Start()
    {
        PerlinNoise();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ErrasePerlinNoise();
            
        }
    }

    public void ErrasePerlinNoise()
    {
        foreach( Transform hijo in transform)
        {
            Destroy(hijo.gameObject);
        }
        PerlinNoise();
    }
    
    public void PerlinNoise()
    {
        _worldSizeX = PlayerPrefs.GetInt("SizeX");
        _worldSizeZ = PlayerPrefs.GetInt("SizeZ");
        // Genera una semilla aleatoria
        if (PlayerPrefs.HasKey("Seed"))
        {
            _randomSeed = PlayerPrefs.GetInt("Seed");
        }
        else
        {
            _randomSeed = Random.Range(0, 100000);
        }

        _gridOffset = 1;


        _detailScale = 10;

        for (int x = 0; x < _worldSizeX; x++)
        {
            for (int z = 0; z < _worldSizeZ; z++)
            {
                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(x, z, _detailScale) * _noiseHeight);
                //Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(x * _gridOffset, _perlinNoiseToInt, z * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Spawn which block depending on Y coordinate
                if (_perlinNoiseToInt == 0)
                {
                    GameObject cube = Instantiate(cubeGameObjectWater, position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, rotaciones[Random.Range(0, rotaciones.Length)], 0)) as GameObject;
                    cube.transform.SetParent(this.transform);
                }
                else if (_perlinNoiseToInt >= 1 && _perlinNoiseToInt <= 1)
                {
                    GameObject cube = Instantiate(cubeGameObjectSand, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                
                   
                }
                else if (_perlinNoiseToInt >= 3 && _perlinNoiseToInt <= 4)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrassNotWalkable, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                }
                else if (_perlinNoiseToInt >= 2 && _perlinNoiseToInt <= 2)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                   
                }

            }

        }



        //Lado de spawn enemigo Lado IZQ

        for (int xmargin = -5; xmargin < 0; xmargin++)
        {

            for (int zmargin = -5; zmargin < _worldSizeZ + 5; zmargin++)
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
                    GameObject cube = Instantiate(cubeGameObjectSand, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

               
                }
                else if (_perlinNoiseToInt >= 3 && _perlinNoiseToInt <= 4)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrassNotWalkable, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                }
                else if (_perlinNoiseToInt >= 2 && _perlinNoiseToInt <= 2)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                   
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
                    GameObject cube = Instantiate(cubeGameObjectSand, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    
                }
                else if (_perlinNoiseToInt >= 3 && _perlinNoiseToInt <= 4)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrassNotWalkable, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                }
                else if (_perlinNoiseToInt >= 2 && _perlinNoiseToInt <= 2)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                   
                }
            }
        }


        //Lado de spawn enemigo LADO INFERIOR

        for (int xmargin = _worldSizeX; xmargin < _worldSizeX + 5; xmargin++)
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
                    GameObject cube = Instantiate(cubeGameObjectSand, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    
                }
                else if (_perlinNoiseToInt >= 3 && _perlinNoiseToInt <= 4)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrassNotWalkable, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                }
                else if (_perlinNoiseToInt >= 2 && _perlinNoiseToInt <= 2)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    
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
                    GameObject cube = Instantiate(cubeGameObjectSand, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                    
                }
                else if (_perlinNoiseToInt >= 3 && _perlinNoiseToInt <= 4)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrassNotWalkable, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                }
                else if (_perlinNoiseToInt >= 2 && _perlinNoiseToInt <= 2)
                {
                    GameObject cube = Instantiate(cubeGameObjectGrass, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);

                   
                }
            }
        }

        if(_worldSizeX == _worldSizeZ)
        {
            cameraPerlin.transform.position = new Vector3(_worldSizeX / 2,_worldSizeX/ 2 + 10, _worldSizeZ / 2);
        }
        else
        {
            if(_worldSizeZ > 2 * _worldSizeX || _worldSizeX > 2 * _worldSizeZ)
            {
                
                if (_worldSizeX > _worldSizeZ)
                {
                    float valor = _worldSizeX / 2 - _worldSizeZ;
                    cameraPerlin.transform.position = new Vector3(_worldSizeX / 2, (_worldSizeZ + _worldSizeX) / 2 + 20 + valor, _worldSizeZ / 2);
                }
                else
                {
                    float valor = _worldSizeZ / 2 - _worldSizeX;
                    cameraPerlin.transform.position = new Vector3(_worldSizeX / 2, (_worldSizeZ + _worldSizeX) / 2 + 20 + valor, _worldSizeZ / 2);
                }
            }
            
            
        }
        

    }

    private float GenerateNoise(int x, int z, float detailScale)
    {
        float xNoise = _randomSeed + (x + this.transform.position.x) / detailScale;
        float zNoise = _randomSeed + (z + this.transform.position.y) / detailScale;

        return Mathf.PerlinNoise(xNoise, zNoise);
    }
}
