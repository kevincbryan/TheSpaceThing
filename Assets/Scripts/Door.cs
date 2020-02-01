using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public void Toggle() {
        isOpen = !isOpen;
        enabled = isOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        enabled = isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
