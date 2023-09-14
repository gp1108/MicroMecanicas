using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMousePosition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Vector3 _lastposition;

    public LayerMask placementLayerMask;


    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray ray = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,100, placementLayerMask))
        {
            _lastposition = hit.point;
        }
        return _lastposition;
    }

}
