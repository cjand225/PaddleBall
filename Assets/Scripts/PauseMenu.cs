using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string gameSceneName = "GameScene";

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("PauseScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
