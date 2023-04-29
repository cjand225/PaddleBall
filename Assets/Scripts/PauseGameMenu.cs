/**
 * @brief The PauseGameMenu class handles pausing and resuming the game by loading and unloading a pause menu scene.
 *
 * When the ESC key is pressed, the class checks if the pause menu scene is loaded. If it is loaded, it resumes the game by unloading
 * the pause menu scene.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneCommon;

public class PauseGameMenu : MonoBehaviour
{
    private string pauseSceneName = "PauseScene";

    /**
     * Called every frame to check if the ESC key has been pressed.
     * 
     * If the pause menu scene is loaded, it resumes the game by unloading the pause menu scene. If the pause menu scene is not
     * loaded, it pauses the game by loading the pause menu scene.
     */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneCommon.SceneExists(pauseSceneName))
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    /**
     * Pauses the game by loading the pause menu scene and setting the time scale to 0.
     */
    void PauseGame()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
    }

    /**
     * Resumes the game by unloading the pause menu scene and setting the time scale to 1.
     */
    void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(pauseSceneName);
    }
}
