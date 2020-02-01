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
        if (collider.tag == "Player") {
            collider.gameObject.GetComponent<PlayerInteraction>().OnDoorEnter(this);
        }
    }

    public void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponent<PlayerInteraction>().OnDoorExit(this);
        }
    }
}
