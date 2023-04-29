/**
 * @brief The PauseMenu class handles the behavior of the pause menu UI elements.
 *
 * The class contains methods to resume the game, restart the game, and quit the game.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string gameSceneName = "GameScene";
    
    private string menuSceneName = "MenuScene";

    /**
     * Resumes the game by unloading the pause menu scene and setting the time scale to 1.
     */
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("PauseScene");
    }

    /**
     * Restarts the game by reloading the game scene and setting the time scale to 1.
     */
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    /**
     * Quits the game by closing the application.
     */
    public void QuitGame()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
