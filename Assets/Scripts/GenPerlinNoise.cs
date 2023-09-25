using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPerlinNoise : MonoBehaviour
{

    public GameObject cubeGameObjectGrass;
    public GameObject cubeGameObjectWater;
    public GameObject cubeGameObjectHill;

    public GameObject node;
    public GameObject nodeGroup;

    [SerializeField] private int _worldSizeX;
    [SerializeField] private int _worldSizeZ;
    private float _gridOffset;

    [Range(1f, 10f)][SerializeField] private int _noiseHeight; // basicamente como de alto se genera nuestro cubo 
    [SerializeField] private float _detailScale; //A menos cantidad mas abrupto se ven las coas , valores muy altos pueden dar lugar a superficies muy planas

    private float _perlinNoiseToInt; // creo esta variable para aproximar los valores a enteros y que de la semsacion de minecraft
    private int _randomSeed;




    void Start()
    {
        // Genera una semilla aleatoria
        _randomSeed = Random.Range(0, 10000);
        Debug.Log("Seed: " + _randomSeed);

        _gridOffset = 1;
       

        _detailScale = 30;
        
        for(int x = 0; x< _worldSizeX; x++)
        {
            for(int z = 0; z < _worldSizeZ; z++)
            {
                _perlinNoiseToInt = Mathf.RoundToInt(GenerateNoise(x, z, _detailScale) * _noiseHeight);
                Debug.Log(_perlinNoiseToInt);
                Vector3 position = new Vector3(x * _gridOffset, _perlinNoiseToInt, z * _gridOffset); // en el eje y va esto GenerateNoise(x,z,_detailScale) * _noiseHeight

                //Esto esta mal , esto solo cambia el color del prefab , que al final lo que hace es cambiar el color de todos
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
                }
                else
                {
                    GameObject cube = Instantiate(cubeGameObjectHill, position, Quaternion.identity) as GameObject;
                    cube.transform.SetParent(this.transform);
                    //Nodos
                    GameObject nodes = Instantiate(node, position + new Vector3(0, 1.01f, 0), Quaternion.identity) as GameObject;
                    nodes.transform.SetParent(nodeGroup.transform);
                }

                

                
            }
        }




    }

    private float GenerateNoise(int x, int z, float detailScale)
    {
        float xNoise = _randomSeed +(x + this.transform.position.x) / detailScale;
        float zNoise = _randomSeed +(z + this.transform.position.y) / detailScale;

        return Mathf.PerlinNoise(xNoise, zNoise);
    }
    
}
