using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameMenu : MonoBehaviour
{
    private string pauseSceneName = "PauseScene";

    bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneExists(pauseSceneName))
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(pauseSceneName);
    }
}
