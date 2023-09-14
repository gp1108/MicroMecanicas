using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{

    [SerializeField] private GameObject _mouseindicator;
    [SerializeField] private InputMousePosition _inputMousePosition;
    void Update()
    {
        Vector3 mousePosition = _inputMousePosition.GetSelectedMapPosition();
        _mouseindicator.transform.position = mousePosition;
    }
}
