using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class SceneLoader  {
    public static void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }

    public static void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
