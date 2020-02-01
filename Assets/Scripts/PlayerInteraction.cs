using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private List<DoorTrigger> nearbyDoors = new List<DoorTrigger>();

    public void Update() {
        if (Input.GetButtonDown("Fire1")) {
            foreach (var door in nearbyDoors) {
                door.Toggle();
            }
        }
    }
    
    public void OnDoorEnter(DoorTrigger door) {
        Debug.Log("OnDoorEnter");
        this.nearbyDoors.Add(door);
        Debug.Log($"Nearby Doors {nearbyDoors.Count}");
    }
    
    public void OnDoorExit(DoorTrigger door) {
        Debug.Log("OnDoorExit");
        this.nearbyDoors.Remove(door);
        Debug.Log($"Nearby Doors {nearbyDoors.Count}");
    }
}
