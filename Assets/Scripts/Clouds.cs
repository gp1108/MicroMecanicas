using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject perlingNoiseGen;
    private Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        //Ajustar el tamaño de las nubes al tamaño del mapa 
        this.gameObject.transform.localScale = new Vector3(perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeX /4, 1, perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeZ /4);
        transform.position = new Vector3((perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeX) / 2, 40, (perlingNoiseGen.GetComponent<GenPerlinNoise>()._worldSizeZ) / 2);
        //StartCoroutine(ChangeCloudOffset());

    }

    IEnumerator ChangeCloudOffset()
    {
        while (true)
        {
            material.mainTextureOffset = new Vector2(material.mainTextureOffset.x + 0.01f, material.mainTextureOffset.y );
            yield return new WaitForSeconds(1f);
        }
    }

    public void Update()
    {
        material.mainTextureOffset = new Vector2(material.mainTextureOffset.x + 0.00001f, material.mainTextureOffset.y);
    }

}
