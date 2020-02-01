using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public void Toggle() {
        Debug.Log("Fire! door");
        isOpen = !isOpen;
        gameObject.SetActive(!isOpen);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(!isOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
