using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NodeGenerator : MonoBehaviour
{
    public GameObject planoPrefab;    // El prefab del plano.
    public GameObject prefab; // El prefab que deseas instanciar.
    public int numFilas = 5;  // Número de filas de cuadrados.
    public int numColumnas = 5; // Número de columnas de cuadrados.
    public float separacion = 0.05f; // Separación entre cuadrados.


    public NavMeshSurface nodoactivo; 

    void Start()
    {
        // Calcular el tamaño total del cuadrado.
        Vector3 tamañoPrefab = prefab.GetComponent<Renderer>().bounds.size;



        // Iterar a través de las filas y columnas para instanciar los cuadrados.
        for (int fila = 0; fila < numFilas; fila++)
        {
            for (int columna = 0; columna < numColumnas; columna++)
            {
                // Calcular la posición de instanciación.
                float x = columna * (tamañoPrefab.x + separacion);
                float z = fila * (tamañoPrefab.z + separacion);

                // Crear una nueva instancia del prefab en la posición calculada.
                Vector3 posición = new Vector3(x, 0, z);
                Instantiate(prefab, posición, Quaternion.identity);
            }
        }

        // Calcular el tamaño del plano para que coincida con el tamaño total de los cuadrados.
        float tamañoTotalX = numColumnas * (tamañoPrefab.x + separacion);
        float tamañoTotalZ = numFilas * (tamañoPrefab.z + separacion);
        Vector3 tamañoPlano = new Vector3(tamañoTotalX/8, 0.02f, tamañoTotalZ/8);

        // Instanciar el plano debajo de los cuadrados.
        Vector3 posiciónPlano = new Vector3(tamañoTotalX/2.5f , -0.01f, tamañoTotalZ/2.25f );
        Instantiate(planoPrefab, posiciónPlano, Quaternion.identity).transform.localScale = tamañoPlano;




    }

    //Cambiar condicion de activacion de maya
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nodoactivo.BuildNavMesh();
        }
    }
}
