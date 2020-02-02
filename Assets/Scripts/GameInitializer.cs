using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

    public GameObject audioManager;
    //public float titleTimeout = 10.0f;

    void Awake () {
        if (GameObject.FindObjectOfType<AudioManager>() == null)
        {
            GameObject.Instantiate(audioManager);
        }
        //Invoke("GoToNextScene", titleTimeout);
	}
	
	public void GoToNextScene()
    {
        SceneLoader.GoToNextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
