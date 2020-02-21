using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour {

    public GameObject musicManager;
    public float titleTimeout = 10.0f;

    void Awake () {
        if (GameObject.FindObjectOfType<MusicManager>() == null)
        {
            GameObject.Instantiate(musicManager);
        }
        //Invoke("GoToNextScene", titleTimeout);
	}

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (SceneManager.GetActiveScene().name.Equals("Title"))
            {
                GoToNextScene();
            }
            else if (SceneManager.GetActiveScene().name.Equals("GameOver"))
            {
                GoToSceneNumber(0);
            }
            
        }
    }

    public void GoToNextScene()
    {
        SceneLoader.GoToNextScene();
    }

    public void GoToSceneNumber(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
