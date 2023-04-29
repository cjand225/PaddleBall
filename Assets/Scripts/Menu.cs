using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameObject exitGameUIButton;

    private string exitGameUIButtonName = "ButtonExit";

    void Start()
    {
        exitGameUIButton = GameObject.Find(exitGameUIButtonName);

        // Remove or hide the UI element depending on the platform
        #if UNITY_WEBGL
            Destroy(exitGameUIButton);
        #endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitCurrentSession()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
