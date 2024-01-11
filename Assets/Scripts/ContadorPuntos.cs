using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPuntos : MonoBehaviour
{
    public TMP_Text _MaxPointText;
    public int _numMaxPoint;

    // Start is called before the first frame update
    void Start()
    {
        _numMaxPoint = 0;
        _MaxPointText.text = PlayerPrefs.GetInt("MaxPoint", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MaxPoint()
    {
        PlayerPrefs.SetInt("MaxPoint", _numMaxPoint);
    }
}
