using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nombre de la escena a cargar

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra al trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Carga la nueva escena
            SceneManager.LoadScene(sceneName);
        }
    }
}