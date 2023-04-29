/**
 * @brief A class that manages the menu screen and its UI elements.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    /**
     * The UI button for exiting the game.
     */
    private GameObject exitGameUIButton;

    /**
     * The name of the UI button for exiting the game.
     */
    private string exitGameUIButtonName = "ButtonExit";

    /**
     * Find and remove or hide the UI element depending on the platform.
     */
    void Start()
    {
        // Find the UI button for exiting the game
        exitGameUIButton = GameObject.Find(exitGameUIButtonName);

        // Remove or hide the UI element depending on the platform
        #if UNITY_WEBGL
            Destroy(exitGameUIButton);
        #endif
    }

    /**
     * Load the game scene.
     */
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    /**
     * Load the menu scene.
     */
    public void ExitCurrentSession()
    {
        SceneManager.LoadScene("MenuScene");
    }

    /**
     * Exit the game.
     */
    public void ExitGame()
    {
        Application.Quit();
    }
}
