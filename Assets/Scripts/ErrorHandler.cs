using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorHandler : MonoBehaviour
{
    void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    void HandleLog(string logText, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            // Aquí puedes agregar lógica adicional si es necesario antes de recargar la escena.
            // Por ejemplo, guardar información del juego o mostrar un mensaje al jugador.

            // Luego, recarga la escena actual.
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
