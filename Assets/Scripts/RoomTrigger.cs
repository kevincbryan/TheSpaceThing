using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Room room;

    public void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponent<PlayerInteraction>()?.OnRoomEnter(this);
        }
    }

    public void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponent<PlayerInteraction>()?.OnRoomExit(this);
        }
    }
}
