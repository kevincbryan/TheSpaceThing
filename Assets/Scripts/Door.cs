using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void SetOpen(bool isOpen) {
        gameObject.SetActive(!isOpen);
    }
}
