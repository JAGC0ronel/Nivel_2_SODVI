using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nombre de la escena a cargar
    public void Play()
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void Exit()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
