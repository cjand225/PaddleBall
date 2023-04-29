/**
 * @brief The PauseMenu class handles the behavior of the pause menu UI elements.
 *
 * The class contains methods to resume the game, restart the game, and quit the game.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /**
     * The name of the game scene.
     */
    private string gameSceneName = "GameScene";

    /**
     * The name of the menu scene.
     */
    private string menuSceneName = "MenuScene";

    /**
     * The name of the pause scene.
     */
    private string pauseSceneName = "PauseScene";

    /**
     * @brief Sets the time scale for the game.
     * @param timeScale The time scale value.
     */
    private void setTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    /**
     * Resumes the game by unloading the pause menu scene and setting the time scale to 1.
     */
    public void ResumeGame()
    {
        setTimeScale(1f);
        SceneManager.UnloadSceneAsync(pauseSceneName);
    }

    /**
     * Restarts the game by reloading the game scene and setting the time scale to 1.
     */
    public void RestartGame()
    {
        setTimeScale(1f);
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
