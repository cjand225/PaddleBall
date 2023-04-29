using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class SceneCommon
{
    /**
     * Checks if a scene with the specified name is loaded.
     *
     * @param sceneName The name of the scene to check for.
     * @return true if the scene is loaded, false otherwise.
     */
    public static bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            if (scenePath.Contains(sceneName))
            {
                return true;
            }
        }
        return false;
    }

    /**
     * @brief Sets the time scale for the game.
     * @param timeScale The time scale value.
     */
    public static void setTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

}
