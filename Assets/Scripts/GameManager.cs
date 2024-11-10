using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GameObject restartButton;   // The restart button UI

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowRestartButton()
    {
        // Make sure the restart button is visible
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        // Restart the scene (assuming you're using the active scene)
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
