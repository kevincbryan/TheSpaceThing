using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    public void Toggle() {
        door.Toggle();
    }

    public void OnTriggerEnter(Collider collider) {
        if (collider.tag == "player") {
            collider.gameObject.GetComponent<PlayerInteraction>();
        }
    }
}
