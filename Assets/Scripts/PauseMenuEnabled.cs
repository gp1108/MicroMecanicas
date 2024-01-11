using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuEnabled : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool pauseMenuActive;
    [Header("Pause Panel")]
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableOrDisablePausePanel()
    {
        pauseMenuActive = !pauseMenuActive;

        if (pauseMenuActive == false)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
