using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<EscapeManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            SceneLoader.GoToScene(0);
        }
    }
}
