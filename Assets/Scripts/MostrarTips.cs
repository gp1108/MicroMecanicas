using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MostrarTips : MonoBehaviour
{
    [SerializeField] private TMP_Text TipsText;
    public string[] Tips;
    public int TipCount;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTips();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateTips();
        }
    }

    public void GenerateTips()
    {
        TipCount = Random.Range(0, Tips.Length);

        TipsText.text = Tips[TipCount];
    }
}
