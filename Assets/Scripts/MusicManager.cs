using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    
    public AudioSource BGM;
    private AudioSource BGMInstance;

	// Use this for initialization
	void Start () {
        if (FindObjectsOfType<MusicManager>().Length > 1)
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
