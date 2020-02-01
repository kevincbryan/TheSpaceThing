using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public AudioSource BGM;
    private AudioSource BGMInstance;

	// Use this for initialization
	void Start () {
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        BGMInstance = GameObject.Instantiate(BGM, this.transform);
        StartMusic();
	}

    public void StartMusic()
    {
        BGMInstance.Play();
    }
	
	
}
