using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewGameSettings : MonoBehaviour
{
    public TMP_InputField sizeXtext;
    public TMP_InputField sizeZtext;
    public TMP_InputField seed;

    public GameObject renderTexture;
    public GameObject enableReloadMapButton;

    

    public GameObject perlinNoise;

    private bool previsualizeEnabled;

    private void Start()
    {
        previsualizeEnabled = true;
        enableReloadMapButton.GetComponent<Image>().color = Color.green;

        //Crear la variable SizeX y SizeZ
        if (!PlayerPrefs.HasKey("SizeX"))
        {
            PlayerPrefs.SetInt("SizeX", 0);
        }
       

        if (!PlayerPrefs.HasKey("SizeZ"))
        {
            PlayerPrefs.SetInt("SizeZ", 0);
        }
        


    }

    public void Update()
    {
        if (string.IsNullOrEmpty(seed.text))
        {
            PlayerPrefs.DeleteKey("Seed");
        }
    }

    public void InputTextFieldDeselected()
    {
        if(string.IsNullOrEmpty(sizeXtext.text))
        {
            return;
        }
        else
        {
            if(int.TryParse(sizeXtext.text, out int valorEntero))
            {
                PlayerPrefs.SetInt("SizeX", valorEntero);
            }
        }
        if(string.IsNullOrEmpty(sizeZtext.text))
        {
            return;
        }
        else
        {
            if (int.TryParse(sizeZtext.text, out int valorEntero))
            {
                PlayerPrefs.SetInt("SizeZ", valorEntero);
            }
        }

        ReloadMap();
    }

    public void SetSeed()
    {
         if (int.TryParse(seed.text, out int valorEntero))
         {
            PlayerPrefs.SetInt("Seed", valorEntero);
            ReloadMap();
         }
        
    }

    public void ReloadMap()
    {
        if(previsualizeEnabled == true)
        {
            
            perlinNoise.GetComponent<PerlinMenu>().ErrasePerlinNoise();
            
        }
        else
        {
           
            return;
        }
        
        
    }

    public void EnableReloadMap()
    {
        previsualizeEnabled = !previsualizeEnabled;
        SoundManager.dameReferencia.PlayOneClipByName("Click");
        if (previsualizeEnabled == true)
        {
            enableReloadMapButton.GetComponent<Image>().color = Color.green;
            perlinNoise.GetComponent<PerlinMenu>().ErrasePerlinNoise();
            renderTexture.SetActive(true);
        }
        else
        {
            enableReloadMapButton.GetComponent<Image>().color = Color.red;
            renderTexture.SetActive(false);
            return;
        }
    }

    public void RandomSeedButton()
    {
        SoundManager.dameReferencia.PlayOneClipByName("Click");
        int semilla = Random.Range(0, 100000);
        PlayerPrefs.SetInt("Seed",semilla );
        seed.text = semilla.ToString();
        ReloadMap();
    }

    public void SmallButton()
    {
        SoundManager.dameReferencia.PlayOneClipByName("Click");
        PlayerPrefs.SetInt("SizeX", 30);
        PlayerPrefs.SetInt("SizeZ", 30);

        sizeXtext.text = 30.ToString();
        sizeZtext.text = 30.ToString();
        ReloadMap();
    }

    public void MediumButton()
    {
        SoundManager.dameReferencia.PlayOneClipByName("Click");
        PlayerPrefs.SetInt("SizeX", 60);
        PlayerPrefs.SetInt("SizeZ", 60);

        sizeXtext.text = 60.ToString();
        sizeZtext.text = 60.ToString();
        ReloadMap();
    }

    public void BigButton()
    {
        SoundManager.dameReferencia.PlayOneClipByName("Click");
        PlayerPrefs.SetInt("SizeX", 100);
        PlayerPrefs.SetInt("SizeZ", 100);

        sizeXtext.text = 100.ToString();
        sizeZtext.text = 100.ToString();
        ReloadMap();
    }
    
}
