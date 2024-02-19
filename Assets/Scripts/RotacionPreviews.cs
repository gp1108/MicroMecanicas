using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotacionPreviews : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float oscillationSpeed = 1f;
    public float oscillationHeight;
    public Vector3 rotationAxis = Vector3.up;

    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        oscillationHeight = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotationAxis, rotationSpeed * Time.unscaledDeltaTime);

        float ocillationOffset = Mathf.Sin(Time.unscaledTime * oscillationSpeed) * oscillationHeight;
        transform.position = posicionInicial + Vector3.up * ocillationOffset;
    }
}
