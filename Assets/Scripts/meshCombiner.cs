using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class meshCombiner : MonoBehaviour
{
    public Material material;

    public void CombineMeshes()
    {
        // Obt�n todos los objetos con MeshFilter en este GameObject
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();

        // Crea un arreglo para almacenar las instancias de CombineInstance
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            // Configura cada CombineInstance con la malla y la transformaci�n del objeto actual
            combine[i].mesh = SimplificarMalla(meshFilters[i].sharedMesh); // Simplifica la malla antes de combinar
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;

            // Desactiva los objetos originales si lo deseas
            meshFilters[i].gameObject.SetActive(false);
        }

        // Crea un nuevo objeto con un MeshFilter y un MeshRenderer
        GameObject combinacionObjeto = new GameObject("CombinacionObjeto");
        MeshFilter combinacionMeshFilter = combinacionObjeto.AddComponent<MeshFilter>();
        if(this.name == "NotWalkableGroup")
        {
            Debug.Log("Hola");
            combinacionObjeto.AddComponent<NavMeshModifier>();
            combinacionObjeto.GetComponent<NavMeshModifier>().overrideArea = true;
            combinacionObjeto.GetComponent<NavMeshModifier>().area = 1;
        }
        if (this.name == "WaterGroup")
        {
            Debug.Log("Hola");
            combinacionObjeto.AddComponent<NavMeshModifier>();
            combinacionObjeto.GetComponent<NavMeshModifier>().overrideArea = true;
            combinacionObjeto.GetComponent<NavMeshModifier>().area = 1;
        }
        MeshRenderer combinacionMeshRenderer = combinacionObjeto.AddComponent<MeshRenderer>();

        // Combina las mallas
        combinacionMeshFilter.sharedMesh = new Mesh();
        combinacionMeshFilter.sharedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32; // Cambia el formato de �ndice
        combinacionMeshFilter.sharedMesh.CombineMeshes(combine);

        // Ajusta el material si es necesario
        combinacionMeshRenderer.material = ObtenerMaterialSimplificado(); // Puedes implementar esta funci�n seg�n tus necesidades

        // Puedes ajustar otras propiedades, como colisionadores, si es necesario
        combinacionObjeto.AddComponent<MeshCollider>();
    }

    Mesh SimplificarMalla(Mesh originalMesh)
    {
        // Implementa la l�gica de simplificaci�n de malla aqu� seg�n tus necesidades
        // Puedes utilizar t�cnicas como reducci�n de pol�gonos, simplificaci�n de texturas, etc.
        // Devuelve la malla simplificada.
        return originalMesh;
    }

    Material ObtenerMaterialSimplificado()
    {
        // Implementa la l�gica para obtener un material simplificado aqu� seg�n tus necesidades
        // Puedes crear un nuevo material con propiedades simplificadas o utilizar un material est�ndar.
        // Devuelve el material simplificado.
        return material;
    }
}
