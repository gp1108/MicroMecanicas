using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshCombiner : MonoBehaviour
{
    public Material material;

    public void CombineMeshes()
    {
        // Obtén todos los objetos con MeshFilter en este GameObject
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        // Crea un arreglo para almacenar las instancias de CombineInstance
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            // Configura cada CombineInstance con la malla y la transformación del objeto actual
            combine[i].mesh = SimplificarMalla(meshFilters[i].sharedMesh); // Simplifica la malla antes de combinar
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;

            // Desactiva los objetos originales si lo deseas
            meshFilters[i].gameObject.SetActive(false);
        }

        // Crea un nuevo objeto con un MeshFilter y un MeshRenderer
        GameObject combinacionObjeto = new GameObject("CombinacionObjeto");
        MeshFilter combinacionMeshFilter = combinacionObjeto.AddComponent<MeshFilter>();
        MeshRenderer combinacionMeshRenderer = combinacionObjeto.AddComponent<MeshRenderer>();

        // Combina las mallas
        combinacionMeshFilter.sharedMesh = new Mesh();
        combinacionMeshFilter.sharedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32; // Cambia el formato de índice
        combinacionMeshFilter.sharedMesh.CombineMeshes(combine);

        // Ajusta el material si es necesario
        combinacionMeshRenderer.material = ObtenerMaterialSimplificado(); // Puedes implementar esta función según tus necesidades

        // Puedes ajustar otras propiedades, como colisionadores, si es necesario
        combinacionObjeto.AddComponent<MeshCollider>();
    }

    Mesh SimplificarMalla(Mesh originalMesh)
    {
        // Implementa la lógica de simplificación de malla aquí según tus necesidades
        // Puedes utilizar técnicas como reducción de polígonos, simplificación de texturas, etc.
        // Devuelve la malla simplificada.
        return originalMesh;
    }

    Material ObtenerMaterialSimplificado()
    {
        // Implementa la lógica para obtener un material simplificado aquí según tus necesidades
        // Puedes crear un nuevo material con propiedades simplificadas o utilizar un material estándar.
        // Devuelve el material simplificado.
        return material;
    }
}
